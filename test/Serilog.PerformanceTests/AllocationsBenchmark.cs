using Serilog.Events;
using Serilog.Parsing;
using Serilog.Core.Enrichers;

using System;
using System.Linq;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;

namespace Serilog.PerformanceTests
{
    [MemoryDiagnoser, InliningDiagnoser, TailCallDiagnoser]
    [MinColumn, MaxColumn]
    public class AllocationsBenchmark
    {
        readonly ILogger _logger;
        readonly ILogger _enrichedLogger;
        readonly LogEvent _emptyEvent;

        readonly object _dictionaryValue;
        readonly object _anonymousObject;
        readonly object _sequence;
        readonly Exception _exception;

        public AllocationsBenchmark()
        {
            _exception = new Exception("An Error");

            _logger = new LoggerConfiguration().CreateLogger();

            _enrichedLogger = _logger.ForContext(new PropertyEnricher("Prop", "Value"));

            _emptyEvent = new LogEvent(
                DateTimeOffset.Now, 
                LogEventLevel.Information, 
                null, 
                new MessageTemplate(Enumerable.Empty<MessageTemplateToken>()),
                Enumerable.Empty<LogEventProperty>());

            _anonymousObject = new
            {
                Level11 = "Val1",
                Level12 = new
                {
                    Level21 = (int?)42,
                    Level22 = new
                    {
                        Level31 = System.Reflection.BindingFlags.FlattenHierarchy,
                        Level32 = new
                        {
                            X = 3,
                            Y = "4",
                            Z = (short?)5
                        }
                    }
                }
            };

            _dictionaryValue = new Dictionary<string, object> {
                { "Level11", "Val1" },
                { "Level12", new Dictionary<string, object>() {
                        { "Level21", (int?)42 },
                        { "Level22", new Dictionary<string, object>() {
                                { "Level31", System.Reflection.BindingFlags.FlattenHierarchy },
                                { "Level32", new { X = 3, Y = "4", Z = (short?)5 } }
                            }
                        }
                    }
                }
            };

            _sequence = new List<object> { "1", 2, (int?)3, "4", (short)5 };
        }

        [Benchmark(Baseline = true)]
        public void LogEmpty()
        {
            _logger.Write(_emptyEvent);
        }

        [Benchmark]
        public void LogEmptyWithEnricher()
        {
            _enrichedLogger.Write(_emptyEvent);
        }

        
        [Benchmark]
        public void LogMsg()
        {
            _logger.Information("Template:");
        }

        [Benchmark]
        public void LogScalar()
        {
            _logger.Information("Template: {ScalarValue}", "42");
        }

        [Benchmark]
        public void LogScalarStruct()
        {
            _logger.Information("Template: {ScalarStructValue}", 42);
        }

        [Benchmark]
        public void LogDictionary()
        {
            _logger.Information("Template: {DictionaryValue}", _dictionaryValue);
        }

        [Benchmark]
        public void LogSequence()
        {
            _logger.Information("Template: {SequenceValue}", _sequence);
        }

        [Benchmark]
        public void LogAnonymous()
        {
            _logger.Information("Template: {@AnonymousObject}.", _anonymousObject);
        }

        [Benchmark]
        public bool LogAll()
        {
            var x = _logger.IsEnabled(LogEventLevel.Debug);
            _logger.Write(_emptyEvent);
            _logger.Information("Template:");
            _logger.Information("Template: {ScalarStructValue}", 42);
            _logger.Information("Template: {ScalarValue}", "42");
            _logger.Information("Template: {DictionaryValue}", _dictionaryValue);
            _logger.Information("Template: {SequenceValue}", _sequence);
            _logger.Information("Template: {@AnonymousObject}.", _anonymousObject);
            _logger.Information(_exception, "Hello, {Name}!", "World");
            _logger.Fatal("Template2:");
            _logger.Fatal("Template: {ScalarStructValue}", 42);
            _logger.Fatal("Template2: {ScalarValue}", "42");
            _logger.Fatal("Template2: {DictionaryValue}", _dictionaryValue);
            _logger.Fatal("Template2: {SequenceValue}", _sequence);
            _logger.Fatal("Template2: {@AnonymousObject}.", _anonymousObject);
            _logger.Fatal(_exception, "Hello, {Name}! 2", "World");

            var y = _enrichedLogger.IsEnabled(LogEventLevel.Debug);
            _enrichedLogger.Write(_emptyEvent);
            _enrichedLogger.Information("Template:");
            _enrichedLogger.Information("Template: {ScalarStructValue}", 42);
            _enrichedLogger.Information("Template: {ScalarValue}", "42");
            _enrichedLogger.Information("Template: {DictionaryValue}", _dictionaryValue);
            _enrichedLogger.Information("Template: {SequenceValue}", _sequence);
            _enrichedLogger.Information("Template: {@AnonymousObject}.", _anonymousObject);
            _enrichedLogger.Information(_exception, "Hello, {Name}!", "World");
            _enrichedLogger.Fatal("Template2:");
            _enrichedLogger.Fatal("Template: {ScalarStructValue}", 42);
            _enrichedLogger.Fatal("Template2: {ScalarValue}", "42");
            _enrichedLogger.Fatal("Template2: {DictionaryValue}", _dictionaryValue);
            _enrichedLogger.Fatal("Template2: {SequenceValue}", _sequence);
            _enrichedLogger.Fatal("Template2: {@AnonymousObject}.", _anonymousObject);
            _enrichedLogger.Fatal(_exception, "Hello, {Name}! 2", "World");

            return x && y;
        }
    }
}
