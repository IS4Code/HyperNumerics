using System;
using System.Collections;
using System.Collections.Generic;

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
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static HyperDiagonal<TInner> Zero => new HyperDiagonal<TInner>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperDiagonal<TInner> RealOne => new HyperDiagonal<TInner>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperDiagonal<TInner> SpecialOne => new HyperDiagonal<TInner>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperDiagonal<TInner> UnitsOne => new HyperDiagonal<TInner>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperDiagonal<TInner> NonRealUnitsOne => new HyperDiagonal<TInner>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperDiagonal<TInner> CombinedOne => new HyperDiagonal<TInner>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperDiagonal<TInner> AllOne => new HyperDiagonal<TInner>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.IsInvertible && First.Add(Second).IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperDiagonal(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public HyperDiagonal<TInner> Add(in HyperDiagonal<TInner> other)
        {
            return new HyperDiagonal<TInner>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperDiagonal<TInner> Subtract(in HyperDiagonal<TInner> other)
        {
            return new HyperDiagonal<TInner>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperDiagonal<TInner> Multiply(in HyperDiagonal<TInner> other)
        {
            return new HyperDiagonal<TInner>(First.Multiply(other.First), First.Multiply(other.Second).Add(Second.Multiply(other.First).Add(Second.Multiply(other.Second))));
        }

        public HyperDiagonal<TInner> Divide(in HyperDiagonal<TInner> other)
        {
            return new HyperDiagonal<TInner>(First.Divide(other.First), Second.Subtract(First.Multiply(other.Second).Divide(other.First)).Divide(other.First.Add(other.Second)));
        }

        public HyperDiagonal<TInner> Power(in HyperDiagonal<TInner> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDiagonal<TInner> Add(in TInner other)
        {
            return new HyperDiagonal<TInner>(First.Add(other), Second);
        }

        public HyperDiagonal<TInner> Subtract(in TInner other)
        {
            return new HyperDiagonal<TInner>(First.Subtract(other), Second);
        }

        public HyperDiagonal<TInner> Multiply(in TInner other)
        {
            return new HyperDiagonal<TInner>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperDiagonal<TInner> Divide(in TInner other)
        {
            return new HyperDiagonal<TInner>(First.Divide(other), Second.Divide(other));
        }

        public HyperDiagonal<TInner> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDiagonal<TInner> SecondAdd(in TInner other)
        {
            return new HyperDiagonal<TInner>(First, Second.Add(other));
        }

        public HyperDiagonal<TInner> SecondSubtract(in TInner other)
        {
            return new HyperDiagonal<TInner>(First, Second.Subtract(other));
        }

        public HyperDiagonal<TInner> Negate()
        {
            return new HyperDiagonal<TInner>(First.Negate(), Second.Negate());
        }

        public HyperDiagonal<TInner> Increment()
        {
            return new HyperDiagonal<TInner>(First.Increment(), Second);
        }

        public HyperDiagonal<TInner> Decrement()
        {
            return new HyperDiagonal<TInner>(First.Decrement(), Second);
        }

        public HyperDiagonal<TInner> SecondIncrement()
        {
            return new HyperDiagonal<TInner>(First, Second.Increment());
        }

        public HyperDiagonal<TInner> SecondDecrement()
        {
            return new HyperDiagonal<TInner>(First, Second.Decrement());
        }

        public HyperDiagonal<TInner> Inverse()
        {
            return new HyperDiagonal<TInner>(First.Inverse(), Second.Negate().Divide(First.Add(Second).Multiply(First)));
        }

        public HyperDiagonal<TInner> Conjugate()
        {
            return new HyperDiagonal<TInner>(First, Second.Negate());
        }

        public HyperDiagonal<TInner> Modulus()
        {
            return First.Add(Second).Multiply(First);
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Double()
        {
            return new HyperDiagonal<TInner>(First.Double(), Second.Double());
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Half()
        {
            return new HyperDiagonal<TInner>(First.Half(), Second.Half());
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Square()
        {
            return new HyperDiagonal<TInner>(First.Square(), First.Multiply(Second).Double().Add(Second.Square()));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.SquareRoot()
        {
            var first = First.SquareRoot();
            return new HyperDiagonal<TInner>(first, First.Add(Second).SquareRoot().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Exponentiate()
        {
            var first = First.Exponentiate();
            return new HyperDiagonal<TInner>(first, First.Add(Second).Exponentiate().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Logarithm()
        {
            var first = First.Logarithm();
            return new HyperDiagonal<TInner>(first, First.Add(Second).Logarithm().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Sine()
        {
            var first = First.Sine();
            return new HyperDiagonal<TInner>(first, First.Add(Second).Sine().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Cosine()
        {
            var first = First.Cosine();
            return new HyperDiagonal<TInner>(first, First.Add(Second).Cosine().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.Tangent()
        {
            var first = First.Tangent();
            return new HyperDiagonal<TInner>(first, First.Add(Second).Tangent().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.HyperbolicSine()
        {
            var first = First.HyperbolicSine();
            return new HyperDiagonal<TInner>(first, First.Add(Second).HyperbolicSine().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.HyperbolicCosine()
        {
            var first = First.HyperbolicCosine();
            return new HyperDiagonal<TInner>(first, First.Add(Second).HyperbolicCosine().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.HyperbolicTangent()
        {
            var first = First.HyperbolicTangent();
            return new HyperDiagonal<TInner>(first, First.Add(Second).HyperbolicTangent().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.ArcSine()
        {
            var first = First.ArcSine();
            return new HyperDiagonal<TInner>(first, First.Add(Second).ArcSine().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.ArcCosine()
        {
            var first = First.ArcCosine();
            return new HyperDiagonal<TInner>(first, First.Add(Second).ArcCosine().Subtract(first));
        }

        HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>>.ArcTangent()
        {
            var first = First.ArcTangent();
            return new HyperDiagonal<TInner>(first, First.Add(Second).ArcTangent().Subtract(first));
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
            return "Weird(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Weird(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
        }

        public static HyperDiagonal<TInner> operator+(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner> operator-(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.Subtract(b);
        }

        public static HyperDiagonal<TInner> operator*(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.Multiply(b);
        }

        public static HyperDiagonal<TInner> operator/(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.Divide(b);
        }

        public static HyperDiagonal<TInner> operator^(in HyperDiagonal<TInner> a, in HyperDiagonal<TInner> b)
        {
            return a.Power(b);
        }

        public static HyperDiagonal<TInner> operator+(in HyperDiagonal<TInner> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner> operator+(in TInner b, in HyperDiagonal<TInner> a)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner> operator-(in HyperDiagonal<TInner> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperDiagonal<TInner> operator*(in HyperDiagonal<TInner> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperDiagonal<TInner> operator/(in HyperDiagonal<TInner> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperDiagonal<TInner> operator^(in HyperDiagonal<TInner> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperDiagonal<TInner> operator-(in HyperDiagonal<TInner> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperDiagonal<TInner>> INumber<HyperDiagonal<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperDiagonal<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public HyperDiagonal<TInner> Zero => HyperDiagonal<TInner>.Zero;
            public HyperDiagonal<TInner> RealOne => HyperDiagonal<TInner>.RealOne;
            public HyperDiagonal<TInner> SpecialOne => HyperDiagonal<TInner>.SpecialOne;
            public HyperDiagonal<TInner> UnitsOne => HyperDiagonal<TInner>.UnitsOne;
            public HyperDiagonal<TInner> NonRealUnitsOne => HyperDiagonal<TInner>.NonRealUnitsOne;
            public HyperDiagonal<TInner> CombinedOne => HyperDiagonal<TInner>.CombinedOne;
            public HyperDiagonal<TInner> AllOne => HyperDiagonal<TInner>.AllOne;
            INumber INumberFactory.Zero => HyperDiagonal<TInner>.Zero;
            INumber INumberFactory.RealOne => HyperDiagonal<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => HyperDiagonal<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperDiagonal<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperDiagonal<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperDiagonal<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => HyperDiagonal<TInner>.AllOne;
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
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static HyperDiagonal<TInner, TPrimitive> Zero => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.Zero);
        public static HyperDiagonal<TInner, TPrimitive> RealOne => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.RealOne, InnerFactory.Zero);
        public static HyperDiagonal<TInner, TPrimitive> SpecialOne => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.RealOne);
        public static HyperDiagonal<TInner, TPrimitive> UnitsOne => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.UnitsOne, InnerFactory.RealOne);
        public static HyperDiagonal<TInner, TPrimitive> NonRealUnitsOne => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne, InnerFactory.RealOne);
        public static HyperDiagonal<TInner, TPrimitive> CombinedOne => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.Zero, InnerFactory.CombinedOne);
        public static HyperDiagonal<TInner, TPrimitive> AllOne => new HyperDiagonal<TInner, TPrimitive>(InnerFactory.AllOne, InnerFactory.AllOne);

        public TInner First { get; }
        public TInner Second { get; }

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public bool IsInvertible => First.IsInvertible && First.Add(Second).IsInvertible;

        public bool IsFinite => First.IsFinite && Second.IsFinite;

        public HyperDiagonal(in TInner first)
        {
            First = first;
            Second = InnerFactory.Zero;
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

        public static HyperDiagonal<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
        {
            return new HyperDiagonal<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), InnerFactory.Create(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
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

        public HyperDiagonal<TInner, TPrimitive> Add(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Add(other.First), Second.Add(other.Second));
        }

        public HyperDiagonal<TInner, TPrimitive> Subtract(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Subtract(other.First), Second.Subtract(other.Second));
        }

        public HyperDiagonal<TInner, TPrimitive> Multiply(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Multiply(other.First), First.Multiply(other.Second).Add(Second.Multiply(other.First).Add(Second.Multiply(other.Second))));
        }

        public HyperDiagonal<TInner, TPrimitive> Divide(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Divide(other.First), Second.Subtract(First.Multiply(other.Second).Divide(other.First)).Divide(other.First.Add(other.Second)));
        }

        public HyperDiagonal<TInner, TPrimitive> Power(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Add(in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> Subtract(in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> Multiply(in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Divide(in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Power(in TInner other)
        {
            return HyperMath.Exp(HyperMath.Log(this).Multiply(other));
        }

        public HyperDiagonal<TInner, TPrimitive> SecondAdd(in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperDiagonal<TInner, TPrimitive> SecondSubtract(in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Add(TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Add(other), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Subtract(other), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondAdd(TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Add(other));
        }

        public HyperDiagonal<TInner, TPrimitive> SecondSubtract(TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Subtract(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Multiply(other), Second.Multiply(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Divide(other), Second.Divide(other));
        }

        public HyperDiagonal<TInner, TPrimitive> Power(TPrimitive other)
        {
            var first = First.Power(other);
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).Power(other).Subtract(first));
        }

        public HyperDiagonal<TInner, TPrimitive> Negate()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Negate(), Second.Negate());
        }

        public HyperDiagonal<TInner, TPrimitive> Increment()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Increment(), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> Decrement()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Decrement(), Second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondIncrement()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Increment());
        }

        public HyperDiagonal<TInner, TPrimitive> SecondDecrement()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Decrement());
        }

        public HyperDiagonal<TInner, TPrimitive> Inverse()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Inverse(), Second.Negate().Divide(First.Add(Second).Multiply(First)));
        }

        public HyperDiagonal<TInner, TPrimitive> Conjugate()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First, Second.Negate());
        }

        public HyperDiagonal<TInner, TPrimitive> Modulus()
        {
            return First.Add(Second).Multiply(First);
        }

        TPrimitive INumber<HyperDiagonal<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            throw new NotImplementedException();
        }

        TPrimitive INumber<HyperDiagonal<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return First.RealValue();
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Double()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Double(), Second.Double());
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Half()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Half(), Second.Half());
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Square()
        {
            return new HyperDiagonal<TInner, TPrimitive>(First.Square(), First.Multiply(Second).Double().Add(Second.Square()));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.SquareRoot()
        {
            var first = First.SquareRoot();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).SquareRoot().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Exponentiate()
        {
            var first = First.Exponentiate();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).Exponentiate().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Logarithm()
        {
            var first = First.Logarithm();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).Logarithm().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Sine()
        {
            var first = First.Sine();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).Sine().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Cosine()
        {
            var first = First.Cosine();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).Cosine().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.Tangent()
        {
            var first = First.Tangent();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).Tangent().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.HyperbolicSine()
        {
            var first = First.HyperbolicSine();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).HyperbolicSine().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.HyperbolicCosine()
        {
            var first = First.HyperbolicCosine();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).HyperbolicCosine().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.HyperbolicTangent()
        {
            var first = First.HyperbolicTangent();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).HyperbolicTangent().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.ArcSine()
        {
            var first = First.ArcSine();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).ArcSine().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.ArcCosine()
        {
            var first = First.ArcCosine();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).ArcCosine().Subtract(first));
        }

        HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>>.ArcTangent()
        {
            var first = First.ArcTangent();
            return new HyperDiagonal<TInner, TPrimitive>(first, First.Add(Second).ArcTangent().Subtract(first));
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
            return "Weird(" + First.ToString() + ", " + Second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Weird(" + First.ToString(format, formatProvider) + ", " + Second.ToString(format, formatProvider) + ")";
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator-(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator*(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator/(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator^(in HyperDiagonal<TInner, TPrimitive> a, in HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(in HyperDiagonal<TInner, TPrimitive> a, in TInner b)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(in TInner b, in HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator-(in HyperDiagonal<TInner, TPrimitive> a, in TInner b)
        {
            return a.Subtract(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator*(in HyperDiagonal<TInner, TPrimitive> a, in TInner b)
        {
            return a.Multiply(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator/(in HyperDiagonal<TInner, TPrimitive> a, in TInner b)
        {
            return a.Divide(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator^(in HyperDiagonal<TInner, TPrimitive> a, in TInner b)
        {
            return a.Power(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(in HyperDiagonal<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(TPrimitive b, in HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Add(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator-(in HyperDiagonal<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Subtract(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator*(in HyperDiagonal<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Multiply(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator*(TPrimitive b, in HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Multiply(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator/(in HyperDiagonal<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Divide(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator^(in HyperDiagonal<TInner, TPrimitive> a, TPrimitive b)
        {
            return a.Power(b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator-(in HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Negate();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperDiagonal<TInner, TPrimitive>> INumber<HyperDiagonal<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<HyperDiagonal<TInner, TPrimitive>, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<HyperDiagonal<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public HyperDiagonal<TInner, TPrimitive> Zero => HyperDiagonal<TInner, TPrimitive>.Zero;
            public HyperDiagonal<TInner, TPrimitive> RealOne => HyperDiagonal<TInner, TPrimitive>.RealOne;
            public HyperDiagonal<TInner, TPrimitive> SpecialOne => HyperDiagonal<TInner, TPrimitive>.SpecialOne;
            public HyperDiagonal<TInner, TPrimitive> UnitsOne => HyperDiagonal<TInner, TPrimitive>.UnitsOne;
            public HyperDiagonal<TInner, TPrimitive> NonRealUnitsOne => HyperDiagonal<TInner, TPrimitive>.NonRealUnitsOne;
            public HyperDiagonal<TInner, TPrimitive> CombinedOne => HyperDiagonal<TInner, TPrimitive>.CombinedOne;
            public HyperDiagonal<TInner, TPrimitive> AllOne => HyperDiagonal<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => HyperDiagonal<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => HyperDiagonal<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => HyperDiagonal<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => HyperDiagonal<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => HyperDiagonal<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => HyperDiagonal<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => HyperDiagonal<TInner, TPrimitive>.AllOne;
            public HyperDiagonal<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => HyperDiagonal<TInner, TPrimitive>.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
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
