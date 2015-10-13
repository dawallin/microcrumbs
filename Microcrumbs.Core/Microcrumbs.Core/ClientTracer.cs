namespace Microcrumbs.Core
{
    class ClientTracer : IClientTracer
    {
        private readonly IThreadContext _threadContext;
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly ISpanSubmitter _spanSubmitter;

        public ClientTracer(IThreadContext threadContext, ISpanContextFactory spanContextFactory, ISpanSubmitter spanSubmitter)
        {
            _threadContext = threadContext;
            _spanContextFactory = spanContextFactory;
            _spanSubmitter = spanSubmitter;
        }

        public void StartClientSpan(string serviceName)
        {
            var clientSpanContext = _spanContextFactory.NewSpan();
            _threadContext.Set(clientSpanContext);
            _spanSubmitter.Send(SpanType.ClientSend);
        }

        public void FinishSpan()
        {
            _spanSubmitter.Send(SpanType.ClientReceive);
        }
    }
}