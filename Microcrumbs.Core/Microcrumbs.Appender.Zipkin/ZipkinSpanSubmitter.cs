using Microcrumbs.Core;

namespace Microcrumbs.Appender.Zipkin
{
    public class ZipkinSpanInterceptor : ISpanInterceptor
    {
        private readonly ISpanSubmitter _spanSubmitter;

        public ZipkinSpanInterceptor(ISpanSubmitter spanSubmitter)
        {
            _spanSubmitter = spanSubmitter;
        }

        public void NewTraceCreated(SpanContext spanContext)
        {
            _spanSubmitter.Send(SpanType.ServerRecieve, spanContext);
        }

        public void TraceFinished(SpanContext spanContext)
        {
            _spanSubmitter.Send(SpanType.ServerSend, spanContext);
        }

        public void NewSpanCreated(SpanContext spanContext)
        {
            _spanSubmitter.Send(SpanType.ClientSend, spanContext);
        }

        public void SpanFinished(SpanContext spanContext)
        {
            _spanSubmitter.Send(SpanType.ClientReceive, spanContext);
        }
    }
}