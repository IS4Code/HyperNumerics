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
    public readonly struct HyperDual<TInner> : IHyperNumber<HyperDual<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(First);

        public bool IsFinite => IsFin(First);

        public HyperDual(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDual(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperDual<TInner> Clone()
        {
            return new HyperDual<TInner>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner> WithFirst(in TInner first)
        {
            return new HyperDual<TInner>(first, Second);
        }

        public HyperDual<TInner> WithSecond(in TInner second)
        {
            return new HyperDual<TInner>(First, second);
        }

        public static implicit operator HyperDual<TInner>(in TInner first)
        {
            return new HyperDual<TInner>(first);
        }

        public static implicit operator HyperDual<TInner>(in (TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperDual<TInner> value)
        {
            return (value.First, value.Second);
        }

        public HyperDual<TInner> Call(BinaryOperation operation, in HyperDual<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner>(Mul(First, other.First), Add(Mul(First, other.Second), Mul(Second, other.First)));
                case BinaryOperation.Divide:
                    if(!CanInv(First) && !CanInv(other.First))
                    {
                        return new HyperDual<TInner>(Div(Second, other.Second));
                    }
                    return new HyperDual<TInner>(Div(First, other.First), Div(Sub(Mul(Second, other.First), Mul(First, other.Second)), Pow2(other.First)));
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
                    return new HyperDual<TInner>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner>(Div(First, other), Div(Second, other));
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
                    return new HyperDual<TInner>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperDual<TInner>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperDual<TInner>(Dec(First), Second);
                case UnaryOperation.Inverse:
                    return new HyperDual<TInner>(Inv(First), Div(Neg(Second), Pow2(First)));
                case UnaryOperation.Conjugate:
                    return new HyperDual<TInner>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Sqrt(Pow2(First));
                case UnaryOperation.Double:
                    return new HyperDual<TInner>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperDual<TInner>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperDual<TInner>(Pow2(First), Mul2(Mul(First, Second)));
                case UnaryOperation.SquareRoot:
                    var sqrt = Sqrt(First);
                    return new HyperDual<TInner>(sqrt, Div(Second, Mul2(sqrt)));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(First);
                    return new HyperDual<TInner>(exp, Mul(exp, Second));
                case UnaryOperation.Logarithm:
                    return new HyperDual<TInner>(Log(First), Div(Second, First));
                case UnaryOperation.Sine:
                    return new HyperDual<TInner>(Sin(First), Mul(Cos(First), Second));
                case UnaryOperation.Cosine:
                    return new HyperDual<TInner>(Cos(First), Mul(Neg(Sin(First)), Second));
                case UnaryOperation.Tangent:
                    return new HyperDual<TInner>(Tan(First), Div(Second, Pow2(Cos(First))));
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    return new HyperDual<TInner>(Asin(First), Div(Second, Sqrt(Inc(Neg(Pow2(First))))));
                case UnaryOperation.ArcCosine:
                    return new HyperDual<TInner>(Acos(First), Neg(Div(Second, Sqrt(Inc(Neg(Pow2(First)))))));
                case UnaryOperation.ArcTangent:
                    return new HyperDual<TInner>(Atan(First), Div(Second, Inc(Pow2(First))));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperDual<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperDual<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperDual<TInner>(HyperMath.Call(operation, First), Second);
        }

        public HyperDual<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperDual<TInner>(First, HyperMath.Call(operation, Second));
        }

        public override bool Equals(object other)
        {
            return other is HyperDual<TInner> value && Equals(in value);
        }

        public bool Equals(HyperDual<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperDual<TInner> other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperDual<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDual<TInner> other)
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
            return "Dual(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Dual(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDual<TInner>> INumber<HyperDual<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperDual<TInner>>, INumberOperations<HyperDual<TInner>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperDual<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDual<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperDual<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDual<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDual<TInner> Call(UnaryOperation operation, in HyperDual<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner> Call(BinaryOperation operation, in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.Call(operation, num2);
            }
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
    public readonly struct HyperDual<TInner, TPrimitive> : IHyperNumber<HyperDual<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(First);

        public bool IsFinite => IsFin(First);

        public HyperDual(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDual(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperDual<TInner, TPrimitive> Clone()
        {
            return new HyperDual<TInner, TPrimitive>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperDual<TInner, TPrimitive>(first, Second);
        }

        public HyperDual<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperDual<TInner, TPrimitive>(First, second);
        }

        public static implicit operator HyperDual<TInner, TPrimitive>(in TInner first)
        {
            return new HyperDual<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperDual<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second) (in HyperDual<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }
        
        public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TPrimitive>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(Mul(First, other.First), Add(Mul(First, other.Second), Mul(Second, other.First)));
                case BinaryOperation.Divide:
                    if(!CanInv(First) && !CanInv(other.First))
                    {
                        return new HyperDual<TInner, TPrimitive>(Div(Second, other.Second));
                    }
                    return new HyperDual<TInner, TPrimitive>(Div(First, other.First), Div(Sub(Mul(Second, other.First), Mul(First, other.Second)), Pow2(other.First)));
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
                    return new HyperDual<TInner, TPrimitive>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TPrimitive>(Div(First, other), Div(Second, other));
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
                    return new HyperDual<TInner, TPrimitive>(AddVal(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(SubVal(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(MulVal(First, other), MulVal(Second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TPrimitive>(DivVal(First, other), DivVal(Second, other));
                case BinaryOperation.Power:
                    var exp = Std<TInner, TPrimitive>(Dec(Create<TInner, TPrimitive>(other)));
                    return new HyperDual<TInner, TPrimitive>(PowVal(First, other), Mul(MulVal(PowVal(First, exp), other), Second));
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
                    return new HyperDual<TInner, TPrimitive>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperDual<TInner, TPrimitive>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperDual<TInner, TPrimitive>(Dec(First), Second);
                case UnaryOperation.Inverse:
                    return new HyperDual<TInner, TPrimitive>(Inv(First), Div(Neg(Second), Pow2(First)));
                case UnaryOperation.Conjugate:
                    return new HyperDual<TInner, TPrimitive>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Sqrt(Pow2(First));
                case UnaryOperation.Double:
                    return new HyperDual<TInner, TPrimitive>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperDual<TInner, TPrimitive>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperDual<TInner, TPrimitive>(Pow2(First), Mul2(Mul(First, Second)));
                case UnaryOperation.SquareRoot:
                    var sqrt = Sqrt(First);
                    return new HyperDual<TInner, TPrimitive>(sqrt, Div(Second, Mul2(sqrt)));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(First);
                    return new HyperDual<TInner, TPrimitive>(exp, Mul(exp, Second));
                case UnaryOperation.Logarithm:
                    return new HyperDual<TInner, TPrimitive>(Log(First), Div(Second, First));
                case UnaryOperation.Sine:
                    return new HyperDual<TInner, TPrimitive>(Sin(First), Mul(Cos(First), Second));
                case UnaryOperation.Cosine:
                    return new HyperDual<TInner, TPrimitive>(Cos(First), Mul(Neg(Sin(First)), Second));
                case UnaryOperation.Tangent:
                    return new HyperDual<TInner, TPrimitive>(Tan(First), Div(Second, Pow2(Cos(First))));
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    return new HyperDual<TInner, TPrimitive>(Asin(First), Div(Second, Sqrt(Inc(Neg(Pow2(First))))));
                case UnaryOperation.ArcCosine:
                    return new HyperDual<TInner, TPrimitive>(Acos(First), Neg(Div(Second, Sqrt(Inc(Neg(Pow2(First)))))));
                case UnaryOperation.ArcTangent:
                    return new HyperDual<TInner, TPrimitive>(Atan(First), Div(Second, Inc(Pow2(First))));
                default:
                    throw new NotSupportedException();
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.AbsoluteValue:
                    return Abs<TInner, TPrimitive>(First);
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(First);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperDual<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, First, other), Second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First, HyperMath.CallPrimitive(operation, Second, other));
        }

        public HyperDual<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.Call(operation, First), Second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperDual<TInner, TPrimitive>(First, HyperMath.Call(operation, Second));
        }

        public override bool Equals(object other)
        {
            return other is HyperDual<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(HyperDual<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperDual<TInner, TPrimitive> other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperDual<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDual<TInner, TPrimitive> other)
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
            return "Dual(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Dual(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDual<TInner, TPrimitive>> INumber<HyperDual<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDual<TInner, TPrimitive>, TPrimitive> INumber<HyperDual<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperDual<TInner, TPrimitive>>, INumberOperations<HyperDual<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperDual<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDual<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperDual<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public HyperDual<TInner, TPrimitive> Call(UnaryOperation operation, in HyperDual<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in HyperDual<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
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
