using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any hyper-number type, i.e. number consisting of two same-type components.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    public interface IHyperNumber<TInner> : IWrapperNumber<TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// The first component of the number.
        /// </summary>
        TInner First { get; }

        /// <summary>
        /// The second component of the number.
        /// </summary>
        TInner Second { get; }

        /// <summary>
        /// Deconstructs the components of the number.
        /// </summary>
        /// <param name="first">The variable to hold the first component of the number.</param>
        /// <param name="first">The variable to hold the second component of the number.</param>
        void Deconstruct(out TInner first, out TInner second);
    }

    /// <summary>
    /// A general interface for any hyper-number type, i.e. number consisting of two components, supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    public interface IHyperNumber<TNumber, TInner> : IHyperNumber<TInner>, IWrapperNumber<TNumber, TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// Returns the copy of the number with the first component replaced by <paramref name="first"/>.
        /// </summary>
        /// <param name="first">The value of the new number's first component.</param>
        /// <returns>The new number.</returns>
        TNumber WithFirst(in TInner first);

        /// <summary>
        /// Returns the copy of the number with the second component replaced by <paramref name="second"/>.
        /// </summary>
        /// <param name="second">The value of the new number's second component.</param>
        /// <returns>The new number.</returns>
        TNumber WithSecond(in TInner second);

        /// <summary>
        /// Invokes a unary operation on the first component of the number.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardUnaryOperation operation);

        /// <summary>
        /// Invokes a binary operation on the first component of the number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardBinaryOperation operation, in TInner other);

        /// <summary>
        /// Invokes a unary operation on the second component of the number.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardUnaryOperation operation);

        /// <summary>
        /// Invokes a binary operation on the second component of the number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardBinaryOperation operation, in TInner other);

        /// <summary>
        /// Retrieves an instance of <see cref="IHyperNumberOperations{TNumber, TInner}"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="IHyperNumberOperations{TNumber, TInner}"/> providing the operations of this type.</returns>
        new IHyperNumberOperations<TNumber, TInner> GetOperations();
    }

    /// <summary>
    /// A general interface for any hyper-number type, i.e. number consisting of two components, supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    public interface IHyperNumber<TNumber, TInner, TComponent> : IHyperNumber<TNumber, TInner>, IWrapperNumber<TNumber, TInner, TComponent> where TNumber : struct, IHyperNumber<TNumber, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        /// <summary>
        /// Invokes a binary operation on the first component of the number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation when invoked on the first component, with the second component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber FirstCall(StandardBinaryOperation operation, in TComponent other);

        /// <summary>
        /// Invokes a binary operation on the second component of the number and <paramref name="other"/>.
        /// </summary>
        /// <param name="operation">The operation that will be invoked.</param>
        /// <param name="other">The second argument to the operation.</param>
        /// <returns>The result of the operation when invoked on the second component, with the first component unchanged.</returns>
        /// <exception cref="System.NotSupportedException">Thrown if the operation is not supported.</exception>
        TNumber SecondCall(StandardBinaryOperation operation, in TComponent other);

        /// <summary>
        /// Retrieves an instance of <see cref="IHyperNumberOperations{TNumber, TInner, TComponent}"/> providing the supported operations on this type.
        /// </summary>
        /// <returns>An instance of <see cref="IHyperNumberOperations{TNumber, TInner, TComponent}"/> providing the operations of this type.</returns>
        new IHyperNumberOperations<TNumber, TInner, TComponent> GetOperations();
    }
}
