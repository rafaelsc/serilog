using Serilog.Events;
using Serilog.Parsing;
using Serilog.Core.Enrichers;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
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
        readonly BigTestStruct _bigStruct;
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

            _bigStruct = new BigTestStruct()
            {
                Active = true,
                Count = 918217217261726172L,
                Lat = -42,
                Long = 42,
                Points = new float[10][]
                {
                    new float[10] {0,1,2,3,4,5,6,7,8,9,},
                    new float[10] {1,2,3,4,5,6,7,8,9,0,},
                    new float[10] {2,3,4,5,6,7,8,9,0,1,},
                    new float[10] {3,4,5,6,7,8,9,0,1,2,},
                    new float[10] {4,5,6,7,8,9,0,1,2,3,},
                    new float[10] {5,6,7,8,9,0,1,2,3,4,},
                    new float[10] {6,7,8,9,0,1,2,3,4,5,},
                    new float[10] {7,8,9,0,1,2,3,4,5,6,},
                    new float[10] {8,9,0,1,2,3,4,5,6,7,},
                    new float[10] {9,0,1,2,3,4,5,6,7,8,},
                },
            };
            
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
        public void LogScalarBigStruct()
        {
            _logger.Information("Template: {ScalarBigStructValue}", _bigStruct);
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
            _logger.Information("Template: {ScalarBigStructValue}", _bigStruct);
            _logger.Information("Template: {ScalarValue}", "42");
            _logger.Information("Template: {DictionaryValue}", _dictionaryValue);
            _logger.Information("Template: {SequenceValue}", _sequence);
            _logger.Information("Template: {@AnonymousObject}.", _anonymousObject);
            _logger.Information(_exception, "Hello, {Name}!", "World");
          
            var y = _enrichedLogger.IsEnabled(LogEventLevel.Debug);
            _enrichedLogger.Write(_emptyEvent);
            _enrichedLogger.Information("Template:");
            _enrichedLogger.Information("Template: {ScalarStructValue}", 42);
            _enrichedLogger.Information("Template: {ScalarBigStructValue}", _bigStruct);
            _enrichedLogger.Information("Template: {ScalarValue}", "42");
            _enrichedLogger.Information("Template: {DictionaryValue}", _dictionaryValue);
            _enrichedLogger.Information("Template: {SequenceValue}", _sequence);
            _enrichedLogger.Information("Template: {@AnonymousObject}.", _anonymousObject);
            _enrichedLogger.Information(_exception, "Hello, {Name}!", "World");
            
            return x && y;
        }

        struct BigTestStruct
        {
            public decimal Lat { get; set; }
            public decimal Long { get; set; }
            public float[][] Points{ get; set; }
            public BigInteger Count { get; set; }
            public bool Active { get; set; }
        }
    }
}
