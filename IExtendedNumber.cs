using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any number type that extends another number.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <remarks>
    /// Implementing this interface indicates that operations provided by the implementing type
    /// in some way extend that of <typeparamref name="TInner"/>. In theory,
    /// <typeparamref name="TInner"/> could implement <see cref="INumber{TNumber}"/>
    /// of the implementing type to achieve the same result, but this way is preferred
    /// to decrease the number of interfaces that need to be provided.
    /// </remarks>
    public interface IExtendedNumber<TNumber, TInner> : INumber<TNumber> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// Invokes a binary operation on this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber Call(BinaryOperation operation, in TInner other);

        /// <summary>
        /// Retrieves an instance of <see cref="IExtendedNumberOperations{TNumber, TInner}"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="IExtendedNumberOperations{TNumber, TInner}"/> providing the operations of this type.</returns>
        new IExtendedNumberOperations<TNumber, TInner> GetOperations();
    }

    /// <summary>
    /// A general interface for any number type that wraps around another number.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// Implementing this interface indicates that operations provided by the implementing type
    /// in some way extend that of <typeparamref name="TInner"/>. In theory,
    /// <typeparamref name="TInner"/> could implement <see cref="INumber{TNumber, TPrimitive}"/>
    /// of the implementing type to achieve the same result, but this way is preferred
    /// to decrease the number of interfaces that need to be provided.
    /// </remarks>
    public interface IExtendedNumber<TNumber, TInner, TPrimitive> : IExtendedNumber<TNumber, TInner>, INumber<TNumber, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        /// <summary>
        /// Retrieves an instance of <see cref="IExtendedNumberOperations{TNumber, TInner, TPrimitive}"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="IExtendedNumberOperations{TNumber, TInner, TPrimitive}"/> providing the operations of this type.</returns>
        new IExtendedNumberOperations<TNumber, TInner, TPrimitive> GetOperations();
    }
}
