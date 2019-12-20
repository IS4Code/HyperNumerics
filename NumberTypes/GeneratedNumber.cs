using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct GeneratedNumber<TInner> : IExtendedNumber<GeneratedNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static GeneratedNumber<TInner> Zero => new GeneratedNumber<TInner>(() => InnerFactory.Zero);
        public static GeneratedNumber<TInner> RealOne => new GeneratedNumber<TInner>(() => InnerFactory.RealOne);
        public static GeneratedNumber<TInner> SpecialOne => new GeneratedNumber<TInner>(() => InnerFactory.SpecialOne);
        public static GeneratedNumber<TInner> UnitsOne => new GeneratedNumber<TInner>(() => InnerFactory.UnitsOne);
        public static GeneratedNumber<TInner> NonRealUnitsOne => new GeneratedNumber<TInner>(() => InnerFactory.NonRealUnitsOne);
        public static GeneratedNumber<TInner> CombinedOne => new GeneratedNumber<TInner>(() => InnerFactory.CombinedOne);
        public static GeneratedNumber<TInner> AllOne => new GeneratedNumber<TInner>(() => InnerFactory.AllOne);

        private readonly Func<TInner> generator;

        public Func<TInner> Generator => generator ?? Zero.Generator;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public GeneratedNumber(TInner value)
        {
            this.generator = () => value;
        }

        public GeneratedNumber(Func<TInner> generator)
        {
            this.generator = generator;
        }

        public GeneratedNumber<TInner> Clone()
        {
            if(generator.Target is ICloneable cloneable)
            {
                return new GeneratedNumber<TInner>((Func<TInner>)Delegate.CreateDelegate(typeof(Func<TInner>), cloneable.Clone(), generator.Method));
            }
            return this;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner> Add(in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => gen1().Add(gen2()));
        }

        public GeneratedNumber<TInner> Subtract(in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => gen1().Subtract(gen2()));
        }

        public GeneratedNumber<TInner> Multiply(in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => gen1().Multiply(gen2()));
        }

        public GeneratedNumber<TInner> Divide(in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => gen1().Divide(gen2()));
        }

        public GeneratedNumber<TInner> Power(in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => gen1().Power(gen2()));
        }

        public GeneratedNumber<TInner> Add(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => gen().Add(value));
        }

        public GeneratedNumber<TInner> Subtract(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => gen().Subtract(value));
        }

        public GeneratedNumber<TInner> Multiply(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => gen().Multiply(value));
        }

        public GeneratedNumber<TInner> Divide(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => gen().Divide(value));
        }

        public GeneratedNumber<TInner> Power(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => gen().Power(value));
        }

        public GeneratedNumber<TInner> Negate()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Negate());
        }

        public GeneratedNumber<TInner> Increment()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Increment());
        }

        public GeneratedNumber<TInner> Decrement()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Decrement());
        }

        public GeneratedNumber<TInner> Inverse()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Inverse());
        }

        public GeneratedNumber<TInner> Conjugate()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Conjugate());
        }

        public GeneratedNumber<TInner> Modulus()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Modulus());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Half()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Half());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Double()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Double());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Square()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Square());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.SquareRoot()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().SquareRoot());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Exponentiate()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Exponentiate());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Logarithm()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Logarithm());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Sine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Sine());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Cosine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Cosine());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.Tangent()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().Tangent());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.HyperbolicSine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().HyperbolicSine());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.HyperbolicCosine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().HyperbolicCosine());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.HyperbolicTangent()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().HyperbolicTangent());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.ArcSine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().ArcSine());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.ArcCosine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().ArcCosine());
        }

        GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>>.ArcTangent()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => gen().ArcTangent());
        }

        public override bool Equals(object obj)
        {
            return obj is GeneratedNumber<TInner> value && Equals(in value);
        }

        public bool Equals(GeneratedNumber<TInner> other)
        {
            return Generator.Equals(other.Generator);
        }

        public bool Equals(in GeneratedNumber<TInner> other)
        {
            return Generator.Equals(other.Generator);
        }

        public int CompareTo(GeneratedNumber<TInner> other)
        {
            return 0;
        }

        public int CompareTo(in GeneratedNumber<TInner> other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Generator.GetHashCode();
        }

        public override string ToString()
        {
            return Generator.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Generator.ToString();
        }

        public static implicit operator GeneratedNumber<TInner>(in TInner value)
        {
            return new GeneratedNumber<TInner>(value);
        }

        public static GeneratedNumber<TInner> operator+(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Add(b);
        }

        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Subtract(b);
        }

        public static GeneratedNumber<TInner> operator*(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Multiply(b);
        }

        public static GeneratedNumber<TInner> operator/(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Divide(b);
        }

        public static GeneratedNumber<TInner> operator^(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Power(b);
        }

        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a)
        {
            return a.Negate();
        }

        public static GeneratedNumber<TInner> operator++(GeneratedNumber<TInner> a)
        {
            return a.Increment();
        }

        public static GeneratedNumber<TInner> operator--(GeneratedNumber<TInner> a)
        {
            return a.Decrement();
        }

        public static bool operator==(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<GeneratedNumber<TInner>> INumber<GeneratedNumber<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<GeneratedNumber<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public GeneratedNumber<TInner> Zero => GeneratedNumber<TInner>.Zero;
            public GeneratedNumber<TInner> RealOne => GeneratedNumber<TInner>.RealOne;
            public GeneratedNumber<TInner> SpecialOne => GeneratedNumber<TInner>.SpecialOne;
            public GeneratedNumber<TInner> UnitsOne => GeneratedNumber<TInner>.UnitsOne;
            public GeneratedNumber<TInner> NonRealUnitsOne => GeneratedNumber<TInner>.NonRealUnitsOne;
            public GeneratedNumber<TInner> CombinedOne => GeneratedNumber<TInner>.CombinedOne;
            public GeneratedNumber<TInner> AllOne => GeneratedNumber<TInner>.AllOne;
            INumber INumberFactory.Zero => GeneratedNumber<TInner>.Zero;
            INumber INumberFactory.RealOne => GeneratedNumber<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => GeneratedNumber<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => GeneratedNumber<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => GeneratedNumber<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => GeneratedNumber<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => GeneratedNumber<TInner>.AllOne;
        }
    }
    
    [Serializable]
    public readonly struct GeneratedNumber<TInner, TPrimitive> : IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static GeneratedNumber<TInner, TPrimitive> Zero => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.Zero);
        public static GeneratedNumber<TInner, TPrimitive> RealOne => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.RealOne);
        public static GeneratedNumber<TInner, TPrimitive> SpecialOne => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.SpecialOne);
        public static GeneratedNumber<TInner, TPrimitive> UnitsOne => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.UnitsOne);
        public static GeneratedNumber<TInner, TPrimitive> NonRealUnitsOne => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne);
        public static GeneratedNumber<TInner, TPrimitive> CombinedOne => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.CombinedOne);
        public static GeneratedNumber<TInner, TPrimitive> AllOne => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.AllOne);

        private readonly Func<TInner> generator;

        public Func<TInner> Generator => generator ?? Zero.Generator;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;

        public GeneratedNumber(TInner value)
        {
            this.generator = () => value;
        }

        public GeneratedNumber(Func<TInner> generator)
        {
            this.generator = generator;
        }

        public GeneratedNumber<TInner, TPrimitive> Clone()
        {
            if(generator.Target is ICloneable cloneable)
            {
                return new GeneratedNumber<TInner, TPrimitive>((Func<TInner>)Delegate.CreateDelegate(typeof(Func<TInner>), cloneable.Clone(), generator.Method));
            }
            return this;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner, TPrimitive> Add(in GeneratedNumber<TInner, TPrimitive> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen1().Add(gen2()));
        }

        public GeneratedNumber<TInner, TPrimitive> Subtract(in GeneratedNumber<TInner, TPrimitive> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen1().Subtract(gen2()));
        }

        public GeneratedNumber<TInner, TPrimitive> Multiply(in GeneratedNumber<TInner, TPrimitive> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen1().Multiply(gen2()));
        }

        public GeneratedNumber<TInner, TPrimitive> Divide(in GeneratedNumber<TInner, TPrimitive> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen1().Divide(gen2()));
        }

        public GeneratedNumber<TInner, TPrimitive> Power(in GeneratedNumber<TInner, TPrimitive> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen1().Power(gen2()));
        }

        public GeneratedNumber<TInner, TPrimitive> Add(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Add(value));
        }

        public GeneratedNumber<TInner, TPrimitive> Subtract(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Subtract(value));
        }

        public GeneratedNumber<TInner, TPrimitive> Multiply(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Multiply(value));
        }

        public GeneratedNumber<TInner, TPrimitive> Divide(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Divide(value));
        }

        public GeneratedNumber<TInner, TPrimitive> Power(in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Power(value));
        }

        public GeneratedNumber<TInner, TPrimitive> Add(TPrimitive other)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Add(other));
        }

        public GeneratedNumber<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Subtract(other));
        }

        public GeneratedNumber<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Multiply(other));
        }

        public GeneratedNumber<TInner, TPrimitive> Divide(TPrimitive other)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Divide(other));
        }

        public GeneratedNumber<TInner, TPrimitive> Power(TPrimitive other)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Power(other));
        }

        public GeneratedNumber<TInner, TPrimitive> Negate()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Negate());
        }

        public GeneratedNumber<TInner, TPrimitive> Increment()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Increment());
        }

        public GeneratedNumber<TInner, TPrimitive> Decrement()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Decrement());
        }

        public GeneratedNumber<TInner, TPrimitive> Inverse()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Inverse());
        }

        public GeneratedNumber<TInner, TPrimitive> Conjugate()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Conjugate());
        }

        public GeneratedNumber<TInner, TPrimitive> Modulus()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Modulus());
        }

        TPrimitive INumber<GeneratedNumber<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return Generator().AbsoluteValue();
        }

        TPrimitive INumber<GeneratedNumber<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            return Generator().RealValue();
        }
        
        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Half()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Half());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Double()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Double());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Square()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Square());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.SquareRoot()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().SquareRoot());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Exponentiate()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Exponentiate());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Logarithm()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Logarithm());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Sine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Sine());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Cosine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Cosine());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.Tangent()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().Tangent());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.HyperbolicSine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().HyperbolicSine());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.HyperbolicCosine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().HyperbolicCosine());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.HyperbolicTangent()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().HyperbolicTangent());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.ArcSine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().ArcSine());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.ArcCosine()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().ArcCosine());
        }

        GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>>.ArcTangent()
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => gen().ArcTangent());
        }

        public override bool Equals(object obj)
        {
            return obj is GeneratedNumber<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(GeneratedNumber<TInner, TPrimitive> other)
        {
            return Generator.Equals(other.Generator);
        }

        public bool Equals(in GeneratedNumber<TInner, TPrimitive> other)
        {
            return Generator.Equals(other.Generator);
        }

        public int CompareTo(GeneratedNumber<TInner, TPrimitive> other)
        {
            return 0;
        }

        public int CompareTo(in GeneratedNumber<TInner, TPrimitive> other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Generator.GetHashCode();
        }

        public override string ToString()
        {
            return Generator.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Generator.ToString();
        }

        public static implicit operator GeneratedNumber<TInner, TPrimitive>(in TInner value)
        {
            return new GeneratedNumber<TInner, TPrimitive>(value);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator+(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator-(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator*(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator/(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator^(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator-(in GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Negate();
        }

        public static GeneratedNumber<TInner, TPrimitive> operator++(in GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Increment();
        }

        public static GeneratedNumber<TInner, TPrimitive> operator--(in GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<GeneratedNumber<TInner, TPrimitive>> INumber<GeneratedNumber<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<GeneratedNumber<TInner, TPrimitive>, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<GeneratedNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public GeneratedNumber<TInner, TPrimitive> Zero => GeneratedNumber<TInner, TPrimitive>.Zero;
            public GeneratedNumber<TInner, TPrimitive> RealOne => GeneratedNumber<TInner, TPrimitive>.RealOne;
            public GeneratedNumber<TInner, TPrimitive> SpecialOne => GeneratedNumber<TInner, TPrimitive>.SpecialOne;
            public GeneratedNumber<TInner, TPrimitive> UnitsOne => GeneratedNumber<TInner, TPrimitive>.UnitsOne;
            public GeneratedNumber<TInner, TPrimitive> NonRealUnitsOne => GeneratedNumber<TInner, TPrimitive>.NonRealUnitsOne;
            public GeneratedNumber<TInner, TPrimitive> CombinedOne => GeneratedNumber<TInner, TPrimitive>.CombinedOne;
            public GeneratedNumber<TInner, TPrimitive> AllOne => GeneratedNumber<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => GeneratedNumber<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => GeneratedNumber<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => GeneratedNumber<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => GeneratedNumber<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => GeneratedNumber<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => GeneratedNumber<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => GeneratedNumber<TInner, TPrimitive>.AllOne;
            public GeneratedNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => new GeneratedNumber<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined));
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(Generator());

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Generator());

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Generator(), index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Generator(), index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Generator().IndexOf(item);
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
            return Generator().Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Generator().CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Generator().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Generator().GetEnumerator();
        }
    }
}
