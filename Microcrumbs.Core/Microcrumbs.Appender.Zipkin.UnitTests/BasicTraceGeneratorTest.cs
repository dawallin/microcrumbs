using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NUnit.Framework;
using Thrift.Protocol;
using Thrift.Transport;

namespace Microcrumbs.Appender.Zipkin.UnitTests
{
    public class BasicTraceGeneratorTest
    {
        [Test]
        [Explicit]
        public void SendSimpleTraceToZipkin()
        {
            using (var socket = new TSocket("192.168.99.100", 9410))
            {
                var transport = new TFramedTransport(socket);
                using (var protocol = new TBinaryProtocol(transport))
                {
                    protocol.Transport.Open();
                    var client = new ZipkinCollector.Client(protocol);

                    var zspan = new Span()
                    {
                        Trace_id = 1,
                        Id = 1,
                        Name = "GET",
                        Parent_id = 0,
                        Annotations = new List<global::Annotation>
                    {
                        new global::Annotation
                        {
                            Host = new Endpoint()
                            {
                                Ipv4 = BitConverter.ToInt32(IPAddress.Parse("127.0.0.1").GetAddressBytes(), 0),
                                Port = 80,
                                Service_name = "ThriftTest",
                            },
                            Value="sr",
                            Timestamp=GetTimeStamp(),
                        },
                    },
                        Debug = true,
                    };

                    using (var stream = new MemoryStream())
                    {
                        var streamTransport = new Thrift.Transport.TStreamTransport(null, stream);
                        var messageProtocol2 = new TBinaryProtocol.Factory().GetProtocol(streamTransport);

                        zspan.Write(messageProtocol2);

                        var byteArray = stream.ToArray();
                        var byteMessage = System.Convert.ToBase64String(byteArray);
                        var logs = new List<LogEntry>
                                {
                                    new LogEntry
                                    {
                                        Category = "zipkin",
                                        Message = byteMessage,
                                    }
                                };
                        client.Log(logs);
                    }
                }
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private long GetTimeStamp()
        {
            var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToInt64(t.TotalMilliseconds * 1000);
        }
    }
}
