using IS4.HyperNumerics.AdditionalInterfaces;
using IS4.HyperNumerics.Operations;
using System;
using System.Collections.Generic;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any number type.
    /// </summary>
    public interface INumber : IFormattable, ICloneable
    {
        /// <summary>
        /// If the number can be expressed as an element of a vector space, returns its dimension (-1 if infinite).
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// Returns true if the number is invertible (usually equivalent to being non-zero), i.e. its inverse can be calculated.
        /// </summary>
        bool IsInvertible { get; }

        /// <summary>
        /// Returns true if the number is finite (meaning depends on the actual number type).
        /// </summary>
        bool IsFinite { get; }

        INumberOperations GetOperations();
    }

    /// <summary>
    /// A general interface for any number type supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    public interface INumber<TNumber> : INumber, IReadOnlyRefEquatable<TNumber>, IReadOnlyRefComparable<TNumber> where TNumber : struct, INumber<TNumber>
    {
        /// <summary>
        /// Obtains a deep copy of the number.
        /// </summary>
        /// <returns></returns>
        new TNumber Clone();

        TNumber Call(BinaryOperation operation, in TNumber other);

        TNumber Call(UnaryOperation operation);

        new INumberOperations<TNumber> GetOperations();
    }

    /// <summary>
    /// A general interface for any number type supporting the common set of standard operations, represented internally with a specific primitive type.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface INumber<TNumber, TPrimitive> : INumber<TNumber>, IList<TPrimitive>, IReadOnlyList<TPrimitive> where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        TPrimitive Call(PrimitiveUnaryOperation operation);

        TNumber Call(BinaryOperation operation, TPrimitive other);

        new INumberOperations<TNumber, TPrimitive> GetOperations();
    }
}
