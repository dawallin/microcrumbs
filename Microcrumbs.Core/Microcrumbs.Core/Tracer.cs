namespace Microcrumbs.Core
{
    public sealed class Tracer
    {
        private readonly IThreadContext _threadContext;
        private readonly ITraceContextFactory _traceContextFactory;
        private readonly ITraceEvents _traceEvents;

        internal Tracer(IThreadContext threadContext, ITraceContextFactory traceContextFactory, ITraceEvents _traceEvents)
        {
            _threadContext = threadContext;
            _traceContextFactory = traceContextFactory;
            this._traceEvents = _traceEvents;
        }

        public Span StartNewTrace(string serviceName)
        {
            var newSpanContext = _traceContextFactory.NewRootTraceContext(serviceName);
            _threadContext.Push(newSpanContext);
            _traceEvents.NewTraceCreated(newSpanContext);

            return new Span(newSpanContext, FinishTrace);
        }

        public Span JoinTrace(TraceContext traceContext)
        {
            _threadContext.Push(traceContext);
            _traceEvents.JoinTrace(traceContext);

            return new Span(traceContext, FinishTrace);
        }

        internal void FinishTrace(TraceContext traceContext)
        {
            _threadContext.Dispose();
            _traceEvents.TraceFinished(traceContext);
        }

        public Span StartChildTrace(string serviceName)
        {
            var clientSpanContext = _traceContextFactory.NewChildTraceContext(_threadContext);
            _traceEvents.NewChildTraceCreated(clientSpanContext);

            return new Span(clientSpanContext, FinishChildTrace);
        }

        internal void FinishChildTrace(TraceContext clientTraceContext)
        {
            _traceEvents.ChildTraceFinished(clientTraceContext);
        }
    }
}