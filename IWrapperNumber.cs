using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any number that wraps a value of another number type.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IWrapperNumber<TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// The inner value of the number.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if the specific instance of the number type doesn't contain a <typeparamref name="TInner"/> value.</exception>
        TInner Value { get; }
    }

    /// <summary>
    /// A general interface for any number that wraps a value of another number type.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IWrapperNumber<TNumber, TInner> : IWrapperNumber<TInner>, IExtendedNumber<TNumber, TInner> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {

    }

    /// <summary>
    /// A general interface for any number that wraps a value of another number type.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface IWrapperNumber<TNumber, TInner, TPrimitive> : IWrapperNumber<TNumber, TInner>, IExtendedNumber<TNumber, TInner, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
