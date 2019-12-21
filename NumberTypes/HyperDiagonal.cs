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
        public TInner First { get; }
        public TInner Second { get; }

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(First) && CanInv(Add(First, Second));

        public bool IsFinite => IsFin(First) && IsFin(Second);

        public HyperDiagonal(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDiagonal(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperDiagonal<TInner> Clone()
        {
            return new HyperDiagonal<TInner>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner> WithFirst(in TInner first)
        {
            return new HyperDiagonal<TInner>(first, Second);
        }

        public HyperDiagonal<TInner> WithSecond(in TInner second)
        {
            return new HyperDiagonal<TInner>(First, second);
        }

        public static implicit operator HyperDiagonal<TInner>(in TInner first)
        {
            return new HyperDiagonal<TInner>(first);
        }

        public static implicit operator HyperDiagonal<TInner>(in (TInner first, TInner second) tuple)
        {
            return new HyperDiagonal<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperDiagonal<TInner> value)
        {
            return (value.First, value.Second);
        }
        public HyperDiagonal<TInner> Call(BinaryOperation operation, in HyperDiagonal<TInner> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(First, other.First), Add(Add(Mul(First, other.Second), Mul(Second, other.First)), Mul(Second, other.Second)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.First), Pow2(other.Second));
                    return new HyperDiagonal<TInner>(Div(First, other.First), Div(Sub(Second, Div(Mul(First, other.Second), other.First)), Add(other.First, other.Second)));
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
                    return new HyperDiagonal<TInner>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner>(Div(First, other), Div(Second, other));
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
                    return new HyperDiagonal<TInner>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperDiagonal<TInner>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperDiagonal<TInner>(Dec(First), Second);
                case UnaryOperation.Inverse:
                    return new HyperDiagonal<TInner>(Inv(First), Div(Neg(Second), Mul(Add(First, Second), First)));
                case UnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Mul(Add(First, Second), First);
                case UnaryOperation.Double:
                    return new HyperDiagonal<TInner>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperDiagonal<TInner>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperDiagonal<TInner>(Pow2(First), Add(Mul2(Mul(First, Second)), Pow2(Second)));
                default:
                    var first = Call<TInner>(operation, First);
                    return new HyperDiagonal<TInner>(first, Sub(Call<TInner>(operation, Add(First, Second)), first));
            }
        }

        public HyperDiagonal<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperDiagonal<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperDiagonal<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner>(HyperMath.Call(operation, First), Second);
        }

        public HyperDiagonal<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner>(First, HyperMath.Call(operation, Second));
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
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperDiagonal<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDiagonal<TInner> other)
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
            return "Diagonal(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Diagonal(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
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
        public TInner First { get; }
        public TInner Second { get; }
        
        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public bool IsInvertible => CanInv(First) && CanInv(Add(First, Second));

        public bool IsFinite => IsFin(First) && IsFin(Second);

        public HyperDiagonal(in TInner first)
        {
            First = first;
            Second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDiagonal(in TInner first, in TInner second)
        {
            First = first;
            Second = second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = First;
            second = Second;
        }

        public HyperDiagonal<TInner, TPrimitive> Clone()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Clone(), Second.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, Second);
        }

        public HyperDiagonal<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, second);
        }

        public static implicit operator HyperDiagonal<TInner, TPrimitive>(in TInner first)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperDiagonal<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperDiagonal<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperDiagonal<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }
        public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> other)
        {
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new HyperDiagonal<TInner, TPrimitive>(Add(First, other.First), Add(Second, other.Second));
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(Sub(First, other.First), Sub(Second, other.Second));
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul(First, other.First), Add(Add(Mul(First, other.Second), Mul(Second, other.First)), Mul(Second, other.Second)));
                case BinaryOperation.Divide:
                    var denom = Add(Pow2(other.First), Pow2(other.Second));
                    return new HyperDiagonal<TInner, TPrimitive>(Div(First, other.First), Div(Sub(Second, Div(Mul(First, other.Second), other.First)), Add(other.First, other.Second)));
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
                    return new HyperDiagonal<TInner, TPrimitive>(Add(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(Sub(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul(First, other), Mul(Second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TPrimitive>(Div(First, other), Div(Second, other));
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
                    return new HyperDiagonal<TInner, TPrimitive>(AddVal(First, other), Second);
                case BinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TPrimitive>(SubVal(First, other), Second);
                case BinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TPrimitive>(MulVal(First, other), MulVal(Second, other));
                case BinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TPrimitive>(DivVal(First, other), DivVal(Second, other));
                case BinaryOperation.Power:
                    var first = PowVal(First, other);
                    return new HyperDiagonal<TInner, TPrimitive>(first, Sub(PowVal(Add(First, Second), other), first));
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
                    return new HyperDiagonal<TInner, TPrimitive>(Neg(First), Neg(Second));
                case UnaryOperation.Increment:
                    return new HyperDiagonal<TInner, TPrimitive>(Inc(First), Second);
                case UnaryOperation.Decrement:
                    return new HyperDiagonal<TInner, TPrimitive>(Dec(First), Second);
                case UnaryOperation.Inverse:
                    return new HyperDiagonal<TInner, TPrimitive>(Inv(First), Div(Neg(Second), Mul(Add(First, Second), First)));
                case UnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner, TPrimitive>(First, Neg(Second));
                case UnaryOperation.Modulus:
                    return Mul(Add(First, Second), First);
                case UnaryOperation.Double:
                    return new HyperDiagonal<TInner, TPrimitive>(Mul2(First), Mul2(Second));
                case UnaryOperation.Half:
                    return new HyperDiagonal<TInner, TPrimitive>(Div2(First), Div2(Second));
                case UnaryOperation.Square:
                    return new HyperDiagonal<TInner, TPrimitive>(Pow2(First), Add(Mul2(Mul(First, Second)), Pow2(Second)));
                default:
                    var first = Call<TInner>(operation, First);
                    return new HyperDiagonal<TInner, TPrimitive>(first, Sub(Call<TInner>(operation, Add(First, Second)), first));
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            switch(operation)
            {
                case PrimitiveUnaryOperation.RealValue:
                    return Std<TInner, TPrimitive>(First);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call(operation, First, other), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, HyperMath.Call(operation, Second, other));
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, First, other), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(BinaryOperation operation, TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, HyperMath.CallPrimitive(operation, Second, other));
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call(operation, First), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, HyperMath.Call(operation, Second));
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
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public int CompareTo(HyperDiagonal<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in HyperDiagonal<TInner, TPrimitive> other)
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
            return "Diagonal(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Diagonal(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
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
