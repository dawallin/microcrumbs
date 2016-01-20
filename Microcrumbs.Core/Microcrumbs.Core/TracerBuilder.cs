using System;

namespace Microcrumbs.Core
{
    public class TracerBuilder
    {
        private readonly LogicalThreadContext _threadContext = new LogicalThreadContext();
        private readonly TraceContextFactory _traceContextFactory = new TraceContextFactory();
        private ITraceEvents _traceEvents = null;

        public TracerBuilder()
        {
            
        }

        public TracerBuilder SetSpanSubmitter(ITraceEvents traceEvents)
        {
            _traceEvents = traceEvents;
            return this;
        }

        public Tracer BuildTracer()
        {
            if (_traceEvents == null)
            {
                throw new ArgumentNullException("No span interceptor set.");
            }

            return new Tracer(_threadContext, _traceContextFactory, _traceEvents);
        }
    }
}