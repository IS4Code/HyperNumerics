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

        public NullNumber Call(StandardBinaryOperation operation, in NullNumber other)
        {
            return default;
        }

        public NullNumber Call(StandardUnaryOperation operation)
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

            public NullNumber Create(StandardNumber num)
            {
                return default;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }

    /// <summary>
    /// Represents a number type with a single value which is the result of all operations.
    /// </summary>
    /// <typeparam name="TComponent">The component type the number mimics, but doesn't actually store.</typeparam>
    [Serializable]
    public readonly partial struct NullNumber<TComponent> : INumber<NullNumber<TComponent>, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        public static readonly NullNumber<TComponent> Value = default;

        int INumber.Dimension => 0;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        public NullNumber<TComponent> Clone()
        {
            return default;
        }

        public NullNumber<TComponent> Call(StandardBinaryOperation operation, in NullNumber<TComponent> other)
        {
            return default;
        }

        public NullNumber<TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            return default;
        }

        public NullNumber<TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            return default;
        }

        public NullNumber<TComponent> Call(StandardUnaryOperation operation)
        {
            return default;
        }

        public TComponent CallComponent(StandardUnaryOperation operation)
        {
            return default;
        }

        public override bool Equals(object obj)
        {
            return obj is NullNumber<TComponent> value;
        }

        public bool Equals(in NullNumber<TComponent> other)
        {
            return true;
        }

        public int CompareTo(in NullNumber<TComponent> other)
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

        partial class Operations : NumberOperations<NullNumber<TComponent>>, INumberOperations<NullNumber<TComponent>, TComponent>
        {
            public override int Dimension => 0;

            public NullNumber<TComponent> Create(StandardNumber num)
            {
                return default;
            }

            public NullNumber<TComponent> Create(in TComponent num)
            {
                return default;
            }

            public NullNumber<TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                return default;
            }

            public NullNumber<TComponent> Create(IEnumerable<TComponent> units)
            {
                return default;
            }

            public NullNumber<TComponent> Create(IEnumerator<TComponent> units)
            {
                return default;
            }
        }

        int ICollection<TComponent>.Count => 0;

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => 0;

        TComponent IReadOnlyList<TComponent>.this[int index] => throw new ArgumentOutOfRangeException(nameof(index));

        TComponent IList<TComponent>.this[int index]
        {
            get{
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            return -1;
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return false;
        }

        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {

        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }
}
