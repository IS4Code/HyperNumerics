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

        public HyperSplitComplex<TInner> Call(BinaryOperation operation, in HyperSplitComplex<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Add(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(other.first), Pow2(other.second));
                    return new HyperSplitComplex<TInner>(Div(Sub(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner> CallReversed(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(other, first), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(other, first), Neg(second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Mul(other, first), Mul(other, second));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner>(Div(Mul(other, first), denom), Div(Neg(Mul(other, second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(other, this);
                case BinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Identity:
                    return this;
                case UnaryOperation.Negate:
                    return new HyperSplitComplex<TInner>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperSplitComplex<TInner>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner>(Dec(first), second);
                case UnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner>(Div(first, denom), Div(Neg(second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperSplitComplex<TInner>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperSplitComplex<TInner>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperSplitComplex<TInner>(Add(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    return SqrtDefault(this);
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperSplitComplex<TInner>(Mul(Cosh(second), exp), Mul(Sinh(second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner>(Div2(Log(Mul(Add(first, second), Sub(first, second)))), Div2(Log(Div(Add(first, second), Sub(first, second)))));
                case UnaryOperation.Sine:
                    throw new NotImplementedException();
                case UnaryOperation.Cosine:
                    throw new NotImplementedException();
                case UnaryOperation.Tangent:
                    throw new NotImplementedException();
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    throw new NotImplementedException();
                case UnaryOperation.ArcCosine:
                    throw new NotImplementedException();
                case UnaryOperation.ArcTangent:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException();
            }
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

        public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TComponent> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(Add(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(other.first), Pow2(other.second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(Sub(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TComponent>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> CallReversed(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(Add(other, first), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(Sub(other, first), Neg(second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(Mul(other, first), Mul(other, second));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(Mul(other, first), denom), Div(Neg(Mul(other, second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(other, this);
                case BinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(AddVal(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(SubVal(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(MulVal(first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TComponent>(DivVal(first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    return PowValDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> CallReversed(BinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TComponent>(AddValRev(other, first), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TComponent>(SubValRev(other, first), Neg(second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TComponent>(MulValRev(other, first), MulValRev(other, second));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(MulValRev(other, first), denom), Div(Neg(MulValRev(other, second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(Operations.Instance.Create(other, default, default, default), this);
                case BinaryOperation.Atan2:
                    return Atan2Default(Operations.Instance.Create(other, default, default, default), this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TComponent> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Identity:
                    return this;
                case UnaryOperation.Negate:
                    return new HyperSplitComplex<TInner, TComponent>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperSplitComplex<TInner, TComponent>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner, TComponent>(Dec(first), second);
                case UnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TComponent>(Div(first, denom), Div(Neg(second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner, TComponent>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperSplitComplex<TInner, TComponent>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperSplitComplex<TInner, TComponent>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperSplitComplex<TInner, TComponent>(Add(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    throw new NotImplementedException();
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperSplitComplex<TInner, TComponent>(Mul(Cosh(second), exp), Mul(Sinh(second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner, TComponent>(Div2(Log(Mul(Add(first, second), Sub(first, second)))), Div2(Log(Div(Add(first, second), Sub(first, second)))));
                case UnaryOperation.Sine:
                    throw new NotImplementedException();
                case UnaryOperation.Cosine:
                    throw new NotImplementedException();
                case UnaryOperation.Tangent:
                    throw new NotImplementedException();
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    throw new NotImplementedException();
                case UnaryOperation.ArcCosine:
                    throw new NotImplementedException();
                case UnaryOperation.ArcTangent:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException();
            }
        }

        public TComponent CallComponent(UnaryOperation operation)
        {
            return Sqrt(Sub(Pow2(first), Pow2(second))).CallComponent(operation);
        }

        public override bool Equals(object other)
        {
            return other is HyperSplitComplex<TInner, TComponent> value && Equals(in value);
        }
    }
}
