using System;

namespace Microcrumbs.Core
{
    internal interface IThreadContext : IDisposable
    {
        IDisposable Push(SpanContext spanContext);
        SpanContext GetTop();
    }
}