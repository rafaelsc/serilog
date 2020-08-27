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
using System.IO;
using System.Runtime.CompilerServices;
using Serilog.Support;

namespace Serilog.Events
{
    /// <summary>
    /// A log event.
    /// </summary>
    public class LogEvent
    {
        const byte DefaultExtraCapacityForProperties = 2;
        readonly int _numOfEnrichers = 0;

        //A cached and shared instance for a empty list of Properties
        static readonly IReadOnlyDictionary<string, LogEventPropertyValue> NoProperties = new EmptyReadOnlyDictionary<string, LogEventPropertyValue>();

        //Lazy Load a Instance for the Properties List
        Dictionary<string, LogEventPropertyValue> _properties => _propertiesInternal ??= new Dictionary<string, LogEventPropertyValue>(_numOfEnrichers + DefaultExtraCapacityForProperties);
        Dictionary<string, LogEventPropertyValue> _propertiesInternal = null; //This can be null. When null the LogEvent will use the NoProperties shared/cached instance.

        LogEvent(DateTimeOffset timestamp, LogEventLevel level, Exception exception, MessageTemplate messageTemplate, Dictionary<string, LogEventPropertyValue> propertiesDictionary)
        {
            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            _propertiesInternal = propertiesDictionary; //This can be null. When null the LogEvent will use the NoProperties shared/cached instance.
        }

        /// <summary>
        /// Construct a new <seealso cref="LogEvent"/>.
        /// </summary>
        /// <param name="timestamp">The time at which the event occurred.</param>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">An exception associated with the event, or null.</param>
        /// <param name="messageTemplate">The message template describing the event.</param>
        /// <param name="properties">Properties associated with the event, including those presented in <paramref name="messageTemplate"/>.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="messageTemplate"/> is <code>null</code></exception>
        /// <exception cref="ArgumentNullException">When <paramref name="properties"/> is <code>null</code></exception>
        public LogEvent(DateTimeOffset timestamp, LogEventLevel level, Exception exception, MessageTemplate messageTemplate, IEnumerable<LogEventProperty> properties)
        {
            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));

            if (properties is null) throw new ArgumentNullException(nameof(properties));
            ProcessProperties(properties, messageTemplate.AllProperties.Length);
        }

        /// <summary>
        /// Construct a new <seealso cref="LogEvent"/>.
        /// </summary>
        /// <param name="timestamp">The time at which the event occurred.</param>
        /// <param name="level">The level of the event.</param>
        /// <param name="exception">An exception associated with the event, or null.</param>
        /// <param name="messageTemplate">The message template describing the event.</param>
        /// <param name="properties">Properties associated with the event, including those presented in <paramref name="messageTemplate"/>.</param>
        /// <param name="numOfEnrichers"></param>
        /// <exception cref="ArgumentNullException">When <paramref name="messageTemplate"/> is <code>null</code></exception>
        /// <exception cref="ArgumentNullException">When <paramref name="properties"/> is <code>null</code></exception>
        internal LogEvent(DateTimeOffset timestamp, LogEventLevel level, Exception exception, MessageTemplate messageTemplate, in EventProperty[] properties, int numOfEnrichers)
        {
            Timestamp = timestamp;
            Level = level;
            Exception = exception;
            MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
            _numOfEnrichers = numOfEnrichers;

            if (properties == null) throw new ArgumentNullException(nameof(properties));
            ProcessProperties(properties, messageTemplate.AllProperties.Length, numOfEnrichers);
        }

        /// <summary>
        /// The time at which the event occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public LogEventLevel Level { get; }

        /// <summary>
        /// The message template describing the event.
        /// </summary>
        public MessageTemplate MessageTemplate { get; }

        /// <summary>
        /// Render the message template to the specified output, given the properties associated
        /// with the event.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        public void RenderMessage(TextWriter output, IFormatProvider formatProvider = null)
        {
            MessageTemplate.Render(Properties, output, formatProvider);
        }

        /// <summary>
        /// Render the message template given the properties associated
        /// with the event, and return the result.
        /// </summary>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        public string RenderMessage(IFormatProvider formatProvider = null)
        {
            return MessageTemplate.Render(Properties, formatProvider);
        }

        /// <summary>
        /// Properties associated with the event, including those presented in <see cref="LogEvent.MessageTemplate"/>.
        /// </summary>
        public IReadOnlyDictionary<string, LogEventPropertyValue> Properties => _propertiesInternal ?? NoProperties;

        /// <summary>
        /// An exception associated with the event, or null.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Add a property to the event if not already present, otherwise, update its value.
        /// </summary>
        /// <param name="property">The property to add or update.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="property"/> is <code>null</code></exception>
        public void AddOrUpdateProperty(LogEventProperty property)
        {
            if (property is null) throw new ArgumentNullException(nameof(property));

            _properties[property.Name] = property.Value;
        }

        /// <summary>
        /// Add a property to the event if not already present, otherwise, update its value.
        /// </summary>
        /// <param name="property">The property to add or update.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="property"/> is <code>default</code></exception>
        internal void AddOrUpdateProperty(in EventProperty property)
        {
            if (property.Equals(EventProperty.None)) throw new ArgumentNullException(nameof(property));

            _properties[property.Name] = property.Value;
        }

        /// <summary>
        /// Add a property to the event if not already present.
        /// </summary>
        /// <param name="property">The property to add.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="property"/> is <code>null</code></exception>
        public void AddPropertyIfAbsent(LogEventProperty property)
        {
            if (property is null) throw new ArgumentNullException(nameof(property));

            if (!_properties.ContainsKey(property.Name))
                _properties.Add(property.Name, property.Value);
        }

        /// <summary>
        /// Add a property to the event if not already present.
        /// </summary>
        /// <param name="property">The property to add.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="property"/> is <code>default</code></exception>
        internal void AddPropertyIfAbsent(in EventProperty property)
        {
            if (property.Equals(EventProperty.None)) throw new ArgumentNullException(nameof(property));

            if (!_properties.ContainsKey(property.Name))
                _properties.Add(property.Name, property.Value);
        }

        /// <summary>
        /// Remove a property from the event, if present. Otherwise no action
        /// is performed.
        /// </summary>
        /// <param name="propertyName">The name of the property to remove.</param>
        public void RemovePropertyIfPresent(string propertyName)
        {
            _properties.Remove(propertyName);
        }

        internal LogEvent Copy()
        {
            return new LogEvent(
                Timestamp,
                Level,
                Exception,
                MessageTemplate,
                _propertiesInternal == null ? null : new Dictionary<string, LogEventPropertyValue>(_propertiesInternal)); //Clone the Dictionary Instance, because another Sink can add more properties, but we don't need to clone the LogEventPropertyValue because is a immutable class.
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ProcessProperties(in EventProperty[] properties, int propertiesCountInMessage, int numOfEnricherProperties)
        {
            if (properties.Length == 0)
                return;

            InitProperties(Math.Max(properties.Length, propertiesCountInMessage) + numOfEnricherProperties);

            foreach (var p in properties) //This will be optimized to for(;;) by the compiler
                _propertiesInternal[p.Name] = p.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ProcessProperties(IEnumerable<LogEventProperty> properties, int propertiesCountInMessage)
        {
            InitProperties(propertiesCountInMessage);

            foreach (var p in properties)
                _properties[p.Name] = p.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void InitProperties(int itemCount)
        {
            if (itemCount == 0)
                return;

            _propertiesInternal = new Dictionary<string, LogEventPropertyValue>(itemCount + DefaultExtraCapacityForProperties);
        }
    }
}
