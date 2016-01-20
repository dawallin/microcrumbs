using Microcrumbs.Core;
using NUnit.Framework;

namespace Microcrumbs.Appender.Zipkin.UnitTests
{
    public class MicrocrumbsTraceGeneratorTest
    {
        [Test]
        [Explicit]
        public void SendSimpleTraceToZipkin()
        {
            var zipkinSettings = new ZipkinSettings()
            {
                Host = "192.168.99.100",
                Port = 9410,
            };

            var zipkinSubmitter = new DirectZipkinSubmitter(zipkinSettings);
            var zipkinInterceptor = new ZipkinTraceEventListener(zipkinSubmitter);
            var traceBuilder = new TracerBuilder().SetSpanSubmitter(zipkinInterceptor);

            var tracer = traceBuilder.BuildTracer();

            using (var span = tracer.StartNewTrace("MicrocrumbsTraceGenerator"))
            {
                using (var span1 = tracer.StartChildTrace("CallOut"))
                {
                    var spanContext = new TraceContext("InnerService", span1.Context.TraceId, span1.Context.ParentId,
                        span1.Context.SpanId);
                    using (tracer.JoinTrace(spanContext))
                    {
                        using (var span1b = tracer.StartChildTrace("Callout1b"))
                        {
                            var spanContext1b = new TraceContext("InnerService1b", span1b.Context.TraceId,
                                span1b.Context.ParentId, span1b.Context.SpanId);

                            using (tracer.JoinTrace(spanContext1b))
                            {
                            }
                        }
                    }
                }

                using (var span2 = tracer.StartChildTrace("CallOut2"))
                {
                    var spanContext2 = new TraceContext("InnerService2", span2.Context.TraceId, span2.Context.ParentId,
                        span2.Context.SpanId);
                    using (tracer.JoinTrace(spanContext2))
                    {
                    }
                }
            }
        }
    }
}
