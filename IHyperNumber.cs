using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any hyper-number type, i.e. number consisting of two same-type components.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    public interface IHyperNumber<TInner> : INumber where TInner : struct, INumber<TInner>
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
    public interface IHyperNumber<TNumber, TInner> : IExtendedNumber<TNumber, TInner>, IHyperNumber<TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
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

        TNumber FirstCall(UnaryOperation operation);
        TNumber FirstCall(BinaryOperation operation, in TInner other);
        TNumber SecondCall(UnaryOperation operation);
        TNumber SecondCall(BinaryOperation operation, in TInner other);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface IHyperNumber<TNumber, TInner, TPrimitive> : IHyperNumber<TNumber, TInner>, IExtendedNumber<TNumber, TInner, TPrimitive> where TNumber : struct, IHyperNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        TNumber FirstCall(BinaryOperation operation, TPrimitive other);
        TNumber SecondCall(BinaryOperation operation, TPrimitive other);
    }
}
