using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Tests.Support
{
    class DelegatingEnricher : ILogEventEnricher
    {
        readonly Action<LogEvent, ILogEventPropertyFactory> _enrich;

        public DelegatingEnricher(in Action<LogEvent, ILogEventPropertyFactory> enrich)
        {
            _enrich = enrich ?? throw new ArgumentNullException(nameof(enrich));
        }

        public void Enrich(in LogEvent logEvent, in ILogEventPropertyFactory propertyFactory)
        {
            _enrich(logEvent, propertyFactory);
        }
    }
}
