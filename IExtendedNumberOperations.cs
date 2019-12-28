using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    public interface IExtendedNumberOperations<TNumber, TInner> : INumberOperations<TNumber> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        TNumber Create(in TInner num);

        TNumber Call(BinaryOperation operation, in TNumber num1, in TInner num2);
    }

    public interface IExtendedNumberOperations<TNumber, TInner, TPrimitive> : IExtendedNumberOperations<TNumber, TInner>, INumberOperations<TNumber, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
