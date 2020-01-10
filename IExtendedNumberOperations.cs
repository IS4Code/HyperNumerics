using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// Provides operations for a number type implementing <see cref="IExtendedNumber{TNumber, TInner}"/>.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IExtendedNumberOperations<TNumber, TInner> : INumberOperations<TNumber> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from the value of <typeparamref name="TInner"/>.
        /// </summary>
        /// <param name="num">The inner value with which the instance shall be initialized to.</param>
        /// <returns>A new instance containing the inner value.</returns>
        TNumber Create(in TInner num);

        /// <summary>
        /// Invokes a binary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(BinaryOperation operation, in TNumber num1, in TInner num2);

        /// <summary>
        /// Invokes a binary operation for the number type.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(BinaryOperation operation, in TInner num1, in TNumber num2);
    }

    /// <summary>
    /// Provides operations for a number type implementing <see cref="IExtendedNumber{TNumber, TInner, TPrimitive}"/>.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface IExtendedNumberOperations<TNumber, TInner, TPrimitive> : IExtendedNumberOperations<TNumber, TInner>, INumberOperations<TNumber, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
