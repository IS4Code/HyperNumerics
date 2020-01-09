using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a diagonal number formed from two values of type <typeparamref name="TInner"/>.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <remarks>
    /// A diagonal number (a, b) can be represented algebraically as a + bk, where k^2 = k.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDiagonal<TInner> where TInner : struct, INumber<TInner>
    {
        public bool IsInvertible => CanInv(first) && CanInv(Add(first, second));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperDiagonal<TInner> Call(BinaryOperation operation, in HyperDiagonal<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(first, other.first), Add(Add(Mul(first, other.second), Mul(second, other.first)), Mul(second, other.second)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperDiagonal<TInner>(Div(first, other.first), Div(Sub(second, Div(Mul(first, other.second), other.first)), Add(other.first, other.second)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperDiagonal<TInner>(Neg(this.first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDiagonal<TInner>(Inc(this.first), second);
                case UnaryOperation.Decrement:
                    return new HyperDiagonal<TInner>(Dec(this.first), second);
                case UnaryOperation.Inverse:
                    return new HyperDiagonal<TInner>(Inv(this.first), Div(Neg(second), Mul(Add(this.first, second), this.first)));
                case UnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner>(this.first, Neg(second));
                case UnaryOperation.Modulus:
                    return Mul(Add(this.first, second), this.first);
                case UnaryOperation.Double:
                    return new HyperDiagonal<TInner>(Mul2(this.first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDiagonal<TInner>(Div2(this.first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDiagonal<TInner>(Pow2(this.first), Add(Mul2(Mul(this.first, second)), Pow2(second)));
                default:
                    var first = HyperMath.Call(operation, this.first);
                    return new HyperDiagonal<TInner>(first, Sub(HyperMath.Call(operation, Add(this.first, second)), first));
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperDiagonal<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a diagonal number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TPrimitive"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// A diagonal number (a, b) can be represented algebraically as a + bk, where k^2 = k.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDiagonal<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public bool IsInvertible => CanInv(first) && CanInv(Add(first, second));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul(first, other.first), Add(Add(Mul(first, other.second), Mul(second, other.first)), Mul(second, other.second)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperDiagonal<TInner, TPrimitive>(Div(first, other.first), Div(Sub(second, Div(Mul(first, other.second), other.first)), Add(other.first, other.second)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TPrimitive>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(AddVal(this.first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(SubVal(this.first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(MulVal(this.first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TPrimitive>(DivVal(this.first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    var first = PowVal(this.first, other);
                    return new HyperDiagonal<TInner, TPrimitive>(first, Sub(PowVal(Add(this.first, second), other), first));
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperDiagonal<TInner, TPrimitive>(Neg(this.first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDiagonal<TInner, TPrimitive>(Inc(this.first), second);
                case UnaryOperation.Decrement:
                    return new HyperDiagonal<TInner, TPrimitive>(Dec(this.first), second);
                case UnaryOperation.Inverse:
                    return new HyperDiagonal<TInner, TPrimitive>(Inv(this.first), Div(Neg(second), Mul(Add(this.first, second), this.first)));
                case UnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner, TPrimitive>(this.first, Neg(second));
                case UnaryOperation.Modulus:
                    return Mul(Add(this.first, second), this.first);
                case UnaryOperation.Double:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul2(this.first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDiagonal<TInner, TPrimitive>(Div2(this.first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDiagonal<TInner, TPrimitive>(Pow2(this.first), Add(Mul2(Mul(this.first, second)), Pow2(second)));
                default:
                    var first = HyperMath.Call(operation, this.first);
                    return new HyperDiagonal<TInner, TPrimitive>(first, Sub(HyperMath.Call(operation, Add(this.first, second)), first));
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(first);
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperDiagonal<TInner, TPrimitive> value && Equals(in value);
        }
    }
}
