using System;
using System.Collections;
using System.Collections.Generic;

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
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static HyperDual<TInner> Zero => new HyperDual<TInner>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperDual<TInner> RealOne => new HyperDual<TInner>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperDual<TInner> SpecialOne => new HyperDual<TInner>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperDual<TInner> UnitsOne => new HyperDual<TInner>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperDual<TInner> NonRealUnitsOne => new HyperDual<TInner>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperDual<TInner> CombinedOne => new HyperDual<TInner>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperDual<TInner> AllOne => new HyperDual<TInner>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperDual(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public HyperDual<TInner> Add(in HyperDual<TInner> other)
        {
            return new HyperDual<TInner>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperDual<TInner> Subtract(in HyperDual<TInner> other)
        {
            return new HyperDual<TInner>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperDual<TInner> Multiply(in HyperDual<TInner> other)
        {
            return new HyperDual<TInner>(First.Multiply(other.First), First.Multiply(other.Second).Add(Second.Multiply(other.First)));
        }

        public HyperDual<TInner> Divide(in HyperDual<TInner> other)
        {
            if(!First.IsInvertible && !other.First.IsInvertible)
            {
                return new HyperDual<TInner>(Second.Divide(other.Second));
            }
            return new HyperDual<TInner>(First.Divide(other.First), Second.Multiply(other.First).Subtract(First.Multiply(other.Second)).Divide(other.First.Square()));
        }

        public HyperDual<TInner> Power(in HyperDual<TInner> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDual<TInner> Add(in TInner other)
        {
            return new HyperDual<TInner>(First.Add(other), Second);
        }

        public HyperDual<TInner> Subtract(in TInner other)
        {
            return new HyperDual<TInner>(First.Subtract(other), Second);
        }

        public HyperDual<TInner> Multiply(in TInner other)
        {
            return new HyperDual<TInner>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperDual<TInner> Divide(in TInner other)
        {
            return new HyperDual<TInner>(First.Divide(other), Second.Divide(other));
        }

        public HyperDual<TInner> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDual<TInner> SecondAdd(in TInner other)
        {
            return new HyperDual<TInner>(First, Second.Add(other));
        }

        public HyperDual<TInner> SecondSubtract(in TInner other)
        {
            return new HyperDual<TInner>(First, Second.Subtract(other));
        }

        public HyperDual<TInner> Negate()
        {
            return new HyperDual<TInner>(First.Negate(), Second.Negate());
        }

        public HyperDual<TInner> Increment()
        {
            return new HyperDual<TInner>(First.Increment(), Second);
        }

        public HyperDual<TInner> Decrement()
        {
            return new HyperDual<TInner>(First.Decrement(), Second);
        }

        public HyperDual<TInner> SecondIncrement()
        {
            return new HyperDual<TInner>(First, Second.Increment());
        }

        public HyperDual<TInner> SecondDecrement()
        {
            return new HyperDual<TInner>(First, Second.Decrement());
        }

        public HyperDual<TInner> Inverse()
        {
            return new HyperDual<TInner>(First.Inverse(), Second.Negate().Divide(First.Square()));
        }

        public HyperDual<TInner> Conjugate()
        {
            return new HyperDual<TInner>(First, Second.Negate());
        }

        public HyperDual<TInner> Modulus()
        {
            return HyperMath.Sqrt(Multiply(Conjugate()));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Double()
        {
            return new HyperDual<TInner>(First.Double(), Second.Double());
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Half()
        {
            return new HyperDual<TInner>(First.Half(), Second.Half());
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Square()
        {
            return new HyperDual<TInner>(First.Square(), First.Multiply(Second).Double());
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.SquareRoot()
        {
            var sqrt = First.SquareRoot();
            return new HyperDual<TInner>(sqrt, Second.Divide(sqrt.Double()));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Exponentiate()
        {
            var exp = First.Exponentiate();
            return new HyperDual<TInner>(exp, exp.Multiply(Second));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Logarithm()
        {
            return new HyperDual<TInner>(First.Logarithm(), Second.Divide(First));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Sine()
        {
            return new HyperDual<TInner>(First.Sine(), First.Cosine().Multiply(Second));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Cosine()
        {
            return new HyperDual<TInner>(First.Cosine(), First.Sine().Negate().Multiply(Second));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.Tangent()
        {
            return new HyperDual<TInner>(First.Tangent(), Second.Divide(First.Cosine().Square()));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.HyperbolicSine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Subtract(HyperMath.Exp(this.Negate())));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.HyperbolicCosine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Add(HyperMath.Exp(this.Negate())));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.HyperbolicTangent()
        {
            return HyperMath.Exp(HyperMath.Mul2(this)).Decrement().Divide(HyperMath.Exp(HyperMath.Mul2(this)).Increment());
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.ArcSine()
        {
            return new HyperDual<TInner>(First.ArcSine(), Second.Divide(First.Square().Negate().Increment().SquareRoot()));
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.ArcCosine()
        {
            return new HyperDual<TInner>(First.ArcCosine(), Second.Divide(First.Square().Negate().Increment().SquareRoot()).Negate());
        }

        HyperDual<TInner> INumber<HyperDual<TInner>>.ArcTangent()
        {
            return new HyperDual<TInner>(First.ArcTangent(), Second.Divide(First.Square().Increment()));
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

        public static HyperDual<TInner> operator+(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner> operator-(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.Subtract(b);
        }

        public static HyperDual<TInner> operator*(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.Multiply(b);
        }

        public static HyperDual<TInner> operator/(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.Divide(b);
        }

        public static HyperDual<TInner> operator^(in HyperDual<TInner> a, in HyperDual<TInner> b)
        {
            return a.Power(b);
        }

        public static HyperDual<TInner> operator+(in HyperDual<TInner> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner> operator+(in TInner b, in HyperDual<TInner> a)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner> operator-(in HyperDual<TInner> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperDual<TInner> operator*(in HyperDual<TInner> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperDual<TInner> operator/(in HyperDual<TInner> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperDual<TInner> operator^(in HyperDual<TInner> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperDual<TInner> operator-(in HyperDual<TInner> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperDual<TInner>> INumber<HyperDual<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperDual<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public HyperDual<TInner> Zero => HyperDual<TInner>.Zero;
            public HyperDual<TInner> RealOne => HyperDual<TInner>.RealOne;
            public HyperDual<TInner> SpecialOne => HyperDual<TInner>.SpecialOne;
            public HyperDual<TInner> UnitsOne => HyperDual<TInner>.UnitsOne;
            public HyperDual<TInner> NonRealUnitsOne => HyperDual<TInner>.NonRealUnitsOne;
            public HyperDual<TInner> CombinedOne => HyperDual<TInner>.CombinedOne;
            public HyperDual<TInner> AllOne => HyperDual<TInner>.AllOne;
            INumber INumberFactory.Zero => HyperDual<TInner>.Zero;
            INumber INumberFactory.RealOne => HyperDual<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => HyperDual<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperDual<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperDual<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperDual<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => HyperDual<TInner>.AllOne;
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
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static HyperDual<TInner, TPrimitive> Zero => new HyperDual<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperDual<TInner, TPrimitive> RealOne => new HyperDual<TInner, TPrimitive>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperDual<TInner, TPrimitive> SpecialOne => new HyperDual<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperDual<TInner, TPrimitive> UnitsOne => new HyperDual<TInner, TPrimitive>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperDual<TInner, TPrimitive> NonRealUnitsOne => new HyperDual<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperDual<TInner, TPrimitive> CombinedOne => new HyperDual<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperDual<TInner, TPrimitive> AllOne => new HyperDual<TInner, TPrimitive>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperDual(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public static HyperDual<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
        {
            return new HyperDual<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), InnerFactory.Create(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
        }

        public static implicit operator HyperDual<TInner, TPrimitive>(in TInner first)
        {
            return new HyperDual<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperDual<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperDual<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }

        public HyperDual<TInner, TPrimitive> Add(in HyperDual<TInner, TPrimitive> other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperDual<TInner, TPrimitive> Subtract(in HyperDual<TInner, TPrimitive> other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperDual<TInner, TPrimitive> Multiply(in HyperDual<TInner, TPrimitive> other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Multiply(other.First), First.Multiply(other.Second).Add(Second.Multiply(other.First)));
        }

        public HyperDual<TInner, TPrimitive> Divide(in HyperDual<TInner, TPrimitive> other)
        {
            if(!First.IsInvertible && !other.First.IsInvertible)
            {
                return new HyperDual<TInner, TPrimitive>(Second.Divide(other.Second));
            }
            return new HyperDual<TInner, TPrimitive>(First.Divide(other.First), Second.Multiply(other.First).Subtract(First.Multiply(other.Second)).Divide(other.First.Square()));
        }

        public HyperDual<TInner, TPrimitive> Power(in HyperDual<TInner, TPrimitive> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDual<TInner, TPrimitive> Add(in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperDual<TInner, TPrimitive> Subtract(in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperDual<TInner, TPrimitive> Multiply(in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperDual<TInner, TPrimitive> Divide(in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperDual<TInner, TPrimitive> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDual<TInner, TPrimitive> SecondAdd(in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperDual<TInner, TPrimitive> SecondSubtract(in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperDual<TInner, TPrimitive> Add(TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperDual<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperDual<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperDual<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperDual<TInner, TPrimitive> Power(TPrimitive other)
        {
            var exp = InnerFactory.RealOne.Multiply(other).Decrement().RealValue();
            return new HyperDual<TInner, TPrimitive>(First.Power(other), First.Power(exp).Multiply(other).Multiply(Second));
        }

        public HyperDual<TInner, TPrimitive> SecondAdd(TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperDual<TInner, TPrimitive> SecondSubtract(TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperDual<TInner, TPrimitive> Negate()
        {
            return new HyperDual<TInner, TPrimitive>(First.Negate(), Second.Negate());
        }

        public HyperDual<TInner, TPrimitive> Increment()
        {
            return new HyperDual<TInner, TPrimitive>(First.Increment(), Second);
        }

        public HyperDual<TInner, TPrimitive> Decrement()
        {
            return new HyperDual<TInner, TPrimitive>(First.Decrement(), Second);
        }

        public HyperDual<TInner, TPrimitive> SecondIncrement()
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Increment());
        }

        public HyperDual<TInner, TPrimitive> SecondDecrement()
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Decrement());
        }

        public HyperDual<TInner, TPrimitive> Inverse()
        {
            return new HyperDual<TInner, TPrimitive>(First.Inverse(), Second.Negate().Divide(First.Square()));
        }

        public HyperDual<TInner, TPrimitive> Conjugate()
        {
            return new HyperDual<TInner, TPrimitive>(First, Second.Negate());
        }

        public HyperDual<TInner, TPrimitive> Modulus()
        {
            return HyperMath.Sqrt(Multiply(Conjugate()));
        }

        TPrimitive INumber<HyperDual<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return First.AbsoluteValue();
        }

        TPrimitive INumber<HyperDual<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return First.RealValue();
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Double()
        {
            return new HyperDual<TInner, TPrimitive>(First.Double(), Second.Double());
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Half()
        {
            return new HyperDual<TInner, TPrimitive>(First.Half(), Second.Half());
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Square()
        {
            return new HyperDual<TInner, TPrimitive>(First.Square(), First.Multiply(Second).Double());
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.SquareRoot()
        {
            var sqrt = First.SquareRoot();
            return new HyperDual<TInner, TPrimitive>(sqrt, Second.Divide(sqrt.Double()));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Exponentiate()
        {
            var exp = First.Exponentiate();
            return new HyperDual<TInner, TPrimitive>(exp, exp.Multiply(Second));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Logarithm()
        {
            return new HyperDual<TInner, TPrimitive>(First.Logarithm(), Second.Divide(First));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Sine()
        {
            return new HyperDual<TInner, TPrimitive>(First.Sine(), First.Cosine().Multiply(Second));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Cosine()
        {
            return new HyperDual<TInner, TPrimitive>(First.Cosine(), First.Sine().Negate().Multiply(Second));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.Tangent()
        {
            return new HyperDual<TInner, TPrimitive>(First.Tangent(), Second.Divide(First.Cosine().Square()));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.HyperbolicSine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Subtract(HyperMath.Exp(this.Negate())));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.HyperbolicCosine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Add(HyperMath.Exp(this.Negate())));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.HyperbolicTangent()
        {
            return HyperMath.Exp(HyperMath.Mul2(this)).Decrement().Divide(HyperMath.Exp(HyperMath.Mul2(this)).Increment());
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.ArcSine()
        {
            return new HyperDual<TInner, TPrimitive>(First.ArcSine(), Second.Divide(First.Square().Negate().Increment().SquareRoot()));
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.ArcCosine()
        {
            return new HyperDual<TInner, TPrimitive>(First.ArcCosine(), Second.Divide(First.Square().Negate().Increment().SquareRoot()).Negate());
        }

        HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>>.ArcTangent()
        {
            return new HyperDual<TInner, TPrimitive>(First.ArcTangent(), Second.Divide(First.Square().Increment()));
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

        public static HyperDual<TInner, TPrimitive> operator+(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner, TPrimitive> operator-(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static HyperDual<TInner, TPrimitive> operator*(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static HyperDual<TInner, TPrimitive> operator/(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static HyperDual<TInner, TPrimitive> operator^(in HyperDual<TInner, TPrimitive> a, in HyperDual<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static HyperDual<TInner, TPrimitive> operator+(in HyperDual<TInner, TPrimitive> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner, TPrimitive> operator+(in TInner b, in HyperDual<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner, TPrimitive> operator-(in HyperDual<TInner, TPrimitive> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperDual<TInner, TPrimitive> operator*(in HyperDual<TInner, TPrimitive> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperDual<TInner, TPrimitive> operator/(in HyperDual<TInner, TPrimitive> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperDual<TInner, TPrimitive> operator^(in HyperDual<TInner, TPrimitive> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperDual<TInner, TPrimitive> operator+(in HyperDual<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner, TPrimitive> operator+(TPrimitive b, in HyperDual<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperDual<TInner, TPrimitive> operator-(in HyperDual<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Subtract(b);
        }

        public static HyperDual<TInner, TPrimitive> operator*(in HyperDual<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Multiply(b);
        }

        public static HyperDual<TInner, TPrimitive> operator*(TPrimitive b, in HyperDual<TInner, TPrimitive> a)
        {
            return a.Multiply(b);
        }

        public static HyperDual<TInner, TPrimitive> operator/(in HyperDual<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Divide(b);
        }

        public static HyperDual<TInner, TPrimitive> operator^(in HyperDual<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Power(b);
        }

        public static HyperDual<TInner, TPrimitive> operator-(in HyperDual<TInner, TPrimitive> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperDual<TInner, TPrimitive>> INumber<HyperDual<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperDual<TInner, TPrimitive>, TPrimitive> INumber<HyperDual<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperDual<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public HyperDual<TInner, TPrimitive> Zero => HyperDual<TInner, TPrimitive>.Zero;
            public HyperDual<TInner, TPrimitive> RealOne => HyperDual<TInner, TPrimitive>.RealOne;
            public HyperDual<TInner, TPrimitive> SpecialOne => HyperDual<TInner, TPrimitive>.SpecialOne;
            public HyperDual<TInner, TPrimitive> UnitsOne => HyperDual<TInner, TPrimitive>.UnitsOne;
            public HyperDual<TInner, TPrimitive> NonRealUnitsOne => HyperDual<TInner, TPrimitive>.NonRealUnitsOne;
            public HyperDual<TInner, TPrimitive> CombinedOne => HyperDual<TInner, TPrimitive>.CombinedOne;
            public HyperDual<TInner, TPrimitive> AllOne => HyperDual<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => HyperDual<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => HyperDual<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => HyperDual<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperDual<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperDual<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperDual<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => HyperDual<TInner, TPrimitive>.AllOne;
            public HyperDual<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => HyperDual<TInner, TPrimitive>.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
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
