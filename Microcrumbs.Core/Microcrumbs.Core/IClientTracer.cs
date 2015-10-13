namespace Microcrumbs.Core
{
    public interface IClientTracer
    {
        SpanContext StartClientSpan(string serviceName);
        void FinishSpan(SpanContext clientSpanContext);
    }
}