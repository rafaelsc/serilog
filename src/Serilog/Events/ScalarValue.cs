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
using System.Globalization;
using System.IO;

namespace Serilog.Events
{
    /// <summary>
    /// A property value corresponding to a simple, scalar type.
    /// </summary>
    public class ScalarValue : LogEventPropertyValue
    {
        /// <summary>
        /// Construct a <see cref="ScalarValue"/> with the specified
        /// value.
        /// </summary>
        /// <param name="value">The value, which may be <code>null</code>.</param>
        public ScalarValue(object value)
        {
            Value = value;
        }

        /// <summary>
        /// The value, which may be <code>null</code>.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Render the value to the output.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="format">A format string applied to the value, or null.</param>
        /// <param name="formatProvider">A format provider to apply to the value, or null to use the default.</param>
        /// <seealso cref="LogEventPropertyValue.ToString(string, IFormatProvider)"/>.
        /// <exception cref="ArgumentNullException">When <paramref name="output"/> is <code>null</code></exception>
        public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null)
        {
            Render(Value, output, format, formatProvider);
        }

        /// <exception cref="ArgumentNullException">When <paramref name="output"/> is <code>null</code></exception>
        internal static void Render(object value, TextWriter output, string format = null, IFormatProvider formatProvider = null)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));

            if (value == null)
            {
                output.Write("null");
                return;
            }

            if (value is string s)
            {
                if (format != "l")
                {
                    output.Write("\"");
                    output.Write(s.Replace("\"", "\\\""));
                    output.Write("\"");
                }
                else
                {
                    output.Write(s);
                }
                return;
            }

            if (formatProvider != null)
            {
                var custom = (ICustomFormatter)formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null)
                {
                    output.Write(custom.Format(format, value, formatProvider));
                    return;
                }
            }

            if (value is IFormattable f)
            {
                output.Write(f.ToString(format, formatProvider ?? CultureInfo.InvariantCulture));
            }
            else
            {
                output.Write(value.ToString());
            }
        }

        public void Deconstruct(out object value)
        {
            value = Value;
        }

        /// <summary>
        /// Indicates whether this instance and a specified <see cref="ScalarValue"/> are equal.
        /// </summary>
        /// <param name="other">The <see cref="ScalarValue"/> to compare with the current instance.</param>
        /// <returns>
        ///     <see langword="true"/> if <paramref name="other" /> and this instance represent the same value; otherwise, <see langword="false"/>.
        /// </returns>
        public virtual bool Equals(ScalarValue other) => Equals(Value, other.Value);

        /// <inheritdoc />
        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is ScalarValue other && Equals(other);

        /// <inheritdoc />
        public override int GetHashCode() => (Value != null ? Value.GetHashCode() : 0);

        /// <inheritdoc />
        public static bool operator ==(ScalarValue left, ScalarValue right) => Equals(left, right);

        /// <inheritdoc />
        public static bool operator !=(ScalarValue left, ScalarValue right) => !Equals(left, right);
    }
}
