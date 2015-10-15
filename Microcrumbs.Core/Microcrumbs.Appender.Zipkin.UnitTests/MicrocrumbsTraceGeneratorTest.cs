using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microcrumbs.Core;
using NUnit.Framework;
using Thrift.Protocol;
using Thrift.Transport;

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

            var threadContext = new LogicalThreadContext();
            var spanContextFactory = new SpanContextFactory(threadContext);

            var serverTracer = new ServiceTracer(threadContext, spanContextFactory, zipkinSubmitter);
            var clientTracer = new ClientTracer(spanContextFactory, zipkinSubmitter);

            var span = serverTracer.StartNewTrace("MicrocrumbsTraceGenerator");

            var span1 = clientTracer.StartClientSpan("CallOut");
            span1.Finish();
 
            var span2 = clientTracer.StartClientSpan("CallOut2");
            span2.Finish();

            span.Finish();
        }
    }
}
