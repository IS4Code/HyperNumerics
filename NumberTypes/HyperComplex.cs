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
    public readonly struct HyperComplex<TInner> : IHyperNumber<HyperComplex<TInner>, TInner>, IWrapperNumber<HyperComplex<TInner>, HyperComplex<TInner>> where TInner : struct, INumber<TInner>
    {
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        HyperComplex<TInner> IWrapperNumber<HyperComplex<TInner>>.Value => this;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(first) || CanInv(second);

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperComplex<TInner> Clone()
        {
            return new HyperComplex<TInner>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner> WithFirst(in TInner first)
        {
            return new HyperComplex<TInner>(first, second);
        }

        public HyperComplex<TInner> WithSecond(in TInner second)
        {
            return new HyperComplex<TInner>(first, second);
        }

        public static implicit operator HyperComplex<TInner>(TInner first)
        {
            return new HyperComplex<TInner>(first);
        }

        public static implicit operator HyperComplex<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperComplex<TInner> value)
        {
            return (value.first, value.second);
        }

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

        public HyperComplex<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperComplex<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner>(first, HyperMath.Call(operation, second, other));
        }

        public HyperComplex<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperComplex<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner>(first, HyperMath.Call(operation, second));
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
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperComplex<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperComplex<TInner> other)
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
            return "Complex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Complex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
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

        IExtendedNumberOperations<HyperComplex<TInner>, TInner> IExtendedNumber<HyperComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperComplex<TInner>, TInner> IHyperNumber<HyperComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperComplex<TInner>>, IHyperNumberOperations<HyperComplex<TInner>, TInner>, IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>>
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

            public HyperComplex<TInner> Clone(in HyperComplex<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperComplex<TInner> num1, HyperComplex<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(HyperComplex<TInner> num1, HyperComplex<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(HyperComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperComplex<TInner> num)
            {
                return num.GetHashCode();
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

            public HyperComplex<TInner> Call(BinaryOperation operation, in HyperComplex<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner> Create(in TInner num)
            {
                return new HyperComplex<TInner>(num);
            }

            public HyperComplex<TInner> Create(in HyperComplex<TInner> num)
            {
                return num;
            }

            public HyperComplex<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperComplex<TInner>(first, second);
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
    public readonly struct HyperComplex<TInner, TPrimitive> : IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>, IWrapperNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        HyperComplex<TInner, TPrimitive> IWrapperNumber<HyperComplex<TInner, TPrimitive>>.Value => this;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(first) || CanInv(second);

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperComplex<TInner, TPrimitive> Clone()
        {
            return new HyperComplex<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperComplex<TInner, TPrimitive>(first, second);
        }

        public HyperComplex<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperComplex<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>(TInner first)
        {
            return new HyperComplex<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperComplex<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }

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

        public HyperComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }

        public HyperComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }

        public HyperComplex<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
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
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperComplex<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperComplex<TInner, TPrimitive> other)
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
            return "Complex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Complex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
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

        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, TInner> IExtendedNumber<HyperComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperComplex<TInner, TPrimitive>, TInner> IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperComplex<TInner, TPrimitive>>, IHyperNumberOperations<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>, IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>
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

            public HyperComplex<TInner, TPrimitive> Clone(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperComplex<TInner, TPrimitive> num1, HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(HyperComplex<TInner, TPrimitive> num1, HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in HyperComplex<TInner, TPrimitive> num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in HyperComplex<TInner, TPrimitive> num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(HyperComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
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

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return new HyperComplex<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperComplex<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperComplex<TInner, TPrimitive>(num);
            }

            public HyperComplex<TInner, TPrimitive> Create(in HyperComplex<TInner, TPrimitive> num)
            {
                return num;
            }

            public HyperComplex<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperComplex<TInner, TPrimitive>(first, second);
            }

            public HyperComplex<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public HyperComplex<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                var first = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                var second = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                return new HyperComplex<TInner, TPrimitive>(first, second);
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
