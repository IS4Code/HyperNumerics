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
    public readonly struct HyperSplitComplex<TInner> : IHyperNumber<HyperSplitComplex<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(Sub(Pow2(first), Pow2(second)));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperSplitComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperSplitComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperSplitComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperSplitComplex<TInner> Clone()
        {
            return new HyperSplitComplex<TInner>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner> WithFirst(in TInner first)
        {
            return new HyperSplitComplex<TInner>(first, second);
        }

        public HyperSplitComplex<TInner> WithSecond(in TInner second)
        {
            return new HyperSplitComplex<TInner>(first, second);
        }

        public static implicit operator HyperSplitComplex<TInner>(TInner first)
        {
            return new HyperSplitComplex<TInner>(first);
        }

        public static implicit operator HyperSplitComplex<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner>(tuple);
        }

        public static implicit operator (TInner first, TInner second)(HyperSplitComplex<TInner> value)
        {
            return (value.first, value.second);
        }

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

        public HyperSplitComplex<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperSplitComplex<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner>(first, HyperMath.Call(operation, second, other));
        }

        public HyperSplitComplex<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperSplitComplex<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner>(first, HyperMath.Call(operation, second));
        }

        public override bool Equals(object other)
        {
            return other is HyperSplitComplex<TInner> value && Equals(in value);
        }

        public bool Equals(HyperSplitComplex<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperSplitComplex<TInner> other)
        {
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperSplitComplex<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperSplitComplex<TInner> other)
        {
            int value = first.CompareTo(other.first);
            return value != 0 ? value : second.CompareTo(other.second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "SplitComplex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "SplitComplex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperSplitComplex<TInner>> INumber<HyperSplitComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperSplitComplex<TInner>, TInner> IExtendedNumber<HyperSplitComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperSplitComplex<TInner>, TInner> IHyperNumber<HyperSplitComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperSplitComplex<TInner>>, IHyperNumberOperations<HyperSplitComplex<TInner>, TInner>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperSplitComplex<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperSplitComplex<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperSplitComplex<TInner> Clone(in HyperSplitComplex<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperSplitComplex<TInner> num1, HyperSplitComplex<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(HyperSplitComplex<TInner> num1, HyperSplitComplex<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(HyperSplitComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperSplitComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public HyperSplitComplex<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperSplitComplex<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperSplitComplex<TInner> Call(UnaryOperation operation, in HyperSplitComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner> Call(BinaryOperation operation, in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner> Call(BinaryOperation operation, in HyperSplitComplex<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner>(num);
            }

            public HyperSplitComplex<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperSplitComplex<TInner>(first, second);
            }
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
    public readonly struct HyperSplitComplex<TInner, TPrimitive> : IHyperNumber<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(Sub(Pow2(first), Pow2(second)));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperSplitComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperSplitComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperSplitComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperSplitComplex<TInner, TPrimitive> Clone()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, second);
        }

        public HyperSplitComplex<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>(TInner first)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(tuple);
        }

        public static implicit operator (TInner first, TInner second)(HyperSplitComplex<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }
        
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

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
        }

        public override bool Equals(object other)
        {
            return other is HyperSplitComplex<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(HyperSplitComplex<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperSplitComplex<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            int value = first.CompareTo(other.first);
            return value != 0 ? value : second.CompareTo(other.second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "SplitComplex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "SplitComplex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperSplitComplex<TInner, TPrimitive>> INumber<HyperSplitComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperSplitComplex<TInner, TPrimitive>, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner> IHyperNumber<HyperSplitComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperSplitComplex<TInner, TPrimitive>>, IHyperNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperSplitComplex<TInner, TPrimitive> Clone(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperSplitComplex<TInner, TPrimitive> num1, HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(HyperSplitComplex<TInner, TPrimitive> num1, HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in HyperSplitComplex<TInner, TPrimitive> num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in HyperSplitComplex<TInner, TPrimitive> num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(UnaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(num);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(first, second);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                var first = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                var second = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                return new HyperSplitComplex<TInner, TPrimitive>(first, second);
            }
        }

        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TPrimitive>
        {
            return value.Count;
        }

        static TPrimitive GetListItem<T>(in T value, int index) where T : struct, IList<TPrimitive>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TPrimitive>
        {
            return value.Count;
        }

        static TPrimitive GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TPrimitive>
        {
            return value[index];
        }

        int ICollection<TPrimitive>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetReadOnlyCollectionCount(first);
                if(index >= offset)
                {
                    return GetReadOnlyListItem(second, index - offset);
                }
                return GetReadOnlyListItem(first, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetCollectionCount(first);
                if(index >= offset)
                {
                    return GetListItem(second, index - offset);
                }
                return GetListItem(first, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
        }

        void IList<TPrimitive>.Insert(int index, TPrimitive item)
        {
            throw new NotSupportedException();
        }

        void IList<TPrimitive>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TPrimitive>.Add(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TPrimitive>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TPrimitive>.Contains(TPrimitive item)
        {
            return first.Contains(item) || second.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            first.CopyTo(array, arrayIndex);
            int offset = GetCollectionCount(first);
            second.CopyTo(array, offset + arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach(var num in (IEnumerable)first)
            {
                yield return num;
            }
            foreach(var num in (IEnumerable)second)
            {
                yield return num;
            }
        }
    }
}
