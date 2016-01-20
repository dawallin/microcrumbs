using Microcrumbs.Core;

namespace Microcrumbs.Appender.Zipkin
{
    public class ZipkinTraceEventListener : ITraceEvents
    {
        private readonly ISpanSubmitter _spanSubmitter;

        public ZipkinTraceEventListener(ISpanSubmitter spanSubmitter)
        {
            _spanSubmitter = spanSubmitter;
        }

        public void NewTraceCreated(TraceContext traceContext)
        {
            _spanSubmitter.Send(SpanType.ServerRecieve, traceContext);
        }

        public void JoinTrace(TraceContext traceContext)
        {
            _spanSubmitter.Send(SpanType.ServerRecieve, traceContext);
        }

        public void TraceFinished(TraceContext traceContext)
        {
            _spanSubmitter.Send(SpanType.ServerSend, traceContext);
        }

        public void NewChildTraceCreated(TraceContext traceContext)
        {
            _spanSubmitter.Send(SpanType.ClientSend, traceContext);
        }

        public void ChildTraceFinished(TraceContext traceContext)
        {
            _spanSubmitter.Send(SpanType.ClientReceive, traceContext);
        }
    }
}