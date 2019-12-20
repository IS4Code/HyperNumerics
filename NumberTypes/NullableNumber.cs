using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct NullableNumber<TInner> : IExtendedNumber<NullableNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static NullableNumber<TInner> Zero => new NullableNumber<TInner>(InnerFactory.Zero);
        public static NullableNumber<TInner> RealOne => new NullableNumber<TInner>(InnerFactory.RealOne);
        public static NullableNumber<TInner> SpecialOne => new NullableNumber<TInner>(InnerFactory.SpecialOne);
        public static NullableNumber<TInner> UnitsOne => new NullableNumber<TInner>(InnerFactory.UnitsOne);
        public static NullableNumber<TInner> NonRealUnitsOne => new NullableNumber<TInner>(InnerFactory.NonRealUnitsOne);
        public static NullableNumber<TInner> CombinedOne => new NullableNumber<TInner>(InnerFactory.CombinedOne);
        public static NullableNumber<TInner> AllOne => new NullableNumber<TInner>(InnerFactory.AllOne);

        public TInner? Value { get; }

        public bool IsInvertible => Value?.IsInvertible ?? true;

        public bool IsFinite => Value?.IsFinite ?? true;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public NullableNumber(in TInner value)
        {
            Value = value;
        }

        public NullableNumber(in TInner? value)
        {
            Value = value;
        }

        public NullableNumber<TInner> Clone()
        {
            return new NullableNumber<TInner>(Value?.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner> Add(in NullableNumber<TInner> other)
        {
            return new NullableNumber<TInner>(other.Value.HasValue ? Value?.Add(other.Value.Value) : null);
        }

        public NullableNumber<TInner> Subtract(in NullableNumber<TInner> other)
        {
            return new NullableNumber<TInner>(other.Value.HasValue ? Value?.Subtract(other.Value.Value) : null);
        }

        public NullableNumber<TInner> Multiply(in NullableNumber<TInner> other)
        {
            return new NullableNumber<TInner>(other.Value.HasValue ? Value?.Multiply(other.Value.Value) : null);
        }

        public NullableNumber<TInner> Divide(in NullableNumber<TInner> other)
        {
            return new NullableNumber<TInner>(other.Value.HasValue ? Value?.Divide(other.Value.Value) : null);
        }

        public NullableNumber<TInner> Power(in NullableNumber<TInner> other)
        {
            return new NullableNumber<TInner>(other.Value.HasValue ? Value?.Power(other.Value.Value) : null);
        }

        public NullableNumber<TInner> Add(in TInner other)
        {
            return new NullableNumber<TInner>(Value?.Add(other));
        }

        public NullableNumber<TInner> Subtract(in TInner other)
        {
            return new NullableNumber<TInner>(Value?.Subtract(other));
        }

        public NullableNumber<TInner> Multiply(in TInner other)
        {
            return new NullableNumber<TInner>(Value?.Multiply(other));
        }

        public NullableNumber<TInner> Divide(in TInner other)
        {
            return new NullableNumber<TInner>(Value?.Divide(other));
        }

        public NullableNumber<TInner> Power(in TInner other)
        {
            return new NullableNumber<TInner>(Value?.Power(other));
        }

        public NullableNumber<TInner> Negate()
        {
            return new NullableNumber<TInner>(Value?.Negate());
        }

        public NullableNumber<TInner> Increment()
        {
            return new NullableNumber<TInner>(Value?.Increment());
        }

        public NullableNumber<TInner> Decrement()
        {
            return new NullableNumber<TInner>(Value?.Decrement());
        }

        public NullableNumber<TInner> Inverse()
        {
            return new NullableNumber<TInner>(Value?.Inverse());
        }

        public NullableNumber<TInner> Conjugate()
        {
            return new NullableNumber<TInner>(Value?.Conjugate());
        }

        public NullableNumber<TInner> Modulus()
        {
            return new NullableNumber<TInner>(Value?.Modulus());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Half()
        {
            return new NullableNumber<TInner>(Value?.Half());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Double()
        {
            return new NullableNumber<TInner>(Value?.Double());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Square()
        {
            return new NullableNumber<TInner>(Value?.Square());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.SquareRoot()
        {
            return new NullableNumber<TInner>(Value?.SquareRoot());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Exponentiate()
        {
            return new NullableNumber<TInner>(Value?.Exponentiate());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Logarithm()
        {
            return new NullableNumber<TInner>(Value?.Logarithm());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Sine()
        {
            return new NullableNumber<TInner>(Value?.Sine());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Cosine()
        {
            return new NullableNumber<TInner>(Value?.Cosine());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.Tangent()
        {
            return new NullableNumber<TInner>(Value?.Tangent());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.HyperbolicSine()
        {
            return new NullableNumber<TInner>(Value?.HyperbolicSine());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.HyperbolicCosine()
        {
            return new NullableNumber<TInner>(Value?.HyperbolicCosine());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.HyperbolicTangent()
        {
            return new NullableNumber<TInner>(Value?.HyperbolicTangent());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.ArcSine()
        {
            return new NullableNumber<TInner>(Value?.ArcSine());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.ArcCosine()
        {
            return new NullableNumber<TInner>(Value?.ArcCosine());
        }

        NullableNumber<TInner> INumber<NullableNumber<TInner>>.ArcTangent()
        {
            return new NullableNumber<TInner>(Value?.ArcTangent());
        }

        public override bool Equals(object obj)
        {
            return obj is NullableNumber<TInner> value && Equals(in value);
        }

        public bool Equals(NullableNumber<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in NullableNumber<TInner> other)
        {
            return Value.HasValue ? other.Value.HasValue && Value.Value.Equals(other.Value.Value) : !other.Value.HasValue;
        }

        public int CompareTo(NullableNumber<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in NullableNumber<TInner> other)
        {
            return Value.HasValue ? (other.Value.HasValue ? Value.Value.CompareTo(other.Value.Value) : 1) : (other.Value.HasValue ? -1 : 0);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString() : "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.HasValue ? Value.Value.ToString(format, formatProvider) : "Null";
        }

        public static implicit operator NullableNumber<TInner>(in TInner value)
        {
            return new NullableNumber<TInner>(value);
        }

        public static NullableNumber<TInner> operator+(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Add(b);
        }

        public static NullableNumber<TInner> operator-(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Subtract(b);
        }

        public static NullableNumber<TInner> operator*(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Multiply(b);
        }

        public static NullableNumber<TInner> operator/(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Divide(b);
        }

        public static NullableNumber<TInner> operator^(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Power(b);
        }

        public static NullableNumber<TInner> operator-(in NullableNumber<TInner> a)
        {
            return a.Negate();
        }

        public static NullableNumber<TInner> operator++(in NullableNumber<TInner> a)
        {
            return a.Increment();
        }

        public static NullableNumber<TInner> operator--(in NullableNumber<TInner> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<NullableNumber<TInner>> INumber<NullableNumber<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<NullableNumber<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public NullableNumber<TInner> Zero => NullableNumber<TInner>.Zero;
            public NullableNumber<TInner> RealOne => NullableNumber<TInner>.RealOne;
            public NullableNumber<TInner> SpecialOne => NullableNumber<TInner>.SpecialOne;
            public NullableNumber<TInner> UnitsOne => NullableNumber<TInner>.UnitsOne;
            public NullableNumber<TInner> NonRealUnitsOne => NullableNumber<TInner>.NonRealUnitsOne;
            public NullableNumber<TInner> CombinedOne => NullableNumber<TInner>.CombinedOne;
            public NullableNumber<TInner> AllOne => NullableNumber<TInner>.AllOne;
            INumber INumberFactory.Zero => NullableNumber<TInner>.Zero;
            INumber INumberFactory.RealOne => NullableNumber<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => NullableNumber<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => NullableNumber<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => NullableNumber<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => NullableNumber<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => NullableNumber<TInner>.AllOne;
        }

        public interface ITraits
        {
            TInner DefaultValue { get; }
        }
    }
    
    [Serializable]
    public readonly struct NullableNumber<TInner, TPrimitive> : IExtendedNumber<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static NullableNumber<TInner, TPrimitive> Zero => new NullableNumber<TInner, TPrimitive>(InnerFactory.Zero);
        public static NullableNumber<TInner, TPrimitive> RealOne => new NullableNumber<TInner, TPrimitive>(InnerFactory.RealOne);
        public static NullableNumber<TInner, TPrimitive> SpecialOne => new NullableNumber<TInner, TPrimitive>(InnerFactory.SpecialOne);
        public static NullableNumber<TInner, TPrimitive> UnitsOne => new NullableNumber<TInner, TPrimitive>(InnerFactory.UnitsOne);
        public static NullableNumber<TInner, TPrimitive> NonRealUnitsOne => new NullableNumber<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne);
        public static NullableNumber<TInner, TPrimitive> CombinedOne => new NullableNumber<TInner, TPrimitive>(InnerFactory.CombinedOne);
        public static NullableNumber<TInner, TPrimitive> AllOne => new NullableNumber<TInner, TPrimitive>(InnerFactory.AllOne);

        public TInner? Value { get; }

        public bool IsInvertible => Value?.IsInvertible ?? true;

        public bool IsFinite => Value?.IsFinite ?? true;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public NullableNumber(in TInner value)
        {
            Value = value;
        }

        public NullableNumber(in TInner? value)
        {
            Value = value;
        }

        public NullableNumber<TInner, TPrimitive> Clone()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner, TPrimitive> Add(in NullableNumber<TInner, TPrimitive> other)
        {
            return new NullableNumber<TInner, TPrimitive>(other.Value.HasValue ? Value?.Add(other.Value.Value) : null);
        }

        public NullableNumber<TInner, TPrimitive> Subtract(in NullableNumber<TInner, TPrimitive> other)
        {
            return new NullableNumber<TInner, TPrimitive>(other.Value.HasValue ? Value?.Subtract(other.Value.Value) : null);
        }

        public NullableNumber<TInner, TPrimitive> Multiply(in NullableNumber<TInner, TPrimitive> other)
        {
            return new NullableNumber<TInner, TPrimitive>(other.Value.HasValue ? Value?.Multiply(other.Value.Value) : null);
        }

        public NullableNumber<TInner, TPrimitive> Divide(in NullableNumber<TInner, TPrimitive> other)
        {
            return new NullableNumber<TInner, TPrimitive>(other.Value.HasValue ? Value?.Divide(other.Value.Value) : null);
        }

        public NullableNumber<TInner, TPrimitive> Power(in NullableNumber<TInner, TPrimitive> other)
        {
            return new NullableNumber<TInner, TPrimitive>(other.Value.HasValue ? Value?.Power(other.Value.Value) : null);
        }

        public NullableNumber<TInner, TPrimitive> Add(in TInner other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Add(other));
        }

        public NullableNumber<TInner, TPrimitive> Subtract(in TInner other)
        {
            return new NullableNumber<TInner, TPrimitive>( Value?.Subtract(other));
        }

        public NullableNumber<TInner, TPrimitive> Multiply(in TInner other)
        {
            return new NullableNumber<TInner, TPrimitive>( Value?.Multiply(other));
        }

        public NullableNumber<TInner, TPrimitive> Divide(in TInner other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Divide(other));
        }

        public NullableNumber<TInner, TPrimitive> Power(in TInner other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Power(other));
        }

        public NullableNumber<TInner, TPrimitive> Add(TPrimitive other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Add(other));
        }

        public NullableNumber<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Subtract(other));
        }

        public NullableNumber<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Multiply(other));
        }

        public NullableNumber<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Divide(other));
        }

        public NullableNumber<TInner, TPrimitive> Power(TPrimitive other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Power(other));
        }

        public NullableNumber<TInner, TPrimitive> Negate()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Negate());
        }

        public NullableNumber<TInner, TPrimitive> Increment()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Increment());
        }

        public NullableNumber<TInner, TPrimitive> Decrement()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Decrement());
        }

        public NullableNumber<TInner, TPrimitive> Inverse()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Inverse());
        }

        public NullableNumber<TInner, TPrimitive> Conjugate()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Conjugate());
        }

        public NullableNumber<TInner, TPrimitive> Modulus()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Modulus());
        }

        TPrimitive INumber<NullableNumber<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return Value?.AbsoluteValue() ?? default;
        }

        TPrimitive INumber<NullableNumber<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return Value?.RealValue() ?? default;
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Half()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Half());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Double()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Double());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>, TPrimitive>.Power(TPrimitive other)
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Power(other));
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Square()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Square());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.SquareRoot()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.SquareRoot());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Exponentiate()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Exponentiate());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Logarithm()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Logarithm());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Sine()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Sine());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Cosine()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Cosine());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.Tangent()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Tangent());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.HyperbolicSine()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.HyperbolicSine());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.HyperbolicCosine()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.HyperbolicCosine());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.HyperbolicTangent()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.HyperbolicTangent());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.ArcSine()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.ArcSine());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.ArcCosine()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.ArcCosine());
        }

        NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>>.ArcTangent()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.ArcTangent());
        }

        public override bool Equals(object obj)
        {
            return obj is NullableNumber<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(NullableNumber<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in NullableNumber<TInner, TPrimitive> other)
        {
            return Value.HasValue ? other.Value.HasValue && Value.Value.Equals(other.Value.Value) : !other.Value.HasValue;
        }

        public int CompareTo(NullableNumber<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in NullableNumber<TInner, TPrimitive> other)
        {
            return Value.HasValue ? (other.Value.HasValue ? Value.Value.CompareTo(other.Value.Value) : 1) : (other.Value.HasValue ? -1 : 0);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString() : "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.HasValue ? Value.Value.ToString(format, formatProvider) : "Null";
        }

        public static implicit operator NullableNumber<TInner, TPrimitive>(in TInner value)
        {
            return new NullableNumber<TInner, TPrimitive>(value);
        }

        public static NullableNumber<TInner, TPrimitive> operator+(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static NullableNumber<TInner, TPrimitive> operator-(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static NullableNumber<TInner, TPrimitive> operator*(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static NullableNumber<TInner, TPrimitive> operator/(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static NullableNumber<TInner, TPrimitive> operator^(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static NullableNumber<TInner, TPrimitive> operator-(in NullableNumber<TInner, TPrimitive> a)
        {
            return a.Negate();
        }

        public static NullableNumber<TInner, TPrimitive> operator++(in NullableNumber<TInner, TPrimitive> a)
        {
            return a.Increment();
        }

        public static NullableNumber<TInner, TPrimitive> operator--(in NullableNumber<TInner, TPrimitive> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<NullableNumber<TInner, TPrimitive>> INumber<NullableNumber<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<NullableNumber<TInner, TPrimitive>, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<NullableNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public NullableNumber<TInner, TPrimitive> Zero => NullableNumber<TInner, TPrimitive>.Zero;
            public NullableNumber<TInner, TPrimitive> RealOne => NullableNumber<TInner, TPrimitive>.RealOne;
            public NullableNumber<TInner, TPrimitive> SpecialOne => NullableNumber<TInner, TPrimitive>.SpecialOne;
            public NullableNumber<TInner, TPrimitive> UnitsOne => NullableNumber<TInner, TPrimitive>.UnitsOne;
            public NullableNumber<TInner, TPrimitive> NonRealUnitsOne => NullableNumber<TInner, TPrimitive>.NonRealUnitsOne;
            public NullableNumber<TInner, TPrimitive> CombinedOne => NullableNumber<TInner, TPrimitive>.CombinedOne;
            public NullableNumber<TInner, TPrimitive> AllOne => NullableNumber<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => NullableNumber<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => NullableNumber<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => NullableNumber<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => NullableNumber<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => NullableNumber<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => NullableNumber<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => NullableNumber<TInner, TPrimitive>.AllOne;
            public NullableNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => new NullableNumber<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined));
        }

        public interface ITraits
        {
            TInner DefaultValue { get; }
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

        int ICollection<TPrimitive>.Count => Value.HasValue ? GetCollectionCount(Value.Value) : 0;

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => Value.HasValue ? GetReadOnlyCollectionCount(Value.Value) : 0;

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                if(!Value.HasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetReadOnlyListItem(Value.Value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get {
                if(!Value.HasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetListItem(Value.Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Value?.IndexOf(item) ?? -1;
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
            return Value?.Contains(item) ?? false;
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Value?.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Value?.GetEnumerator() ?? Enumerable.Empty<TPrimitive>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value?.GetEnumerator() ?? Enumerable.Empty<TPrimitive>().GetEnumerator();
        }
    }
}
