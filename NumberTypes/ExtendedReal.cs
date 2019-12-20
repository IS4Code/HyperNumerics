using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents an extended real number, with its value stored as a <see cref="System.Double"/>, allowing for infinities and NaNs.
    /// </summary>
    [Serializable]
    public readonly struct ExtendedReal : ISimpleNumber<ExtendedReal, double>, ISimpleNumber<ExtendedReal, float>
    {
        public static readonly ExtendedReal Zero = new ExtendedReal(0.0);
        public static readonly ExtendedReal One = new ExtendedReal(1.0);

        public double Value { get; }
        float ISimpleNumber<float>.Value => (float)Value;

        public bool IsInvertible => true;

        public bool IsFinite => Double.IsInfinity(Value) || Double.IsNaN(Value);

        int INumber.Dimension => 1;

        /// <summary>
        /// Constructs a new value from its inner <see cref="System.Double"/> value.
        /// </summary>
        /// <param name="value">The value of the real number.</param>
        public ExtendedReal(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructs a new value from its inner <see cref="System.Single"/> value.
        /// </summary>
        /// <param name="value">The value of the real number.</param>
        public ExtendedReal(float value)
        {
            Value = (float)value;
        }

        ExtendedReal INumber<ExtendedReal>.Clone()
        {
            return this;
        }

        object ICloneable.Clone()
        {
            return this;
        }

        public ExtendedReal Add(in ExtendedReal other)
        {
            return new ExtendedReal(Value + other.Value);
        }

        public ExtendedReal Subtract(in ExtendedReal other)
        {
            return new ExtendedReal(Value - other.Value);
        }

        public ExtendedReal Multiply(in ExtendedReal other)
        {
            return new ExtendedReal(Value * other.Value);
        }

        public ExtendedReal Divide(in ExtendedReal other)
        {
            return new ExtendedReal(Value / other.Value);
        }

        public ExtendedReal Power(in ExtendedReal other)
        {
            return new ExtendedReal(Math.Pow(Value, other.Value));
        }

        public ExtendedReal Add(double other)
        {
            return new ExtendedReal(Value + other);
        }

        public ExtendedReal Subtract(double other)
        {
            return new ExtendedReal(Value - other);
        }

        public ExtendedReal Multiply(double other)
        {
            return new ExtendedReal(Value * other);
        }

        public ExtendedReal Divide(double other)
        {
            return new ExtendedReal(Value / other);
        }

        public ExtendedReal Power(double other)
        {
            return new ExtendedReal(Math.Pow(Value, other));
        }

        public ExtendedReal Add(float other)
        {
            return new ExtendedReal(Value + other);
        }

        public ExtendedReal Subtract(float other)
        {
            return new ExtendedReal(Value - other);
        }

        public ExtendedReal Multiply(float other)
        {
            return new ExtendedReal(Value * other);
        }

        public ExtendedReal Divide(float other)
        {
            return new ExtendedReal(Value / other);
        }

        public ExtendedReal Power(float other)
        {
            return new ExtendedReal(Math.Pow(Value, other));
        }

        public ExtendedReal Negate()
        {
            return new ExtendedReal(-Value);
        }

        public ExtendedReal Increment()
        {
            return new ExtendedReal(Value + 1);
        }

        public ExtendedReal Decrement()
        {
            return new ExtendedReal(Value - 1);
        }

        public ExtendedReal Inverse()
        {
            return new ExtendedReal(1.0 / Value);
        }

        double INumber<ExtendedReal, double>.AbsoluteValue()
        {
            return Math.Abs(Value);
        }

        float INumber<ExtendedReal, float>.AbsoluteValue()
        {
            return (float)Math.Abs(Value);
        }

        double INumber<ExtendedReal, double>.RealValue()
        {
            return Value;
        }

        float INumber<ExtendedReal, float>.RealValue()
        {
            return (float)Value;
        }

        ExtendedReal INumber<ExtendedReal>.Conjugate()
        {
            return this;
        }

        ExtendedReal INumber<ExtendedReal>.Modulus()
        {
            return new ExtendedReal(Math.Abs(Value));
        }

        ExtendedReal INumber<ExtendedReal>.Half()
        {
            return new ExtendedReal(Value / 2.0);
        }

        ExtendedReal INumber<ExtendedReal>.Double()
        {
            return new ExtendedReal(Value * 2.0);
        }

        ExtendedReal INumber<ExtendedReal>.Square()
        {
            return new ExtendedReal(Value * Value);
        }

        ExtendedReal INumber<ExtendedReal>.SquareRoot()
        {
            return new ExtendedReal(Math.Sqrt(Value));
        }

        ExtendedReal INumber<ExtendedReal>.Exponentiate()
        {
            return new ExtendedReal(Math.Exp(Value));
        }

        ExtendedReal INumber<ExtendedReal>.Logarithm()
        {
            return new ExtendedReal(Math.Log(Value));
        }

        ExtendedReal INumber<ExtendedReal>.Sine()
        {
            return new ExtendedReal(Math.Sin(Value));
        }

        ExtendedReal INumber<ExtendedReal>.Cosine()
        {
            return new ExtendedReal(Math.Cos(Value));
        }

        ExtendedReal INumber<ExtendedReal>.Tangent()
        {
            return new ExtendedReal(Math.Tan(Value));
        }

        ExtendedReal INumber<ExtendedReal>.HyperbolicSine()
        {
            return new ExtendedReal(Math.Sinh(Value));
        }

        ExtendedReal INumber<ExtendedReal>.HyperbolicCosine()
        {
            return new ExtendedReal(Math.Cosh(Value));
        }

        ExtendedReal INumber<ExtendedReal>.HyperbolicTangent()
        {
            return new ExtendedReal(Math.Tanh(Value));
        }

        ExtendedReal INumber<ExtendedReal>.ArcSine()
        {
            return new ExtendedReal(Math.Asin(Value));
        }

        ExtendedReal INumber<ExtendedReal>.ArcCosine()
        {
            return new ExtendedReal(Math.Acos(Value));
        }

        ExtendedReal INumber<ExtendedReal>.ArcTangent()
        {
            return new ExtendedReal(Math.Atan(Value));
        }

        public override bool Equals(object obj)
        {
            return obj is ExtendedReal value && Equals(in value);
        }

        public bool Equals(ExtendedReal other)
        {
            return Equals(in other);
        }

        public bool Equals(in ExtendedReal other)
        {
            return Value.Equals(other.Value);
        }

        public int CompareTo(ExtendedReal other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in ExtendedReal other)
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

        public static implicit operator ExtendedReal(double value)
        {
            return new ExtendedReal(value);
        }

        public static implicit operator ExtendedReal(float value)
        {
            return new ExtendedReal(value);
        }

        public static implicit operator double(ExtendedReal value)
        {
            return value.Value;
        }

        public static explicit operator float(ExtendedReal value)
        {
            return (float)value.Value;
        }

        public static ExtendedReal operator+(ExtendedReal a, ExtendedReal b)
        {
            return a.Add(b);
        }

        public static ExtendedReal operator-(ExtendedReal a, ExtendedReal b)
        {
            return a.Subtract(b);
        }

        public static ExtendedReal operator*(ExtendedReal a, ExtendedReal b)
        {
            return a.Multiply(b);
        }

        public static ExtendedReal operator/(ExtendedReal a, ExtendedReal b)
        {
            return a.Divide(b);
        }

        public static ExtendedReal operator^(ExtendedReal a, ExtendedReal b)
        {
            return a.Power(b);
        }

        public static ExtendedReal operator+(ExtendedReal a, double b)
        {
            return a.Add(b);
        }

        public static ExtendedReal operator+(double b, ExtendedReal a)
        {
            return a.Add(b);
        }

        public static ExtendedReal operator-(ExtendedReal a, double b)
        {
            return a.Subtract(b);
        }

        public static ExtendedReal operator*(ExtendedReal a, double b)
        {
            return a.Multiply(b);
        }

        public static ExtendedReal operator*(double b, ExtendedReal a)
        {
            return a.Multiply(b);
        }

        public static ExtendedReal operator/(ExtendedReal a, double b)
        {
            return a.Divide(b);
        }

        public static ExtendedReal operator^(ExtendedReal a, double b)
        {
            return a.Power(b);
        }
        
        public static ExtendedReal operator+(ExtendedReal a, float b)
        {
            return a.Add(b);
        }

        public static ExtendedReal operator+(float b, ExtendedReal a)
        {
            return a.Add(b);
        }

        public static ExtendedReal operator-(ExtendedReal a, float b)
        {
            return a.Subtract(b);
        }

        public static ExtendedReal operator*(ExtendedReal a, float b)
        {
            return a.Multiply(b);
        }

        public static ExtendedReal operator*(float b, ExtendedReal a)
        {
            return a.Multiply(b);
        }

        public static ExtendedReal operator/(ExtendedReal a, float b)
        {
            return a.Divide(b);
        }

        public static ExtendedReal operator^(ExtendedReal a, float b)
        {
            return a.Power(b);
        }

        public static ExtendedReal operator-(ExtendedReal a)
        {
            return a.Negate();
        }

        public static ExtendedReal operator++(ExtendedReal a)
        {
            return a.Increment();
        }

        public static ExtendedReal operator--(ExtendedReal a)
        {
            return a.Decrement();
        }

        public static bool operator==(ExtendedReal a, ExtendedReal b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(ExtendedReal a, ExtendedReal b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<ExtendedReal> INumber<ExtendedReal>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<ExtendedReal, double> INumber<ExtendedReal, double>.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<ExtendedReal, float> INumber<ExtendedReal, float>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<ExtendedReal, double>, INumberFactory<ExtendedReal, float>
        {
            public static readonly Factory Instance = new Factory();
            public ExtendedReal Zero => ExtendedReal.Zero;
            public ExtendedReal RealOne => ExtendedReal.One;
            public ExtendedReal SpecialOne => ExtendedReal.Zero;
            public ExtendedReal UnitsOne => ExtendedReal.One;
            public ExtendedReal NonRealUnitsOne => ExtendedReal.Zero;
            public ExtendedReal CombinedOne => ExtendedReal.Zero;
            public ExtendedReal AllOne => ExtendedReal.One;
            INumber INumberFactory.Zero => ExtendedReal.Zero;
            INumber INumberFactory.RealOne => ExtendedReal.One;
            INumber INumberFactory.SpecialOne => ExtendedReal.Zero;
            INumber INumberFactory.UnitsOne => ExtendedReal.One;
            INumber INumberFactory.NonRealUnitsOne => ExtendedReal.Zero;
            INumber INumberFactory.CombinedOne => ExtendedReal.Zero;
            INumber INumberFactory.AllOne => ExtendedReal.One;
            public ExtendedReal Create(double realUnit, double otherUnits, double someUnitsCombined, double allUnitsCombined) => new ExtendedReal(realUnit);
            ExtendedReal INumberFactory<ExtendedReal, float>.Create(float realUnit, float otherUnits, float someUnitsCombined, float allUnitsCombined) => new ExtendedReal(realUnit);
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
