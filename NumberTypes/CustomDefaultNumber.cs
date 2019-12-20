using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct CustomDefaultNumber<TInner, TTraits> : IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
    {
        static readonly TInner defaultValue = default(TTraits).DefaultValue;
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static CustomDefaultNumber<TInner, TTraits> Zero => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.Zero);
        public static CustomDefaultNumber<TInner, TTraits> RealOne => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.RealOne);
        public static CustomDefaultNumber<TInner, TTraits> SpecialOne => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.SpecialOne);
        public static CustomDefaultNumber<TInner, TTraits> UnitsOne => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.UnitsOne);
        public static CustomDefaultNumber<TInner, TTraits> NonRealUnitsOne => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.NonRealUnitsOne);
        public static CustomDefaultNumber<TInner, TTraits> CombinedOne => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.CombinedOne);
        public static CustomDefaultNumber<TInner, TTraits> AllOne => new CustomDefaultNumber<TInner, TTraits>(InnerFactory.AllOne);

        private readonly TInner value;
        private readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => Value.IsInvertible;

        public bool IsFinite => Value.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TTraits> Clone()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Value.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TTraits> Add(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Add(other.Value));
        }

        public CustomDefaultNumber<TInner, TTraits> Subtract(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Subtract(other.Value));
        }

        public CustomDefaultNumber<TInner, TTraits> Multiply(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Multiply(other.Value));
        }

        public CustomDefaultNumber<TInner, TTraits> Divide(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Divide(other.Value));
        }

        public CustomDefaultNumber<TInner, TTraits> Power(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Power(other.Value));
        }

        public CustomDefaultNumber<TInner, TTraits> Add(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Add(other));
        }

        public CustomDefaultNumber<TInner, TTraits> Subtract(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Subtract(other));
        }

        public CustomDefaultNumber<TInner, TTraits> Multiply(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Multiply(other));
        }

        public CustomDefaultNumber<TInner, TTraits> Divide(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Divide(other));
        }

        public CustomDefaultNumber<TInner, TTraits> Power(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Power(other));
        }

        TInner INumber<TInner>.Add(in TInner other)
        {
            return Value.Add(other);
        }

        TInner INumber<TInner>.Subtract(in TInner other)
        {
            return Value.Subtract(other);
        }

        TInner INumber<TInner>.Multiply(in TInner other)
        {
            return Value.Multiply(other);
        }

        TInner INumber<TInner>.Divide(in TInner other)
        {
            return Value.Divide(other);
        }

        TInner INumber<TInner>.Power(in TInner other)
        {
            return Value.Power(other);
        }

        public CustomDefaultNumber<TInner, TTraits> Negate()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Negate());
        }

        public CustomDefaultNumber<TInner, TTraits> Increment()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Increment());
        }

        public CustomDefaultNumber<TInner, TTraits> Decrement()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Decrement());
        }

        public CustomDefaultNumber<TInner, TTraits> Inverse()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Inverse());
        }

        public CustomDefaultNumber<TInner, TTraits> Conjugate()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Conjugate());
        }

        public CustomDefaultNumber<TInner, TTraits> Modulus()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Modulus());
        }

        TInner INumber<TInner>.Negate()
        {
            return Value.Negate();
        }

        TInner INumber<TInner>.Increment()
        {
            return Value.Increment();
        }

        TInner INumber<TInner>.Decrement()
        {
            return Value.Decrement();
        }

        TInner INumber<TInner>.Inverse()
        {
            return Value.Inverse();
        }

        TInner INumber<TInner>.Conjugate()
        {
            return Value.Conjugate();
        }

        TInner INumber<TInner>.Modulus()
        {
            return Value.Modulus();
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Half()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Half());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Double()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Double());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Square()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Square());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.SquareRoot()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.SquareRoot());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Exponentiate()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Exponentiate());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Logarithm()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Logarithm());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Sine()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Sine());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Cosine()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Cosine());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.Tangent()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Tangent());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.HyperbolicSine()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.HyperbolicSine());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.HyperbolicCosine()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.HyperbolicCosine());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.HyperbolicTangent()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.HyperbolicTangent());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.ArcSine()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.ArcSine());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.ArcCosine()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.ArcCosine());
        }

        CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>>.ArcTangent()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.ArcTangent());
        }

        TInner INumber<TInner>.Half()
        {
            return Value.Half();
        }

        TInner INumber<TInner>.Double()
        {
            return Value.Double();
        }

        TInner INumber<TInner>.Square()
        {
            return Value.Square();
        }

        TInner INumber<TInner>.SquareRoot()
        {
            return Value.SquareRoot();
        }

        TInner INumber<TInner>.Exponentiate()
        {
            return Value.Exponentiate();
        }

        TInner INumber<TInner>.Logarithm()
        {
            return Value.Logarithm();
        }

        TInner INumber<TInner>.Sine()
        {
            return Value.Sine();
        }

        TInner INumber<TInner>.Cosine()
        {
            return Value.Cosine();
        }

        TInner INumber<TInner>.Tangent()
        {
            return Value.Tangent();
        }

        TInner INumber<TInner>.HyperbolicSine()
        {
            return Value.HyperbolicSine();
        }

        TInner INumber<TInner>.HyperbolicCosine()
        {
            return Value.HyperbolicCosine();
        }

        TInner INumber<TInner>.HyperbolicTangent()
        {
            return Value.HyperbolicTangent();
        }

        TInner INumber<TInner>.ArcSine()
        {
            return Value.ArcSine();
        }

        TInner INumber<TInner>.ArcCosine()
        {
            return Value.ArcCosine();
        }

        TInner INumber<TInner>.ArcTangent()
        {
            return Value.ArcTangent();
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(CustomDefaultNumber<TInner, TTraits> other)
        {
            return Equals(in other);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return Value.Equals(other.Value);
        }

        public bool Equals(TInner other)
        {
            return Value.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Value.Equals(other);
        }

        public int CompareTo(CustomDefaultNumber<TInner, TTraits> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(TInner other)
        {
            return Value.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Value.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString(format, formatProvider);
        }

        public static implicit operator CustomDefaultNumber<TInner, TTraits>(in TInner value)
        {
            return new CustomDefaultNumber<TInner, TTraits>(value);
        }

        public static implicit operator TInner(in CustomDefaultNumber<TInner, TTraits> number)
        {
            return number.Value;
        }

        public static CustomDefaultNumber<TInner, TTraits> operator+(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Add(b);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator-(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Subtract(b);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator*(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Multiply(b);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator/(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Divide(b);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator^(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Power(b);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator-(in CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Negate();
        }

        public static CustomDefaultNumber<TInner, TTraits> operator++(in CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Increment();
        }

        public static CustomDefaultNumber<TInner, TTraits> operator--(in CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<CustomDefaultNumber<TInner, TTraits>> INumber<CustomDefaultNumber<TInner, TTraits>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<TInner> INumber<TInner>.GetFactory()
        {
            return Value.GetFactory();
        }

        class Factory : INumberFactory<CustomDefaultNumber<TInner, TTraits>>
        {
            public static readonly Factory Instance = new Factory();
            public CustomDefaultNumber<TInner, TTraits> Zero => CustomDefaultNumber<TInner, TTraits>.Zero;
            public CustomDefaultNumber<TInner, TTraits> RealOne => CustomDefaultNumber<TInner, TTraits>.RealOne;
            public CustomDefaultNumber<TInner, TTraits> SpecialOne => CustomDefaultNumber<TInner, TTraits>.SpecialOne;
            public CustomDefaultNumber<TInner, TTraits> UnitsOne => CustomDefaultNumber<TInner, TTraits>.UnitsOne;
            public CustomDefaultNumber<TInner, TTraits> NonRealUnitsOne => CustomDefaultNumber<TInner, TTraits>.NonRealUnitsOne;
            public CustomDefaultNumber<TInner, TTraits> CombinedOne => CustomDefaultNumber<TInner, TTraits>.CombinedOne;
            public CustomDefaultNumber<TInner, TTraits> AllOne => CustomDefaultNumber<TInner, TTraits>.AllOne;
            INumber INumberFactory.Zero => CustomDefaultNumber<TInner, TTraits>.Zero;
            INumber INumberFactory.RealOne => CustomDefaultNumber<TInner, TTraits>.RealOne;
            INumber INumberFactory.SpecialOne => CustomDefaultNumber<TInner, TTraits>.SpecialOne;
            INumber INumberFactory.UnitsOne => CustomDefaultNumber<TInner, TTraits>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => CustomDefaultNumber<TInner, TTraits>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => CustomDefaultNumber<TInner, TTraits>.CombinedOne;
            INumber INumberFactory.AllOne => CustomDefaultNumber<TInner, TTraits>.AllOne;
        }

        public interface ITraits
        {
            TInner DefaultValue { get; }
        }
    }
    
    [Serializable]
    public readonly struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>, INumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
    {
        static readonly TInner defaultValue = default(TTraits).DefaultValue;
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> Zero => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.Zero);
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> RealOne => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.RealOne);
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> SpecialOne => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.SpecialOne);
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> UnitsOne => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.UnitsOne);
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> NonRealUnitsOne => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.NonRealUnitsOne);
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> CombinedOne => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.CombinedOne);
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> AllOne => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.AllOne);

        private readonly TInner value;
        private readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => Value.IsInvertible;

        public bool IsFinite => Value.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Clone()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Value.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Add(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Add(other.Value));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Subtract(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Subtract(other.Value));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Multiply(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Multiply(other.Value));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Divide(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Divide(other.Value));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Power(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Power(other.Value));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Add(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Add(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Subtract(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Subtract(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Multiply(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Multiply(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Divide(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Divide(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Power(in TInner other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Power(other));
        }

        TInner INumber<TInner>.Add(in TInner other)
        {
            return Value.Add(other);
        }

        TInner INumber<TInner>.Subtract(in TInner other)
        {
            return Value.Subtract(other);
        }

        TInner INumber<TInner>.Multiply(in TInner other)
        {
            return Value.Multiply(other);
        }

        TInner INumber<TInner>.Divide(in TInner other)
        {
            return Value.Divide(other);
        }

        TInner INumber<TInner>.Power(in TInner other)
        {
            return Value.Power(other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Add(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Add(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Subtract(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Subtract(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Multiply(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Multiply(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Divide(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Divide(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Power(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Power(other));
        }

        TInner INumber<TInner, TPrimitive>.Add(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Add(other));
        }

        TInner INumber<TInner, TPrimitive>.Subtract(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Subtract(other));
        }

        TInner INumber<TInner, TPrimitive>.Multiply(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Multiply(other));
        }

        TInner INumber<TInner, TPrimitive>.Divide(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Divide(other));
        }

        TInner INumber<TInner, TPrimitive>.Power(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Power(other));
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Negate()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Negate());
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Increment()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Increment());
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Decrement()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Decrement());
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Inverse()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Inverse());
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Conjugate()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Conjugate());
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Modulus()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Modulus());
        }

        TInner INumber<TInner>.Negate()
        {
            return Value.Negate();
        }

        TInner INumber<TInner>.Increment()
        {
            return Value.Increment();
        }

        TInner INumber<TInner>.Decrement()
        {
            return Value.Decrement();
        }

        TInner INumber<TInner>.Inverse()
        {
            return Value.Inverse();
        }

        TInner INumber<TInner>.Conjugate()
        {
            return Value.Conjugate();
        }

        TInner INumber<TInner>.Modulus()
        {
            return Value.Modulus();
        }

        TPrimitive INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.AbsoluteValue()
        {
            return Value.AbsoluteValue();
        }

        TPrimitive INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.RealValue()
        {
            return Value.RealValue();
        }

        TPrimitive INumber<TInner, TPrimitive>.AbsoluteValue()
        {
            return Value.AbsoluteValue();
        }

        TPrimitive INumber<TInner, TPrimitive>.RealValue()
        {
            return Value.RealValue();
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Half()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Half());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Double()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Double());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.Power(TPrimitive other)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Power(other));
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Square()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Square());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.SquareRoot()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.SquareRoot());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Exponentiate()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Exponentiate());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Logarithm()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Logarithm());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Sine()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Sine());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Cosine()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Cosine());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Tangent()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Tangent());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.HyperbolicSine()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.HyperbolicSine());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.HyperbolicCosine()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.HyperbolicCosine());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.HyperbolicTangent()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.HyperbolicTangent());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.ArcSine()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.ArcSine());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.ArcCosine()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.ArcCosine());
        }

        CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.ArcTangent()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.ArcTangent());
        }

        TInner INumber<TInner>.Half()
        {
            return Value.Half();
        }

        TInner INumber<TInner>.Double()
        {
            return Value.Double();
        }

        TInner INumber<TInner>.Square()
        {
            return Value.Square();
        }

        TInner INumber<TInner>.SquareRoot()
        {
            return Value.SquareRoot();
        }

        TInner INumber<TInner>.Exponentiate()
        {
            return Value.Exponentiate();
        }

        TInner INumber<TInner>.Logarithm()
        {
            return Value.Logarithm();
        }

        TInner INumber<TInner>.Sine()
        {
            return Value.Sine();
        }

        TInner INumber<TInner>.Cosine()
        {
            return Value.Cosine();
        }

        TInner INumber<TInner>.Tangent()
        {
            return Value.Tangent();
        }

        TInner INumber<TInner>.HyperbolicSine()
        {
            return Value.HyperbolicSine();
        }

        TInner INumber<TInner>.HyperbolicCosine()
        {
            return Value.HyperbolicCosine();
        }

        TInner INumber<TInner>.HyperbolicTangent()
        {
            return Value.HyperbolicTangent();
        }

        TInner INumber<TInner>.ArcSine()
        {
            return Value.ArcSine();
        }

        TInner INumber<TInner>.ArcCosine()
        {
            return Value.ArcCosine();
        }

        TInner INumber<TInner>.ArcTangent()
        {
            return Value.ArcTangent();
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TPrimitive, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Equals(in other);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Value.Equals(other.Value);
        }

        public bool Equals(TInner other)
        {
            return Value.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Value.Equals(other);
        }

        public int CompareTo(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(TInner other)
        {
            return Value.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Value.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString(format, formatProvider);
        }

        public static implicit operator CustomDefaultNumber<TInner, TPrimitive, TTraits>(in TInner value)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(value);
        }

        public static implicit operator TInner(in CustomDefaultNumber<TInner, TPrimitive, TTraits> number)
        {
            return number.Value;
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator+(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Add(b);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator-(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Subtract(b);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator*(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Multiply(b);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator/(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Divide(b);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator^(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Power(b);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator-(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Negate();
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator++(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Increment();
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator--(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<CustomDefaultNumber<TInner, TPrimitive, TTraits>> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<TInner> INumber<TInner>.GetFactory()
        {
            return Value.GetFactory();
        }

        INumberFactory<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetFactory()
        {
            return Value.GetFactory();
        }

        class Factory : INumberFactory<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Zero => CustomDefaultNumber<TInner, TPrimitive, TTraits>.Zero;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> RealOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.RealOne;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> SpecialOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.SpecialOne;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> UnitsOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.UnitsOne;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> NonRealUnitsOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.NonRealUnitsOne;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> CombinedOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.CombinedOne;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> AllOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.AllOne;
            INumber INumberFactory.Zero => CustomDefaultNumber<TInner, TPrimitive, TTraits>.Zero;
            INumber INumberFactory.RealOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.RealOne;
            INumber INumberFactory.SpecialOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.SpecialOne;
            INumber INumberFactory.UnitsOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.CombinedOne;
            INumber INumberFactory.AllOne => CustomDefaultNumber<TInner, TPrimitive, TTraits>.AllOne;
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => new CustomDefaultNumber<TInner, TPrimitive, TTraits>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined));
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(Value);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Value);

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Value.IndexOf(item);
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
            return Value.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
