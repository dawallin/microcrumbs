namespace Microcrumbs.Core
{
    internal interface ISpanContextFactory
    {
        SpanContext NewTrace(string serviceName);
        SpanContext NewSpan(IThreadContext threadContext);
    }
}