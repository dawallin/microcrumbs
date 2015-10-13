namespace Microcrumbs.Core
{
    public interface ISpanSubmitter
    {
        void Send(SpanType spanType);
    }
}