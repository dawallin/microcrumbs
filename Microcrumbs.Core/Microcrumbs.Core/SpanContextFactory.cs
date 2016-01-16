﻿using System;

namespace Microcrumbs.Core
{
    internal class SpanContextFactory : ISpanContextFactory
    {
        public SpanContextFactory()
        {
        }

        public SpanContext NewTrace(string serviceName)
        {
            return new SpanContext(serviceName, NewGuid(), 0, NewGuid());
        }

        public SpanContext NewSpan(IThreadContext threadContext)
        {
            var parentSpanContext = threadContext.GetTop();
            var childSpanContext = new SpanContext(parentSpanContext.ServiceName, parentSpanContext.TraceId, parentSpanContext.SpanId, NewGuid());
            return childSpanContext;
        }

        private ulong NewGuid()
        {
            return BitConverter.ToUInt64(Guid.NewGuid().ToByteArray(), 0);
        }
    }
}