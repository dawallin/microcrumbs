namespace Microcrumbs.Core
{
    public interface IServiceTracer
    {
        SpanContext StartNewTrace(string serviceName);
        void ContinueTrace(SpanContext spanContext);
        void FinishRequest(SpanContext spanContext);
    }
}