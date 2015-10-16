using System.Runtime.Remoting.Messaging;

namespace Microcrumbs.Core
{
    public class ClientTracer
    {
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly IThreadContext _threadContext;
        private readonly ISpanSubmitter _spanSubmitter;

        internal ClientTracer(IThreadContext threadContext, ISpanContextFactory spanContextFactory, ISpanSubmitter spanSubmitter)
        {
            _spanContextFactory = spanContextFactory;
            _threadContext = threadContext;
            _spanSubmitter = spanSubmitter;
        }

        public Span StartClientSpan(string serviceName)
        {
            var clientSpanContext = _spanContextFactory.NewSpan(_threadContext);
            _spanSubmitter.Send(SpanType.ClientSend, clientSpanContext);

            return new Span(clientSpanContext, FinishSpan);
        }

        public void FinishSpan(SpanContext clientSpanContext)
        {
            _spanSubmitter.Send(SpanType.ClientReceive, clientSpanContext);
        }
    }
}