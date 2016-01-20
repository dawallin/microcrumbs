namespace Microcrumbs.Core
{
    internal interface ITraceContextFactory
    {
        TraceContext NewRootTraceContext(string serviceName);
        TraceContext NewChildTraceContext(IThreadContext threadContext);
    }
}