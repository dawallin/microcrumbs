namespace Microcrumbs.Core
{
    public interface IServiceTracer
    {
        Span StartNewTrace(string serviceName);
        void ContinueTrace(SpanContext spanContext);
    }
}