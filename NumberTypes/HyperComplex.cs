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
    public readonly struct HyperComplex<TInner> : IHyperNumber<HyperComplex<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(First) || CanInv(Second);

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperComplex(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperComplex<TInner> Clone()
        {
            return new HyperComplex<TInner>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner> WithFirst(in TInner first)
        {
            return new HyperComplex<TInner>(first, Second);
        }

        public HyperComplex<TInner> WithSecond(in TInner second)
        {
            return new HyperComplex<TInner>(First, second);
        }

        public static implicit operator HyperComplex<TInner>(in TInner first)
        {
            return new HyperComplex<TInner>(first);
        }

        public static implicit operator HyperComplex<TInner>(in (TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperComplex<TInner> value)
        {
            return (value.First, value.Second);
        }

        public TInner Magnitude()
        {
            return Sqrt(Add(Pow2(First), Pow2(Second)));
        }

        public TInner Argument()
        {
            if(IsInvertible)
            {
                return Atan2(Second, First);
            }
            return HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex<TInner> Call(BinaryOperation operation, in HyperComplex<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Sub(Mul(First, other.First), Mul(Second, other.Second)), Add(Mul(First, other.Second), Mul(Second, other.First)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.First), Pow2(other.Second));
                    return new HyperComplex<TInner>(Div(Add(Mul(First, other.First), Mul(Second, other.Second)), denom), Div(Sub(Mul(Second, other.First), Mul(First, other.Second)), denom));
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
                    return new HyperComplex<TInner>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperComplex<TInner>(Div(First, other), Div(Second, other));
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
                    return new HyperComplex<TInner>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperComplex<TInner>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperComplex<TInner>(Dec(First), Second);
                case UnaryOperation.Inverse:
                {
                    var denom = Add(Pow2(First), Pow2(Second));
                    return new HyperComplex<TInner>(Div(First, denom), Div(Neg(Second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperComplex<TInner>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperComplex<TInner>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperComplex<TInner>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperComplex<TInner>(Sub(Pow2(First), Pow2(Second)), Mul2(Mul(First, Second)));
                case UnaryOperation.SquareRoot:
                    var mag = Sqrt(Magnitude());
                    var arg = Div2(Argument());
                    return new HyperComplex<TInner>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(First);
                    return new HyperComplex<TInner>(Mul(Cos(Second), exp), Mul(Sin(Second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperComplex<TInner>(Log(Magnitude()), Argument());
                case UnaryOperation.Sine:
                    return new HyperComplex<TInner>(Mul(Sin(First), Cosh(Second)), Mul(Cos(First), Sinh(Second)));
                case UnaryOperation.Cosine:
                    return new HyperComplex<TInner>(Mul(Cos(First), Sinh(Second)), Neg(Mul(Sin(First), Sinh(Second))));
                case UnaryOperation.Tangent:
                {
                    var denom = Add(Cos(Mul2(First)), Cosh(Mul2(Second)));
                    return new HyperComplex<TInner>(Div(Sin(Mul2(First)), denom), Div(Sinh(Mul2(Second)), denom));
                }
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                {
                    var result = new HyperComplex<TInner>(Neg(Second), First);
                    result = Log(Add(result, Sqrt(Inc(Neg(Pow2(this))))));
                    return new HyperComplex<TInner>(result.Second, Neg(result.First));
                }
                case UnaryOperation.ArcCosine:
                {
                    var result = Log(Add(this, Sqrt(Dec(Pow2(this)))));
                    return new HyperComplex<TInner>(result.Second, Neg(result.First));
                }
                case UnaryOperation.ArcTangent:
                {
                    var result = Div2(Log(Div(new HyperComplex<TInner>(First, Inc(Second)), new HyperComplex<TInner>(Neg(First), Inc(Neg(Second))))));
                    return new HyperComplex<TInner>(Neg(result.Second), result.First);
                }
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperComplex<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperComplex<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner>(HyperMath.Call(operation, First), Second);
        }

        public HyperComplex<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner>(First, HyperMath.Call(operation, Second));
        }

        public override bool Equals(object other)
        {
            return other is HyperComplex<TInner> value && Equals(in value);
        }

        public bool Equals(HyperComplex<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperComplex<TInner> other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperComplex<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperComplex<TInner> other)
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
            return "Complex(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Complex(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperComplex<TInner>> INumber<HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperComplex<TInner>>, INumberOperations<HyperComplex<TInner>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperComplex<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperComplex<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperComplex<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperComplex<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperComplex<TInner> Call(UnaryOperation operation, in HyperComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner> Call(BinaryOperation operation, in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.Call(operation, num2);
            }
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
    public readonly struct HyperComplex<TInner, TPrimitive> : IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => First.IsInvertible || Second.IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperComplex(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperComplex<TInner, TPrimitive> Clone()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperComplex<TInner, TPrimitive>(first, Second);
        }

        public HyperComplex<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperComplex<TInner, TPrimitive>(First, second);
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>(in TInner first)
        {
            return new HyperComplex<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second) (in HyperComplex<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }

        public TInner Magnitude()
        {
            return Sqrt(Add(Pow2(First), Pow2(Second)));
        }

        public TInner Argument()
        {
            if(IsInvertible)
            {
                return Atan2(Second, First);
            }
            return HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperComplex<TInner, TPrimitive>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner, TPrimitive>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner, TPrimitive>(Sub(Mul(First, other.First), Mul(Second, other.Second)), Add(Mul(First, other.Second), Mul(Second, other.First)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.First), Pow2(other.Second));
                    return new HyperComplex<TInner, TPrimitive>(Div(Add(Mul(First, other.First), Mul(Second, other.Second)), denom), Div(Sub(Mul(Second, other.First), Mul(First, other.Second)), denom));
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
                    return new HyperComplex<TInner, TPrimitive>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner, TPrimitive>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner, TPrimitive>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperComplex<TInner, TPrimitive>(Div(First, other), Div(Second, other));
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
                    return new HyperComplex<TInner, TPrimitive>(AddVal(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperComplex<TInner, TPrimitive>(SubVal(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperComplex<TInner, TPrimitive>(MulVal(First, other), MulVal(Second, other));
                case BinaryOperation.Divide:
                    return new HyperComplex<TInner, TPrimitive>(DivVal(First, other), DivVal(Second, other));
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
                    return new HyperComplex<TInner, TPrimitive>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperComplex<TInner, TPrimitive>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperComplex<TInner, TPrimitive>(Dec(First), Second);
                case UnaryOperation.Inverse:
                {
                    var denom = Add(Pow2(First), Pow2(Second));
                    return new HyperComplex<TInner, TPrimitive>(Div(First, denom), Div(Neg(Second), denom));
                }
                case UnaryOperation.Conjugate:
                    return new HyperComplex<TInner, TPrimitive>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Sqrt(Mul(this, Con(this)));
                case UnaryOperation.Double:
                    return new HyperComplex<TInner, TPrimitive>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperComplex<TInner, TPrimitive>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperComplex<TInner, TPrimitive>(Sub(Pow2(First), Pow2(Second)), Mul2(Mul(First, Second)));
                case UnaryOperation.SquareRoot:
                    var mag = Sqrt(Magnitude());
                    var arg = Div2(Argument());
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(arg), mag), Mul(Sin(arg), mag));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(First);
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(Second), exp), Mul(Sin(Second), exp));
                case UnaryOperation.Logarithm:
                    return new HyperComplex<TInner, TPrimitive>(Log(Magnitude()), Argument());
                case UnaryOperation.Sine:
                    return new HyperComplex<TInner, TPrimitive>(Mul(Sin(First), Cosh(Second)), Mul(Cos(First), Sinh(Second)));
                case UnaryOperation.Cosine:
                    return new HyperComplex<TInner, TPrimitive>(Mul(Cos(First), Sinh(Second)), Neg(Mul(Sin(First), Sinh(Second))));
                case UnaryOperation.Tangent:
                {
                    var denom = Add(Cos(Mul2(First)), Cosh(Mul2(Second)));
                    return new HyperComplex<TInner, TPrimitive>(Div(Sin(Mul2(First)), denom), Div(Sinh(Mul2(Second)), denom));
                }
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                {
                    var result = new HyperComplex<TInner, TPrimitive>(Neg(Second), First);
                    result = Log(Add(result, Sqrt(Inc(Neg(Pow2(this))))));
                    return new HyperComplex<TInner, TPrimitive>(result.Second, Neg(result.First));
                }
                case UnaryOperation.ArcCosine:
                {
                    var result = Log(Add(this, Sqrt(Dec(Pow2(this)))));
                    return new HyperComplex<TInner, TPrimitive>(result.Second, Neg(result.First));
                }
                case UnaryOperation.ArcTangent:
                {
                    var result = Div2(Log(Div(new HyperComplex<TInner, TPrimitive>(First, Inc(Second)), new HyperComplex<TInner, TPrimitive>(Neg(First), Inc(Neg(Second))))));
                    return new HyperComplex<TInner, TPrimitive>(Neg(result.Second), result.First);
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
                    return Std<TInner, TPrimitive>(First);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, First, other), Second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First, HyperMath.CallPrimitive(operation, Second, other));
        }

        public HyperComplex<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.Call(operation, First), Second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner, TPrimitive>(First, HyperMath.Call(operation, Second));
        }

        public override bool Equals(object other)
        {
            return other is HyperComplex<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(HyperComplex<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperComplex<TInner, TPrimitive> other)
        {
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperComplex<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperComplex<TInner, TPrimitive> other)
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
            return "Complex(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Complex(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperComplex<TInner, TPrimitive>> INumber<HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperComplex<TInner, TPrimitive>, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperComplex<TInner, TPrimitive>>, INumberOperations<HyperComplex<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperComplex<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public HyperComplex<TInner, TPrimitive> Call(UnaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
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
