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

namespace Serilog.Events
{
    /// <summary>
    /// A property associated with a <see cref="LogEvent"/>.
    /// </summary>
    public readonly struct LogEventProperty
    {
        /// <summary>
        /// Construct a <see cref="LogEventProperty"/> with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public LogEventProperty(in string name, in LogEventPropertyValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (!IsValidName(name))
                throw new ArgumentException("Property name is not valid.");

            Name = name;
            Value = value;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The value of the property.
        /// </summary>
        public LogEventPropertyValue Value { get; }

        /// <summary>
        /// Test <paramref name="name" /> to determine if it is a valid property name.
        /// </summary>
        /// <param name="name">The name to check.</param>
        /// <returns>True if the name is valid; otherwise, false.</returns>
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
        
        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <returns>true if <paramref name="other" /> and this instance are the same type and represent the same value; otherwise, false. </returns>
        /// <param name="other">The object to compare with the current instance. </param>
        public bool Equals(LogEventProperty other)
        {
            return string.Equals(Name, other.Name) && Equals(Value, other.Value);
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <returns>true if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, false. </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LogEventProperty other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}
