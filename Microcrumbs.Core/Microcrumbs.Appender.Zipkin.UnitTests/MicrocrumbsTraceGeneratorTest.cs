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
            var traceBuilder = new TracerBuilder().SetSpanSubmitter(zipkinSubmitter);

            var serverTracer = traceBuilder.BuildServiceTracer();
            var clientTracer = traceBuilder.BuildClientTracer();

            var span = serverTracer.StartNewTrace("MicrocrumbsTraceGenerator");

            var span1 = clientTracer.StartClientSpan("CallOut");

            var spanContext = new SpanContext("InnerService", span1.Context.TraceId, span1.Context.ParentId, span1.Context.SpanId);
            serverTracer.ContinueTrace(spanContext);

            var span1b = clientTracer.StartClientSpan("Callout1b");
            var spanContext1b = new SpanContext("InnerService1b", span1b.Context.TraceId, span1b.Context.ParentId, span1b.Context.SpanId);
            serverTracer.ContinueTrace(spanContext1b);
            serverTracer.FinishRequest(spanContext1b);
            span1b.Finish();

            serverTracer.FinishRequest(spanContext);

            span1.Finish();
 
            var span2 = clientTracer.StartClientSpan("CallOut2");
            var spanContext2 = new SpanContext("InnerService2", span2.Context.TraceId, span2.Context.ParentId, span2.Context.SpanId);
            serverTracer.ContinueTrace(spanContext2);
            serverTracer.FinishRequest(spanContext2);
            span2.Finish();

            span.Finish();
        }
    }
}
