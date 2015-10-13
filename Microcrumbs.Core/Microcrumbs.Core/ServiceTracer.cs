namespace Microcrumbs.Core
{
    public class ServiceTracer : IServiceTracer
    {
        private readonly IThreadContext _threadContext;
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly ISpanSubmitter _spanSubmitter;

        public ServiceTracer(IThreadContext threadContext, ISpanContextFactory spanContextFactory, ISpanSubmitter spanSubmitter)
        {
            _threadContext = threadContext;
            _spanContextFactory = spanContextFactory;
            _spanSubmitter = spanSubmitter;
        }

        public void StartNewTrace(string serviceName)
        {
            _threadContext.Set(_spanContextFactory.NewTrace(serviceName));
            _spanSubmitter.Send(SpanType.ServerRecieve);
        }

        public void ContinueTrace(SpanContext spanContext)
        {
            _threadContext.Set(spanContext);
            _spanSubmitter.Send(SpanType.ServerRecieve);
        }

        public void FinishRequest()
        {
            _spanSubmitter.Send(SpanType.ServerSend);
        }
    }
}