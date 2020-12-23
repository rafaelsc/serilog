// Copyright 2013-2015 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Serilog.Core;
using Serilog.Events;

namespace Serilog
{
    /// <summary>
    /// The core Serilog logging API, used for writing log events.
    /// </summary>
    /// <example>
    /// var log = new LoggerConfiguration()
    ///     .WriteTo.Console()
    ///     .CreateLogger();
    ///
    /// var thing = "World";
    /// log.Information("Hello, {Thing}!", thing);
    /// </example>
    /// <remarks>
    /// The methods on <see cref="ILogger"/> (and its static sibling <see cref="Log"/>) are guaranteed
    /// never to throw exceptions. Methods on all other types may.
    /// </remarks>
    public interface ILogger
    {
#if FEATURE_DEFAULT_INTERFACE
        private static readonly object[] NoPropertyValues = Array.Empty<object>();
        private static readonly Logger DefaultLoggerImpl = new LoggerConfiguration().CreateLogger();
#endif

        /// <summary>
        /// Create a logger that enriches log events via the provided enrichers.
        /// </summary>
        /// <param name="enricher">Enricher that applies in the context.</param>
        /// <returns>A logger that will enrich log events as specified.</returns>
#if FEATURE_DEFAULT_INTERFACE
        [CustomDefaultMethodImplementation]
#endif
        ILogger ForContext(ILogEventEnricher enricher)
#if FEATURE_DEFAULT_INTERFACE
            => new LoggerConfiguration()
                .MinimumLevel.Is(LevelAlias.Minimum)
                .WriteTo.Logger(this)
                .CreateLogger()
                .ForContext(enricher)
#endif
        ;

        /// <summary>
        /// Create a logger that enriches log events via the provided enrichers.
        /// </summary>
        /// <param name="enrichers">Enrichers that apply in the context.</param>
        /// <returns>A logger that will enrich log events as specified.</returns>
        ILogger ForContext(IEnumerable<ILogEventEnricher> enrichers)
#if FEATURE_DEFAULT_INTERFACE
        {
            if (enrichers is null)
                return this; // No context here, so little point writing to SelfLog.

            return ForContext(new Core.Enrichers.SafeAggregateEnricher(enrichers));
        }
#else
        ;
#endif

        /// <summary>
        /// Create a logger that enriches log events with the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property. Must be non-empty.</param>
        /// <param name="value">The property value.</param>
        /// <param name="destructureObjects">If true, the value will be serialized as a structured
        /// object if possible; if false, the object will be recorded as a scalar or simple array.</param>
        /// <returns>A logger that will enrich log events as specified.</returns>
#if FEATURE_DEFAULT_INTERFACE
        [CustomDefaultMethodImplementation]
#endif
        ILogger ForContext(string propertyName, object value, bool destructureObjects = false)
#if FEATURE_DEFAULT_INTERFACE
            => new LoggerConfiguration()
                .MinimumLevel.Is(LevelAlias.Minimum)
                .WriteTo.Logger(this)
                .CreateLogger()
                .ForContext(propertyName, value, destructureObjects)
#endif
        ;

        /// <summary>
        /// Create a logger that marks log events as being from the specified
        /// source type.
        /// </summary>
        /// <typeparam name="TSource">Type generating log messages in the context.</typeparam>
        /// <returns>A logger that will enrich log events as specified.</returns>
        ILogger ForContext<TSource>()
#if FEATURE_DEFAULT_INTERFACE
            => ForContext(typeof(TSource))
#endif
            ;

        /// <summary>
        /// Create a logger that marks log events as being from the specified
        /// source type.
        /// </summary>
        /// <param name="source">Type generating log messages in the context.</param>
        /// <returns>A logger that will enrich log events as specified.</returns>
        ILogger ForContext(Type source)
#if FEATURE_DEFAULT_INTERFACE
        {
            if (source is null)
                return this; // Little point in writing to SelfLog here because we don't have any contextual information

            return ForContext(Constants.SourceContextPropertyName, source.FullName);
        }
#else
        ;
#endif

        /// <summary>
        /// Write an event to the log.
        /// </summary>
        /// <param name="logEvent">The event to write.</param>
        void Write(LogEvent logEvent);

