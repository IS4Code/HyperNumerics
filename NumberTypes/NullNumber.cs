using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number type with a single value which is the result of all operations.
    /// </summary>
    [Serializable]
    public readonly struct NullNumber : INumber<NullNumber>, IWrapperNumber<NullNumber, NullNumber>
    {
        public static readonly NullNumber Value = default;

        NullNumber IWrapperNumber<NullNumber>.Value => this;

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

        public NullNumber Call(BinaryOperation operation, in NullNumber other)
        {
            return default;
        }

        public NullNumber Call(UnaryOperation operation)
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

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullNumber> INumber<NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<NullNumber, NullNumber> IExtendedNumber<NullNumber, NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<NullNumber>, INumberOperations<NullNumber>, IExtendedNumberOperations<NullNumber, NullNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => 0;

            public bool IsInvertible(in NullNumber num)
            {
                return true;
            }

            public bool IsFinite(in NullNumber num)
            {
                return true;
            }

            public NullNumber Clone(in NullNumber num)
            {
                return default;
            }

            public bool Equals(NullNumber num1, NullNumber num2)
            {
                return true;
            }

            public int Compare(NullNumber num1, NullNumber num2)
            {
                return 0;
            }

            public bool Equals(in NullNumber num1, in NullNumber num2)
            {
                return true;
            }

            public int Compare(in NullNumber num1, in NullNumber num2)
            {
                return 0;
            }

            public int GetHashCode(NullNumber num)
            {
                return 0;
            }

            public int GetHashCode(in NullNumber num)
            {
                return 0;
            }

            public NullNumber Call(NullaryOperation operation)
            {
                return default;
            }

            public NullNumber Call(UnaryOperation operation, in NullNumber num)
            {
                return default;
            }

            public NullNumber Call(BinaryOperation operation, in NullNumber num1, in NullNumber num2)
            {
                return default;
            }

            public NullNumber Create(in NullNumber num)
            {
                return num;
            }
        }
    }

    /// <summary>
    /// Represents a number type with a single value which is the result of all operations.
    /// </summary>
    /// <typeparam name="TPrimitive">The primitive type the number mimics, but doesn't actually store.</typeparam>
    [Serializable]
    public readonly struct NullNumber<TPrimitive> : INumber<NullNumber<TPrimitive>, TPrimitive>, IWrapperNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public static readonly NullNumber<TPrimitive> Value = default;

        NullNumber<TPrimitive> IWrapperNumber<NullNumber<TPrimitive>>.Value => this;

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

        public NullNumber<TPrimitive> Call(BinaryOperation operation, in NullNumber<TPrimitive> other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            return default;
        }

        public NullNumber<TPrimitive> Call(UnaryOperation operation)
        {
            return default;
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
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

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullNumber<TPrimitive>> INumber<NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullNumber<TPrimitive>, TPrimitive> INumber<NullNumber<TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<NullNumber<TPrimitive>>, INumberOperations<NullNumber<TPrimitive>, TPrimitive>, IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => 0;

            public bool IsInvertible(in NullNumber<TPrimitive> num)
            {
                return true;
            }

            public bool IsFinite(in NullNumber<TPrimitive> num)
            {
                return true;
            }

            public NullNumber<TPrimitive> Clone(in NullNumber<TPrimitive> num)
            {
                return default;
            }

            public bool Equals(NullNumber<TPrimitive> num1, NullNumber<TPrimitive> num2)
            {
                return true;
            }

            public int Compare(NullNumber<TPrimitive> num1, NullNumber<TPrimitive> num2)
            {
                return 0;
            }

            public bool Equals(in NullNumber<TPrimitive> num1, in NullNumber<TPrimitive> num2)
            {
                return true;
            }

            public int Compare(in NullNumber<TPrimitive> num1, in NullNumber<TPrimitive> num2)
            {
                return 0;
            }

            public int GetHashCode(NullNumber<TPrimitive> num)
            {
                return 0;
            }

            public int GetHashCode(in NullNumber<TPrimitive> num)
            {
                return 0;
            }

            public NullNumber<TPrimitive> Call(NullaryOperation operation)
            {
                return default;
            }

            public NullNumber<TPrimitive> Call(UnaryOperation operation, in NullNumber<TPrimitive> num)
            {
                return default;
            }

            public NullNumber<TPrimitive> Call(BinaryOperation operation, in NullNumber<TPrimitive> num1, in NullNumber<TPrimitive> num2)
            {
                return default;
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in NullNumber<TPrimitive> num)
            {
                return default;
            }

            public NullNumber<TPrimitive> Call(BinaryOperation operation, in NullNumber<TPrimitive> num1, TPrimitive num2)
            {
                return default;
            }

            public NullNumber<TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return default;
            }

            public NullNumber<TPrimitive> Create(in NullNumber<TPrimitive> num)
            {
                return default;
            }

            public NullNumber<TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                return default;
            }

            public NullNumber<TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                return default;
            }
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
