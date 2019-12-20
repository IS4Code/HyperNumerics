using System;
using System.Collections;
using System.Collections.Generic;

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
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static HyperSplitComplex<TInner> Zero => new HyperSplitComplex<TInner>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperSplitComplex<TInner> RealOne => new HyperSplitComplex<TInner>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperSplitComplex<TInner> SpecialOne => new HyperSplitComplex<TInner>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperSplitComplex<TInner> UnitsOne => new HyperSplitComplex<TInner>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperSplitComplex<TInner> NonRealUnitsOne => new HyperSplitComplex<TInner>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperSplitComplex<TInner> CombinedOne => new HyperSplitComplex<TInner>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperSplitComplex<TInner> AllOne => new HyperSplitComplex<TInner>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.Square().Subtract(Second.Square()).IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperSplitComplex(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public HyperSplitComplex<TInner> Add(in HyperSplitComplex<TInner> other)
        {
            return new HyperSplitComplex<TInner>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperSplitComplex<TInner> Subtract(in HyperSplitComplex<TInner> other)
        {
            return new HyperSplitComplex<TInner>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperSplitComplex<TInner> Multiply(in HyperSplitComplex<TInner> other)
        {
            return new HyperSplitComplex<TInner>(First.Multiply(other.First).Add(Second.Multiply(other.Second)), First.Multiply(other.Second).Add(Second.Multiply(other.First)));
        }

        public HyperSplitComplex<TInner> Divide(in HyperSplitComplex<TInner> other)
        {
            var denom = other.First.Square().Subtract(other.Second.Square());
            return new HyperSplitComplex<TInner>(First.Multiply(other.First).Subtract(Second.Multiply(other.Second)).Divide(denom), Second.Multiply(other.First).Subtract(First.Multiply(other.Second)).Divide(denom));
        }

        public HyperSplitComplex<TInner> Power(in HyperSplitComplex<TInner> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperSplitComplex<TInner> Add(in TInner other)
        {
            return new HyperSplitComplex<TInner>(First.Add(other), Second);
        }

        public HyperSplitComplex<TInner> Subtract(in TInner other)
        {
            return new HyperSplitComplex<TInner>(First.Subtract(other), Second);
        }

        public HyperSplitComplex<TInner> Multiply(in TInner other)
        {
            return new HyperSplitComplex<TInner>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperSplitComplex<TInner> Divide(in TInner other)
        {
            return new HyperSplitComplex<TInner>(First.Divide(other), Second.Divide(other));
        }

        public HyperSplitComplex<TInner> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperSplitComplex<TInner> SecondAdd(in TInner other)
        {
            return new HyperSplitComplex<TInner>(First, Second.Add(other));
        }

        public HyperSplitComplex<TInner> SecondSubtract(in TInner other)
        {
            return new HyperSplitComplex<TInner>(First, Second.Subtract(other));
        }

        public HyperSplitComplex<TInner> Negate()
        {
            return new HyperSplitComplex<TInner>(First.Negate(), Second.Negate());
        }

        public HyperSplitComplex<TInner> Increment()
        {
            return new HyperSplitComplex<TInner>(First.Increment(), Second);
        }

        public HyperSplitComplex<TInner> Decrement()
        {
            return new HyperSplitComplex<TInner>(First.Decrement(), Second);
        }

        public HyperSplitComplex<TInner> SecondIncrement()
        {
            return new HyperSplitComplex<TInner>(First, Second.Increment());
        }

        public HyperSplitComplex<TInner> SecondDecrement()
        {
            return new HyperSplitComplex<TInner>(First, Second.Decrement());
        }

        public HyperSplitComplex<TInner> Inverse()
        {
            var denom = First.Square().Subtract(Second.Square());
            return new HyperSplitComplex<TInner>(First.Divide(denom), Second.Negate().Divide(denom));
        }

        public HyperSplitComplex<TInner> Conjugate()
        {
            return new HyperSplitComplex<TInner>(First, Second.Negate());
        }

        public HyperSplitComplex<TInner> Modulus()
        {
            return Multiply(Conjugate());
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Double()
        {
            return new HyperSplitComplex<TInner>(First.Double(), Second.Double());
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Half()
        {
            return new HyperSplitComplex<TInner>(First.Half(), Second.Half());
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Square()
        {
            return new HyperSplitComplex<TInner>(First.Square().Add(Second.Square()), First.Multiply(Second).Double());
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.SquareRoot()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Exponentiate()
        {
            var exp = First.Exponentiate();
            return new HyperSplitComplex<TInner>(Second.HyperbolicCosine().Multiply(exp), Second.HyperbolicSine().Multiply(exp));
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Logarithm()
        {
            return new HyperSplitComplex<TInner>(First.Add(Second).Multiply(First.Subtract(Second)).Logarithm().Half(), First.Add(Second).Divide(First.Subtract(Second)).Logarithm().Half());
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Sine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Cosine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.Tangent()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.HyperbolicSine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Subtract(HyperMath.Exp(this.Negate())));
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.HyperbolicCosine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Add(HyperMath.Exp(this.Negate())));
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.HyperbolicTangent()
        {
            return HyperMath.Exp(HyperMath.Mul2(this)).Subtract(RealOne).Divide(HyperMath.Exp(HyperMath.Mul2(this)).Add(RealOne));
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.ArcSine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.ArcCosine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>>.ArcTangent()
        {
            throw new NotImplementedException();
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

        public static HyperSplitComplex<TInner> operator+(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner> operator-(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.Subtract(b);
        }

        public static HyperSplitComplex<TInner> operator*(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.Multiply(b);
        }

        public static HyperSplitComplex<TInner> operator/(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.Divide(b);
        }

        public static HyperSplitComplex<TInner> operator^(in HyperSplitComplex<TInner> a, in HyperSplitComplex<TInner> b)
        {
            return a.Power(b);
        }

        public static HyperSplitComplex<TInner> operator+(in HyperSplitComplex<TInner> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner> operator+(in TInner b, in HyperSplitComplex<TInner> a)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner> operator-(in HyperSplitComplex<TInner> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperSplitComplex<TInner> operator*(in HyperSplitComplex<TInner> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperSplitComplex<TInner> operator/(in HyperSplitComplex<TInner> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperSplitComplex<TInner> operator^(in HyperSplitComplex<TInner> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperSplitComplex<TInner> operator-(in HyperSplitComplex<TInner> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperSplitComplex<TInner>> INumber<HyperSplitComplex<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperSplitComplex<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public HyperSplitComplex<TInner> Zero => HyperSplitComplex<TInner>.Zero;
            public HyperSplitComplex<TInner> RealOne => HyperSplitComplex<TInner>.RealOne;
            public HyperSplitComplex<TInner> SpecialOne => HyperSplitComplex<TInner>.SpecialOne;
            public HyperSplitComplex<TInner> UnitsOne => HyperSplitComplex<TInner>.UnitsOne;
            public HyperSplitComplex<TInner> NonRealUnitsOne => HyperSplitComplex<TInner>.NonRealUnitsOne;
            public HyperSplitComplex<TInner> CombinedOne => HyperSplitComplex<TInner>.CombinedOne;
            public HyperSplitComplex<TInner> AllOne => HyperSplitComplex<TInner>.AllOne;
            INumber INumberFactory.Zero => HyperSplitComplex<TInner>.Zero;
            INumber INumberFactory.RealOne => HyperSplitComplex<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => HyperSplitComplex<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperSplitComplex<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperSplitComplex<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperSplitComplex<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => HyperSplitComplex<TInner>.AllOne;
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
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static HyperSplitComplex<TInner, TPrimitive> Zero => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperSplitComplex<TInner, TPrimitive> RealOne => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperSplitComplex<TInner, TPrimitive> SpecialOne => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperSplitComplex<TInner, TPrimitive> UnitsOne => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperSplitComplex<TInner, TPrimitive> NonRealUnitsOne => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperSplitComplex<TInner, TPrimitive> CombinedOne => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperSplitComplex<TInner, TPrimitive> AllOne => new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.Square().Subtract(Second.Square()).IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperSplitComplex(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public static HyperSplitComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), InnerFactory.Create(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>(in TInner first)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperSplitComplex<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> Add(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperSplitComplex<TInner, TPrimitive> Subtract(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperSplitComplex<TInner, TPrimitive> Multiply(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Multiply(other.First).Add(Second.Multiply(other.Second)), First.Multiply(other.Second).Add(Second.Multiply(other.First)));
        }

        public HyperSplitComplex<TInner, TPrimitive> Divide(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            var denom = other.First.Square().Subtract(other.Second.Square());
            return new HyperSplitComplex<TInner, TPrimitive>(First.Multiply(other.First).Subtract(Second.Multiply(other.Second)).Divide(denom), Second.Multiply(other.First).Subtract(First.Multiply(other.Second)).Divide(denom));
        }

        public HyperSplitComplex<TInner, TPrimitive> Power(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Add(in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> Subtract(in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> Multiply(in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Divide(in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondAdd(in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondSubtract(in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Add(TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Power(TPrimitive other)
        {
            throw new NotImplementedException();
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondAdd(TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondSubtract(TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperSplitComplex<TInner, TPrimitive> Negate()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Negate(), Second.Negate());
        }

        public HyperSplitComplex<TInner, TPrimitive> Increment()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Increment(), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> Decrement()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Decrement(), Second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondIncrement()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Increment());
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondDecrement()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Decrement());
        }

        public HyperSplitComplex<TInner, TPrimitive> Inverse()
        {
            var denom = First.Square().Subtract(Second.Square());
            return new HyperSplitComplex<TInner, TPrimitive>(First.Divide(denom), Second.Negate().Divide(denom));
        }

        public HyperSplitComplex<TInner, TPrimitive> Conjugate()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First, Second.Negate());
        }

        public HyperSplitComplex<TInner, TPrimitive> Modulus()
        {
            return Multiply(Conjugate());
        }

        TPrimitive INumber<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return HyperMath.Sqrt(First.Square().Subtract(Second.Square())).AbsoluteValue();
        }

        TPrimitive INumber<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return First.RealValue();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Double()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Double(), Second.Double());
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Half()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Half(), Second.Half());
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Square()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Square().Add(Second.Square()), First.Multiply(Second).Double());
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.SquareRoot()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Exponentiate()
        {
            var exp = First.Exponentiate();
            return new HyperSplitComplex<TInner, TPrimitive>(Second.HyperbolicCosine().Multiply(exp), Second.HyperbolicSine().Multiply(exp));
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Logarithm()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(First.Add(Second).Multiply(First.Subtract(Second)).Logarithm().Half(), First.Add(Second).Divide(First.Subtract(Second)).Logarithm().Half());
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Sine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Cosine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.Tangent()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.HyperbolicSine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Subtract(HyperMath.Exp(this.Negate())));
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.HyperbolicCosine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Add(HyperMath.Exp(this.Negate())));
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.HyperbolicTangent()
        {
            return HyperMath.Exp(HyperMath.Mul2(this)).Subtract(RealOne).Divide(HyperMath.Exp(HyperMath.Mul2(this)).Add(RealOne));
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.ArcSine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.ArcCosine()
        {
            throw new NotImplementedException();
        }

        HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>>.ArcTangent()
        {
            throw new NotImplementedException();
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

        public static HyperSplitComplex<TInner, TPrimitive> operator+(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator-(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator*(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator/(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator^(in HyperSplitComplex<TInner, TPrimitive> a, in HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator+(in HyperSplitComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator+(in TInner b, in HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator-(in HyperSplitComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator*(in HyperSplitComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator/(in HyperSplitComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator^(in HyperSplitComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator+(in HyperSplitComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator+(TPrimitive b, in HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator-(in HyperSplitComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Subtract(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator*(in HyperSplitComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Multiply(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator*(TPrimitive b, in HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Multiply(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator/(in HyperSplitComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Divide(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator^(in HyperSplitComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Power(b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator-(in HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperSplitComplex<TInner, TPrimitive>> INumber<HyperSplitComplex<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperSplitComplex<TInner, TPrimitive>, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public HyperSplitComplex<TInner, TPrimitive> Zero => HyperSplitComplex<TInner, TPrimitive>.Zero;
            public HyperSplitComplex<TInner, TPrimitive> RealOne => HyperSplitComplex<TInner, TPrimitive>.RealOne;
            public HyperSplitComplex<TInner, TPrimitive> SpecialOne => HyperSplitComplex<TInner, TPrimitive>.SpecialOne;
            public HyperSplitComplex<TInner, TPrimitive> UnitsOne => HyperSplitComplex<TInner, TPrimitive>.UnitsOne;
            public HyperSplitComplex<TInner, TPrimitive> NonRealUnitsOne => HyperSplitComplex<TInner, TPrimitive>.NonRealUnitsOne;
            public HyperSplitComplex<TInner, TPrimitive> CombinedOne => HyperSplitComplex<TInner, TPrimitive>.CombinedOne;
            public HyperSplitComplex<TInner, TPrimitive> AllOne => HyperSplitComplex<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => HyperSplitComplex<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => HyperSplitComplex<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => HyperSplitComplex<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperSplitComplex<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperSplitComplex<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperSplitComplex<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => HyperSplitComplex<TInner, TPrimitive>.AllOne;
            public HyperSplitComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => HyperSplitComplex<TInner, TPrimitive>.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
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
