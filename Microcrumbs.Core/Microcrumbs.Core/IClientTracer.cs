namespace Microcrumbs.Core
{
    public interface IClientTracer
    {
        void StartClientSpan(string serviceName);
        void FinishSpan();
    }
}