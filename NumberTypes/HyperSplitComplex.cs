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
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(Sub(Pow2(First), Pow2(Second)));

        public bool IsFinite => IsFin(First) && IsFin(Second);

        public HyperSplitComplex(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperSplitComplex(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperSplitComplex<TInner> Clone()
        {
            return new HyperSplitComplex<TInner>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner> WithFirst(in TInner first)
        {
            return new HyperSplitComplex<TInner>(first, Second);
        }

        public HyperSplitComplex<TInner> WithSecond(in TInner second)
        {
            return new HyperSplitComplex<TInner>(First, second);
        }

        public static implicit operator HyperSplitComplex<TInner>(in TInner first)
        {
            return new HyperSplitComplex<TInner>(first);
        }

        public static implicit operator HyperSplitComplex<TInner>(in (TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperSplitComplex<TInner> value)
        {
            return (value.First, value.Second);
        }

        public HyperSplitComplex<TInner> Call(BinaryOperation operation, in HyperSplitComplex<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Add(Mul(First, other.First), Mul(Second, other.Second)), Add(Mul(First, other.Second), Mul(Second, other.First)));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(other.First), Pow2(other.Second));
                    return new HyperSplitComplex<TInner>(Div(Sub(Mul(First, other.First), Mul(Second, other.Second)), denom), Div(Sub(Mul(Second, other.First), Mul(First, other.Second)), denom));
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
                    return new HyperSplitComplex<TInner>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner>(Div(First, other), Div(Second, other));
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
                    return new HyperSplitComplex<TInner>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperSplitComplex<TInner>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner>(Dec(First), Second);
                case UnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(First), Pow2(Second));
                    return new HyperSplitComplex<TInner>(Div(First, denom), Div(Neg(Second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperSplitComplex<TInner>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperSplitComplex<TInner>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperSplitComplex<TInner>(Add(Pow2(First), Pow2(Second)), Mul2(Mul(First, Second)));
                case UnaryOperation.SquareRoot:
                    throw new NotImplementedException();
                case UnaryOperation.Exponentiate:
                    var exp = Exp(First);
                    return new HyperSplitComplex<TInner>(Mul(Cosh(Second), exp), Mul(Sinh(Second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner>(Div2(Log(Mul(Add(First, Second), Sub(First, Second)))), Div2(Log(Div(Add(First, Second), Sub(First, Second)))));
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
            return new HyperSplitComplex<TInner>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperSplitComplex<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperSplitComplex<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner>(HyperMath.Call(operation, First), Second);
        }

        public HyperSplitComplex<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner>(First, HyperMath.Call(operation, Second));
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
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperSplitComplex<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperSplitComplex<TInner> other)
        {
            int value = First.CompareTo(other.First);
            return value != 0 ? value : Second.CompareTo(other.Second);
        }

        public override int GetHashCode()
        {
            return First.GetHashCode() * 17 + Second.GetHashCode();
        }

        public override string ToString()
        {
            return "SplitComplex(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "SplitComplex(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
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

        class Operations : NumberOperations<HyperSplitComplex<TInner>>, INumberOperations<HyperSplitComplex<TInner>>
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
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(Sub(Pow2(First), Pow2(Second)));

        public bool IsFinite => IsFin(First) && IsFin(Second);

        public HyperSplitComplex(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperSplitComplex(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperSplitComplex<TInner, TPrimitive> Clone()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, second);
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>(in TInner first)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second) (in HyperSplitComplex<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }
        
        public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TPrimitive>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(Mul(First, other.First), Mul(Second, other.Second)), Add(Mul(First, other.Second), Mul(Second, other.First)));
                case BinaryOperation.Divide:
                    var denom = Sub(Pow2(other.First), Pow2(other.Second));
                    return new HyperSplitComplex<TInner, TPrimitive>(Div(Sub(Mul(First, other.First), Mul(Second, other.Second)), denom), Div(Sub(Mul(Second, other.First), Mul(First, other.Second)), denom));
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
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TPrimitive>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TPrimitive>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TPrimitive>(Div(First, other), Div(Second, other));
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
                    return new HyperSplitComplex<TInner, TPrimitive>(AddVal(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperSplitComplex<TInner, TPrimitive>(SubVal(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperSplitComplex<TInner, TPrimitive>(MulVal(First, other), MulVal(Second, other));
                case BinaryOperation.Divide:
                    return new HyperSplitComplex<TInner, TPrimitive>(DivVal(First, other), DivVal(Second, other));
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
                    return new HyperSplitComplex<TInner, TPrimitive>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperSplitComplex<TInner, TPrimitive>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperSplitComplex<TInner, TPrimitive>(Dec(First), Second);
                case UnaryOperation.Inverse:
                {
                    var denom = Sub(Pow2(First), Pow2(Second));
                    return new HyperSplitComplex<TInner, TPrimitive>(Div(First, denom), Div(Neg(Second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperSplitComplex<TInner, TPrimitive>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperSplitComplex<TInner, TPrimitive>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperSplitComplex<TInner, TPrimitive>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperSplitComplex<TInner, TPrimitive>(Add(Pow2(First), Pow2(Second)), Mul2(Mul(First, Second)));
                case UnaryOperation.SquareRoot:
                    throw new NotImplementedException();
                case UnaryOperation.Exponentiate:
                    var exp = Exp(First);
                    return new HyperSplitComplex<TInner, TPrimitive>(Mul(Cosh(Second), exp), Mul(Sinh(Second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperSplitComplex<TInner, TPrimitive>(Div2(Log(Mul(Add(First, Second), Sub(First, Second)))), Div2(Log(Div(Add(First, Second), Sub(First, Second)))));
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
                    return Abs<TInner, TPrimitive>(Sqrt(Sub(Pow2(First), Pow2(Second))));
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(First);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, First, other), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, HyperMath.CallPrimitive(operation, Second, other));
        }

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call(operation, First), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, HyperMath.Call(operation, Second));
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
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperSplitComplex<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            int value = First.CompareTo(other.First);
            return value != 0 ? value : Second.CompareTo(other.Second);
        }

        public override int GetHashCode()
        {
            return First.GetHashCode() * 17 + Second.GetHashCode();
        }

        public override string ToString()
        {
            return "SplitComplex(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "SplitComplex(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
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

        class Operations : NumberOperations<HyperSplitComplex<TInner, TPrimitive>>, INumberOperations<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>
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

            public HyperSplitComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(First) + GetCollectionCount(Second);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(First) + GetReadOnlyCollectionCount(Second);

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetReadOnlyCollectionCount(First);
                if(index >= offset)
                {
                    return GetReadOnlyListItem(Second, index - offset);
                }
                return GetReadOnlyListItem(First, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetCollectionCount(First);
                if(index >= offset)
                {
                    return GetListItem(Second, index - offset);
                }
                return GetListItem(First, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            int index = First.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(First);
                return offset + Second.IndexOf(item);
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
            return First.Contains(item) || Second.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            First.CopyTo(array, arrayIndex);
            int offset = GetCollectionCount(First);
            Second.CopyTo(array, offset + arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            foreach(var num in First)
            {
                yield return num;
            }
            foreach(var num in Second)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach(var num in (IEnumerable)First)
            {
                yield return num;
            }
            foreach(var num in (IEnumerable)Second)
            {
                yield return num;
            }
        }
    }
}
