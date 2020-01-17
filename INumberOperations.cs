using IS4.HyperNumerics.Operations;
using IS4.HyperNumerics.Utils;
using System;
using System.Collections.Generic;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// Provides operations for a number type implementing <see cref="INumber"/>.
    /// </summary>
    public interface INumberOperations
    {
        /// <summary>
        /// If the number can be expressed as an element of a vector space, returns its dimension (-1 if infinite).
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// Creates a new instance of the number type based on a value of the <see cref="StandardNumber"/> enum.
        /// </summary>
        /// <param name="num">The specific number that should be obtained.</param>
        /// <returns>The concrete instance of the number corresponding to <paramref name="num"/>.</returns>
        INumber Create(StandardNumber num);

        /// <summary>
        /// Invokes a unary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the argument doesn't have the same type that is supported by the instance.</exception>
        INumber Call(StandardUnaryOperation operation, INumber num);

        /// <summary>
        /// Invokes a binary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown if the argument doesn't have the same type that is supported by the instance.</exception>
        INumber Call(StandardBinaryOperation operation, INumber num1, INumber num2);
    }

    /// <summary>
    /// Provides operations for a number type implementing <see cref="INumber{TNumber}"/>.
    /// </summary>
    public interface INumberOperations<TNumber> : INumberOperations, IReadOnlyRefComparer<TNumber>, IReadOnlyRefEqualityComparer<TNumber> where TNumber : struct, INumber<TNumber>
    {
        /// <summary>
        /// Returns true if the number is invertible (usually equivalent to being non-zero), i.e. its inverse can be calculated.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if the number is invertible, false otherwise.</returns>
        bool IsInvertible(in TNumber num);

        /// <summary>
        /// Returns true if the number is finite, i.e. adding or subtracting finite values change its value.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if the number is finite, false otherwise.</returns>
        bool IsFinite(in TNumber num);

        /// <summary>
        /// Obtains a deep copy of the number.
        /// </summary>
        /// <param name="num">The number to clone.</param>
        /// <returns>A new instance equal to the original number.</returns>
        TNumber Clone(in TNumber num);

        /// <summary>
        /// Creates a new instance of the number type based on a value of the <see cref="StandardNumber"/> enum.
        /// </summary>
        /// <param name="num">The specific number that should be obtained.</param>
        /// <returns>The concrete instance of the number corresponding to <paramref name="num"/>.</returns>
        new TNumber Create(StandardNumber num);

        /// <summary>
        /// Invokes a unary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(StandardUnaryOperation operation, in TNumber num);

        /// <summary>
        /// Invokes a binary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(StandardBinaryOperation operation, in TNumber num1, in TNumber num2);
    }

    /// <summary>
    /// Provides operations for a number type implementing <see cref="INumber{TNumber, TComponent}"/>.
    /// </summary>
    public interface INumberOperations<TNumber, TComponent> : INumberOperations<TNumber> where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from the value of <typeparamref name="TComponent"/>.
        /// </summary>
        /// <param name="num">The inner value with which the instance shall be initialized to.</param>
        /// <returns>A new instance containing the inner value.</returns>
        TNumber Create(in TComponent num);

        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from the component coefficients of its components.
        /// </summary>
        /// <param name="realUnit">The real (standard) part of the number.</param>
        /// <param name="otherUnits">The other (non-real) units.</param>
        /// <param name="someUnitsCombined">Any combination of non-real units.</param>
        /// <param name="allUnitsCombined">The combination of all units.</param>
        /// <returns>A new instance with the specified units.</returns>
        TNumber Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined);

        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from its component components.
        /// </summary>
        /// <param name="units">A sequence of component values, used to construct the number.</param>
        /// <returns>A new instance with the specified units.</returns>
        TNumber Create(IEnumerable<TComponent> units);

        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from its component components.
        /// </summary>
        /// <param name="units">A sequence of component values, used to construct the number.</param>
        /// <returns>A new instance with the specified units.</returns>
        TNumber Create(IEnumerator<TComponent> units);

        /// <summary>
        /// Invokes a component-returning unary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TComponent CallComponent(StandardUnaryOperation operation, in TNumber num);

        /// <summary>
        /// Invokes a binary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(StandardBinaryOperation operation, in TNumber num1, in TComponent num2);

        /// <summary>
        /// Invokes a binary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(StandardBinaryOperation operation, in TComponent num1, in TNumber num2);
    }
}
