using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// Provides operations for a number type implementing <see cref="IHyperNumber{TNumber, TInner}"/>.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IHyperNumberOperations<TNumber, TInner> : IExtendedNumberOperations<TNumber, TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from the values of its two components.
        /// </summary>
        /// <param name="first">The first component's value.</param>
        /// <param name="second">The second component's value.</param>
        /// <returns>A new instance containing both values.</returns>
        TNumber Create(in TInner first, in TInner second);

        /// <summary>
        /// Returns the first component of <paramref name="num"/>.
        /// </summary>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The first component of <paramref name="num"/>.</returns>
        TInner GetFirst(in TNumber num);

        /// <summary>
        /// Returns the first component of <paramref name="num"/>.
        /// </summary>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The first component of <paramref name="num"/>.</returns>
        ref readonly TInner GetFirstReference(in TNumber num);

        /// <summary>
        /// Returns the second component of <paramref name="num"/>.
        /// </summary>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The second component of <paramref name="num"/>.</returns>
        TInner GetSecond(in TNumber num);

        /// <summary>
        /// Returns the second component of <paramref name="num"/>.
        /// </summary>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The second component of <paramref name="num"/>.</returns>
        ref readonly TInner GetSecondReference(in TNumber num);

        /// <summary>
        /// Returns the copy of <paramref name="num"/> with the first component replaced by <paramref name="first"/>.
        /// </summary>
        /// <param name="num">The argument of the operation.</param>
        /// <param name="first">The value of the new number's first component.</param>
        /// <returns>The new number.</returns>
        TNumber WithFirst(in TNumber num, in TInner first);

        /// <summary>
        /// Returns the copy of <paramref name="num"/> with the second component replaced by <paramref name="second"/>.
        /// </summary>
        /// <param name="num">The argument of the operation.</param>
        /// <param name="second">The value of the new number's second component.</param>
        /// <returns>The new number.</returns>
        TNumber WithSecond(in TNumber num, in TInner second);

        /// <summary>
        /// Invokes a unary operation on the first component of <paramref name="num"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardUnaryOperation operation, in TNumber num);

        /// <summary>
        /// Invokes a binary operation on the first component of <paramref name="num1"/> and <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardBinaryOperation operation, in TNumber num1, in TInner num2);

        /// <summary>
        /// Invokes a binary operation on <paramref name="num1"/> and the first component of <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardBinaryOperation operation, in TInner num1, in TNumber num2);

        /// <summary>
        /// Invokes a unary operation on the second component of <paramref name="num"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num">The argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardUnaryOperation operation, in TNumber num);

        /// <summary>
        /// Invokes a binary operation on the second component of <paramref name="num1"/> and <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardBinaryOperation operation, in TNumber num1, in TInner num2);

        /// <summary>
        /// Invokes a binary operation on <paramref name="num1"/> and the second component of <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardBinaryOperation operation, in TInner num1, in TNumber num2);
    }

    /// <summary>
    /// Provides operations for a number type implementing <see cref="IHyperNumber{TNumber, TInner, TComponent}"/>.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    public interface IHyperNumberOperations<TNumber, TInner, TComponent> : IHyperNumberOperations<TNumber, TInner>, IExtendedNumberOperations<TNumber, TInner, TComponent> where TNumber : struct, IHyperNumber<TNumber, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        /// <summary>
        /// Invokes a binary operation on the first component of <paramref name="num1"/> and <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardBinaryOperation operation, in TNumber num1, in TComponent num2);

        /// <summary>
        /// Invokes a binary operation on <paramref name="num1"/> and the second component of <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardBinaryOperation operation, in TComponent num1, in TNumber num2);

        /// <summary>
        /// Invokes a binary operation on the second component of <paramref name="num1"/> and <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardBinaryOperation operation, in TNumber num1, in TComponent num2);

        /// Invokes a binary operation on <paramref name="num1"/> and the second component of <paramref name="num2"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="num1">The first argument of the operation.</param>
        /// <param name="num2">The second argument of the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardBinaryOperation operation, in TComponent num1, in TNumber num2);
    }
}
