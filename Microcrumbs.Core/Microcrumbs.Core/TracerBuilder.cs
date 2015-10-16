using System;

namespace Microcrumbs.Core
{
    public class TracerBuilder
    {
        private readonly LogicalThreadContext _threadContext = new LogicalThreadContext();
        private readonly SpanContextFactory _spanContextFactory = new SpanContextFactory();
        private ISpanSubmitter _spanSubmitter = null;

        public TracerBuilder()
        {
            
        }

        public TracerBuilder SetSpanSubmitter(ISpanSubmitter spanSubmitter)
        {
            _spanSubmitter = spanSubmitter;
            return this;
        }

        public ServiceTracer BuildServiceTracer()
        {
            if (_spanSubmitter == null)
            {
                throw new ArgumentNullException("No span submitter set.");
            }

            return new ServiceTracer(_threadContext, _spanContextFactory, _spanSubmitter);
        }
        public ClientTracer BuildClientTracer()
        {
            if (_spanSubmitter == null)
            {
                throw new ArgumentNullException("No span submitter set.");
            }

            return new ClientTracer(_threadContext, _spanContextFactory, _spanSubmitter);
        }
    }
}