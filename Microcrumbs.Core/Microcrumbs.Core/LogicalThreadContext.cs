using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Microcrumbs.Core
{
    internal class LogicalThreadContext : IThreadContext
    {
        private const string StackCallContextName = "Microcrumbs:SpanStack";

        private Stack<SpanContext> spanStack
        {
            get
            {
                var value = CallContext.LogicalGetData(StackCallContextName);
                return value == null ? new Stack<SpanContext>() : value as Stack<SpanContext>;
            }
            set
            {
                CallContext.LogicalSetData(StackCallContextName, value);
            }
        }

        public SpanContext GetTop()
        {
            var topSpan = spanStack.Peek();
            var serviceName = topSpan.ServiceName;
            var traceId = topSpan.TraceId;
            var parentId = topSpan.ParentId;
            var spanId = topSpan.SpanId;

            return new SpanContext(serviceName, traceId, parentId, spanId);
        }

        public IDisposable Push(SpanContext spanContext)
        {
            spanStack = spanStack;
            spanStack.Push(spanContext);
            spanStack = spanStack;

            return this;
        }

        public void Dispose()
        {
            spanStack = spanStack;
            spanStack.Pop();
            spanStack = spanStack;
        }
    }
}