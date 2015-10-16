namespace Microcrumbs.Core
{
    public class ServiceTracer
    {
        private readonly IThreadContext _threadContext;
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly ISpanSubmitter _spanSubmitter;

        internal ServiceTracer(IThreadContext threadContext, ISpanContextFactory spanContextFactory, ISpanSubmitter spanSubmitter)
        {
            _threadContext = threadContext;
            _spanContextFactory = spanContextFactory;
            _spanSubmitter = spanSubmitter;
        }

        public Span StartNewTrace(string serviceName)
        {
            var newSpanContext = _spanContextFactory.NewTrace(serviceName);
            _threadContext.Set(newSpanContext);
            _spanSubmitter.Send(SpanType.ServerRecieve, newSpanContext);

            return new Span(newSpanContext, FinishRequest);
        }

        public void ContinueTrace(SpanContext spanContext)
        {
            _threadContext.Set(spanContext);
            _spanSubmitter.Send(SpanType.ServerRecieve, spanContext);
        }

        public void FinishRequest(SpanContext spanContext)
        {
            _spanSubmitter.Send(SpanType.ServerSend, spanContext);
        }
    }
}