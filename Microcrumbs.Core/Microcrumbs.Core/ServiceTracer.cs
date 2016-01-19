namespace Microcrumbs.Core
{
    public class ServiceTracer
    {
        private readonly IThreadContext _threadContext;
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly ISpanInterceptor _spanInterceptor;

        internal ServiceTracer(IThreadContext threadContext, ISpanContextFactory spanContextFactory, ISpanInterceptor _spanInterceptor)
        {
            _threadContext = threadContext;
            _spanContextFactory = spanContextFactory;
            this._spanInterceptor = _spanInterceptor;
        }

        public Span StartNewTrace(string serviceName)
        {
            var newSpanContext = _spanContextFactory.NewTrace(serviceName);
            _threadContext.Push(newSpanContext);
            _spanInterceptor.NewTraceCreated(newSpanContext);

            return new Span(newSpanContext, FinishRequest);
        }

        public void ContinueTrace(SpanContext spanContext)
        {
            _threadContext.Push(spanContext);
            _spanInterceptor.NewTraceCreated(spanContext);
        }

        public void FinishRequest(SpanContext spanContext)
        {
            _threadContext.Dispose();
            _spanInterceptor.TraceFinished(spanContext);
        }
    }
}