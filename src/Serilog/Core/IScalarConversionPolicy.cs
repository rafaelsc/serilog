using System.Diagnostics.CodeAnalysis;
using Serilog.Events;

namespace Serilog.Core
{
    /// <summary>
    /// Determine how a simple value is carried through the logging
    /// pipeline as an immutable <see cref="ScalarValue"/>.
    /// </summary>
    interface IScalarConversionPolicy
    {
        /// <summary>
        /// If supported, convert the provided value into an immutable scalar.
        /// </summary>
        /// <param name="value">The value to convert. Can be <code>null</code>.</param>
        /// <param name="result">The converted value, or null.</param>
        /// <returns>True if the value could be converted under this policy.</returns>
        bool TryConvertToScalar([NotNullWhen(true)] object? value, [NotNullWhen(true)] out ScalarValue? result);
    }
}
