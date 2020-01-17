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
            return HyperMath.Create<TInner>(StandardNumber.Zero);
        }

        public HyperComplex<TInner> Call(StandardBinaryOperation operation, in HyperComplex<TInner> other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner>(Add(first, other.first), Add(second, other.second));
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(first, other.first), Sub(second, other.second));
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Sub(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperComplex<TInner>(Div(Add(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner> Call(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner>(Add(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Mul(first, other), Mul(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperComplex<TInner>(Div(first, other), Div(second, other));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner>(Add(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Mul(other, first), Mul(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner>(Div(Mul(other, first), denom), Div(Neg(Mul(other, second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(other, this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner> Call(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new HyperComplex<TInner>(Neg(first), Neg(second));
                case StandardUnaryOperation.Increment:
                    return new HyperComplex<TInner>(Inc(first), second);
                case StandardUnaryOperation.Decrement:
                    return new HyperComplex<TInner>(Dec(first), second);
                case StandardUnaryOperation.Inverse:
                {
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner>(Div(first, denom), Div(Neg(second), denom));
                }
                case StandardUnaryOperation.Conjugate:
                    return new HyperComplex<TInner>(first, Neg(second));
                case StandardUnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case StandardUnaryOperation.Double:
                    return new HyperComplex<TInner>(Mul2(first), Mul2(second));
                case StandardUnaryOperation.Half:
                    return new HyperComplex<TInner>(Div2(first), Div2(second));
                case StandardUnaryOperation.Square:
                    return new HyperComplex<TInner>(Sub(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case StandardUnaryOperation.SquareRoot:
                    var mag = Sqrt(Magnitude());
                    var arg = Div2(Argument());
                    return new HyperComplex<TInner>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case StandardUnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperComplex<TInner>(Mul(Cos(second), exp), Mul(Sin(second), exp));
                case StandardUnaryOperation.Logarithm:
                    return new HyperComplex<TInner>(Log(Magnitude()), Argument());
                case StandardUnaryOperation.Sine:
                    return new HyperComplex<TInner>(Mul(Sin(first), Cosh(second)), Mul(Cos(first), Sinh(second)));
                case StandardUnaryOperation.Cosine:
                    return new HyperComplex<TInner>(Mul(Cos(first), Sinh(second)), Neg(Mul(Sin(first), Sinh(second))));
                case StandardUnaryOperation.Tangent:
                {
                    var denom = Add(Cos(Mul2(first)), Cosh(Mul2(second)));
                    return new HyperComplex<TInner>(Div(Sin(Mul2(first)), denom), Div(Sinh(Mul2(second)), denom));
                }
                case StandardUnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case StandardUnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case StandardUnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case StandardUnaryOperation.ArcSine:
                {
                    var result = new HyperComplex<TInner>(Neg(second), first);
                    result = Log(Add(result, Sqrt(Inc(Neg(Pow2(this))))));
                    return new HyperComplex<TInner>(result.second, Neg(result.first));
                }
                case StandardUnaryOperation.ArcCosine:
                {
                    var result = Log(Add(this, Sqrt(Dec(Pow2(this)))));
                    return new HyperComplex<TInner>(result.second, Neg(result.first));
                }
                case StandardUnaryOperation.ArcTangent:
                {
                    var result = Div2(Log(Div(new HyperComplex<TInner>(first, Inc(second)), new HyperComplex<TInner>(Neg(first), Inc(Neg(second))))));
                    return new HyperComplex<TInner>(Neg(result.second), result.first);
                }
                default:
                    throw new NotSupportedException();
            }
        }

        public TInner CallComponent(StandardUnaryOperation operation)
        {
            return Magnitude().Call(operation);
        }

        public override bool Equals(object other)
        {
            return other is HyperComplex<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a complex number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TComponent"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    /// <remarks>
    /// A complex number (a, b) can be represented algebraically as a + bi, where i^2 = -1.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperComplex<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
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
            return HyperMath.Create<TInner>(StandardNumber.Zero);
        }

        public HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperComplex<TInner, TComponent> other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner, TComponent>(Add(first, other.first), Add(second, other.second));
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner, TComponent>(Sub(first, other.first), Sub(second, other.second));
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner, TComponent>(Sub(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperComplex<TInner, TComponent>(Div(Add(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner, TComponent>(Add(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner, TComponent>(Sub(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner, TComponent>(Mul(first, other), Mul(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperComplex<TInner, TComponent>(Div(first, other), Div(second, other));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner, TComponent>(Add(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner, TComponent>(Sub(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner, TComponent>(Mul(other, first), Mul(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner, TComponent>(Div(Mul(other, first), denom), Div(Neg(Mul(other, second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(other, this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner, TComponent>(AddVal(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner, TComponent>(SubVal(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner, TComponent>(MulVal(first, other), MulVal(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperComplex<TInner, TComponent>(DivVal(first, other), DivVal(second, other));
                case StandardBinaryOperation.Power:
                    var mag = PowVal(Magnitude(), other);
                    var arg = MulVal(Argument(), other);
                    return new HyperComplex<TInner, TComponent>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperComplex<TInner, TComponent>(AddValRev(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperComplex<TInner, TComponent>(SubValRev(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperComplex<TInner, TComponent>(MulValRev(other, first), MulValRev(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner, TComponent>(Div(MulValRev(other, first), denom), Div(Neg(MulValRev(other, second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(Operations.Instance.Create(other, default, default, default), this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(Operations.Instance.Create(other, default, default, default), this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TComponent> Call(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new HyperComplex<TInner, TComponent>(Neg(first), Neg(second));
                case StandardUnaryOperation.Increment:
                    return new HyperComplex<TInner, TComponent>(Inc(first), second);
                case StandardUnaryOperation.Decrement:
                    return new HyperComplex<TInner, TComponent>(Dec(first), second);
                case StandardUnaryOperation.Inverse:
                {
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperComplex<TInner, TComponent>(Div(first, denom), Div(Neg(second), denom));
                }
                case StandardUnaryOperation.Conjugate:
                    return new HyperComplex<TInner, TComponent>(first, Neg(second));
                case StandardUnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case StandardUnaryOperation.Double:
                    return new HyperComplex<TInner, TComponent>(Mul2(first), Mul2(second));
                case StandardUnaryOperation.Half:
                    return new HyperComplex<TInner, TComponent>(Div2(first), Div2(second));
                case StandardUnaryOperation.Square:
                    return new HyperComplex<TInner, TComponent>(Sub(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case StandardUnaryOperation.SquareRoot:
                    var mag = Sqrt(Magnitude());
                    var arg = Div2(Argument());
                    return new HyperComplex<TInner, TComponent>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case StandardUnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperComplex<TInner, TComponent>(Mul(Cos(second), exp), Mul(Sin(second), exp));
                case StandardUnaryOperation.Logarithm:
                    return new HyperComplex<TInner, TComponent>(Log(Magnitude()), Argument());
                case StandardUnaryOperation.Sine:
                    return new HyperComplex<TInner, TComponent>(Mul(Sin(first), Cosh(second)), Mul(Cos(first), Sinh(second)));
                case StandardUnaryOperation.Cosine:
                    return new HyperComplex<TInner, TComponent>(Mul(Cos(first), Sinh(second)), Neg(Mul(Sin(first), Sinh(second))));
                case StandardUnaryOperation.Tangent:
                {
                    var denom = Add(Cos(Mul2(first)), Cosh(Mul2(second)));
                    return new HyperComplex<TInner, TComponent>(Div(Sin(Mul2(first)), denom), Div(Sinh(Mul2(second)), denom));
                }
                case StandardUnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case StandardUnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case StandardUnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case StandardUnaryOperation.ArcSine:
                {
                    var result = new HyperComplex<TInner, TComponent>(Neg(second), first);
                    result = Log(Add(result, Sqrt(Inc(Neg(Pow2(this))))));
                    return new HyperComplex<TInner, TComponent>(result.second, Neg(result.first));
                }
                case StandardUnaryOperation.ArcCosine:
                {
                    var result = Log(Add(this, Sqrt(Dec(Pow2(this)))));
                    return new HyperComplex<TInner, TComponent>(result.second, Neg(result.first));
                }
                case StandardUnaryOperation.ArcTangent:
                {
                    var result = Div2(Log(Div(new HyperComplex<TInner, TComponent>(first, Inc(second)), new HyperComplex<TInner, TComponent>(Neg(first), Inc(Neg(second))))));
                    return new HyperComplex<TInner, TComponent>(Neg(result.second), result.first);
                }
                default:
                    throw new NotSupportedException();
            }
        }

        public TComponent CallComponent(StandardUnaryOperation operation)
        {
            return Magnitude().CallComponent(operation);
        }

        public override bool Equals(object other)
        {
            return other is HyperComplex<TInner, TComponent> value && Equals(in value);
        }
    }
}
