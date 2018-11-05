using System;
using Serilog.Core;
using Serilog.Events;

namespace TestDummies
{
    public class DummyHardCodedStringDestructuringPolicy : IDestructuringPolicy
    {
        readonly string _hardCodedString;

        public DummyHardCodedStringDestructuringPolicy(in string hardCodedString)
        {
            _hardCodedString = hardCodedString ?? throw new ArgumentNullException(nameof(hardCodedString));
        }

        public bool TryDestructure(in object value, in ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
        {
            result = new ScalarValue(_hardCodedString);
            return true;
        }
    }
}
