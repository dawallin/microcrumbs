using System;

namespace Microcrumbs.Core
{
    internal interface IThreadContext : IDisposable
    {
        IDisposable Push(TraceContext spanContext);
        TraceContext GetTop();
    }
}