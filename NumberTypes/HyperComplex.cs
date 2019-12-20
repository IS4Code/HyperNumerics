using System;
using System.Collections;
using System.Collections.Generic;

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
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static HyperComplex<TInner> Zero => new HyperComplex<TInner>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperComplex<TInner> RealOne => new HyperComplex<TInner>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperComplex<TInner> SpecialOne => new HyperComplex<TInner>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperComplex<TInner> UnitsOne => new HyperComplex<TInner>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperComplex<TInner> NonRealUnitsOne => new HyperComplex<TInner>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperComplex<TInner> CombinedOne => new HyperComplex<TInner>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperComplex<TInner> AllOne => new HyperComplex<TInner>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.IsInvertible || Second.IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperComplex(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public HyperComplex<TInner> Add(in HyperComplex<TInner> other)
        {
            return new HyperComplex<TInner>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperComplex<TInner> Subtract(in HyperComplex<TInner> other)
        {
            return new HyperComplex<TInner>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperComplex<TInner> Multiply(in HyperComplex<TInner> other)
        {
            return new HyperComplex<TInner>(First.Multiply(other.First).Subtract(Second.Multiply(other.Second)), First.Multiply(other.Second).Add(Second.Multiply(other.First)));
        }

        public HyperComplex<TInner> Divide(in HyperComplex<TInner> other)
        {
            var denom = other.First.Square().Add(other.Second.Square());
            return new HyperComplex<TInner>(First.Multiply(other.First).Add(Second.Multiply(other.Second)).Divide(denom), Second.Multiply(other.First).Subtract(First.Multiply(other.Second)).Divide(denom));
        }

        public HyperComplex<TInner> Power(in HyperComplex<TInner> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperComplex<TInner> Add(in TInner other)
        {
            return new HyperComplex<TInner>(First.Add(other), Second);
        }

        public HyperComplex<TInner> Subtract(in TInner other)
        {
            return new HyperComplex<TInner>(First.Subtract(other), Second);
        }

        public HyperComplex<TInner> Multiply(in TInner other)
        {
            return new HyperComplex<TInner>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperComplex<TInner> Divide(in TInner other)
        {
            return new HyperComplex<TInner>(First.Divide(other), Second.Divide(other));
        }

        public HyperComplex<TInner> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperComplex<TInner> SecondAdd(in TInner other)
        {
            return new HyperComplex<TInner>(First, Second.Add(other));
        }

        public HyperComplex<TInner> SecondSubtract(in TInner other)
        {
            return new HyperComplex<TInner>(First, Second.Subtract(other));
        }

        public HyperComplex<TInner> Negate()
        {
            return new HyperComplex<TInner>(First.Negate(), Second.Negate());
        }

        public HyperComplex<TInner> Increment()
        {
            return new HyperComplex<TInner>(First.Increment(), Second);
        }

        public HyperComplex<TInner> Decrement()
        {
            return new HyperComplex<TInner>(First.Decrement(), Second);
        }

        public HyperComplex<TInner> SecondIncrement()
        {
            return new HyperComplex<TInner>(First, Second.Increment());
        }

        public HyperComplex<TInner> SecondDecrement()
        {
            return new HyperComplex<TInner>(First, Second.Decrement());
        }

        public HyperComplex<TInner> Inverse()
        {
            var denom = First.Square().Add(Second.Square());
            return new HyperComplex<TInner>(First.Divide(denom), Second.Negate().Divide(denom));
        }

        public HyperComplex<TInner> Conjugate()
        {
            return new HyperComplex<TInner>(First, Second.Negate());
        }

        public HyperComplex<TInner> Modulus()
        {
            return HyperMath.Sqrt(Multiply(Conjugate()));
        }

        public TInner Magnitude()
        {
            return First.Square().Add(Second.Square()).SquareRoot();
        }

        public TInner Argument()
        {
            if(IsInvertible)
            {
                return HyperMath.Atan2(Second, First);
            }
            return InnerFactory.Zero;
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Double()
        {
            return new HyperComplex<TInner>(First.Double(), Second.Double());
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Half()
        {
            return new HyperComplex<TInner>(First.Half(), Second.Half());
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Square()
        {
            return new HyperComplex<TInner>(First.Square().Subtract(Second.Square()), First.Multiply(Second).Double());
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.SquareRoot()
        {
            var mag = Magnitude().SquareRoot();
            var arg = Argument().Half();
            return new HyperComplex<TInner>(arg.Cosine().Multiply(mag), arg.Sine().Multiply(mag));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Exponentiate()
        {
            var exp = First.Exponentiate();
            return new HyperComplex<TInner>(Second.Cosine().Multiply(exp), Second.Sine().Multiply(exp));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Logarithm()
        {
            return new HyperComplex<TInner>(Magnitude().Logarithm(), Argument());
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Sine()
        {
            return new HyperComplex<TInner>(First.Sine().Multiply(Second.HyperbolicCosine()), First.Cosine().Multiply(Second.HyperbolicSine()));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Cosine()
        {
            return new HyperComplex<TInner>(First.Cosine().Multiply(Second.HyperbolicCosine()), First.Sine().Multiply(Second.HyperbolicSine()).Negate());
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.Tangent()
        {
            var denom = First.Double().Cosine().Add(Second.Double().HyperbolicCosine());
            return new HyperComplex<TInner>(First.Double().Sine().Divide(denom), Second.Double().HyperbolicSine().Divide(denom));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.HyperbolicSine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Subtract(HyperMath.Exp(this.Negate())));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.HyperbolicCosine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Add(HyperMath.Exp(this.Negate())));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.HyperbolicTangent()
        {
            return HyperMath.Exp(HyperMath.Mul2(this)).Subtract(RealOne).Divide(HyperMath.Exp(HyperMath.Mul2(this)).Add(RealOne));
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.ArcSine()
        {
            return HyperMath.Log(Multiply(SpecialOne).Add(HyperMath.Sqrt(RealOne.Subtract(HyperMath.Pow2(this))))).Multiply(SpecialOne).Negate();
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.ArcCosine()
        {
            return HyperMath.Log(Add(HyperMath.Sqrt(HyperMath.Pow2(this).Subtract(RealOne)))).Multiply(SpecialOne).Negate();
        }

        HyperComplex<TInner> INumber<HyperComplex<TInner>>.ArcTangent()
        {
            return HyperMath.Div2(HyperMath.Log(SpecialOne.Add(this).Divide(SpecialOne.Subtract(this))).Multiply(SpecialOne));
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

        public static HyperComplex<TInner> operator+(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner> operator-(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.Subtract(b);
        }

        public static HyperComplex<TInner> operator*(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.Multiply(b);
        }

        public static HyperComplex<TInner> operator/(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.Divide(b);
        }

        public static HyperComplex<TInner> operator^(in HyperComplex<TInner> a, in HyperComplex<TInner> b)
        {
            return a.Power(b);
        }

        public static HyperComplex<TInner> operator+(in HyperComplex<TInner> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner> operator+(in TInner b, in HyperComplex<TInner> a)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner> operator-(in HyperComplex<TInner> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperComplex<TInner> operator*(in HyperComplex<TInner> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperComplex<TInner> operator/(in HyperComplex<TInner> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperComplex<TInner> operator^(in HyperComplex<TInner> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperComplex<TInner> operator-(in HyperComplex<TInner> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperComplex<TInner>> INumber<HyperComplex<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperComplex<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public HyperComplex<TInner> Zero => HyperComplex<TInner>.Zero;
            public HyperComplex<TInner> RealOne => HyperComplex<TInner>.RealOne;
            public HyperComplex<TInner> SpecialOne => HyperComplex<TInner>.SpecialOne;
            public HyperComplex<TInner> UnitsOne => HyperComplex<TInner>.UnitsOne;
            public HyperComplex<TInner> NonRealUnitsOne => HyperComplex<TInner>.NonRealUnitsOne;
            public HyperComplex<TInner> CombinedOne => HyperComplex<TInner>.CombinedOne;
            public HyperComplex<TInner> AllOne => HyperComplex<TInner>.AllOne;
            INumber INumberFactory.Zero => HyperComplex<TInner>.Zero;
            INumber INumberFactory.RealOne => HyperComplex<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => HyperComplex<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperComplex<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperComplex<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperComplex<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => HyperComplex<TInner>.AllOne;
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
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static HyperComplex<TInner, TPrimitive> Zero => new HyperComplex<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperComplex<TInner, TPrimitive> RealOne => new HyperComplex<TInner, TPrimitive>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperComplex<TInner, TPrimitive> SpecialOne => new HyperComplex<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperComplex<TInner, TPrimitive> UnitsOne => new HyperComplex<TInner, TPrimitive>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperComplex<TInner, TPrimitive> NonRealUnitsOne => new HyperComplex<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperComplex<TInner, TPrimitive> CombinedOne => new HyperComplex<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperComplex<TInner, TPrimitive> AllOne => new HyperComplex<TInner, TPrimitive>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.IsInvertible || Second.IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperComplex(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public static HyperComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
        {
            return new HyperComplex<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), InnerFactory.Create(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>(in TInner first)
        {
            return new HyperComplex<TInner, TPrimitive>(first);
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>(in (TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(in HyperComplex<TInner, TPrimitive> value)
        {
            return (value.First, value.Second);
        }

        public HyperComplex<TInner, TPrimitive> Add(in HyperComplex<TInner, TPrimitive> other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperComplex<TInner, TPrimitive> Subtract(in HyperComplex<TInner, TPrimitive> other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperComplex<TInner, TPrimitive> Multiply(in HyperComplex<TInner, TPrimitive> other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Multiply(other.First).Subtract(Second.Multiply(other.Second)), First.Multiply(other.Second).Add(Second.Multiply(other.First)));
        }

        public HyperComplex<TInner, TPrimitive> Divide(in HyperComplex<TInner, TPrimitive> other)
        {
            var denom = other.First.Square().Add(other.Second.Square());
            return new HyperComplex<TInner, TPrimitive>(First.Multiply(other.First).Add(Second.Multiply(other.Second)).Divide(denom), Second.Multiply(other.First).Subtract(First.Multiply(other.Second)).Divide(denom));
        }

        public HyperComplex<TInner, TPrimitive> Power(in HyperComplex<TInner, TPrimitive> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperComplex<TInner, TPrimitive> Add(in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperComplex<TInner, TPrimitive> Subtract(in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperComplex<TInner, TPrimitive> Multiply(in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperComplex<TInner, TPrimitive> Divide(in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperComplex<TInner, TPrimitive> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperComplex<TInner, TPrimitive> SecondAdd(in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperComplex<TInner, TPrimitive> SecondSubtract(in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperComplex<TInner, TPrimitive> Add(TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperComplex<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperComplex<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperComplex<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperComplex<TInner, TPrimitive> Power(TPrimitive other)
        {
            var mag = Magnitude().Power(other);
            var arg = Argument().Multiply(other);
            return new HyperComplex<TInner, TPrimitive>(arg.Cosine().Multiply(mag), arg.Sine().Multiply(mag));
        }

        public HyperComplex<TInner, TPrimitive> SecondAdd(TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperComplex<TInner, TPrimitive> SecondSubtract(TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperComplex<TInner, TPrimitive> Negate()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Negate(), Second.Negate());
        }

        public HyperComplex<TInner, TPrimitive> Increment()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Increment(), Second);
        }

        public HyperComplex<TInner, TPrimitive> Decrement()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Decrement(), Second);
        }

        public HyperComplex<TInner, TPrimitive> SecondIncrement()
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Increment());
        }

        public HyperComplex<TInner, TPrimitive> SecondDecrement()
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Decrement());
        }

        public HyperComplex<TInner, TPrimitive> Inverse()
        {
            var denom = First.Square().Add(Second.Square());
            return new HyperComplex<TInner, TPrimitive>(First.Divide(denom), Second.Negate().Divide(denom));
        }

        public HyperComplex<TInner, TPrimitive> Conjugate()
        {
            return new HyperComplex<TInner, TPrimitive>(First, Second.Negate());
        }

        public HyperComplex<TInner, TPrimitive> Modulus()
        {
            return HyperMath.Sqrt(Multiply(Conjugate()));
        }

        public TInner Magnitude()
        {
            return First.Square().Add(Second.Square()).SquareRoot();
        }

        public TInner Argument()
        {
            if(IsInvertible)
            {
                return HyperMath.Atan2(Second, First);
            }
            return InnerFactory.Zero;
        }

        TPrimitive INumber<HyperComplex<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return Magnitude().AbsoluteValue();
        }

        TPrimitive INumber<HyperComplex<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return First.RealValue();
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Double()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Double(), Second.Double());
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Half()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Half(), Second.Half());
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Square()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Square().Subtract(Second.Square()), First.Multiply(Second).Double());
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.SquareRoot()
        {
            var mag = Magnitude().SquareRoot();
            var arg = Argument().Half();
            return new HyperComplex<TInner, TPrimitive>(arg.Cosine().Multiply(mag), arg.Sine().Multiply(mag));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Exponentiate()
        {
            var exp = First.Exponentiate();
            return new HyperComplex<TInner, TPrimitive>(Second.Cosine().Multiply(exp), Second.Sine().Multiply(exp));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Logarithm()
        {
            return new HyperComplex<TInner, TPrimitive>(Magnitude().Logarithm(), Argument());
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Sine()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Sine().Multiply(Second.HyperbolicCosine()), First.Cosine().Multiply(Second.HyperbolicSine()));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Cosine()
        {
            return new HyperComplex<TInner, TPrimitive>(First.Cosine().Multiply(Second.HyperbolicCosine()), First.Sine().Multiply(Second.HyperbolicSine()).Negate());
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.Tangent()
        {
            var denom = First.Double().Cosine().Add(Second.Double().HyperbolicCosine());
            return new HyperComplex<TInner, TPrimitive>(First.Double().Sine().Divide(denom), Second.Double().HyperbolicSine().Divide(denom));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.HyperbolicSine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Subtract(HyperMath.Exp(this.Negate())));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.HyperbolicCosine()
        {
            return HyperMath.Div2(HyperMath.Exp(this).Add(HyperMath.Exp(this.Negate())));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.HyperbolicTangent()
        {
            return HyperMath.Exp(HyperMath.Mul2(this)).Subtract(RealOne).Divide(HyperMath.Exp(HyperMath.Mul2(this)).Add(RealOne));
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.ArcSine()
        {
            return HyperMath.Log(Multiply(SpecialOne).Add(HyperMath.Sqrt(RealOne.Subtract(HyperMath.Pow2(this))))).Multiply(SpecialOne).Negate();
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.ArcCosine()
        {
            return HyperMath.Log(Add(HyperMath.Sqrt(HyperMath.Pow2(this).Subtract(RealOne)))).Multiply(SpecialOne).Negate();
        }

        HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>>.ArcTangent()
        {
            return HyperMath.Div2(HyperMath.Log(SpecialOne.Add(this).Divide(SpecialOne.Subtract(this))).Multiply(SpecialOne));
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

        public static HyperComplex<TInner, TPrimitive> operator+(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator-(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator*(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator/(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator^(in HyperComplex<TInner, TPrimitive> a, in HyperComplex<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator+(in HyperComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator+(in TInner b, in HyperComplex<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator-(in HyperComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator*(in HyperComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator/(in HyperComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator^(in HyperComplex<TInner, TPrimitive> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator+(in HyperComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator+(TPrimitive b, in HyperComplex<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator-(in HyperComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Subtract(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator*(in HyperComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Multiply(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator*(TPrimitive b, in HyperComplex<TInner, TPrimitive> a)
        {
            return a.Multiply(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator/(in HyperComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Divide(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator^(in HyperComplex<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Power(b);
        }

        public static HyperComplex<TInner, TPrimitive> operator-(in HyperComplex<TInner, TPrimitive> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperComplex<TInner, TPrimitive>> INumber<HyperComplex<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperComplex<TInner, TPrimitive>, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperComplex<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public HyperComplex<TInner, TPrimitive> Zero => HyperComplex<TInner, TPrimitive>.Zero;
            public HyperComplex<TInner, TPrimitive> RealOne => HyperComplex<TInner, TPrimitive>.RealOne;
            public HyperComplex<TInner, TPrimitive> SpecialOne => HyperComplex<TInner, TPrimitive>.SpecialOne;
            public HyperComplex<TInner, TPrimitive> UnitsOne => HyperComplex<TInner, TPrimitive>.UnitsOne;
            public HyperComplex<TInner, TPrimitive> NonRealUnitsOne => HyperComplex<TInner, TPrimitive>.NonRealUnitsOne;
            public HyperComplex<TInner, TPrimitive> CombinedOne => HyperComplex<TInner, TPrimitive>.CombinedOne;
            public HyperComplex<TInner, TPrimitive> AllOne => HyperComplex<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => HyperComplex<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => HyperComplex<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => HyperComplex<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperComplex<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperComplex<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperComplex<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => HyperComplex<TInner, TPrimitive>.AllOne;
            public HyperComplex<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => HyperComplex<TInner, TPrimitive>.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
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
