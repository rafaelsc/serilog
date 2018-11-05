﻿using Serilog.Core;
using Serilog.Events;

namespace TestDummies
{
    public class DummyThreadIdEnricher : ILogEventEnricher
    {
        public void Enrich(in LogEvent logEvent, in ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory
                .CreateProperty("ThreadId", "SomeId"));
        }
    }
}
