namespace Microcrumbs.Core
{
    public interface IThreadContext
    {
        void Set(SpanContext spanContext);
        SpanContext Get();
    }
}