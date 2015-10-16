using System;
using System.Runtime.Remoting.Messaging;

namespace Microcrumbs.Core
{
    internal class LogicalThreadContext : IThreadContext
    {
        private const string ServiceNamePropertyName = "Microcrumbs:ServiceName";
        private const string TraceIdPropertyName = "Microcrumbs:TraceId";
        private const string ParentIdPropertyName = "Microcrumbs:ParentId";
        private const string SpanIdPropertyName = "Microcrumbs:SpanId";

        public SpanContext Get()
        {
            return new SpanContext(ServiceName, TraceId, ParentId, SpanId);
        }

        public void Set(SpanContext spanContext)
        {
            ServiceName = spanContext.ServiceName;
            TraceId = spanContext.TraceId;
            ParentId = spanContext.ParentId;
            SpanId = spanContext.SpanId;
        }

        private string ServiceName
        {
            get { return GetString(ServiceNamePropertyName); }
            set { SetString(ServiceNamePropertyName, value); }
        }

        private ulong? TraceId
        {
            get { return GetUlong(TraceIdPropertyName); }
            set { SetUlong(TraceIdPropertyName, value); }
        }

        private ulong? ParentId
        {
            get { return GetUlong(ParentIdPropertyName); }
            set { SetUlong(ParentIdPropertyName, value); }
        }

        private ulong? SpanId
        {
            get { return GetUlong(SpanIdPropertyName); }
            set { SetUlong(SpanIdPropertyName, value); }
        }

        private string GetString(string properyName)
        {
            var propertyObject = CallContext.LogicalGetData(properyName);
            if (propertyObject == null)
            {
                return null;
            }

            return propertyObject.ToString();
        }

        private void SetString(string properyName, string value)
        {
            CallContext.LogicalSetData(properyName, value);
        }

        private ulong? GetUlong(string properyName)
        {
            var propertyObject = CallContext.LogicalGetData(properyName);
            if (propertyObject == null)
            {
                return null;
            }

            ulong propertyValue;
            var couldParse = UInt64.TryParse(propertyObject.ToString(), out propertyValue);

            if (couldParse)
            {
                return propertyValue;
            }
            else
            {
                return null;
            }
        }

        private void SetUlong(string properyName, ulong? value)
        {
            CallContext.LogicalSetData(properyName, value);
        }
    }
}