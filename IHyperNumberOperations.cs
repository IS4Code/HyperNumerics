using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    public interface IHyperNumberOperations<TNumber, TInner> : IExtendedNumberOperations<TNumber, TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        TNumber Create(in TInner first, in TInner second);
    }

    public interface IHyperNumberOperations<TNumber, TInner, TPrimitive> : IHyperNumberOperations<TNumber, TInner>, IExtendedNumberOperations<TNumber, TInner, TPrimitive> where TNumber : struct, IHyperNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
