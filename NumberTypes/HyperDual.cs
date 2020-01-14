using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public HyperDual<TInner> CallReversed(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner>(Add(other, first), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner>(Sub(other, first), Neg(second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner>(Mul(other, first), Mul(other, second));
                case BinaryOperation.Divide:
                    if(!CanInv(other) && !CanInv(first))
                    {
                        return Div(HyperMath.Operations.For<TInner>.Instance.Call(NullaryOperation.Zero), second);
                    }
                    return new HyperDual<TInner>(Div(other, first), Div(Neg(Mul(other, second)), Pow2(first)));
                case BinaryOperation.Power:
                    return PowDefault(other, this);
                case BinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Identity:
                    return this;
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
                    if(!CanInv(sqrt) && !CanInv(second))
                    {
                        return new HyperDual<TInner>(sqrt);
                    }
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

        public TInner CallComponent(UnaryOperation operation)
        {
            return HyperMath.Call(operation, first);
        }

        public override bool Equals(object other)
        {
            return other is HyperDual<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a dual number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TComponent"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    /// <remarks>
    /// A dual number (a, b) can be represented algebraically as a + bε, where ε^2 = 0.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDual<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        public bool IsInvertible => CanInv(first);

        public bool IsFinite => IsFin(first);

        public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in HyperDual<TInner, TComponent> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TComponent>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TComponent>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TComponent>(Mul(first, other.first), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    if(!CanInv(first) && !CanInv(other.first))
                    {
                        return new HyperDual<TInner, TComponent>(Div(second, other.second));
                    }
                    return new HyperDual<TInner, TComponent>(Div(first, other.first), Div(Sub(Mul(second, other.first), Mul(first, other.second)), Pow2(other.first)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TComponent>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TComponent>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TComponent>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TComponent>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TComponent> CallReversed(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TComponent>(Add(other, first), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TComponent>(Sub(other, first), Neg(second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TComponent>(Mul(other, first), Mul(other, second));
                case BinaryOperation.Divide:
                    if(!CanInv(other) && !CanInv(first))
                    {
                        return Div(HyperMath.Operations.For<TInner>.Instance.Call(NullaryOperation.Zero), second);
                    }
                    return new HyperDual<TInner, TComponent>(Div(other, first), Div(Neg(Mul(other, second)), Pow2(first)));
                case BinaryOperation.Power:
                    return PowDefault(other, this);
                case BinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TComponent>(AddVal(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TComponent>(SubVal(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TComponent>(MulVal(first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TComponent>(DivVal(first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    var exp = Dec(Create<TInner, TComponent>(other)).First();
                    return new HyperDual<TInner, TComponent>(PowVal(first, other), Mul(MulVal(PowVal(first, exp), other), second));
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TComponent> CallReversed(BinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TComponent>(AddValRev(other, first), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TComponent>(SubValRev(other, first), Neg(second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TComponent>(MulValRev(other, first), MulValRev(other, second));
                case BinaryOperation.Divide:
                    bool caninv = other is INumber num ? num.IsInvertible : !other.Equals(default);
                    if(!caninv && !CanInv(first))
                    {
                        return Div(HyperMath.Operations.For<TInner>.Instance.Call(NullaryOperation.Zero), second);
                    }
                    return new HyperDual<TInner, TComponent>(DivValRev(other, first), Div(Neg(MulValRev(other, second)), Pow2(first)));
                case BinaryOperation.Power:
                    return PowDefault(Operations.Instance.Create(other, default, default, default), this);
                case BinaryOperation.Atan2:
                    return Atan2Default(Operations.Instance.Create(other, default, default, default), this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TComponent> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Identity:
                    return this;
                case UnaryOperation.Negate:
                    return new HyperDual<TInner, TComponent>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDual<TInner, TComponent>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperDual<TInner, TComponent>(Dec(first), second);
                case UnaryOperation.Inverse:
                    return new HyperDual<TInner, TComponent>(Inv(first), Div(Neg(second), Pow2(first)));
                case UnaryOperation.Conjugate:
                    return new HyperDual<TInner, TComponent>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Pow2(first));
                case UnaryOperation.Double:
                    return new HyperDual<TInner, TComponent>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDual<TInner, TComponent>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDual<TInner, TComponent>(Pow2(first), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    var sqrt = Sqrt(first);
                    if(!CanInv(sqrt) && !CanInv(second))
                    {
                        return new HyperDual<TInner, TComponent>(sqrt);
                    }
                    return new HyperDual<TInner, TComponent>(sqrt, Div(second, Mul2(sqrt)));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperDual<TInner, TComponent>(exp, Mul(exp, second));
                case UnaryOperation.Logarithm:
                    return new HyperDual<TInner, TComponent>(Log(first), Div(second, first));
                case UnaryOperation.Sine:
                    return new HyperDual<TInner, TComponent>(Sin(first), Mul(Cos(first), second));
                case UnaryOperation.Cosine:
                    return new HyperDual<TInner, TComponent>(Cos(first), Mul(Neg(Sin(first)), second));
                case UnaryOperation.Tangent:
                    return new HyperDual<TInner, TComponent>(Tan(first), Div(second, Pow2(Cos(first))));
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    return new HyperDual<TInner, TComponent>(Asin(first), Div(second, Sqrt(Inc(Neg(Pow2(first))))));
                case UnaryOperation.ArcCosine:
                    return new HyperDual<TInner, TComponent>(Acos(first), Neg(Div(second, Sqrt(Inc(Neg(Pow2(first)))))));
                case UnaryOperation.ArcTangent:
                    return new HyperDual<TInner, TComponent>(Atan(first), Div(second, Inc(Pow2(first))));
                default:
                    throw new NotSupportedException();
            }
        }

        public TComponent CallComponent(UnaryOperation operation)
        {
            return HyperMath.CallComponent<TInner, TComponent>(operation, first);
        }

        public override bool Equals(object other)
        {
            return other is HyperDual<TInner, TComponent> value && Equals(in value);
        }
    }
}
