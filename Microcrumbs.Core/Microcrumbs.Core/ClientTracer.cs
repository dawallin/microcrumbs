﻿using System.Runtime.Remoting.Messaging;

namespace Microcrumbs.Core
{
    public class ClientTracer : IClientTracer
    {
        private readonly ISpanContextFactory _spanContextFactory;
        private readonly ISpanSubmitter _spanSubmitter;

        public ClientTracer(ISpanContextFactory spanContextFactory, ISpanSubmitter spanSubmitter)
        {
            _spanContextFactory = spanContextFactory;
            _spanSubmitter = spanSubmitter;
        }

        public Span StartClientSpan(string serviceName)
        {
            var clientSpanContext = _spanContextFactory.NewSpan();
            _spanSubmitter.Send(SpanType.ClientSend, clientSpanContext);

            return new Span(clientSpanContext, FinishSpan);
        }

        public void FinishSpan(SpanContext clientSpanContext)
        {
            _spanSubmitter.Send(SpanType.ClientReceive, clientSpanContext);
        }
    }
}