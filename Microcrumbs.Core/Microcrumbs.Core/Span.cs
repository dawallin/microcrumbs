using System;

namespace Microcrumbs.Core
{
    public class Span
    {
        private readonly Action<SpanContext> _finishCallback;
        public SpanContext Context { get; }

        public Span(SpanContext context, Action<SpanContext> finishCallback)
        {
            _finishCallback = finishCallback;
            Context = context;
        }

        public void Finish()
        {
            _finishCallback(Context);
        }
    }
}