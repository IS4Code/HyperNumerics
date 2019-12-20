using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number in a projective space where the inverse of a number is always defined (an infinity of some sort for every non-invertible number).
    /// </summary>
    /// <typeparam name="TInner">The original number type.</typeparam>
    /// <remarks>
    /// Even though taking the inverse of a number of this type is always
    /// supported, not all types of operations are possible on the result,
    /// namely multiplication with zero, addition, and subtraction.
    /// </remarks>
    [Serializable]
    public readonly struct ProjectiveNumber<TInner> : IExtendedNumber<ProjectiveNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        static readonly Lazy<INumberFactory<TInner>> InnerFactoryLazy = new Lazy<INumberFactory<TInner>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner> InnerFactory => InnerFactoryLazy.Value;
        public static ProjectiveNumber<TInner> Zero => new ProjectiveNumber<TInner>(InnerFactory.Zero);
        public static ProjectiveNumber<TInner> RealOne => new ProjectiveNumber<TInner>(InnerFactory.RealOne);
        public static ProjectiveNumber<TInner> SpecialOne => new ProjectiveNumber<TInner>(InnerFactory.SpecialOne);
        public static ProjectiveNumber<TInner> UnitsOne => new ProjectiveNumber<TInner>(InnerFactory.UnitsOne);
        public static ProjectiveNumber<TInner> NonRealUnitsOne => new ProjectiveNumber<TInner>(InnerFactory.NonRealUnitsOne);
        public static ProjectiveNumber<TInner> CombinedOne => new ProjectiveNumber<TInner>(InnerFactory.CombinedOne);
        public static ProjectiveNumber<TInner> AllOne => new ProjectiveNumber<TInner>(InnerFactory.AllOne);

        public TInner Value { get; }
        public bool IsInfinity { get; }

        public bool IsInvertible => true;

        public bool IsFinite => !IsInfinity && Value.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public ProjectiveNumber(in TInner value, bool isInfinity = false)
        {
            Value = value;
            IsInfinity = isInfinity;
        }

        public ProjectiveNumber<TInner> Clone()
        {
            return new ProjectiveNumber<TInner>(Value.Clone(), IsInfinity);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner> Add(in ProjectiveNumber<TInner> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner>(Value.Multiply(other.Value).Divide(other.Value.Add(Value)), true);
                }
                return new ProjectiveNumber<TInner>(other.Value, true);
            }
            return new ProjectiveNumber<TInner>(IsInfinity ? Value : Value.Add(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner> Subtract(in ProjectiveNumber<TInner> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner>(Value.Multiply(other.Value).Divide(other.Value.Subtract(Value)), true);
                }
                return new ProjectiveNumber<TInner>(other.Value, true);
            }
            return new ProjectiveNumber<TInner>(IsInfinity ? Value : Value.Subtract(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner> Multiply(in ProjectiveNumber<TInner> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner>(Value.Multiply(other.Value), true);
                }
                return new ProjectiveNumber<TInner>(Value.Divide(other.Value), true);
            }
            return new ProjectiveNumber<TInner>(IsInfinity ? Value.Divide(other.Value) : Value.Multiply(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner> Divide(in ProjectiveNumber<TInner> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner>(Value.Divide(other.Value));
                }
                return new ProjectiveNumber<TInner>(Value.Multiply(other.Value));
            }
            if(IsInfinity)
            {
                return new ProjectiveNumber<TInner>(Value.Multiply(other.Value), true);
            }
            if(!other.Value.IsInvertible)
            {
                return Multiply(other.Inverse());
            }
            return new ProjectiveNumber<TInner>(Value.Divide(other.Value));
        }

        public ProjectiveNumber<TInner> Power(in ProjectiveNumber<TInner> other)
        {
            if(other.IsInfinity)
            {
                throw new NotImplementedException();
            }
            return new ProjectiveNumber<TInner>(Value.Power(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner> Add(in TInner other)
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value : Value.Add(other), IsInfinity);
        }

        public ProjectiveNumber<TInner> Subtract(in TInner other)
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value : Value.Subtract(other), IsInfinity);
        }

        public ProjectiveNumber<TInner> Multiply(in TInner other)
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value.Divide(other) : Value.Multiply(other), IsInfinity);
        }

        public ProjectiveNumber<TInner> Divide(in TInner other)
        {
            if(IsInfinity)
            {
                return new ProjectiveNumber<TInner>(Value.Multiply(other), true);
            }
            if(!other.IsInvertible)
            {
                return Multiply(other.Inverse());
            }
            return new ProjectiveNumber<TInner>(Value.Divide(other));
        }

        public ProjectiveNumber<TInner> Power(in TInner other)
        {
            return new ProjectiveNumber<TInner>(Value.Power(other), IsInfinity);
        }

        public ProjectiveNumber<TInner> Negate()
        {
            return new ProjectiveNumber<TInner>(Value.Negate(), IsInfinity);
        }

        public ProjectiveNumber<TInner> Increment()
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value : Value.Increment(), IsInfinity);
        }

        public ProjectiveNumber<TInner> Decrement()
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value : Value.Decrement(), IsInfinity);
        }

        public ProjectiveNumber<TInner> Inverse()
        {
            if(!IsInfinity && Value.IsInvertible)
            {
                return new ProjectiveNumber<TInner>(Value.Inverse());
            }
            return new ProjectiveNumber<TInner>(Value, !IsInfinity);
        }

        public ProjectiveNumber<TInner> Conjugate()
        {
            return new ProjectiveNumber<TInner>(Value.Conjugate(), IsInfinity);
        }

        public ProjectiveNumber<TInner> Modulus()
        {
            return new ProjectiveNumber<TInner>(Value.Modulus(), IsInfinity);
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Half()
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value.Double() : Value.Half(), IsInfinity);
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Double()
        {
            return new ProjectiveNumber<TInner>(IsInfinity ? Value.Half() : Value.Double(), IsInfinity);
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Square()
        {
            return new ProjectiveNumber<TInner>(Value.Square(), IsInfinity);
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.SquareRoot()
        {
            return new ProjectiveNumber<TInner>(Value.SquareRoot(), IsInfinity);
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Exponentiate()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.Exponentiate());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Logarithm()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.Logarithm());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Sine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.Sine());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Cosine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.Cosine());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.Tangent()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.Tangent());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.HyperbolicSine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.HyperbolicSine());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.HyperbolicCosine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.HyperbolicCosine());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.HyperbolicTangent()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.HyperbolicTangent());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.ArcSine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.ArcSine());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.ArcCosine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.ArcCosine());
        }

        ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>>.ArcTangent()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner>(Value.ArcTangent());
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectiveNumber<TInner> value && Equals(in value);
        }

        public bool Equals(ProjectiveNumber<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in ProjectiveNumber<TInner> other)
        {
            return Value.Equals(other.Value) && IsInfinity == other.IsInfinity;
        }

        public int CompareTo(ProjectiveNumber<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in ProjectiveNumber<TInner> other)
        {
            return Value.CompareTo(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() * 17 + IsInfinity.GetHashCode();
        }

        public override string ToString()
        {
            return IsInfinity ? "Infinity(" + Value.ToString() + ")" : Value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return IsInfinity ? "Infinity(" + Value.ToString(format, formatProvider) + ")" : Value.ToString(format, formatProvider);
        }

        public static ProjectiveNumber<TInner> operator+(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Add(b);
        }

        public static ProjectiveNumber<TInner> operator-(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Subtract(b);
        }

        public static ProjectiveNumber<TInner> operator*(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Multiply(b);
        }

        public static ProjectiveNumber<TInner> operator/(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Divide(b);
        }

        public static ProjectiveNumber<TInner> operator^(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Power(b);
        }

        public static ProjectiveNumber<TInner> operator-(in ProjectiveNumber<TInner> a)
        {
            return a.Negate();
        }

        public static ProjectiveNumber<TInner> operator++(in ProjectiveNumber<TInner> a)
        {
            return a.Increment();
        }

        public static ProjectiveNumber<TInner> operator--(in ProjectiveNumber<TInner> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<ProjectiveNumber<TInner>> INumber<ProjectiveNumber<TInner>>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<ProjectiveNumber<TInner>>
        {
            public static readonly Factory Instance = new Factory();
            public ProjectiveNumber<TInner> Zero => ProjectiveNumber<TInner>.Zero;
            public ProjectiveNumber<TInner> RealOne => ProjectiveNumber<TInner>.RealOne;
            public ProjectiveNumber<TInner> SpecialOne => ProjectiveNumber<TInner>.SpecialOne;
            public ProjectiveNumber<TInner> UnitsOne => ProjectiveNumber<TInner>.UnitsOne;
            public ProjectiveNumber<TInner> NonRealUnitsOne => ProjectiveNumber<TInner>.NonRealUnitsOne;
            public ProjectiveNumber<TInner> CombinedOne => ProjectiveNumber<TInner>.CombinedOne;
            public ProjectiveNumber<TInner> AllOne => ProjectiveNumber<TInner>.AllOne;
            INumber INumberFactory.Zero => ProjectiveNumber<TInner>.Zero;
            INumber INumberFactory.RealOne => ProjectiveNumber<TInner>.RealOne;
            INumber INumberFactory.SpecialOne => ProjectiveNumber<TInner>.SpecialOne;
            INumber INumberFactory.UnitsOne => ProjectiveNumber<TInner>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => ProjectiveNumber<TInner>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => ProjectiveNumber<TInner>.CombinedOne;
            INumber INumberFactory.AllOne => ProjectiveNumber<TInner>.AllOne;
        }
    }

    /// <summary>
    /// Represents a number in a projective space where the inverse of a number is always defined (an infinity of some sort for every non-invertible number).
    /// </summary>
    /// <typeparam name="TInner">The original number type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// Even though taking the inverse of a number of this type is always
    /// supported, not all types of operations are possible on the result,
    /// namely multiplication with zero, addition, and subtraction.
    /// </remarks>
    [Serializable]
    public readonly struct ProjectiveNumber<TInner, TPrimitive> : IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        static readonly Lazy<INumberFactory<TInner, TPrimitive>> InnerFactoryLazy = new Lazy<INumberFactory<TInner, TPrimitive>>(() => default(TInner).GetFactory());
        static INumberFactory<TInner, TPrimitive> InnerFactory => InnerFactoryLazy.Value;
        public static ProjectiveNumber<TInner, TPrimitive> Zero => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.Zero);
        public static ProjectiveNumber<TInner, TPrimitive> RealOne => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.RealOne);
        public static ProjectiveNumber<TInner, TPrimitive> SpecialOne => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.SpecialOne);
        public static ProjectiveNumber<TInner, TPrimitive> UnitsOne => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.UnitsOne);
        public static ProjectiveNumber<TInner, TPrimitive> NonRealUnitsOne => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.NonRealUnitsOne);
        public static ProjectiveNumber<TInner, TPrimitive> CombinedOne => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.CombinedOne);
        public static ProjectiveNumber<TInner, TPrimitive> AllOne => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.AllOne);

        public TInner Value { get; }
        public bool IsInfinity { get; }

        public bool IsInvertible => true;

        public bool IsFinite => !IsInfinity && Value.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public ProjectiveNumber(in TInner value, bool isInfinity = false)
        {
            Value = value;
            IsInfinity = isInfinity;
        }

        public ProjectiveNumber<TInner, TPrimitive> Clone()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Clone(), IsInfinity);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner, TPrimitive> Add(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner, TPrimitive>(Value.Multiply(other.Value).Divide(other.Value.Add(Value)), true);
                }
                return new ProjectiveNumber<TInner, TPrimitive>(other.Value, true);
            }
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Add(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Subtract(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner, TPrimitive>(Value.Multiply(other.Value).Divide(other.Value.Subtract(Value)), true);
                }
                return new ProjectiveNumber<TInner, TPrimitive>(other.Value, true);
            }
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Subtract(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Multiply(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner, TPrimitive>(Value.Multiply(other.Value), true);
                }
                return new ProjectiveNumber<TInner, TPrimitive>(Value.Divide(other.Value), true);
            }
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value.Divide(other.Value) : Value.Multiply(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Divide(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            if(other.IsInfinity)
            {
                if(IsInfinity)
                {
                    return new ProjectiveNumber<TInner, TPrimitive>(Value.Divide(other.Value));
                }
                return new ProjectiveNumber<TInner, TPrimitive>(Value.Multiply(other.Value));
            }
            if(IsInfinity)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(Value.Multiply(other.Value), true);
            }
            if(!other.Value.IsInvertible)
            {
                return Multiply(other.Inverse());
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Divide(other.Value));
        }

        public ProjectiveNumber<TInner, TPrimitive> Power(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            if(other.IsInfinity)
            {
                throw new NotImplementedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Power(other.Value), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Add(in TInner other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Add(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Subtract(in TInner other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Subtract(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Multiply(in TInner other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value.Divide(other) : Value.Multiply(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Divide(in TInner other)
        {
            if(IsInfinity)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(Value.Multiply(other), true);
            }
            if(!other.IsInvertible)
            {
                return Multiply(other.Inverse());
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Divide(other));
        }

        public ProjectiveNumber<TInner, TPrimitive> Power(in TInner other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Power(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Add(TPrimitive other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Add(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Subtract(TPrimitive other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Subtract(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Multiply(TPrimitive other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value.Divide(other) : Value.Multiply(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Divide(TPrimitive other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value.Multiply(other) : Value.Divide(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Power(TPrimitive other)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Power(other), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Negate()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Negate(), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Increment()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Increment(), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Decrement()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value : Value.Decrement(), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Inverse()
        {
            if(!IsInfinity && Value.IsInvertible)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(Value.Inverse());
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value, !IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Conjugate()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Conjugate(), IsInfinity);
        }

        public ProjectiveNumber<TInner, TPrimitive> Modulus()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Modulus(), IsInfinity);
        }

        TPrimitive INumber<ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            if(IsInfinity)
            {
                throw new InvalidOperationException();
            }
            return Value.AbsoluteValue();
        }

        TPrimitive INumber<ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.RealValue()
        {
            if(IsInfinity)
            {
                throw new InvalidOperationException();
            }
            return Value.RealValue();
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Half()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value.Double() : Value.Half(), IsInfinity);
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Double()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(IsInfinity ? Value.Half() : Value.Double(), IsInfinity);
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Square()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Square(), IsInfinity);
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.SquareRoot()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(Value.SquareRoot(), IsInfinity);
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Exponentiate()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Exponentiate());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Logarithm()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Logarithm());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Sine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Sine());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Cosine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Cosine());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.Tangent()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.Tangent());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.HyperbolicSine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.HyperbolicSine());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.HyperbolicCosine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.HyperbolicCosine());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.HyperbolicTangent()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.HyperbolicTangent());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.ArcSine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.ArcSine());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.ArcCosine()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.ArcCosine());
        }

        ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>>.ArcTangent()
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return new ProjectiveNumber<TInner, TPrimitive>(Value.ArcTangent());
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectiveNumber<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(ProjectiveNumber<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            return Value.Equals(other.Value) && IsInfinity == other.IsInfinity;
        }

        public int CompareTo(ProjectiveNumber<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            return Value.CompareTo(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() * 17 + IsInfinity.GetHashCode();
        }

        public override string ToString()
        {
            return IsInfinity ? "Infinity(" + Value.ToString() + ")" : Value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return IsInfinity ? "Infinity(" + Value.ToString(format, formatProvider) + ")" : Value.ToString(format, formatProvider);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator+(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Add(b);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator-(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Subtract(b);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator*(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Multiply(b);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator/(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Divide(b);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator^(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Power(b);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator-(in ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Negate();
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator++(in ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Increment();
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator--(in ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Decrement();
        }

        public static bool operator==(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<ProjectiveNumber<TInner, TPrimitive>> INumber<ProjectiveNumber<TInner, TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<ProjectiveNumber<TInner, TPrimitive>, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<ProjectiveNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public ProjectiveNumber<TInner, TPrimitive> Zero => ProjectiveNumber<TInner, TPrimitive>.Zero;
            public ProjectiveNumber<TInner, TPrimitive> RealOne => ProjectiveNumber<TInner, TPrimitive>.RealOne;
            public ProjectiveNumber<TInner, TPrimitive> SpecialOne => ProjectiveNumber<TInner, TPrimitive>.SpecialOne;
            public ProjectiveNumber<TInner, TPrimitive> UnitsOne => ProjectiveNumber<TInner, TPrimitive>.UnitsOne;
            public ProjectiveNumber<TInner, TPrimitive> NonRealUnitsOne => ProjectiveNumber<TInner, TPrimitive>.NonRealUnitsOne;
            public ProjectiveNumber<TInner, TPrimitive> CombinedOne => ProjectiveNumber<TInner, TPrimitive>.CombinedOne;
            public ProjectiveNumber<TInner, TPrimitive> AllOne => ProjectiveNumber<TInner, TPrimitive>.AllOne;
            INumber INumberFactory.Zero => ProjectiveNumber<TInner, TPrimitive>.Zero;
            INumber INumberFactory.RealOne => ProjectiveNumber<TInner, TPrimitive>.RealOne;
            INumber INumberFactory.SpecialOne => ProjectiveNumber<TInner, TPrimitive>.SpecialOne;
            INumber INumberFactory.UnitsOne => ProjectiveNumber<TInner, TPrimitive>.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => ProjectiveNumber<TInner, TPrimitive>.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => ProjectiveNumber<TInner, TPrimitive>.CombinedOne;
            INumber INumberFactory.AllOne => ProjectiveNumber<TInner, TPrimitive>.AllOne;
            public ProjectiveNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => new ProjectiveNumber<TInner, TPrimitive>(InnerFactory.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined));
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
