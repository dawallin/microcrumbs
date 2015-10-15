namespace Microcrumbs.Core
{
    public interface IClientTracer
    {
        Span StartClientSpan(string serviceName);
    }
}