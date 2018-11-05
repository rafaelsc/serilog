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
using Serilog.Events;

namespace Serilog.Core.Pipeline
{
    internal sealed class SilentLogger : ILogger
    {
        public static readonly ILogger Instance = new SilentLogger();

        private SilentLogger()
        {
        }

        public ILogger ForContext(in ILogEventEnricher enricher)
        {
            return this;
        }

        public ILogger ForContext(in IEnumerable<ILogEventEnricher> enrichers)
        {
            return this;
        }

        public ILogger ForContext(in string propertyName, in object value, in bool destructureObjects = false)
        {
            return this;
        }

        public ILogger ForContext<TSource>()
        {
            return this;
        }

        public ILogger ForContext(in Type source)
        {
            return this;
        }

        public void Write(in LogEvent logEvent)
        {
        }

        public void Write(in LogEventLevel level, in string messageTemplate)
        {
        }

        public void Write<T>(in LogEventLevel level, in string messageTemplate, in T propertyValue)
        {
        }

        public void Write<T0, T1>(in LogEventLevel level, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Write<T0, T1, T2>(in LogEventLevel level, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Write(in LogEventLevel level, in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Write(in LogEventLevel level, in Exception exception, in string messageTemplate)
        {
        }

        public void Write<T>(in LogEventLevel level, in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Write<T0, T1>(in LogEventLevel level, in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Write<T0, T1, T2>(in LogEventLevel level, in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Write(in LogEventLevel level, in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        public bool IsEnabled(in LogEventLevel level)
        {
            return false;
        }

        public void Verbose(in string messageTemplate)
        {
        }

        public void Verbose<T>(in string messageTemplate, in T propertyValue)
        {
        }

        public void Verbose<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Verbose<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Verbose(in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Verbose(in Exception exception, in string messageTemplate)
        {
        }

        public void Verbose<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Verbose<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Verbose<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Verbose(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Debug(in string messageTemplate)
        {
        }

        public void Debug<T>(in string messageTemplate, in T propertyValue)
        {
        }

        public void Debug<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Debug<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Debug(in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Debug(in Exception exception, in string messageTemplate)
        {
        }

        public void Debug<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Debug<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Debug<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Debug(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Information(in string messageTemplate)
        {
        }

        public void Information<T>(in string messageTemplate, in T propertyValue)
        {
        }

        public void Information<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Information<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Information(in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Information(in Exception exception, in string messageTemplate)
        {
        }

        public void Information<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Information<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Information<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Information(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Warning(in string messageTemplate)
        {
        }

        public void Warning<T>(in string messageTemplate, in T propertyValue)
        {
        }

        public void Warning<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Warning<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Warning(in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Warning(in Exception exception, in string messageTemplate)
        {
        }

        public void Warning<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Warning<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Warning<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Warning(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Error(in string messageTemplate)
        {
        }

        public void Error<T>(in string messageTemplate, in T propertyValue)
        {
        }

        public void Error<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Error<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Error(in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Error(in Exception exception, in string messageTemplate)
        {
        }

        public void Error<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Error<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Error<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Error(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Fatal(in string messageTemplate)
        {
        }

        public void Fatal<T>(in string messageTemplate, in T propertyValue)
        {
        }

        public void Fatal<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Fatal<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Fatal(in string messageTemplate, params object[] propertyValues)
        {
        }

        public void Fatal(in Exception exception, in string messageTemplate)
        {
        }

        public void Fatal<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
        }

        public void Fatal<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
        }

        public void Fatal<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
        }

        public void Fatal(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
        }

        [MessageTemplateFormatMethod("messageTemplate")]
        public bool BindMessageTemplate(in string messageTemplate, in object[] propertyValues, out MessageTemplate parsedTemplate, out IEnumerable<LogEventProperty> boundProperties)
        {
            parsedTemplate = null;
            boundProperties = null;
            return false;
        }

        public bool BindProperty(in string propertyName, in object value, in bool destructureObjects, out LogEventProperty property)
        {
            property = default;
            return false;
        }
    }
}
