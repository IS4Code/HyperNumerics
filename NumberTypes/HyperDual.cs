using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a dual number formed from two values of type <typeparamref name="TInner"/>.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <remarks>
    /// A dual number (a, b) can be represented algebraically as a + bε, where ε^2 = 0.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDual<TInner> where TInner : struct, INumber<TInner>
    {
        public bool IsInvertible => CanInv(first);

        public bool IsFinite => IsFin(first);

        public HyperDual<TInner> Call(BinaryOperation operation, in HyperDual<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner>(Mul(first, other.first), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    if(!CanInv(first) && !CanInv(other.first))
                    {
                        return new HyperDual<TInner>(Div(second, other.second));
                    }
                    return new HyperDual<TInner>(Div(first, other.first), Div(Sub(Mul(second, other.first), Mul(first, other.second)), Pow2(other.first)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperDual<TInner>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDual<TInner>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperDual<TInner>(Dec(first), second);
                case UnaryOperation.Inverse:
                    return new HyperDual<TInner>(Inv(first), Div(Neg(second), Pow2(first)));
                case UnaryOperation.Conjugate:
                    return new HyperDual<TInner>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Pow2(first));
                case UnaryOperation.Double:
                    return new HyperDual<TInner>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDual<TInner>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDual<TInner>(Pow2(first), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    var sqrt = Sqrt(first);
                    return new HyperDual<TInner>(sqrt, Div(second, Mul2(sqrt)));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperDual<TInner>(exp, Mul(exp, second));
                case UnaryOperation.Logarithm:
                    return new HyperDual<TInner>(Log(first), Div(second, first));
                case UnaryOperation.Sine:
                    return new HyperDual<TInner>(Sin(first), Mul(Cos(first), second));
                case UnaryOperation.Cosine:
                    return new HyperDual<TInner>(Cos(first), Mul(Neg(Sin(first)), second));
                case UnaryOperation.Tangent:
                    return new HyperDual<TInner>(Tan(first), Div(second, Pow2(Cos(first))));
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    return new HyperDual<TInner>(Asin(first), Div(second, Sqrt(Inc(Neg(Pow2(first))))));
                case UnaryOperation.ArcCosine:
                    return new HyperDual<TInner>(Acos(first), Neg(Div(second, Sqrt(Inc(Neg(Pow2(first)))))));
                case UnaryOperation.ArcTangent:
                    return new HyperDual<TInner>(Atan(first), Div(second, Inc(Pow2(first))));
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperDual<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a dual number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TPrimitive"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// A dual number (a, b) can be represented algebraically as a + bε, where ε^2 = 0.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDual<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public bool IsInvertible => CanInv(first);

        public bool IsFinite => IsFin(first);

        public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TPrimitive>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(Mul(first, other.first), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    if(!CanInv(first) && !CanInv(other.first))
                    {
                        return new HyperDual<TInner, TPrimitive>(Div(second, other.second));
                    }
                    return new HyperDual<TInner, TPrimitive>(Div(first, other.first), Div(Sub(Mul(second, other.first), Mul(first, other.second)), Pow2(other.first)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TPrimitive>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TPrimitive>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TPrimitive>(AddVal(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(SubVal(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(MulVal(first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TPrimitive>(DivVal(first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    var exp = Std<TInner, TPrimitive>(Dec(Create<TInner, TPrimitive>(other)));
                    return new HyperDual<TInner, TPrimitive>(PowVal(first, other), Mul(MulVal(PowVal(first, exp), other), second));
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperDual<TInner, TPrimitive>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDual<TInner, TPrimitive>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperDual<TInner, TPrimitive>(Dec(first), second);
                case UnaryOperation.Inverse:
                    return new HyperDual<TInner, TPrimitive>(Inv(first), Div(Neg(second), Pow2(first)));
                case UnaryOperation.Conjugate:
                    return new HyperDual<TInner, TPrimitive>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Pow2(first));
                case UnaryOperation.Double:
                    return new HyperDual<TInner, TPrimitive>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDual<TInner, TPrimitive>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDual<TInner, TPrimitive>(Pow2(first), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    var sqrt = Sqrt(first);
                    return new HyperDual<TInner, TPrimitive>(sqrt, Div(second, Mul2(sqrt)));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperDual<TInner, TPrimitive>(exp, Mul(exp, second));
                case UnaryOperation.Logarithm:
                    return new HyperDual<TInner, TPrimitive>(Log(first), Div(second, first));
                case UnaryOperation.Sine:
                    return new HyperDual<TInner, TPrimitive>(Sin(first), Mul(Cos(first), second));
                case UnaryOperation.Cosine:
                    return new HyperDual<TInner, TPrimitive>(Cos(first), Mul(Neg(Sin(first)), second));
                case UnaryOperation.Tangent:
                    return new HyperDual<TInner, TPrimitive>(Tan(first), Div(second, Pow2(Cos(first))));
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    return new HyperDual<TInner, TPrimitive>(Asin(first), Div(second, Sqrt(Inc(Neg(Pow2(first))))));
                case UnaryOperation.ArcCosine:
                    return new HyperDual<TInner, TPrimitive>(Acos(first), Neg(Div(second, Sqrt(Inc(Neg(Pow2(first)))))));
                case UnaryOperation.ArcTangent:
                    return new HyperDual<TInner, TPrimitive>(Atan(first), Div(second, Inc(Pow2(first))));
                default:
                    throw new NotSupportedException();
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.AbsoluteValue:
                    return Abs<TInner, TPrimitive>(first);
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(first);
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperDual<TInner, TPrimitive> value && Equals(in value);
        }
    }
}
