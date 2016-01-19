using System;

namespace Microcrumbs.Core
{
    public class TracerBuilder
    {
        private readonly LogicalThreadContext _threadContext = new LogicalThreadContext();
        private readonly SpanContextFactory _spanContextFactory = new SpanContextFactory();
        private ISpanInterceptor _spanInterceptor = null;

        public TracerBuilder()
        {
            
        }

        public TracerBuilder SetSpanSubmitter(ISpanInterceptor spanInterceptor)
        {
            _spanInterceptor = spanInterceptor;
            return this;
        }

        public ServiceTracer BuildServiceTracer()
        {
            if (_spanInterceptor == null)
            {
                throw new ArgumentNullException("No span interceptor set.");
            }

            return new ServiceTracer(_threadContext, _spanContextFactory, _spanInterceptor);
        }
        public ClientTracer BuildClientTracer()
        {
            if (_spanInterceptor == null)
            {
                throw new ArgumentNullException("No span interceptor set.");
            }

            return new ClientTracer(_threadContext, _spanContextFactory, _spanInterceptor);
        }
    }
}