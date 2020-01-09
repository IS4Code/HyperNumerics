using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a complex number formed from two values of type <typeparamref name="TInner"/>.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <remarks>
    /// A complex number (a, b) can be represented algebraically as a + bi, where i^2 = -1.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperComplex<TInner> where TInner : struct, INumber<TInner>
    {
        public bool IsInvertible => CanInv(first) || CanInv(second);

        public bool IsFinite => IsFin(first) && IsFin(second);

        public TInner Magnitude()
        {
            return Sqrt(Add(Pow2(first), Pow2(second)));
        }

        public TInner Argument()
        {
            if(IsInvertible)
            {
                return Atan2(second, first);
            }
            return HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex<TInner> Call(BinaryOperation operation, in HyperComplex<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Sub(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperComplex<TInner>(Div(Add(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperComplex<TInner>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperComplex<TInner>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperComplex<TInner>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperComplex<TInner>(Dec(first), second);
                case UnaryOperation.Inverse:
                {
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner>(Div(first, denom), Div(Neg(second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperComplex<TInner>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperComplex<TInner>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperComplex<TInner>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperComplex<TInner>(Sub(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    var mag = Sqrt(Magnitude());
                    var arg = Div2(Argument());
                    return new HyperComplex<TInner>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperComplex<TInner>(Mul(Cos(second), exp), Mul(Sin(second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperComplex<TInner>(Log(Magnitude()), Argument());
                case UnaryOperation.Sine:
                    return new HyperComplex<TInner>(Mul(Sin(first), Cosh(second)), Mul(Cos(first), Sinh(second)));
                case UnaryOperation.Cosine:
                    return new HyperComplex<TInner>(Mul(Cos(first), Sinh(second)), Neg(Mul(Sin(first), Sinh(second))));
                case UnaryOperation.Tangent:
                {
                    var denom = Add(Cos(Mul2(first)), Cosh(Mul2(second)));
                    return new HyperComplex<TInner>(Div(Sin(Mul2(first)), denom), Div(Sinh(Mul2(second)), denom));
                }
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                {
                    var result = new HyperComplex<TInner>(Neg(second), first);
                    result = Log(Add(result, Sqrt(Inc(Neg(Pow2(this))))));
                    return new HyperComplex<TInner>(result.second, Neg(result.first));
                }
                case UnaryOperation.ArcCosine:
                {
                    var result = Log(Add(this, Sqrt(Dec(Pow2(this)))));
                    return new HyperComplex<TInner>(result.second, Neg(result.first));
                }
                case UnaryOperation.ArcTangent:
                {
                    var result = Div2(Log(Div(new HyperComplex<TInner>(first, Inc(second)), new HyperComplex<TInner>(Neg(first), Inc(Neg(second))))));
                    return new HyperComplex<TInner>(Neg(result.second), result.first);
                }
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperComplex<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a complex number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TPrimitive"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// A complex number (a, b) can be represented algebraically as a + bi, where i^2 = -1.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperComplex<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public bool IsInvertible => CanInv(first) || CanInv(second);

        public bool IsFinite => IsFin(first) && IsFin(second);

        public TInner Magnitude()
        {
            return Sqrt(Add(Pow2(first), Pow2(second)));
        }

        public TInner Argument()
        {
            if(IsInvertible)
            {
                return Atan2(second, first);
            }
            return HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner, TPrimitive>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner, TPrimitive>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner, TPrimitive>(Sub(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperComplex<TInner, TPrimitive>(Div(Add(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner, TPrimitive>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner, TPrimitive>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner, TPrimitive>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperComplex<TInner, TPrimitive>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner, TPrimitive>(AddVal(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner, TPrimitive>(SubVal(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner, TPrimitive>(MulVal(first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperComplex<TInner, TPrimitive>(DivVal(first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    var mag = PowVal(Magnitude(), other);
                    var arg = MulVal(Argument(), other);
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperComplex<TInner, TPrimitive>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperComplex<TInner, TPrimitive>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperComplex<TInner, TPrimitive>(Dec(first), second);
                case UnaryOperation.Inverse:
                {
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner, TPrimitive>(Div(first, denom), Div(Neg(second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperComplex<TInner, TPrimitive>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperComplex<TInner, TPrimitive>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperComplex<TInner, TPrimitive>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperComplex<TInner, TPrimitive>(Sub(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    var mag = Sqrt(Magnitude());
                    var arg = Div2(Argument());
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(second), exp), Mul(Sin(second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperComplex<TInner, TPrimitive>(Log(Magnitude()), Argument());
                case UnaryOperation.Sine:
                    return new HyperComplex<TInner, TPrimitive>(Mul(Sin(first), Cosh(second)), Mul(Cos(first), Sinh(second)));
                case UnaryOperation.Cosine:
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(first), Sinh(second)), Neg(Mul(Sin(first), Sinh(second))));
                case UnaryOperation.Tangent:
                {
                    var denom = Add(Cos(Mul2(first)), Cosh(Mul2(second)));
                    return new HyperComplex<TInner, TPrimitive>(Div(Sin(Mul2(first)), denom), Div(Sinh(Mul2(second)), denom));
                }
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                {
                    var result = new HyperComplex<TInner, TPrimitive>(Neg(second), first);
                    result = Log(Add(result, Sqrt(Inc(Neg(Pow2(this))))));
                    return new HyperComplex<TInner, TPrimitive>(result.second, Neg(result.first));
                }
                case UnaryOperation.ArcCosine:
                {
                    var result = Log(Add(this, Sqrt(Dec(Pow2(this)))));
                    return new HyperComplex<TInner, TPrimitive>(result.second, Neg(result.first));
                }
                case UnaryOperation.ArcTangent:
                {
                    var result = Div2(Log(Div(new HyperComplex<TInner, TPrimitive>(first, Inc(second)), new HyperComplex<TInner, TPrimitive>(Neg(first), Inc(Neg(second))))));
                    return new HyperComplex<TInner, TPrimitive>(Neg(result.second), result.first);
                }
                default:
                    throw new NotSupportedException();
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.AbsoluteValue:
                    return Abs<TInner, TPrimitive>(Magnitude());
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(first);
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperComplex<TInner, TPrimitive> value && Equals(in value);
        }
    }
}
