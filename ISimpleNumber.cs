using System;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface type for any number backed up by a single primitive type.
    /// </summary>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface ISimpleNumber<TPrimitive> : INumber, IList<TPrimitive>, IReadOnlyList<TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        TPrimitive Value { get; }
    }

    /// <summary>
    /// A general interface type for any number backed up by a single primitive type, supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface ISimpleNumber<TNumber, TPrimitive> : ISimpleNumber<TPrimitive>, INumber<TNumber, TPrimitive> where TNumber : struct, ISimpleNumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
