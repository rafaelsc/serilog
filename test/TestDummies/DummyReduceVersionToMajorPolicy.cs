using System;
using Serilog.Core;
using Serilog.Events;

namespace TestDummies
{
    public class DummyReduceVersionToMajorPolicy : IDestructuringPolicy
    {
        public bool TryDestructure(in object value, in ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
        {
            if (value is Version version)
            {
                result = new ScalarValue(version.Major);
                return true;
            }

            result = null;
            return false;
        }
    }
}
