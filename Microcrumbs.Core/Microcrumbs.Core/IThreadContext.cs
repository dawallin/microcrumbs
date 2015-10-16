namespace Microcrumbs.Core
{
    internal interface IThreadContext
    {
        void Set(SpanContext spanContext);
        SpanContext Get();
    }
}