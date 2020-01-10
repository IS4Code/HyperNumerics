using IS4.HyperNumerics.Operations;
using IS4.HyperNumerics.Utils;
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
        /// Returns true if the number is finite, i.e. adding or subtracting finite values change its value.
        /// </summary>
        bool IsFinite { get; }

        /// <summary>
        /// Retrieves an instance of <see cref="INumberOperation"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="INumberOperation"/> providing the operations of this type.</returns>
        INumberOperations GetOperations();
    }

    /// <summary>
    /// A general interface for any number type supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <remarks>
    /// A type <c>T</c> might implement this interface not only with <typeparamref name="TNumber"/>
    /// set to <c>T</c> but also to other types. This means that the implementing type is expressible
    /// as <typeparamref name="TNumber"/>, or, in another words, <typeparamref name="TNumber"/> extends it.
    /// </remarks>
    public interface INumber<TNumber> : INumber, IReadOnlyRefEquatable<TNumber>, IReadOnlyRefComparable<TNumber> where TNumber : struct, INumber<TNumber>
    {
        /// <summary>
        /// Obtains a deep copy of the number.
        /// </summary>
        /// <returns>A new instance equal to the original number.</returns>
        new TNumber Clone();

        /// <summary>
        /// Invokes a unary operation on this number.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(UnaryOperation operation);

        /// <summary>
        /// Invokes a binary operation on this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(BinaryOperation operation, in TNumber other);

        /// <summary>
        /// Invokes a binary operation on <paramref name="other"/> and this number.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The first argument to the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber CallReversed(BinaryOperation operation, in TNumber other);

        /// <summary>
        /// Retrieves an instance of <see cref="INumberOperation{TNumber}"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="INumberOperation{TNumber}"/> providing the operations of this type.</returns>
        new INumberOperations<TNumber> GetOperations();
    }

    /// <summary>
    /// A general interface for any number type supporting the common set of standard operations, represented internally with a specific primitive type.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// Not all instances of this type might be directly representable as a list of <typeparamref name="TPrimitive"/>.
    /// If this is the case, the list interface might appear to be empty for certain values, or not even supported at all.
    /// </remarks>
    public interface INumber<TNumber, TPrimitive> : INumber<TNumber>, IList<TPrimitive>, IReadOnlyList<TPrimitive> where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        /// <summary>
        /// Invokes a primitive-returning unary operation on this number.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TPrimitive Call(PrimitiveUnaryOperation operation);

        /// <summary>
        /// Invokes a binary operation on this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(BinaryOperation operation, TPrimitive other);

        /// <summary>
        /// Invokes a binary operation on <paramref name="other"/> and this number.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber CallReversed(BinaryOperation operation, TPrimitive other);

        /// <summary>
        /// Retrieves an instance of <see cref="INumberOperation{TNumber, TPrimitive}"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="INumberOperation{TNumber, TPrimitive}"/> providing the operations of this type.</returns>
        new INumberOperations<TNumber, TPrimitive> GetOperations();
    }
}
