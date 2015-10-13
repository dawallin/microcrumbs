using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microcrumbs.Core;
using Thrift.Protocol;
using Thrift.Transport;

namespace Microcrumbs.Appender.Zipkin
{
    class DirectZipkinSubmitter : ISpanSubmitter
    {
        private readonly ZipkinSettings _zipkinSettings;

        public DirectZipkinSubmitter(ZipkinSettings zipkinSettings)
        {
            _zipkinSettings = zipkinSettings;
        }

        public void Send(SpanType spanType, SpanContext spanContext)
        {
            using (var socket = new TSocket(_zipkinSettings.Host, _zipkinSettings.Port))
            {
                var transport = new TFramedTransport(socket);
                using (var protocol = new TBinaryProtocol(transport))
                {
                    protocol.Transport.Open();
                    var client = new ZipkinCollector.Client(protocol);

                    var zspan = new Span()
                    {
                        Trace_id = ToLong(spanContext.TraceId),
                        Id = ToLong(spanContext.SpanId),
                        Name = "GET",
                        Parent_id = ToLong(spanContext.ParentId),
                        Annotations = new List<global::Annotation>
                    {
                        new global::Annotation
                        {
                            Host = new Endpoint()
                            {
                                Ipv4 = BitConverter.ToInt32(IPAddress.Parse("127.0.0.1").GetAddressBytes(), 0),
                                Port = 80,
                                Service_name = spanContext.ServiceName,
                            },
                            Value=ToSpanType(spanType),
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

        private string ToSpanType(SpanType spanType)
        {
            switch (spanType)
            {
                case SpanType.ClientSend:
                    return "cs";
                case SpanType.ClientReceive:
                    return "cr";
                case SpanType.ServerRecieve:
                    return "sr";
                case SpanType.ServerSend:
                    return "ss";
                default:
                    throw new InvalidOperationException("Span type not supported: '" + Enum.GetName(typeof(SpanType), spanType));
            }
        }

        private long ToLong(ulong? traceId)
        {
            if (!traceId.HasValue)
                return 0;

            unchecked
            {
                return Convert.ToInt64(traceId.Value);
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