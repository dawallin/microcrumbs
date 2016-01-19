using Microcrumbs.Core;

namespace Microcrumbs.Appender.Zipkin
{
    public interface ISpanSubmitter
    {
        void Send(SpanType spanType, SpanContext spanContext);
    }
}