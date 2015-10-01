using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microcrumbs.Core
{
    public class SpanContext
    {
        public SpanContext(string serviceName, long traceId, long parentId, long spanId)
        {
            ServiceName = serviceName;
            TraceId = traceId;
            ParentId = parentId;
            SpanId = spanId;
        }

        public string ServiceName { get; private set; }
        public long TraceId { get; private set; }
        public long ParentId { get; private set; }
        public long SpanId { get; private set; }
    }
}
