using System;

namespace Microcrumbs.Core
{
    public class SpanContextFactory : ISpanContextFactory
    {
        private readonly IThreadContext _threadContext;

        public SpanContextFactory(IThreadContext threadContext)
        {
            _threadContext = threadContext;
        }

        public SpanContext NewTrace(string serviceName)
        {
            return new SpanContext(serviceName, NewGuid(), 0, NewGuid());
        }

        public SpanContext NewSpan()
        {
            var parentSpanContext = _threadContext.Get();
            var childSpanContext = new SpanContext(parentSpanContext.ServiceName, parentSpanContext.TraceId, parentSpanContext.SpanId, NewGuid());
            return childSpanContext;
        }

        private ulong NewGuid()
        {
            return BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(), 0);
        }
    }
}