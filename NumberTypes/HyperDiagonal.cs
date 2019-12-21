using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a diagonal number formed from two values of type <typeparamref name="TInner"/>.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <remarks>
    /// A diagonal number (a, b) can be represented algebraically as a + bk, where k^2 = k.
    /// </remarks>
    [Serializable]
    public readonly struct HyperDiagonal<TInner> : IHyperNumber<HyperDiagonal<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(first) && CanInv(Add(first, second));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperDiagonal(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDiagonal(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDiagonal(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDiagonal<TInner> Clone()
        {
            return new HyperDiagonal<TInner>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner> WithFirst(in TInner first)
        {
            return new HyperDiagonal<TInner>(first, second);
        }

        public HyperDiagonal<TInner> WithSecond(in TInner second)
        {
            return new HyperDiagonal<TInner>(first, second);
        }

        public static implicit operator HyperDiagonal<TInner>(TInner first)
        {
            return new HyperDiagonal<TInner>(first);
        }

        public static implicit operator HyperDiagonal<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperDiagonal<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperDiagonal<TInner> value)
        {
            return (value.first, value.second);
        }
        public HyperDiagonal<TInner> Call(BinaryOperation operation, in HyperDiagonal<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(first, other.first), Add(Add(Mul(first, other.second), Mul(second, other.first)), Mul(second, other.second)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperDiagonal<TInner>(Div(first, other.first), Div(Sub(second, Div(Mul(first, other.second), other.first)), Add(other.first, other.second)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperDiagonal<TInner>(Neg(this.first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDiagonal<TInner>(Inc(this.first), second);
                case UnaryOperation.Decrement:
                    return new HyperDiagonal<TInner>(Dec(this.first), second);
                case UnaryOperation.Inverse:
                    return new HyperDiagonal<TInner>(Inv(this.first), Div(Neg(second), Mul(Add(this.first, second), this.first)));
                case UnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner>(this.first, Neg(second));
                case UnaryOperation.Modulus:
                    return Mul(Add(this.first, second), this.first);
                case UnaryOperation.Double:
                    return new HyperDiagonal<TInner>(Mul2(this.first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDiagonal<TInner>(Div2(this.first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDiagonal<TInner>(Pow2(this.first), Add(Mul2(Mul(this.first, second)), Pow2(second)));
                default:
                    var first = HyperMath.Call(operation, this.first);
                    return new HyperDiagonal<TInner>(first, Sub(HyperMath.Call(operation, Add(this.first, second)), first));
            }
        }

        public HyperDiagonal<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDiagonal<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner>(first, HyperMath.Call(operation, second, other));
        }

        public HyperDiagonal<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperDiagonal<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner>(first, HyperMath.Call(operation, second));
        }

        public override bool Equals(object other)
        {
            return other is HyperDiagonal<TInner> value && Equals(in value);
        }

        public bool Equals(HyperDiagonal<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperDiagonal<TInner> other)
        {
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperDiagonal<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDiagonal<TInner> other)
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
            return "Diagonal(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Diagonal(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDiagonal<TInner>> INumber<HyperDiagonal<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperDiagonal<TInner>>, INumberOperations<HyperDiagonal<TInner>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperDiagonal<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDiagonal<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperDiagonal<TInner> Clone(in HyperDiagonal<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public HyperDiagonal<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDiagonal<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDiagonal<TInner> Call(UnaryOperation operation, in HyperDiagonal<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner> Call(BinaryOperation operation, in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.Call(operation, num2);
            }
        }
    }

    /// <summary>
    /// Represents a diagonal number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TPrimitive"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// A diagonal number (a, b) can be represented algebraically as a + bk, where k^2 = k.
    /// </remarks>
    [Serializable]
    public readonly struct HyperDiagonal<TInner, TPrimitive> : IHyperNumber<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(first) && CanInv(Add(first, second));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperDiagonal(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDiagonal(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDiagonal(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDiagonal<TInner, TPrimitive> Clone()
        {
            return new HyperDiagonal<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, second);
        }

        public HyperDiagonal<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperDiagonal<TInner, TPrimitive>(TInner first)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperDiagonal<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperDiagonal<TInner, TPrimitive>(tuple);
        }

        public static implicit operator (TInner first, TInner second)(in HyperDiagonal<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }
        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(Add(first, other.first), Add(second, other.second));
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(Sub(first, other.first), Sub(second, other.second));
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul(first, other.first), Add(Add(Mul(first, other.second), Mul(second, other.first)), Mul(second, other.second)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperDiagonal<TInner, TPrimitive>(Div(first, other.first), Div(Sub(second, Div(Mul(first, other.second), other.first)), Add(other.first, other.second)));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(Add(first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(Sub(first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul(first, other), Mul(second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TPrimitive>(Div(first, other), Div(second, other));
                case BinaryOperation.Power:
                    return PowDefault(this, other);
                case BinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(AddVal(this.first, other), second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(SubVal(this.first, other), second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(MulVal(this.first, other), MulVal(second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TPrimitive>(DivVal(this.first, other), DivVal(second, other));
                case BinaryOperation.Power:
                    var first = PowVal(this.first, other);
                    return new HyperDiagonal<TInner, TPrimitive>(first, Sub(PowVal(Add(this.first, second), other), first));
                case BinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new HyperDiagonal<TInner, TPrimitive>(Neg(this.first), Neg(second));
                case UnaryOperation.Increment:
                    return new HyperDiagonal<TInner, TPrimitive>(Inc(this.first), second);
                case UnaryOperation.Decrement:
                    return new HyperDiagonal<TInner, TPrimitive>(Dec(this.first), second);
                case UnaryOperation.Inverse:
                    return new HyperDiagonal<TInner, TPrimitive>(Inv(this.first), Div(Neg(second), Mul(Add(this.first, second), this.first)));
                case UnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner, TPrimitive>(this.first, Neg(second));
                case UnaryOperation.Modulus:
                    return Mul(Add(this.first, second), this.first);
                case UnaryOperation.Double:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul2(this.first), Mul2(second));
                case UnaryOperation.Half:
                    return new HyperDiagonal<TInner, TPrimitive>(Div2(this.first), Div2(second));
                case UnaryOperation.Square:
                    return new HyperDiagonal<TInner, TPrimitive>(Pow2(this.first), Add(Mul2(Mul(this.first, second)), Pow2(second)));
                default:
                    var first = HyperMath.Call(operation, this.first);
                    return new HyperDiagonal<TInner, TPrimitive>(first, Sub(HyperMath.Call(operation, Add(this.first, second)), first));
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(first);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
        }

        public override bool Equals(object other)
        {
            return other is HyperDiagonal<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(HyperDiagonal<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public int CompareTo(HyperDiagonal<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDiagonal<TInner, TPrimitive> other)
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
            return "Diagonal(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Diagonal(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        public static bool operator==(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDiagonal<TInner, TPrimitive>> INumber<HyperDiagonal<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDiagonal<TInner, TPrimitive>, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<HyperDiagonal<TInner, TPrimitive>>, INumberOperations<HyperDiagonal<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

            public bool IsInvertible(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperDiagonal<TInner, TPrimitive> Clone(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(in HyperDiagonal<TInner, TPrimitive> num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDiagonal<TInner, TPrimitive> num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDiagonal<TInner, TPrimitive>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDiagonal<TInner, TPrimitive> Call(UnaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
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
