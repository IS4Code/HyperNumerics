using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    public interface INumberOperations
    {
        int Dimension { get; }

        INumber Call(NullaryOperation operation);
    }

    public interface INumberOperations<TNumber> : INumberOperations where TNumber : struct, INumber<TNumber>
    {
        bool IsInvertible(in TNumber num);

        bool IsFinite(in TNumber num);

        TNumber Clone(in TNumber num);

        bool Equals(in TNumber num1, in TNumber num2);

        int Compare(in TNumber num1, in TNumber num2);

        new TNumber Call(NullaryOperation operation);
        TNumber Call(UnaryOperation operation, in TNumber num);
        TNumber Call(BinaryOperation operation, in TNumber num1, in TNumber num2);
    }

    public interface INumberOperations<TNumber, TPrimitive> : INumberOperations<TNumber> where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        TNumber Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined);

        TPrimitive Call(PrimitiveUnaryOperation operation, in TNumber num);
        TNumber Call(BinaryOperation operation, in TNumber num1, TPrimitive num2);
    }
}
