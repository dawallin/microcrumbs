namespace Microcrumbs.Core
{
    public interface ITraceEvents
    {
        void NewTraceCreated(TraceContext traceContext);

        void JoinTrace(TraceContext traceContext);

        void TraceFinished(TraceContext traceContext);

        void NewChildTraceCreated(TraceContext traceContext);

        void ChildTraceFinished(TraceContext traceContext);
    }
}