        /// <summary>
        /// Write a log event with the specified level.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write(LogEventLevel level, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, null, messageTemplate);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write<T>(LogEventLevel level, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, null, messageTemplate, propertyValue);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write<T0, T1>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, null, messageTemplate, propertyValue0, propertyValue1);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write<T0, T1, T2>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="messageTemplate"></param>
        /// <param name="propertyValues"></param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write(LogEventLevel level, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the specified level and associated exception.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write(LogEventLevel level, Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, exception, messageTemplate);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level and associated exception.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write<T>(LogEventLevel level, Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, exception, messageTemplate, propertyValue);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level and associated exception.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write<T0, T1>(LogEventLevel level, Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, exception, messageTemplate, propertyValue0, propertyValue1);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level and associated exception.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write<T0, T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
#else
        ;
#endif

        /// <summary>
        /// Write a log event with the specified level and associated exception.
        /// </summary>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Write(LogEventLevel level, Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(level, exception, messageTemplate, propertyValues);
#else
        ;
#endif

#if FEATURE_DEFAULT_INTERFACE

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteInternal<T>(LogEventLevel level, Exception exception, string messageTemplate, T propertyValue)
        {
            // Avoid the array allocation and any boxing allocations when the level isn't enabled
            if (IsEnabled(level))
            {
                WriteInternal(level, exception, messageTemplate, new object[] { propertyValue });
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteInternal<T0, T1>(LogEventLevel level, Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            // Avoid the array allocation and any boxing allocations when the level isn't enabled
            if (IsEnabled(level))
            {
                WriteInternal(level, exception, messageTemplate, new object[] { propertyValue0, propertyValue1 });
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteInternal<T0, T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            // Avoid the array allocation and any boxing allocations when the level isn't enabled
            if (IsEnabled(level))
            {
                WriteInternal(level, exception, messageTemplate, new object[] { propertyValue0, propertyValue1, propertyValue2 });
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteInternal(LogEventLevel level, Exception exception, string messageTemplate)
        {
            WriteInternal(level, exception, messageTemplate, NoPropertyValues);
        }

        [CustomDefaultMethodImplementation]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteInternal(LogEventLevel level, Exception exception, string messageTemplate, object[] propertyValues)
        {
            if (!IsEnabled(level)) return;
            if (messageTemplate is null) return;

            // Catch a common pitfall when a single non-object array is cast to object[]
            if (propertyValues != null &&
                propertyValues.GetType() != typeof(object[]))
                propertyValues = new object[] { propertyValues };

            if (BindMessageTemplate(messageTemplate, propertyValues, out var parsedTemplate, out var boundProperties))
            {
                Write(new LogEvent(DateTimeOffset.Now, level, exception, parsedTemplate, boundProperties));
            }
        }
#endif

        /// <summary>
        /// Determine if events at the specified level will be passed through
        /// to the log sinks.
        /// </summary>
        /// <param name="level">Level to check.</param>
        /// <returns>True if the level is enabled; otherwise, false.</returns>
#if FEATURE_DEFAULT_INTERFACE
        [CustomDefaultMethodImplementation]
#endif
        bool IsEnabled(LogEventLevel level)
#if FEATURE_DEFAULT_INTERFACE
            => true
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Verbose("Staring into space, wondering if we're alone.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose(string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, null, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose("Staring into space, wondering if we're alone.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose<T>(string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, null, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose("Staring into space, wondering if we're alone.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, null, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose("Staring into space, wondering if we're alone.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose("Staring into space, wondering if we're alone.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose(string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Verbose(ex, "Staring into space, wondering where this comet came from.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose(Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, exception, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose(ex, "Staring into space, wondering where this comet came from.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose<T>(Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, exception, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose(ex, "Staring into space, wondering where this comet came from.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, exception, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose(ex, "Staring into space, wondering where this comet came from.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Verbose"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Verbose(ex, "Staring into space, wondering where this comet came from.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, exception, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug(string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, null, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug<T>(string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, null, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, null, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug("Starting up at {StartedAt}.", DateTime.Now);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug(string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Debug(ex, "Swallowing a mundane exception.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug(Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, exception, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug(ex, "Swallowing a mundane exception.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug<T>(Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, exception, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug(ex, "Swallowing a mundane exception.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, exception, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug(ex, "Swallowing a mundane exception.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Debug"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Debug(ex, "Swallowing a mundane exception.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Debug, exception, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information(string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, null, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information<T>(string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, null, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, null, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information(string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information(Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, exception, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information<T>(Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, exception, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, exception, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Information"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Information(Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Information, exception, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning(string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, null, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning<T>(string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, null, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, null, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning(string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Verbose, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning(Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, exception, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning<T>(Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, exception, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, exception, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Warning"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Warning, exception, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error(string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, null, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error<T>(string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, null, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, null, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error(string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error(Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, exception, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error<T>(Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, exception, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Error"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Error(Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Error, exception, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Fatal("Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal(string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, null, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal("Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal<T>(string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, null, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal("Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, null, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal("Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, null, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal("Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal(string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, null, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Fatal(ex, "Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal(Exception exception, string messageTemplate)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, exception, messageTemplate)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal(ex, "Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal<T>(Exception exception, string messageTemplate, T propertyValue)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, exception, messageTemplate, propertyValue)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal(ex, "Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, exception, messageTemplate, propertyValue0, propertyValue1)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal(ex, "Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2)
#endif
            ;

        /// <summary>
        /// Write a log event with the <see cref="LogEventLevel.Fatal"/> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Fatal(ex, "Process terminating.");
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
        void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
#if FEATURE_DEFAULT_INTERFACE
            => WriteInternal(LogEventLevel.Fatal, exception, messageTemplate, propertyValues)
#endif
            ;

        /// <summary>
        /// Uses configured scalar conversion and destructuring rules to bind a set of properties to a
        /// message template. Returns false if the template or values are invalid (<c>ILogger</c>
        /// methods never throw exceptions).
        /// </summary>
        /// <param name="messageTemplate">Message template describing an event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <param name="parsedTemplate">The internal representation of the template, which may be used to
        /// render the <paramref name="boundProperties"/> as text.</param>
        /// <param name="boundProperties">Captured properties from the template and <paramref name="propertyValues"/>.</param>
        /// <example>
        /// MessageTemplate template;
        /// IEnumerable&lt;LogEventProperty&gt; properties>;
        /// if (Log.BindMessageTemplate("Hello, {Name}!", new[] { "World" }, out template, out properties)
        /// {
        ///     var propsByName = properties.ToDictionary(p => p.Name, p => p.Value);
        ///     Console.WriteLine(template.Render(propsByName, null));
        ///     // -> "Hello, World!"
        /// }
        /// </example>
        [MessageTemplateFormatMethod("messageTemplate")]
#if FEATURE_DEFAULT_INTERFACE
        [CustomDefaultMethodImplementation]
#endif
        bool BindMessageTemplate(string messageTemplate, object[] propertyValues,
                                 out MessageTemplate parsedTemplate, out IEnumerable<LogEventProperty> boundProperties)
#if FEATURE_DEFAULT_INTERFACE
            => DefaultLoggerImpl.BindMessageTemplate(messageTemplate, propertyValues, out parsedTemplate, out boundProperties)
#endif
            ;

        /// <summary>
        /// Uses configured scalar conversion and destructuring rules to bind a property value to its captured
        /// representation.
        /// </summary>
        /// <param name="propertyName">The name of the property. Must be non-empty.</param>
        /// <param name="value">The property value.</param>
        /// <param name="destructureObjects">If true, the value will be serialized as a structured
        /// object if possible; if false, the object will be recorded as a scalar or simple array.</param>
        /// <param name="property">The resulting property.</param>
        /// <returns>True if the property could be bound, otherwise false (<summary>ILogger</summary>
        /// methods never throw exceptions).</returns>
#if FEATURE_DEFAULT_INTERFACE
        [CustomDefaultMethodImplementation]
#endif
        bool BindProperty(string propertyName, object value, bool destructureObjects, out LogEventProperty property)
#if FEATURE_DEFAULT_INTERFACE
            => DefaultLoggerImpl.BindProperty(propertyName, value, destructureObjects, out property)
#endif
            ;
    }
}
