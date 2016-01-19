namespace Microcrumbs.Core
{
    public interface ISpanInterceptor
    {
        void NewTraceCreated(SpanContext spanContext);

        void TraceFinished(SpanContext spanContext);

        void NewSpanCreated(SpanContext spanContext);

        void SpanFinished(SpanContext spanContext);
    }
}