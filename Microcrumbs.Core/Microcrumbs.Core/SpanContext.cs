namespace Microcrumbs.Core
{
    public class SpanContext
    {
        public SpanContext(string serviceName, ulong? traceId, ulong? parentId, ulong? spanId)
        {
            ServiceName = serviceName;
            TraceId = traceId;
            ParentId = parentId;
            SpanId = spanId;
        }

        public string ServiceName { get; private set; }
        public ulong? TraceId { get; private set; }
        public ulong? ParentId { get; private set; }
        public ulong? SpanId { get; private set; }
    }
}
