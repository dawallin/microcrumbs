using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Microcrumbs.Core
{
    internal class LogicalThreadContext : IThreadContext
    {
        private const string StackCallContextName = "Microcrumbs:SpanStack";

        private Stack<TraceContext> spanStack
        {
            get
            {
                var value = CallContext.LogicalGetData(StackCallContextName);
                return value == null ? new Stack<TraceContext>() : value as Stack<TraceContext>;
            }
            set
            {
                CallContext.LogicalSetData(StackCallContextName, value);
            }
        }

        public TraceContext GetTop()
        {
            var topSpan = spanStack.Peek();
            var serviceName = topSpan.ServiceName;
            var traceId = topSpan.TraceId;
            var parentId = topSpan.ParentId;
            var spanId = topSpan.SpanId;

            return new TraceContext(serviceName, traceId, parentId, spanId);
        }

        public IDisposable Push(TraceContext spanContext)
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