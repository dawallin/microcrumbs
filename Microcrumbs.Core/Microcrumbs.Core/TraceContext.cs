using System;

namespace Microcrumbs.Core
{
    [Serializable]
    public class TraceContext
    {
        public TraceContext(string serviceName, ulong? traceId, ulong? parentId, ulong? spanId)
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
