namespace Microcrumbs.Core
{
    public interface ISpanContextFactory
    {
        SpanContext NewTrace(string serviceName);
        SpanContext NewSpan(IThreadContext threadContext);
    }
}