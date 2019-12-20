using System;

namespace IS4.HyperNumerics
{
    public interface INumberFactory
    {
        INumber Zero { get; }
        INumber RealOne { get; }
        INumber SpecialOne { get; }
        INumber UnitsOne { get; }
        INumber NonRealUnitsOne { get; }
        INumber CombinedOne { get; }
        INumber AllOne { get; }
    }

    public interface INumberFactory<TNumber> : INumberFactory where TNumber : struct, INumber<TNumber>
    {
        new TNumber Zero { get; }
        new TNumber RealOne { get; }
        new TNumber SpecialOne { get; }
        new TNumber UnitsOne { get; }
        new TNumber NonRealUnitsOne { get; }
        new TNumber CombinedOne { get; }
        new TNumber AllOne { get; }
    }

    public interface INumberFactory<TNumber, TPrimitive> : INumberFactory<TNumber> where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        TNumber Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined);
    }
}
