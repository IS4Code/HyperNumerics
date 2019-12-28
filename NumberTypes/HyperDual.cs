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
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(first);

        public bool IsFinite => IsFin(first);

        public HyperDual(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDual(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDual(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDual<TInner> Clone()
        {
            return new HyperDual<TInner>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner> WithFirst(in TInner first)
        {
            return new HyperDual<TInner>(first, second);
        }

        public HyperDual<TInner> WithSecond(in TInner second)
        {
            return new HyperDual<TInner>(first, second);
        }

        public static implicit operator HyperDual<TInner>(TInner first)
        {
            return new HyperDual<TInner>(first);
        }

        public static implicit operator HyperDual<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner>(tuple);
        }

        public static implicit operator (TInner first, TInner second)(HyperDual<TInner> value)
        {
            return (value.first, value.second);
        }

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

        public HyperDual<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
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

        public HyperDual<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDual<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner>(first, HyperMath.Call(operation, second, other));
        }

        public HyperDual<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperDual<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperDual<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperDual<TInner>(first, HyperMath.Call(operation, second));
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
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperDual<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDual<TInner> other)
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
            return "Dual(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Dual(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
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

        IExtendedNumberOperations<HyperDual<TInner>, TInner> IExtendedNumber<HyperDual<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperDual<TInner>, TInner> IHyperNumber<HyperDual<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperDual<TInner>>, IHyperNumberOperations<HyperDual<TInner>, TInner>
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

            public HyperDual<TInner> Clone(in HyperDual<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.CompareTo(num2);
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

            public HyperDual<TInner> Call(BinaryOperation operation, in HyperDual<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner> Create(in TInner num)
            {
                return new HyperDual<TInner>(num);
            }

            public HyperDual<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperDual<TInner>(first, second);
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
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(first);

        public bool IsFinite => IsFin(first);

        public HyperDual(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDual(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDual(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDual<TInner, TPrimitive> Clone()
        {
            return new HyperDual<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperDual<TInner, TPrimitive>(first, second);
        }

        public HyperDual<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperDual<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperDual<TInner, TPrimitive>(TInner first)
        {
            return new HyperDual<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperDual<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner, TPrimitive>(tuple);
        }

        public static implicit operator (TInner first, TInner second)(HyperDual<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }
        
        public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDual<TInner, TPrimitive>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(Mul(first, other.first), Add(Mul(first, other.second), Mul(second, other.first)));
                case BinaryOperation.Divide:
                    if(!CanInv(first) && !CanInv(other.first))
                    {
                        return new HyperDual<TInner, TPrimitive>(Div(second, other.second));
                    }
                    return new HyperDual<TInner, TPrimitive>(Div(first, other.first), Div(Sub(Mul(second, other.first), Mul(first, other.second)), Pow2(other.first)));
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
                    return new HyperDual<TInner, TPrimitive>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TPrimitive>(Div(first, other), Div(second, other));
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
                    return new HyperDual<TInner, TPrimitive>(AddVal(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDual<TInner, TPrimitive>(SubVal(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDual<TInner, TPrimitive>(MulVal(first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperDual<TInner, TPrimitive>(DivVal(first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    var exp = Std<TInner, TPrimitive>(Dec(Create<TInner, TPrimitive>(other)));
                    return new HyperDual<TInner, TPrimitive>(PowVal(first, other), Mul(MulVal(PowVal(first, exp), other), second));
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
                    return new HyperDual<TInner, TPrimitive>(Neg(first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDual<TInner, TPrimitive>(Inc(first), second);
                case UnaryOperation.Decrement:
                    return new HyperDual<TInner, TPrimitive>(Dec(first), second);
                case UnaryOperation.Inverse:
                    return new HyperDual<TInner, TPrimitive>(Inv(first), Div(Neg(second), Pow2(first)));
                case UnaryOperation.Conjugate:
                    return new HyperDual<TInner, TPrimitive>(first, Neg(second));
                case UnaryOperation.Modulus:
                    return Sqrt(Pow2(first));
                case UnaryOperation.Double:
                    return new HyperDual<TInner, TPrimitive>(Mul2(first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDual<TInner, TPrimitive>(Div2(first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDual<TInner, TPrimitive>(Pow2(first), Mul2(Mul(first, second)));
                case UnaryOperation.SquareRoot:
                    var sqrt = Sqrt(first);
                    return new HyperDual<TInner, TPrimitive>(sqrt, Div(second, Mul2(sqrt)));
                case UnaryOperation.Exponentiate:
                    var exp = Exp(first);
                    return new HyperDual<TInner, TPrimitive>(exp, Mul(exp, second));
                case UnaryOperation.Logarithm:
                    return new HyperDual<TInner, TPrimitive>(Log(first), Div(second, first));
                case UnaryOperation.Sine:
                    return new HyperDual<TInner, TPrimitive>(Sin(first), Mul(Cos(first), second));
                case UnaryOperation.Cosine:
                    return new HyperDual<TInner, TPrimitive>(Cos(first), Mul(Neg(Sin(first)), second));
                case UnaryOperation.Tangent:
                    return new HyperDual<TInner, TPrimitive>(Tan(first), Div(second, Pow2(Cos(first))));
                case UnaryOperation.HyperbolicSine:
                    return SinhDefault(this);
                case UnaryOperation.HyperbolicCosine:
                    return CoshDefault(this);
                case UnaryOperation.HyperbolicTangent:
                    return TanhDefault(this);
                case UnaryOperation.ArcSine:
                    return new HyperDual<TInner, TPrimitive>(Asin(first), Div(second, Sqrt(Inc(Neg(Pow2(first))))));
                case UnaryOperation.ArcCosine:
                    return new HyperDual<TInner, TPrimitive>(Acos(first), Neg(Div(second, Sqrt(Inc(Neg(Pow2(first)))))));
                case UnaryOperation.ArcTangent:
                    return new HyperDual<TInner, TPrimitive>(Atan(first), Div(second, Inc(Pow2(first))));
                default:
                    throw new NotSupportedException();
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.AbsoluteValue:
                    return Abs<TInner, TPrimitive>(first);
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(first);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDual<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }

        public HyperDual<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }

        public HyperDual<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperDual<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
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
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperDual<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDual<TInner, TPrimitive> other)
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
            return "Dual(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Dual(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
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

        IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, TInner> IExtendedNumber<HyperDual<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperDual<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperDual<TInner, TPrimitive>, TInner> IHyperNumber<HyperDual<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IHyperNumberOperations<HyperDual<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperDual<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperDual<TInner, TPrimitive>>, IHyperNumberOperations<HyperDual<TInner, TPrimitive>, TInner, TPrimitive>
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

            public HyperDual<TInner, TPrimitive> Clone(in HyperDual<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(in HyperDual<TInner, TPrimitive> num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDual<TInner, TPrimitive> num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
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

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return new HyperDual<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperDual<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperDual<TInner, TPrimitive>(num);
            }

            public HyperDual<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperDual<TInner, TPrimitive>(first, second);
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
