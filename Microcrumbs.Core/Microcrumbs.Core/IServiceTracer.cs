namespace Microcrumbs.Core
{
    public interface IServiceTracer
    {
        void StartNewTrace(string serviceName);
        void ContinueTrace(SpanContext spanContext);
        void FinishRequest(SpanContext spanContext);
    }
}