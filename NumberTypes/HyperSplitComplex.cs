using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a split-complex number formed from two values of type <typeparamref name="TInner"/>.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <remarks>
    /// A split-complex number (a, b) can be represented algebraically as a + bi, where j^2 = 1.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperSplitComplex<TInner> where TInner : struct, INumber<TInner>
    {
        public bool IsInvertible => CanInv(Sub(Pow2(first), Pow2(second)));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public TInner Magnitude()
        {
            return Sqrt(Sub(Pow2(first), Pow2(second)));
        }

        public HyperSplitComplex<TInner> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner> other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(first, other.first), Add(second, other.second));
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(first, other.first), Sub(second, other.second));
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Add(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case StandardBinaryOperation.Divide:
                    var denom = Sub(Pow2(other.first), Pow2(other.second));
                    return new HyperSplitComplex<TInner>(Div(Sub(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner> Call(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Mul(first, other), Mul(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperSplitComplex<TInner>(Div(first, other), Div(second, other));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Mul(other, first), Mul(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner>(Div(Mul(other, first), denom), Div(Neg(Mul(other, second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(other, this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner> Call(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new HyperSplitComplex<TInner>(Neg(first), Neg(second));
                case StandardUnaryOperation.Increment:
                    return new HyperSplitComplex<TInner>(Inc(first), second);
                case StandardUnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner>(Dec(first), second);
                case StandardUnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner>(Div(first, denom), Div(Neg(second), denom));
                }
                case StandardUnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner>(first, Neg(second));
                case StandardUnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case StandardUnaryOperation.Double:
                    return new HyperSplitComplex<TInner>(Mul2(first), Mul2(second));
                case StandardUnaryOperation.Half:
                    return new HyperSplitComplex<TInner>(Div2(first), Div2(second));
                case StandardUnaryOperation.Square:
                    return new HyperSplitComplex<TInner>(Add(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case StandardUnaryOperation.SquareRoot:
                    return SqrtDefault(this);
                case StandardUnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperSplitComplex<TInner>(Mul(Cosh(second), exp), Mul(Sinh(second), exp));
                case StandardUnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner>(Div2(Log(Mul(Add(first, second), Sub(first, second)))), Div2(Log(Div(Add(first, second), Sub(first, second)))));
                case StandardUnaryOperation.Sine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.Cosine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.Tangent:
                    throw new NotImplementedException();
                case StandardUnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case StandardUnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case StandardUnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case StandardUnaryOperation.ArcSine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.ArcCosine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.ArcTangent:
                    throw new NotImplementedException();
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
            return other is HyperSplitComplex<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a split-complex number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TComponent"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    /// <remarks>
    /// A split-complex number (a, b) can be represented algebraically as a + bj, where j^2 = 1.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperSplitComplex<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        public bool IsInvertible => CanInv(Sub(Pow2(first), Pow2(second)));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public TInner Magnitude()
        {
            return Sqrt(Sub(Pow2(first), Pow2(second)));
        }

        public HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner, TComponent> other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(Add(first, other.first), Add(second, other.second));
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(Sub(first, other.first), Sub(second, other.second));
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(Add(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case StandardBinaryOperation.Divide:
                    var denom = Sub(Pow2(other.first), Pow2(other.second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(Sub(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(Add(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(Sub(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(Mul(first, other), Mul(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TComponent>(Div(first, other), Div(second, other));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(Add(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(Sub(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(Mul(other, first), Mul(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(Mul(other, first), denom), Div(Neg(Mul(other, second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(other, this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(AddVal(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(SubVal(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(MulVal(first, other), MulVal(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TComponent>(DivVal(first, other), DivVal(second, other));
                case StandardBinaryOperation.Power:
                    return PowValDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(AddValRev(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(SubValRev(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(MulValRev(other, first), MulValRev(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(MulValRev(other, first), denom), Div(Neg(MulValRev(other, second)), denom));
                case StandardBinaryOperation.Power:
                    return PowDefault(Operations.Instance.Create(other, default, default, default), this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(Operations.Instance.Create(other, default, default, default), this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> Call(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new HyperSplitComplex<TInner, TComponent>(Neg(first), Neg(second));
                case StandardUnaryOperation.Increment:
                    return new HyperSplitComplex<TInner, TComponent>(Inc(first), second);
                case StandardUnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner, TComponent>(Dec(first), second);
                case StandardUnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(first, denom), Div(Neg(second), denom));
                }
                case StandardUnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner, TComponent>(first, Neg(second));
                case StandardUnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case StandardUnaryOperation.Double:
                    return new HyperSplitComplex<TInner, TComponent>(Mul2(first), Mul2(second));
                case StandardUnaryOperation.Half:
                    return new HyperSplitComplex<TInner, TComponent>(Div2(first), Div2(second));
                case StandardUnaryOperation.Square:
                    return new HyperSplitComplex<TInner, TComponent>(Add(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case StandardUnaryOperation.SquareRoot:
                    throw new NotImplementedException();
                case StandardUnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperSplitComplex<TInner, TComponent>(Mul(Cosh(second), exp), Mul(Sinh(second), exp));
                case StandardUnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner, TComponent>(Div2(Log(Mul(Add(first, second), Sub(first, second)))), Div2(Log(Div(Add(first, second), Sub(first, second)))));
                case StandardUnaryOperation.Sine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.Cosine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.Tangent:
                    throw new NotImplementedException();
                case StandardUnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case StandardUnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case StandardUnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case StandardUnaryOperation.ArcSine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.ArcCosine:
                    throw new NotImplementedException();
                case StandardUnaryOperation.ArcTangent:
                    throw new NotImplementedException();
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
            return other is HyperSplitComplex<TInner, TComponent> value && Equals(in value);
        }
    }
}
