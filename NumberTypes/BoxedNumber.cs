using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Stores a reference to a boxed instance of <typeparamref name="TInner"/> so that it is not copied when the value is reassigned.
    /// </summary>
    /// <typeparam name="TInner">The internal number type that the instance supports.</typeparam>
    [Serializable]
    public readonly struct BoxedNumber<TInner> : IExtendedNumber<BoxedNumber<TInner>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner>
    {
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        static TInner defaultValue;

        readonly Instance instance;

        ref TInner Reference{
            get{
                if(instance != null)
                {
                    return ref instance.Value;
                }
                return ref defaultValue;
            }
        }

        public BoxedNumber(in TInner value)
        {
            instance = defaultValue.Equals(in value) ? null : new Instance(value);
        }

        public BoxedNumber<TInner> Clone()
        {
            if(instance == null) return default;
            return new BoxedNumber<TInner>(instance.Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Reference.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public bool IsInvertible => Reference.IsInvertible;

        public bool IsFinite => Reference.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public BoxedNumber<TInner> Add(in BoxedNumber<TInner> other)
        {
            return Reference.Add(other.Reference);
        }

        public BoxedNumber<TInner> Subtract(in BoxedNumber<TInner> other)
        {
            return Reference.Subtract(other.Reference);
        }

        public BoxedNumber<TInner> Multiply(in BoxedNumber<TInner> other)
        {
            return Reference.Multiply(other.Reference);
        }

        public BoxedNumber<TInner> Divide(in BoxedNumber<TInner> other)
        {
            return Reference.Divide(other.Reference);
        }

        public BoxedNumber<TInner> Power(in BoxedNumber<TInner> other)
        {
            return Reference.Power(other.Reference);
        }

        public BoxedNumber<TInner> Add(in TInner other)
        {
            return Reference.Add(other);
        }

        public BoxedNumber<TInner> Subtract(in TInner other)
        {
            return Reference.Subtract(other);
        }

        public BoxedNumber<TInner> Multiply(in TInner other)
        {
            return Reference.Multiply(other);
        }

        public BoxedNumber<TInner> Divide(in TInner other)
        {
            return Reference.Divide(other);
        }

        public BoxedNumber<TInner> Power(in TInner other)
        {
            return Reference.Power(other);
        }

        TInner INumber<TInner>.Add(in TInner other)
        {
            return Reference.Add(other);
        }

        TInner INumber<TInner>.Subtract(in TInner other)
        {
            return Reference.Subtract(other);
        }

        TInner INumber<TInner>.Multiply(in TInner other)
        {
            return Reference.Multiply(other);
        }

        TInner INumber<TInner>.Divide(in TInner other)
        {
            return Reference.Divide(other);
        }

        TInner INumber<TInner>.Power(in TInner other)
        {
            return Reference.Power(other);
        }

        public BoxedNumber<TInner> Negate()
        {
            return Reference.Negate();
        }

        public BoxedNumber<TInner> Increment()
        {
            return Reference.Increment();
        }

        public BoxedNumber<TInner> Decrement()
        {
            return Reference.Decrement();
        }

        public BoxedNumber<TInner> Inverse()
        {
            return Reference.Inverse();
        }

        public BoxedNumber<TInner> Conjugate()
        {
            return Reference.Conjugate();
        }

        public BoxedNumber<TInner> Modulus()
        {
            return Reference.Modulus();
        }

        TInner INumber<TInner>.Negate()
        {
            return Reference.Negate();
        }

        TInner INumber<TInner>.Increment()
        {
            return Reference.Increment();
        }

        TInner INumber<TInner>.Decrement()
        {
            return Reference.Decrement();
        }

        TInner INumber<TInner>.Inverse()
        {
            return Reference.Inverse();
        }

        TInner INumber<TInner>.Conjugate()
        {
            return Reference.Conjugate();
        }

        TInner INumber<TInner>.Modulus()
        {
            return Reference.Modulus();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Half()
        {
            return Reference.Half();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Double()
        {
            return Reference.Double();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Square()
        {
            return Reference.Square();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.SquareRoot()
        {
            return Reference.SquareRoot();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Exponentiate()
        {
            return Reference.Exponentiate();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Logarithm()
        {
            return Reference.Logarithm();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Sine()
        {
            return Reference.Sine();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Cosine()
        {
            return Reference.Cosine();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.Tangent()
        {
            return Reference.Tangent();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.HyperbolicSine()
        {
            return Reference.HyperbolicSine();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.HyperbolicCosine()
        {
            return Reference.HyperbolicCosine();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.HyperbolicTangent()
        {
            return Reference.HyperbolicTangent();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.ArcSine()
        {
            return Reference.ArcSine();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.ArcCosine()
        {
            return Reference.ArcCosine();
        }

        BoxedNumber<TInner> INumber<BoxedNumber<TInner>>.ArcTangent()
        {
            return Reference.ArcTangent();
        }

        TInner INumber<TInner>.Half()
        {
            return Reference.Half();
        }

        TInner INumber<TInner>.Double()
        {
            return Reference.Double();
        }

        TInner INumber<TInner>.Square()
        {
            return Reference.Square();
        }

        TInner INumber<TInner>.SquareRoot()
        {
            return Reference.SquareRoot();
        }

        TInner INumber<TInner>.Exponentiate()
        {
            return Reference.Exponentiate();
        }

        TInner INumber<TInner>.Logarithm()
        {
            return Reference.Logarithm();
        }

        TInner INumber<TInner>.Sine()
        {
            return Reference.Sine();
        }

        TInner INumber<TInner>.Cosine()
        {
            return Reference.Cosine();
        }

        TInner INumber<TInner>.Tangent()
        {
            return Reference.Tangent();
        }

        TInner INumber<TInner>.HyperbolicSine()
        {
            return Reference.HyperbolicSine();
        }

        TInner INumber<TInner>.HyperbolicCosine()
        {
            return Reference.HyperbolicCosine();
        }

        TInner INumber<TInner>.HyperbolicTangent()
        {
            return Reference.HyperbolicTangent();
        }

        TInner INumber<TInner>.ArcSine()
        {
            return Reference.ArcSine();
        }

        TInner INumber<TInner>.ArcCosine()
        {
            return Reference.ArcCosine();
        }

        TInner INumber<TInner>.ArcTangent()
        {
            return Reference.ArcTangent();
        }

        public override bool Equals(object obj)
        {
            return obj is BoxedNumber<TInner> value && Equals(value) || Reference.Equals(obj);
        }

        public bool Equals(BoxedNumber<TInner> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in BoxedNumber<TInner> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(TInner other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(BoxedNumber<TInner> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(in BoxedNumber<TInner> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(TInner other)
        {
            return Reference.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Reference.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        public override string ToString()
        {
            return Reference.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Reference.ToString(format, formatProvider);
        }

        public static implicit operator BoxedNumber<TInner>(in TInner value)
        {
            return new BoxedNumber<TInner>(value);
        }

        public static implicit operator TInner(BoxedNumber<TInner> value)
        {
            return value.Reference;
        }

        public static BoxedNumber<TInner> operator+(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Add(b);
        }

        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Subtract(b);
        }

        public static BoxedNumber<TInner> operator*(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Multiply(b);
        }

        public static BoxedNumber<TInner> operator/(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Divide(b);
        }

        public static BoxedNumber<TInner> operator^(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Power(b);
        }

        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a)
        {
            return a.Negate();
        }

        public static bool operator==(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<BoxedNumber<TInner>> INumber<BoxedNumber<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<TInner> INumber<TInner>.GetFactory()
        {
            return Reference.GetFactory();
        }

        class Factory : INumberFactory<BoxedNumber<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public BoxedNumber<TInner> Zero => InnerFactory.Zero;
            public BoxedNumber<TInner> RealOne => InnerFactory.RealOne;
            public BoxedNumber<TInner> SpecialOne => InnerFactory.SpecialOne;
            public BoxedNumber<TInner> UnitsOne => InnerFactory.UnitsOne;
            public BoxedNumber<TInner> NonRealUnitsOne => InnerFactory.NonRealUnitsOne;
            public BoxedNumber<TInner> CombinedOne => InnerFactory.CombinedOne;
            public BoxedNumber<TInner> AllOne => InnerFactory.AllOne;
            INumber INumberFactory.Zero => InnerFactory.Zero;
            INumber INumberFactory.RealOne => InnerFactory.RealOne;
            INumber INumberFactory.SpecialOne => InnerFactory.SpecialOne;
            INumber INumberFactory.UnitsOne => InnerFactory.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => InnerFactory.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => InnerFactory.CombinedOne;
            INumber INumberFactory.AllOne => InnerFactory.AllOne;
        }

        class Instance
        {
            public TInner Value;

            public Instance(in TInner value)
            {
                Value = value;
            }
        }
    }

    /// <summary>
    /// Stores a reference to a boxed instance of <typeparamref name="TInner"/> so that it is not copied when the value is reassigned.
    /// </summary>
    /// <typeparam name="TInner">The internal number type that the instance supports.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    [Serializable]
    public readonly struct BoxedNumber<TInner, TPrimitive> : IExtendedNumber<BoxedNumber<TInner, TPrimitive>, TInner, TPrimitive>, INumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        static TInner defaultValue;

        readonly Instance instance;

        ref TInner Reference{
            get{
                if(instance != null)
                {
                    return ref instance.Value;
                }
                return ref defaultValue;
            }
        }

        public BoxedNumber(in TInner value)
        {
            instance = defaultValue.Equals(in value) ? null : new Instance(value);
        }

        public BoxedNumber<TInner, TPrimitive> Clone()
        {
            if(instance == null) return default;
            return new BoxedNumber<TInner, TPrimitive>(instance.Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Reference.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public bool IsInvertible => Reference.IsInvertible;

        public bool IsFinite => Reference.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public BoxedNumber<TInner, TPrimitive> Add(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Add(other.Reference);
        }

        public BoxedNumber<TInner, TPrimitive> Subtract(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Subtract(other.Reference);
        }

        public BoxedNumber<TInner, TPrimitive> Multiply(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Multiply(other.Reference);
        }

        public BoxedNumber<TInner, TPrimitive> Divide(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Divide(other.Reference);
        }

        public BoxedNumber<TInner, TPrimitive> Power(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Power(other.Reference);
        }

        public BoxedNumber<TInner, TPrimitive> Add(in TInner other)
        {
            return Reference.Add(other);
        }

        public BoxedNumber<TInner, TPrimitive> Subtract(in TInner other)
        {
            return Reference.Subtract(other);
        }

        public BoxedNumber<TInner, TPrimitive> Multiply(in TInner other)
        {
            return Reference.Multiply(other);
        }

        public BoxedNumber<TInner, TPrimitive> Divide(in TInner other)
        {
            return Reference.Divide(other);
        }

        public BoxedNumber<TInner, TPrimitive> Power(in TInner other)
        {
            return Reference.Power(other);
        }

        TInner INumber<TInner>.Add(in TInner other)
        {
            return Reference.Add(other);
        }

        TInner INumber<TInner>.Subtract(in TInner other)
        {
            return Reference.Subtract(other);
        }

        TInner INumber<TInner>.Multiply(in TInner other)
        {
            return Reference.Multiply(other);
        }

        TInner INumber<TInner>.Divide(in TInner other)
        {
            return Reference.Divide(other);
        }

        TInner INumber<TInner>.Power(in TInner other)
        {
            return Reference.Power(other);
        }

        public BoxedNumber<TInner, TPrimitive> Add(TPrimitive other)
        {
            return Reference.Add(other);
        }

        public BoxedNumber<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return Reference.Subtract(other);
        }

        public BoxedNumber<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return Reference.Multiply(other);
        }

        public BoxedNumber<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return Reference.Divide(other);
        }

        public BoxedNumber<TInner, TPrimitive> Power(TPrimitive other)
        {
            return Reference.Power(other);
        }

        TInner INumber<TInner, TPrimitive>.Add(TPrimitive other)
        {
            return Reference.Add(other);
        }

        TInner INumber<TInner, TPrimitive>.Subtract(TPrimitive other)
        {
            return Reference.Subtract(other);
        }

        TInner INumber<TInner, TPrimitive>.Multiply(TPrimitive other)
        {
            return Reference.Multiply(other);
        }

        TInner INumber<TInner, TPrimitive>.Divide(TPrimitive other)
        {
            return Reference.Divide(other);
        }

        TInner INumber<TInner, TPrimitive>.Power(TPrimitive other)
        {
            return Reference.Power(other);
        }

        public BoxedNumber<TInner, TPrimitive> Negate()
        {
            return Reference.Negate();
        }

        public BoxedNumber<TInner, TPrimitive> Increment()
        {
            return Reference.Increment();
        }

        public BoxedNumber<TInner, TPrimitive> Decrement()
        {
            return Reference.Decrement();
        }

        public BoxedNumber<TInner, TPrimitive> Inverse()
        {
            return Reference.Inverse();
        }

        public BoxedNumber<TInner, TPrimitive> Conjugate()
        {
            return Reference.Conjugate();
        }

        public BoxedNumber<TInner, TPrimitive> Modulus()
        {
            return Reference.Modulus();
        }

        TInner INumber<TInner>.Negate()
        {
            return Reference.Negate();
        }

        TInner INumber<TInner>.Increment()
        {
            return Reference.Increment();
        }

        TInner INumber<TInner>.Decrement()
        {
            return Reference.Decrement();
        }

        TInner INumber<TInner>.Inverse()
        {
            return Reference.Inverse();
        }

        TInner INumber<TInner>.Conjugate()
        {
            return Reference.Conjugate();
        }

        TInner INumber<TInner>.Modulus()
        {
            return Reference.Modulus();
        }

        TPrimitive INumber<BoxedNumber<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return Reference.AbsoluteValue();
        }

        TPrimitive INumber<BoxedNumber<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return Reference.RealValue();
        }

        TPrimitive INumber<TInner, TPrimitive>.AbsoluteValue()
        {
            return Reference.AbsoluteValue();
        }

        TPrimitive INumber<TInner, TPrimitive>.RealValue()
        {
            return Reference.RealValue();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Half()
        {
            return Reference.Half();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Double()
        {
            return Reference.Double();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Square()
        {
            return Reference.Square();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.SquareRoot()
        {
            return Reference.SquareRoot();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Exponentiate()
        {
            return Reference.Exponentiate();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Logarithm()
        {
            return Reference.Logarithm();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Sine()
        {
            return Reference.Sine();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Cosine()
        {
            return Reference.Cosine();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.Tangent()
        {
            return Reference.Tangent();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.HyperbolicSine()
        {
            return Reference.HyperbolicSine();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.HyperbolicCosine()
        {
            return Reference.HyperbolicCosine();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.HyperbolicTangent()
        {
            return Reference.HyperbolicTangent();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.ArcSine()
        {
            return Reference.ArcSine();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.ArcCosine()
        {
            return Reference.ArcCosine();
        }

        BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>>.ArcTangent()
        {
            return Reference.ArcTangent();
        }

        TInner INumber<TInner>.Half()
        {
            return Reference.Half();
        }

        TInner INumber<TInner>.Double()
        {
            return Reference.Double();
        }

        TInner INumber<TInner>.Square()
        {
            return Reference.Square();
        }

        TInner INumber<TInner>.SquareRoot()
        {
            return Reference.SquareRoot();
        }

        TInner INumber<TInner>.Exponentiate()
        {
            return Reference.Exponentiate();
        }

        TInner INumber<TInner>.Logarithm()
        {
            return Reference.Logarithm();
        }

        TInner INumber<TInner>.Sine()
        {
            return Reference.Sine();
        }

        TInner INumber<TInner>.Cosine()
        {
            return Reference.Cosine();
        }

        TInner INumber<TInner>.Tangent()
        {
            return Reference.Tangent();
        }

        TInner INumber<TInner>.HyperbolicSine()
        {
            return Reference.HyperbolicSine();
        }

        TInner INumber<TInner>.HyperbolicCosine()
        {
            return Reference.HyperbolicCosine();
        }

        TInner INumber<TInner>.HyperbolicTangent()
        {
            return Reference.HyperbolicTangent();
        }

        TInner INumber<TInner>.ArcSine()
        {
            return Reference.ArcSine();
        }

        TInner INumber<TInner>.ArcCosine()
        {
            return Reference.ArcCosine();
        }

        TInner INumber<TInner>.ArcTangent()
        {
            return Reference.ArcTangent();
        }

        public override bool Equals(object obj)
        {
            return obj is BoxedNumber<TInner, TPrimitive> value && Equals(value) || Reference.Equals(obj);
        }

        public bool Equals(BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(TInner other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(TInner other)
        {
            return Reference.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Reference.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        public override string ToString()
        {
            return Reference.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Reference.ToString(format, formatProvider);
        }

        public static implicit operator BoxedNumber<TInner, TPrimitive>(in TInner value)
        {
            return new BoxedNumber<TInner, TPrimitive>(value);
        }

        public static implicit operator TInner(BoxedNumber<TInner, TPrimitive> value)
        {
            return (TInner)value.Reference;
        }

        public static BoxedNumber<TInner, TPrimitive> operator+(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static BoxedNumber<TInner, TPrimitive> operator-(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static BoxedNumber<TInner, TPrimitive> operator*(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static BoxedNumber<TInner, TPrimitive> operator/(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static BoxedNumber<TInner, TPrimitive> operator^(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static BoxedNumber<TInner, TPrimitive> operator-(BoxedNumber<TInner, TPrimitive> a)
        {
            return a.Negate();
        }

        public static bool operator==(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<BoxedNumber<TInner, TPrimitive>> INumber<BoxedNumber<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<BoxedNumber<TInner, TPrimitive>, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<TInner> INumber<TInner>.GetFactory()
        {
            return Reference.GetFactory();
        }

        INumberFactory<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetFactory()
        {
            return Reference.GetFactory();
        }

        class Factory : INumberFactory<BoxedNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public BoxedNumber<TInner, TPrimitive> Zero => InnerFactory.Zero;
            public BoxedNumber<TInner, TPrimitive> RealOne => InnerFactory.RealOne;
            public BoxedNumber<TInner, TPrimitive> SpecialOne => InnerFactory.SpecialOne;
            public BoxedNumber<TInner, TPrimitive> UnitsOne => InnerFactory.UnitsOne;
            public BoxedNumber<TInner, TPrimitive> NonRealUnitsOne => InnerFactory.NonRealUnitsOne;
            public BoxedNumber<TInner, TPrimitive> CombinedOne => InnerFactory.CombinedOne;
            public BoxedNumber<TInner, TPrimitive> AllOne => InnerFactory.AllOne;
            INumber INumberFactory.Zero => InnerFactory.Zero;
            INumber INumberFactory.RealOne => InnerFactory.RealOne;
            INumber INumberFactory.SpecialOne => InnerFactory.SpecialOne;
            INumber INumberFactory.UnitsOne => InnerFactory.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => InnerFactory.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => InnerFactory.CombinedOne;
            INumber INumberFactory.AllOne => InnerFactory.AllOne;
            public BoxedNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
        }

        class Instance
        {
            public TInner Value;

            public Instance(in TInner value)
            {
                Value = value;
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(Reference);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Reference);

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Reference, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Reference, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Reference.IndexOf(item);
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
            return Reference.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Reference.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Reference.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Reference.GetEnumerator();
        }
    }
}
