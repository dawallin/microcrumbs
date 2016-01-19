namespace Microcrumbs.Core
{
    public class ClientTracer
    {
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly ISpanInterceptor _spanInterceptor;
        private readonly IThreadContext _threadContext;

        internal ClientTracer(IThreadContext threadContext, ISpanContextFactory spanContextFactory, ISpanInterceptor _spanInterceptor)
        {
            _spanContextFactory = spanContextFactory;
            this._spanInterceptor = _spanInterceptor;
            _threadContext = threadContext;
        }

        public Span StartClientSpan(string serviceName)
        {
            var clientSpanContext = _spanContextFactory.NewSpan(_threadContext);
            _spanInterceptor.NewSpanCreated(clientSpanContext);

            return new Span(clientSpanContext, FinishSpan);
        }

        public void FinishSpan(SpanContext clientSpanContext)
        {
            _spanInterceptor.SpanFinished(clientSpanContext);
        }
    }
}