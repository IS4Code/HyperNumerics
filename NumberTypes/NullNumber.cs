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
    public readonly partial struct NullNumber : INumber<NullNumber>
    {
        public static readonly NullNumber Value = default;

        int INumber.Dimension => 0;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        public NullNumber Clone()
        {
            return default;
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

        public bool Equals(in NullNumber other)
        {
            return true;
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

        partial class Operations : NumberOperations<NullNumber>, INumberOperations<NullNumber>
        {
            public override int Dimension => 0;

            public NullNumber Call(NullaryOperation operation)
            {
                return default;
            }
        }
    }

    /// <summary>
    /// Represents a number type with a single value which is the result of all operations.
    /// </summary>
    /// <typeparam name="TPrimitive">The primitive type the number mimics, but doesn't actually store.</typeparam>
    [Serializable]
    public readonly partial struct NullNumber<TPrimitive> : INumber<NullNumber<TPrimitive>, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public static readonly NullNumber<TPrimitive> Value = default;

        int INumber.Dimension => 0;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        public NullNumber<TPrimitive> Clone()
        {
            return default;
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

        public bool Equals(in NullNumber<TPrimitive> other)
        {
            return true;
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

        partial class Operations : NumberOperations<NullNumber<TPrimitive>>, INumberOperations<NullNumber<TPrimitive>, TPrimitive>
        {
            public override int Dimension => 0;

            public NullNumber<TPrimitive> Call(NullaryOperation operation)
            {
                return default;
            }

            public NullNumber<TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
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
