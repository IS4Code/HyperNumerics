using IS4.HyperNumerics.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any number type that extends another number.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IExtendedNumber<TNumber, TInner> : INumber<TNumber> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        TNumber Call(BinaryOperation operation, in TInner other);
    }

    /// <summary>
    /// A general interface for any number type that wraps around another number.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface IExtendedNumber<TNumber, TInner, TPrimitive> : IExtendedNumber<TNumber, TInner>, INumber<TNumber, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
