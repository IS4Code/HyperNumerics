using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a real number, with its value stored as a <see cref="System.Double"/>.
    /// </summary>
    /// <remarks>
    /// Not all possible values of <see cref="System.Double"/> are allowed, namely infinites and NaNs.
    /// </remarks>
    [Serializable]
    public readonly partial struct Real : ISimpleNumber<Real, double>, ISimpleNumber<Real, float>, ISimpleNumber<Real, Real>, IWrapperNumber<Real, Real, double>, IWrapperNumber<Real, Real, float>, IWrapperNumber<Real, Real, Real>, ISimpleNumber<ExtendedReal, double>, ISimpleNumber<ExtendedReal, float>, ISimpleNumber<ExtendedReal, ExtendedReal>
    {
        public static readonly Real Zero = new Real(0.0);
        public static readonly Real One = new Real(1.0);

        public double Value { get; }

        float ISimpleNumber<float>.Value => (float)Value;

        Real IWrapperNumber<Real>.Value => this;

        Real ISimpleNumber<Real>.Value => this;

        ExtendedReal ISimpleNumber<ExtendedReal>.Value => new ExtendedReal(Value);

        public bool IsInvertible => Value != 0.0;

        public bool IsFinite => true;

        int INumber.Dimension => 1;

        /// <summary>
        /// Constructs a new value from its inner <see cref="System.Double"/> value.
        /// </summary>
        /// <param name="value">The value of the real number.</param>
        /// <exception cref="System.NotFiniteNumberException">Thrown when <paramref name="value"/> doesn't correspond to any real number.</exception>
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
        /// <exception cref="System.NotFiniteNumberException">Thrown when <paramref name="value"/> doesn't correspond to any real number.</exception>
        public Real(float value)
        {
            if(Single.IsInfinity(value) || Single.IsNaN(value))
            {
                throw new NotFiniteNumberException(value);
            }
            Value = value;
        }

        public Real Clone()
        {
            return this;
        }

        ExtendedReal INumber<ExtendedReal>.Clone()
        {
            return new ExtendedReal(Value);
        }

        public Real Call(StandardBinaryOperation operation, in Real other)
        {
            return Call(operation, other.Value);
        }

        public ExtendedReal Call(StandardBinaryOperation operation, in ExtendedReal other)
        {
            return other.CallReversed(operation, Value);
        }

        public ExtendedReal CallReversed(StandardBinaryOperation operation, in ExtendedReal other)
        {
            return other.Call(operation, Value);
        }

        public Real Call(StandardBinaryOperation operation, in double other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return Value + other;
                case StandardBinaryOperation.Subtract:
                    return Value - other;
                case StandardBinaryOperation.Multiply:
                    return Value * other;
                case StandardBinaryOperation.Divide:
                    return Value / other;
                case StandardBinaryOperation.Power:
                    return Math.Pow(Value, other);
                case StandardBinaryOperation.Atan2:
                    return Math.Atan2(Value, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public Real CallReversed(StandardBinaryOperation operation, in double other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return other + Value;
                case StandardBinaryOperation.Subtract:
                    return other - Value;
                case StandardBinaryOperation.Multiply:
                    return other * Value;
                case StandardBinaryOperation.Divide:
                    return other / Value;
                case StandardBinaryOperation.Power:
                    return Math.Pow(other, Value);
                case StandardBinaryOperation.Atan2:
                    return Math.Atan2(other, Value);
                default:
                    throw new NotSupportedException();
            }
        }

        ExtendedReal INumber<ExtendedReal, double>.Call(StandardBinaryOperation operation, in double other)
        {
            return new ExtendedReal(Value).Call(operation, other);
        }

        ExtendedReal INumber<ExtendedReal, double>.CallReversed(StandardBinaryOperation operation, in double other)
        {
            return new ExtendedReal(Value).CallReversed(operation, other);
        }

        public Real Call(StandardBinaryOperation operation, in float other)
        {
            return Call(operation, (double)other);
        }

        public Real CallReversed(StandardBinaryOperation operation, in float other)
        {
            return CallReversed(operation, (double)other);
        }

        ExtendedReal INumber<ExtendedReal, float>.Call(StandardBinaryOperation operation, in float other)
        {
            return new ExtendedReal(Value).Call(operation, other);
        }

        ExtendedReal INumber<ExtendedReal, float>.CallReversed(StandardBinaryOperation operation, in float other)
        {
            return new ExtendedReal(Value).CallReversed(operation, other);
        }

        ExtendedReal INumber<ExtendedReal, ExtendedReal>.Call(StandardBinaryOperation operation, in ExtendedReal other)
        {
            return Call(operation, other);
        }

        ExtendedReal INumber<ExtendedReal, ExtendedReal>.CallReversed(StandardBinaryOperation operation, in ExtendedReal other)
        {
            return CallReversed(operation, other);
        }

        public Real Call(StandardUnaryOperation operation)
        {
            return CallComponent(operation);
        }

        ExtendedReal INumber<ExtendedReal>.Call(StandardUnaryOperation operation)
        {
            return CallComponent(operation);
        }

        public double CallComponent(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return Value;
                case StandardUnaryOperation.Negate:
                    return -Value;
                case StandardUnaryOperation.Increment:
                    return Value + 1;
                case StandardUnaryOperation.Decrement:
                    return Value - 1;
                case StandardUnaryOperation.Inverse:
                    return 1.0 / Value;
                case StandardUnaryOperation.Conjugate:
                    return Value;
                case StandardUnaryOperation.Modulus:
                    return Math.Abs(Value);
                case StandardUnaryOperation.Double:
                    return Value * 2.0;
                case StandardUnaryOperation.Half:
                    return Value * 0.5;
                case StandardUnaryOperation.Square:
                    return Value * Value;
                case StandardUnaryOperation.SquareRoot:
                    return Math.Sqrt(Value);
                case StandardUnaryOperation.Exponentiate:
                    return Math.Exp(Value);
                case StandardUnaryOperation.Logarithm:
                    return Math.Log(Value);
                case StandardUnaryOperation.Sine:
                    return Math.Sin(Value);
                case StandardUnaryOperation.Cosine:
                    return Math.Cos(Value);
                case StandardUnaryOperation.Tangent:
                    return Math.Tan(Value);
                case StandardUnaryOperation.HyperbolicSine:
                    return Math.Sinh(Value);
                case StandardUnaryOperation.HyperbolicCosine:
                    return Math.Cosh(Value);
                case StandardUnaryOperation.HyperbolicTangent:
                    return Math.Tanh(Value);
                case StandardUnaryOperation.ArcSine:
                    return Math.Asin(Value);
                case StandardUnaryOperation.ArcCosine:
                    return Math.Acos(Value);
                case StandardUnaryOperation.ArcTangent:
                    return Math.Atan(Value);
                default:
                    throw new NotSupportedException();
            }
        }

        float INumber<Real, float>.CallComponent(StandardUnaryOperation operation)
        {
            return (float)CallComponent(operation);
        }

        float INumber<ExtendedReal, float>.CallComponent(StandardUnaryOperation operation)
        {
            return (float)CallComponent(operation);
        }

        Real INumber<Real, Real>.CallComponent(StandardUnaryOperation operation)
        {
            return new Real(Call(operation));
        }

        ExtendedReal INumber<ExtendedReal, ExtendedReal>.CallComponent(StandardUnaryOperation operation)
        {
            return new ExtendedReal(Call(operation));
        }

        public override bool Equals(object obj)
        {
            return obj is Real value && Equals(in value) ||  new ExtendedReal(Value).Equals(obj);
        }

        public bool Equals(Real other)
        {
            return Equals(in other);
        }

        public bool Equals(in Real other)
        {
            return Value.Equals(other.Value);
        }

        public bool Equals(ExtendedReal other)
        {
            return Equals(in other);
        }

        public bool Equals(in ExtendedReal other)
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

        public static implicit operator Real(double value)
        {
            return new Real(value);
        }

        public static implicit operator Real(float value)
        {
            return new Real(value);
        }

        public static implicit operator ExtendedReal(Real value)
        {
            return new ExtendedReal(value.Value);
        }

        public static implicit operator double(Real value)
        {
            return value.Value;
        }

        public static explicit operator float(Real value)
        {
            return (float)value.Value;
        }

        INumberOperations<Real, double> INumber<Real, double>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<Real, float> INumber<Real, float>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<Real, Real> INumber<Real, Real>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ExtendedReal> INumber<ExtendedReal>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ExtendedReal, double> INumber<ExtendedReal, double>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ExtendedReal, float> INumber<ExtendedReal, float>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ExtendedReal, ExtendedReal> INumber<ExtendedReal, ExtendedReal>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<Real, Real> IExtendedNumber<Real, Real>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<Real, Real, double> IExtendedNumber<Real, Real, double>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<Real, Real, float> IExtendedNumber<Real, Real, float>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<Real, Real, Real> IExtendedNumber<Real, Real, Real>.GetOperations()
        {
            return Operations.Instance;
        }

        partial class Operations : NumberOperations<Real>, INumberOperations<Real, double>, INumberOperations<Real, float>, INumberOperations<Real, Real>, INumberOperations<ExtendedReal, double>, INumberOperations<ExtendedReal, float>, INumberOperations<ExtendedReal, ExtendedReal>, IExtendedNumberOperations<Real, Real, double>, IExtendedNumberOperations<Real, Real, float>, IExtendedNumberOperations<Real, Real, Real>
        {
            public override int Dimension => 0;

            public virtual bool IsInvertible(in ExtendedReal num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ExtendedReal num)
            {
                return num.IsFinite;
            }

            public virtual ExtendedReal Clone(in ExtendedReal num)
            {
                return num;
            }

            public virtual bool Equals(ExtendedReal num1, ExtendedReal num2)
            {
                return num1.Equals(in num2);
            }

            public virtual int Compare(ExtendedReal num1, ExtendedReal num2)
            {
                return num1.CompareTo(in num2);
            }

            public virtual bool Equals(in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.Equals(in num2);
            }

            public virtual int Compare(in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.CompareTo(in num2);
            }

            public virtual int GetHashCode(ExtendedReal num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ExtendedReal num)
            {
                return num.GetHashCode();
            }

            public virtual Real Create(StandardNumber num)
            {
                switch(num)
                {
                    case StandardNumber.One:
                    case StandardNumber.UnitsOne:
                    case StandardNumber.AllOne:
                    case StandardNumber.CombinedOne:
                        return 1.0;
                    case StandardNumber.Zero:
                    case StandardNumber.SpecialOne:
                    case StandardNumber.NonRealUnitsOne:
                        return 0.0;
                    case StandardNumber.NegativeOne:
                        return -1.0;
                    case StandardNumber.Two:
                        return 2.0;
                    default:
                        throw new NotSupportedException();
                }
            }

            ExtendedReal INumberOperations<ExtendedReal>.Create(StandardNumber num)
            {
                switch(num)
                {
                    case StandardNumber.One:
                    case StandardNumber.UnitsOne:
                    case StandardNumber.AllOne:
                        return 1.0;
                    case StandardNumber.Zero:
                    case StandardNumber.SpecialOne:
                    case StandardNumber.NonRealUnitsOne:
                    case StandardNumber.CombinedOne:
                        return 0.0;
                    default:
                        throw new NotSupportedException();
                }
            }

            public virtual double CallComponent(StandardUnaryOperation operation, in Real num)
            {
                return num.Call(operation);
            }

            float INumberOperations<Real, float>.CallComponent(StandardUnaryOperation operation, in Real num)
            {
                return (float)num.Call(operation);
            }

            Real INumberOperations<Real, Real>.CallComponent(StandardUnaryOperation operation, in Real num)
            {
                return new Real(num.Call(operation));
            }

            public virtual Real Call(StandardBinaryOperation operation, in Real num1, in double num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual Real Call(StandardBinaryOperation operation, in double num1, in Real num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual Real Call(StandardBinaryOperation operation, in Real num1, in float num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual Real Call(StandardBinaryOperation operation, in float num1, in Real num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual ExtendedReal Call(StandardUnaryOperation operation, in ExtendedReal num)
            {
                return num.Call(operation);
            }

            public virtual ExtendedReal Call(StandardBinaryOperation operation, in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual double CallComponent(StandardUnaryOperation operation, in ExtendedReal num)
            {
                return num.Call(operation);
            }

            float INumberOperations<ExtendedReal, float>.CallComponent(StandardUnaryOperation operation, in ExtendedReal num)
            {
                return (float)num.Call(operation);
            }

            ExtendedReal INumberOperations<ExtendedReal, ExtendedReal>.CallComponent(StandardUnaryOperation operation, in ExtendedReal num)
            {
                return new ExtendedReal(num.Call(operation));
            }

            public virtual ExtendedReal Call(StandardBinaryOperation operation, in ExtendedReal num1, in double num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ExtendedReal Call(StandardBinaryOperation operation, in double num1, in ExtendedReal num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual ExtendedReal Call(StandardBinaryOperation operation, in ExtendedReal num1, in float num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ExtendedReal Call(StandardBinaryOperation operation, in float num1, in ExtendedReal num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual Real Create(in double num)
            {
                return new Real(num);
            }

            public virtual Real Create(in double realUnit, in double otherUnits, in double someUnitsCombined, in double allUnitsCombined)
            {
                return new Real(realUnit);
            }

            public virtual Real Create(in float num)
            {
                return new Real(num);
            }

            public virtual Real Create(in float realUnit, in float otherUnits, in float someUnitsCombined, in float allUnitsCombined)
            {
                return new Real(realUnit);
            }

            public virtual Real Create(in Real realUnit, in Real otherUnits, in Real someUnitsCombined, in Real allUnitsCombined)
            {
                return realUnit;
            }

            public virtual ExtendedReal Create(in ExtendedReal realUnit, in ExtendedReal otherUnits, in ExtendedReal someUnitsCombined, in ExtendedReal allUnitsCombined)
            {
                return realUnit;
            }

            ExtendedReal INumberOperations<ExtendedReal, double>.Create(in double num)
            {
                return new ExtendedReal(num);
            }

            ExtendedReal INumberOperations<ExtendedReal, double>.Create(in double realUnit, in double otherUnits, in double someUnitsCombined, in double allUnitsCombined)
            {
                return new ExtendedReal(realUnit);
            }

            ExtendedReal INumberOperations<ExtendedReal, float>.Create(in float num)
            {
                return new ExtendedReal(num);
            }

            ExtendedReal INumberOperations<ExtendedReal, float>.Create(in float realUnit, in float otherUnits, in float someUnitsCombined, in float allUnitsCombined)
            {
                return new ExtendedReal(realUnit);
            }

            public virtual Real Create(in Real num)
            {
                return num;
            }

            public virtual Real Create(IEnumerable<double> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return new Real(ienum.Current);
            }

            public virtual Real Create(IEnumerator<double> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new Real(value);
            }

            public virtual Real Create(IEnumerable<float> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return new Real(ienum.Current);
            }

            public virtual Real Create(IEnumerator<float> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new Real(value);
            }

            public virtual Real Create(IEnumerable<Real> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual Real Create(IEnumerator<Real> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }

            public virtual ExtendedReal Create(in ExtendedReal num)
            {
                return num;
            }

            public virtual ExtendedReal Create(IEnumerable<ExtendedReal> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual ExtendedReal Create(IEnumerator<ExtendedReal> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }

            ExtendedReal INumberOperations<ExtendedReal, double>.Create(IEnumerable<double> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return new ExtendedReal(ienum.Current);
            }

            ExtendedReal INumberOperations<ExtendedReal, double>.Create(IEnumerator<double> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new ExtendedReal(value);
            }

            ExtendedReal INumberOperations<ExtendedReal, float>.Create(IEnumerable<float> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return new ExtendedReal(ienum.Current);
            }

            ExtendedReal INumberOperations<ExtendedReal, float>.Create(IEnumerator<float> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new ExtendedReal(value);
            }
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

        int ICollection<Real>.Count => 1;

        bool ICollection<Real>.IsReadOnly => true;

        int IReadOnlyCollection<Real>.Count => 1;

        Real IReadOnlyList<Real>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        Real IList<Real>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<Real>.IndexOf(Real item)
        {
            return Equals(in item) ? 0 : -1;
        }

        void IList<Real>.Insert(int index, Real item)
        {
            throw new NotSupportedException();
        }

        void IList<Real>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<Real>.Add(Real item)
        {
            throw new NotSupportedException();
        }

        void ICollection<Real>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<Real>.Contains(Real item)
        {
            return Equals(in item);
        }

        void ICollection<Real>.CopyTo(Real[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<Real>.Remove(Real item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<Real> IEnumerable<Real>.GetEnumerator()
        {
            yield return this;
        }

        int ICollection<ExtendedReal>.Count => 1;

        bool ICollection<ExtendedReal>.IsReadOnly => true;

        int IReadOnlyCollection<ExtendedReal>.Count => 1;

        ExtendedReal IReadOnlyList<ExtendedReal>.this[int index] => index == 0 ? new ExtendedReal(Value) : throw new ArgumentOutOfRangeException(nameof(index));

        ExtendedReal IList<ExtendedReal>.this[int index]
        {
            get{
                return index == 0 ? new ExtendedReal(Value) : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ExtendedReal>.IndexOf(ExtendedReal item)
        {
            return Equals(in item) ? 0 : -1;
        }

        void IList<ExtendedReal>.Insert(int index, ExtendedReal item)
        {
            throw new NotSupportedException();
        }

        void IList<ExtendedReal>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ExtendedReal>.Add(ExtendedReal item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ExtendedReal>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ExtendedReal>.Contains(ExtendedReal item)
        {
            return Equals(in item);
        }

        void ICollection<ExtendedReal>.CopyTo(ExtendedReal[] array, int arrayIndex)
        {
            array[arrayIndex] = new ExtendedReal(Value);
        }

        bool ICollection<ExtendedReal>.Remove(ExtendedReal item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ExtendedReal> IEnumerable<ExtendedReal>.GetEnumerator()
        {
            yield return new ExtendedReal(Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
        }
    }
}
