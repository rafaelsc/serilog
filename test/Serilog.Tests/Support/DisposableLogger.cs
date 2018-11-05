using System;
using System.Collections.Generic;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Tests.Support
{
    public class DisposableLogger : ILogger, IDisposable
    {
        public bool Disposed { get; set; }

        public void Dispose()
        {
            Disposed = true;
        }


        public ILogger ForContext(in ILogEventEnricher enricher)
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext(in IEnumerable<ILogEventEnricher> enrichers)
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext(in string propertyName, in object value, in bool destructureObjects = false)
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext<TSource>()
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext(in Type source)
        {
            throw new NotImplementedException();
        }

        public void Write(in LogEvent logEvent)
        {
            throw new NotImplementedException();
        }

        public void Write(in LogEventLevel level, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Write<T>(in LogEventLevel level, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Write<T0, T1>(in LogEventLevel level, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Write<T0, T1, T2>(in LogEventLevel level, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Write(in LogEventLevel level, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Write(in LogEventLevel level, in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Write<T>(in LogEventLevel level, in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Write<T0, T1>(in LogEventLevel level, in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Write<T0, T1, T2>(in LogEventLevel level, in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Write(in LogEventLevel level, in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(in LogEventLevel level)
        {
            throw new NotImplementedException();
        }

        public void Verbose(in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T>(in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Verbose(in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Verbose(in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Verbose(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Debug(in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Debug<T>(in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Debug(in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Debug(in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Debug<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Debug(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Information(in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Information<T>(in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Information(in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Information(in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Information<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Information(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Warning(in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Warning<T>(in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Warning(in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Warning(in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Warning<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Warning(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Error(in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Error<T>(in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Error(in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Error(in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Error<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Error(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Fatal(in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T>(in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1, T2>(in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Fatal(in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Fatal(in Exception exception, in string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T>(in Exception exception, in string messageTemplate, in T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1, T2>(in Exception exception, in string messageTemplate, in T0 propertyValue0, in T1 propertyValue1, in T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Fatal(in Exception exception, in string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public bool BindMessageTemplate(in string messageTemplate, in object[] propertyValues, out MessageTemplate parsedTemplate, out IEnumerable<LogEventProperty> boundProperties)
        {
            throw new NotImplementedException();
        }

        public bool BindProperty(in string propertyName, in object value, in bool destructureObjects, out LogEventProperty property)
        {
            throw new NotImplementedException();
        }
    }
}
