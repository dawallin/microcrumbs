using System;

namespace Microcrumbs.Core
{
    internal class TraceContextFactory : ITraceContextFactory
    {
        public TraceContextFactory()
        {
        }

        public TraceContext NewRootTraceContext(string serviceName)
        {
            return new TraceContext(serviceName, NewGuid(), 0, NewGuid());
        }

        public TraceContext NewChildTraceContext(IThreadContext threadContext)
        {
            var parentTraceContext = threadContext.GetTop();
            var childSpanContext = new TraceContext(parentTraceContext.ServiceName, parentTraceContext.TraceId, parentTraceContext.SpanId, NewGuid());
            return childSpanContext;
        }

        private ulong NewGuid()
        {
            return BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(), 0);
        }
    }
}