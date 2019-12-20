using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number type with a single value which is the result of all operations.
    /// </summary>
    [Serializable]
    public readonly struct NullNumber : INumber<NullNumber>
    {
        public static readonly NullNumber Value = default;

        int INumber.Dimension => 0;

        bool INumber.IsInvertible => true;

        bool INumber.IsFinite => true;

        NullNumber INumber<NullNumber>.Clone()
        {
            return default;
        }

        object ICloneable.Clone()
        {
            return default(NullNumber);
        }

        public NullNumber Add(in NullNumber other)
        {
            return default;
        }

        public NullNumber Subtract(in NullNumber other)
        {
            return default;
        }

        public NullNumber Multiply(in NullNumber other)
        {
            return default;
        }

        public NullNumber Divide(in NullNumber other)
        {
            return default;
        }

        public NullNumber Power(in NullNumber other)
        {
            return default;
        }

        public NullNumber Negate()
        {
            return default;
        }

        public NullNumber Increment()
        {
            return default;
        }

        public NullNumber Decrement()
        {
            return default;
        }

        public NullNumber Inverse()
        {
            return default;
        }

        public NullNumber Conjugate()
        {
            return default;
        }

        public NullNumber Modulus()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Half()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Double()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Square()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.SquareRoot()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Exponentiate()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Logarithm()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Sine()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Cosine()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.Tangent()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.HyperbolicSine()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.HyperbolicCosine()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.HyperbolicTangent()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.ArcSine()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.ArcCosine()
        {
            return default;
        }

        NullNumber INumber<NullNumber>.ArcTangent()
        {
            return default;
        }

        public override bool Equals(object obj)
        {
            return obj is NullNumber value;
        }

        public bool Equals(NullNumber other)
        {
            return true;
        }

        public bool Equals(in NullNumber other)
        {
            return true;
        }

        public int CompareTo(NullNumber other)
        {
            return 0;
        }

        public int CompareTo(in NullNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Null";
        }

        public static NullNumber operator+(NullNumber a, NullNumber b)
        {
            return default;
        }

        public static NullNumber operator-(NullNumber a, NullNumber b)
        {
            return default;
        }

        public static NullNumber operator*(NullNumber a, NullNumber b)
        {
            return default;
        }

        public static NullNumber operator/(NullNumber a, NullNumber b)
        {
            return default;
        }

        public static NullNumber operator-(NullNumber a)
        {
            return default;
        }

        public static bool operator==(NullNumber a, NullNumber b)
        {
            return true;
        }

        public static bool operator!=(NullNumber a, NullNumber b)
        {
            return false;
        }

        public static bool operator>(NullNumber a, NullNumber b)
        {
            return false;
        }

        public static bool operator<(NullNumber a, NullNumber b)
        {
            return false;
        }

        public static bool operator>=(NullNumber a, NullNumber b)
        {
            return true;
        }

        public static bool operator<=(NullNumber a, NullNumber b)
        {
            return true;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<NullNumber> INumber<NullNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<NullNumber>
        {
            public static readonly Factory Instance = new Factory();
            public NullNumber Zero => default;
            public NullNumber RealOne => default;
            public NullNumber SpecialOne => default;
            public NullNumber UnitsOne => default;
            public NullNumber NonRealUnitsOne => default;
            public NullNumber CombinedOne => default;
            public NullNumber AllOne => default;
            static readonly INumber Default = default(NullNumber);
            INumber INumberFactory.Zero => Default;
            INumber INumberFactory.RealOne => Default;
            INumber INumberFactory.SpecialOne => Default;
            INumber INumberFactory.UnitsOne => Default;
            INumber INumberFactory.NonRealUnitsOne => Default;
            INumber INumberFactory.CombinedOne => Default;
            INumber INumberFactory.AllOne => Default;
        }
    }

    /// <summary>
    /// Represents a number type with a single value which is the result of all operations.
    /// </summary>
    /// <typeparam name="TPrimitive">The primitive type the number mimics, but doesn't actually store.</typeparam>
    [Serializable]
    public readonly struct NullNumber<TPrimitive> : INumber<NullNumber<TPrimitive>, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public static readonly NullNumber<TPrimitive> Value = default;

        int INumber.Dimension => 0;

        bool INumber.IsInvertible => true;

        bool INumber.IsFinite => true;

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Clone()
        {
            return default;
        }

        object ICloneable.Clone()
        {
            return default(NullNumber<TPrimitive>);
        }

        public NullNumber<TPrimitive> Add(in NullNumber<TPrimitive> other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Subtract(in NullNumber<TPrimitive> other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Multiply(in NullNumber<TPrimitive> other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Divide(in NullNumber<TPrimitive> other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Power(in NullNumber<TPrimitive> other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Add(TPrimitive other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Subtract(TPrimitive other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Multiply(TPrimitive other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Divide(TPrimitive other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Power(TPrimitive other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Negate()
        {
            return default;
        }

        public NullNumber<TPrimitive> Increment()
        {
            return default;
        }

        public NullNumber<TPrimitive> Decrement()
        {
            return default;
        }

        public NullNumber<TPrimitive> Inverse()
        {
            return default;
        }

        public NullNumber<TPrimitive> Conjugate()
        {
            return default;
        }

        public NullNumber<TPrimitive> Modulus()
        {
            return default;
        }

        TPrimitive INumber<NullNumber<TPrimitive>, TPrimitive>.AbsoluteValue()
        {
            return default;
        }

        TPrimitive INumber<NullNumber<TPrimitive>, TPrimitive>.RealValue()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Half()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Double()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>, TPrimitive>.Power(TPrimitive other)
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Square()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.SquareRoot()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Exponentiate()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Logarithm()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Sine()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Cosine()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.Tangent()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.HyperbolicSine()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.HyperbolicCosine()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.HyperbolicTangent()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.ArcSine()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.ArcCosine()
        {
            return default;
        }

        NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>>.ArcTangent()
        {
            return default;
        }

        public override bool Equals(object obj)
        {
            return obj is NullNumber<TPrimitive> value;
        }

        public bool Equals(NullNumber<TPrimitive> other)
        {
            return true;
        }

        public bool Equals(in NullNumber<TPrimitive> other)
        {
            return true;
        }

        public int CompareTo(NullNumber<TPrimitive> other)
        {
            return 0;
        }

        public int CompareTo(in NullNumber<TPrimitive> other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Null";
        }

        public static NullNumber<TPrimitive> operator+(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return default;
        }

        public static NullNumber<TPrimitive> operator-(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return default;
        }

        public static NullNumber<TPrimitive> operator*(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return default;
        }

        public static NullNumber<TPrimitive> operator/(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return default;
        }

        public static NullNumber<TPrimitive> operator-(NullNumber<TPrimitive> a)
        {
            return default;
        }

        public static bool operator==(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return true;
        }

        public static bool operator!=(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return false;
        }

        public static bool operator>(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return false;
        }

        public static bool operator<(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return false;
        }

        public static bool operator>=(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return true;
        }

        public static bool operator<=(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return true;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<NullNumber<TPrimitive>> INumber<NullNumber<TPrimitive>>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<NullNumber<TPrimitive>, TPrimitive> INumber<NullNumber<TPrimitive>, TPrimitive>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<NullNumber<TPrimitive>, TPrimitive>
        {
            public static readonly Factory Instance = new Factory();
            public NullNumber<TPrimitive> Zero => default;
            public NullNumber<TPrimitive> RealOne => default;
            public NullNumber<TPrimitive> SpecialOne => default;
            public NullNumber<TPrimitive> UnitsOne => default;
            public NullNumber<TPrimitive> NonRealUnitsOne => default;
            public NullNumber<TPrimitive> CombinedOne => default;
            public NullNumber<TPrimitive> AllOne => default;
            static readonly INumber Default = default(NullNumber<TPrimitive>);
            INumber INumberFactory.Zero => Default;
            INumber INumberFactory.RealOne => Default;
            INumber INumberFactory.SpecialOne => Default;
            INumber INumberFactory.UnitsOne => Default;
            INumber INumberFactory.NonRealUnitsOne => Default;
            INumber INumberFactory.CombinedOne => Default;
            INumber INumberFactory.AllOne => Default;
            public NullNumber<TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined) => default;
        }

        int ICollection<TPrimitive>.Count => 0;

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => 0;

        TPrimitive IReadOnlyList<TPrimitive>.this[int index] => throw new ArgumentOutOfRangeException(nameof(index));

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return -1;
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
            return false;
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {

        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }
}
