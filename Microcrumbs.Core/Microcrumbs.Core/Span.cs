using System;

namespace Microcrumbs.Core
{
    public class Span : IDisposable
    {
        private readonly Action<TraceContext> _finishCallback;
        public TraceContext Context { get; }

        public Span(TraceContext context, Action<TraceContext> finishCallback)
        {
            _finishCallback = finishCallback;
            Context = context;
        }

        private bool isDisposed = false;
        public void Dispose()
        {
            if (isDisposed)
                return;

            _finishCallback(Context);
        }
    }
}