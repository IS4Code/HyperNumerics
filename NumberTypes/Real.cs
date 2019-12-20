using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a real number, with its value stored as a <see cref="System.Double"/>.
    /// </summary>
    [Serializable]
    public readonly struct Real : ISimpleNumber<Real, double>, ISimpleNumber<Real, float>
    {
        public static readonly Real Zero = new Real(0.0);
        public static readonly Real One = new Real(1.0);

        public double Value { get; }
        float ISimpleNumber<float>.Value => (float)Value;

        public bool IsInvertible => Value != 0.0;

        public bool IsFinite => true;

        int INumber.Dimension => 1;

        /// <summary>
        /// Constructs a new value from its inner <see cref="System.Double"/> value.
        /// </summary>
        /// <param name="value">The value of the real number.</param>
        /// <exception cref="System.NotFiniteNumberException">
        /// This exception is thrown when <paramref name="value"/> doesn't correspond to any real number.
        /// </exception>
        public Real(double value)
        {
            if(Double.IsInfinity(value) || Double.IsNaN(value))
            {
                throw new NotFiniteNumberException(value);
            }
            Value = value;
        }

        /// <summary>
        /// Constructs a new value from its inner <see cref="System.Single"/> value.
        /// </summary>
        /// <param name="value">The value of the real number.</param>
        /// <exception cref="System.NotFiniteNumberException">
        /// This exception is thrown when <paramref name="value"/> doesn't correspond to any real number.
        /// </exception>
        public Real(float value)
        {
            if(Single.IsInfinity(value) || Single.IsNaN(value))
            {
                throw new NotFiniteNumberException(value);
            }
            Value = value;
        }

        Real INumber<Real>.Clone()
        {
            return this;
        }

        object ICloneable.Clone()
        {
            return this;
        }

        public Real Add(in Real other)
        {
            return new Real(Value + other.Value);
        }

        public Real Subtract(in Real other)
        {
            return new Real(Value - other.Value);
        }

        public Real Multiply(in Real other)
        {
            return new Real(Value * other.Value);
        }

        public Real Divide(in Real other)
        {
            return new Real(Value / other.Value);
        }

        public Real Power(in Real other)
        {
            return new Real(Math.Pow(Value, other.Value));
        }

        public Real Add(double other)
        {
            return new Real(Value + other);
        }

        public Real Subtract(double other)
        {
            return new Real(Value - other);
        }

        public Real Multiply(double other)
        {
            return new Real(Value * other);
        }

        public Real Divide(double other)
        {
            return new Real(Value / other);
        }

        public Real Power(double other)
        {
            return new Real(Math.Pow(Value, other));
        }

        public Real Add(float other)
        {
            return new Real(Value + other);
        }

        public Real Subtract(float other)
        {
            return new Real(Value - other);
        }

        public Real Multiply(float other)
        {
            return new Real(Value * other);
        }

        public Real Divide(float other)
        {
            return new Real(Value / other);
        }

        public Real Power(float other)
        {
            return new Real(Math.Pow(Value, other));
        }

        public Real Negate()
        {
            return new Real(-Value);
        }

        public Real Increment()
        {
            return new Real(Value + 1);
        }

        public Real Decrement()
        {
            return new Real(Value - 1);
        }

        public Real Inverse()
        {
            return new Real(1.0 / Value);
        }

        double INumber<Real, double>.AbsoluteValue()
        {
            return Math.Abs(Value);
        }

        float INumber<Real, float>.AbsoluteValue()
        {
            return (float)Math.Abs(Value);
        }

        double INumber<Real, double>.RealValue()
        {
            return Value;
        }

        float INumber<Real, float>.RealValue()
        {
            return (float)Value;
        }

        Real INumber<Real>.Conjugate()
        {
            return this;
        }

        Real INumber<Real>.Modulus()
        {
            return new Real(Math.Abs(Value));
        }

        Real INumber<Real>.Half()
        {
            return new Real(Value / 2.0);
        }

        Real INumber<Real>.Double()
        {
            return new Real(Value * 2.0);
        }

        Real INumber<Real>.Square()
        {
            return new Real(Value * Value);
        }

        Real INumber<Real>.SquareRoot()
        {
            return new Real(Math.Sqrt(Value));
        }

        Real INumber<Real>.Exponentiate()
        {
            return new Real(Math.Exp(Value));
        }

        Real INumber<Real>.Logarithm()
        {
            return new Real(Math.Log(Value));
        }

        Real INumber<Real>.Sine()
        {
            return new Real(Math.Sin(Value));
        }

        Real INumber<Real>.Cosine()
        {
            return new Real(Math.Cos(Value));
        }

        Real INumber<Real>.Tangent()
        {
            return new Real(Math.Tan(Value));
        }

        Real INumber<Real>.HyperbolicSine()
        {
            return new Real(Math.Sinh(Value));
        }

        Real INumber<Real>.HyperbolicCosine()
        {
            return new Real(Math.Cosh(Value));
        }

        Real INumber<Real>.HyperbolicTangent()
        {
            return new Real(Math.Tanh(Value));
        }

        Real INumber<Real>.ArcSine()
        {
            return new Real(Math.Asin(Value));
        }

        Real INumber<Real>.ArcCosine()
        {
            return new Real(Math.Acos(Value));
        }

        Real INumber<Real>.ArcTangent()
        {
            return new Real(Math.Atan(Value));
        }

        public override bool Equals(object obj)
        {
            return obj is Real value && Equals(in value);
        }

        public bool Equals(Real other)
        {
            return Equals(in other);
        }

        public bool Equals(in Real other)
        {
            return Value.Equals(other.Value);
        }

        public int CompareTo(Real other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in Real other)
        {
            return Value.CompareTo(other.Value);
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

        public static implicit operator Real(double value)
        {
            return new Real(value);
        }

        public static implicit operator Real(float value)
        {
            return new Real(value);
        }

        public static implicit operator double(Real value)
        {
            return value.Value;
        }

        public static explicit operator float(Real value)
        {
            return (float)value.Value;
        }

        public static Real operator+(Real a, Real b)
        {
            return a.Add(b);
        }

        public static Real operator-(Real a, Real b)
        {
            return a.Subtract(b);
        }

        public static Real operator*(Real a, Real b)
        {
            return a.Multiply(b);
        }

        public static Real operator/(Real a, Real b)
        {
            return a.Divide(b);
        }

        public static Real operator^(Real a, Real b)
        {
            return a.Power(b);
        }

        public static Real operator+(Real a, double b)
        {
            return a.Add(b);
        }

        public static Real operator+(double b, Real a)
        {
            return a.Add(b);
        }

        public static Real operator-(Real a, double b)
        {
            return a.Subtract(b);
        }

        public static Real operator*(Real a, double b)
        {
            return a.Multiply(b);
        }

        public static Real operator*(double b, Real a)
        {
            return a.Multiply(b);
        }

        public static Real operator/(Real a, double b)
        {
            return a.Divide(b);
        }

        public static Real operator^(Real a, double b)
        {
            return a.Power(b);
        }
        
        public static Real operator+(Real a, float b)
        {
            return a.Add(b);
        }

        public static Real operator+(float b, Real a)
        {
            return a.Add(b);
        }

        public static Real operator-(Real a, float b)
        {
            return a.Subtract(b);
        }

        public static Real operator*(Real a, float b)
        {
            return a.Multiply(b);
        }

        public static Real operator*(float b, Real a)
        {
            return a.Multiply(b);
        }

        public static Real operator/(Real a, float b)
        {
            return a.Divide(b);
        }

        public static Real operator^(Real a, float b)
        {
            return a.Power(b);
        }

        public static Real operator-(Real a)
        {
            return a.Negate();
        }

        public static Real operator++(Real a)
        {
            return a.Increment();
        }

        public static Real operator--(Real a)
        {
            return a.Decrement();
        }

        public static bool operator==(Real a, Real b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(Real a, Real b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(Real a, Real b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(Real a, Real b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(Real a, Real b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(Real a, Real b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<Real> INumber<Real>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<Real, double> INumber<Real, double>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<Real, float> INumber<Real, float>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<Real, double>, INumberFactory<Real, float>
        {
            public static readonly Factory Instance = new Factory();
            public Real Zero => Real.Zero;
            public Real RealOne => Real.One;
            public Real SpecialOne => Real.Zero;
            public Real UnitsOne => Real.One;
            public Real NonRealUnitsOne => Real.Zero;
            public Real CombinedOne => Real.Zero;
            public Real AllOne => Real.One;
            INumber INumberFactory.Zero => Real.Zero;
            INumber INumberFactory.RealOne => Real.One;
            INumber INumberFactory.SpecialOne => Real.Zero;
            INumber INumberFactory.UnitsOne => Real.One;
            INumber INumberFactory.NonRealUnitsOne => Real.Zero;
            INumber INumberFactory.CombinedOne => Real.Zero;
            INumber INumberFactory.AllOne => Real.One;
            public Real Create(double realUnit, double otherUnits, double someUnitsCombined, double allUnitsCombined) => new Real(realUnit);
            Real INumberFactory<Real, float>.Create(float realUnit, float otherUnits, float someUnitsCombined, float allUnitsCombined) => new Real(realUnit);
        }

        int ICollection<double>.Count => 1;

        bool ICollection<double>.IsReadOnly => true;

        int IReadOnlyCollection<double>.Count => 1;

        double IReadOnlyList<double>.this[int index] => index == 0 ? Value : throw new ArgumentOutOfRangeException(nameof(index));

        double IList<double>.this[int index]
        {
            get{
                return index == 0 ? Value : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<double>.IndexOf(double item)
        {
            return Value == item ? 0 : -1;
        }

        void IList<double>.Insert(int index, double item)
        {
            throw new NotSupportedException();
        }

        void IList<double>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<double>.Add(double item)
        {
            throw new NotSupportedException();
        }

        void ICollection<double>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<double>.Contains(double item)
        {
            return Value == item;
        }

        void ICollection<double>.CopyTo(double[] array, int arrayIndex)
        {
            array[arrayIndex] = Value;
        }

        bool ICollection<double>.Remove(double item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            yield return Value;
        }

        int ICollection<float>.Count => 1;

        bool ICollection<float>.IsReadOnly => true;

        int IReadOnlyCollection<float>.Count => 1;

        float IReadOnlyList<float>.this[int index] => index == 0 ? (float)Value : throw new ArgumentOutOfRangeException(nameof(index));

        float IList<float>.this[int index]
        {
            get{
                return index == 0 ? (float)Value : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<float>.IndexOf(float item)
        {
            return Value == item ? 0 : -1;
        }

        void IList<float>.Insert(int index, float item)
        {
            throw new NotSupportedException();
        }

        void IList<float>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<float>.Add(float item)
        {
            throw new NotSupportedException();
        }

        void ICollection<float>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<float>.Contains(float item)
        {
            return Value == item;
        }

        void ICollection<float>.CopyTo(float[] array, int arrayIndex)
        {
            array[arrayIndex] = (float)Value;
        }

        bool ICollection<float>.Remove(float item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            yield return (float)Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
        }
    }
}
