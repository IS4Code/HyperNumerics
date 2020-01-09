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

        public HyperSplitComplex<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
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
    /// This version should be used if <typeparamref name="TPrimitive"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// A split-complex number (a, b) can be represented algebraically as a + bj, where j^2 = 1.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperSplitComplex<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public bool IsInvertible => CanInv(Sub(Pow2(first), Pow2(second)));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TPrimitive>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(Mul(first, other.first), Mul(second, other.second)), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(other.first), Pow2(other.second));
                    return new HyperSplitComplex<TInner, TPrimitive>(Div(Sub(Mul(first, other.first), Mul(second, other.second)), denom), Div(Sub(Mul(second, other.first), Mul(first, other.second)), denom));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TPrimitive>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TPrimitive>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TPrimitive>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TPrimitive>(AddVal(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TPrimitive>(SubVal(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TPrimitive>(MulVal(first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TPrimitive>(DivVal(first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    return PowValDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }
        
        public HyperSplitComplex<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperSplitComplex<TInner, TPrimitive>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperSplitComplex<TInner, TPrimitive>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner, TPrimitive>(Dec(first), second);
                case UnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(first), Pow2(second));
                    return new HyperSplitComplex<TInner, TPrimitive>(Div(first, denom), Div(Neg(second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner, TPrimitive>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperSplitComplex<TInner, TPrimitive>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperSplitComplex<TInner, TPrimitive>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(Pow2(first), Pow2(second)), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    throw new NotImplementedException();
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperSplitComplex<TInner, TPrimitive>(Mul(Cosh(second), exp), Mul(Sinh(second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner, TPrimitive>(Div2(Log(Mul(Add(first, second), Sub(first, second)))), Div2(Log(Div(Add(first, second), Sub(first, second)))));
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

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.AbsoluteValue:
                    return Abs<TInner, TPrimitive>(Sqrt(Sub(Pow2(first), Pow2(second))));
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(first);
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object other)
        {
            return other is HyperSplitComplex<TInner, TPrimitive> value && Equals(in value);
        }
    }
}
