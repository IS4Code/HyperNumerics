using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct NullableNumber<TInner> : IExtendedNumber<NullableNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        public TInner? Value { get; }

        public bool IsInvertible => Value?.IsInvertible ?? true;

        public bool IsFinite => Value?.IsFinite ?? true;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public NullableNumber(in TInner value)
        {
            Value = value;
        }

        public NullableNumber(in TInner? value)
        {
            Value = value;
        }

        public NullableNumber<TInner> Clone()
        {
            return Value?.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner> Call(BinaryOperation operation, in NullableNumber<TInner> other)
        {
            return other.Value.HasValue ? Value?.Call(operation, other.Value.Value) : null;
        }

        public NullableNumber<TInner> Call(BinaryOperation operation, in TInner other)
        {
            return Value?.Call(operation, other);
        }

        public NullableNumber<TInner> Call(UnaryOperation operation)
        {
            return Value?.Call(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is NullableNumber<TInner> value && Equals(in value);
        }

        public bool Equals(NullableNumber<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in NullableNumber<TInner> other)
        {
            return Value.HasValue ? other.Value.HasValue && Value.Value.Equals(other.Value.Value) : !other.Value.HasValue;
        }

        public int CompareTo(NullableNumber<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in NullableNumber<TInner> other)
        {
            return Value.HasValue ? (other.Value.HasValue ? Value.Value.CompareTo(other.Value.Value) : 1) : (other.Value.HasValue ? -1 : 0);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString() : "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.HasValue ? Value.Value.ToString(format, formatProvider) : "Null";
        }

        public static implicit operator NullableNumber<TInner>(in TInner value)
        {
            return new NullableNumber<TInner>(value);
        }

        public static implicit operator NullableNumber<TInner>(in TInner? value)
        {
            return new NullableNumber<TInner>(value);
        }

        public static bool operator==(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in NullableNumber<TInner> a, in NullableNumber<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullableNumber<TInner>> INumber<NullableNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<NullableNumber<TInner>>, INumberOperations<NullableNumber<TInner>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public bool IsInvertible(in NullableNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullableNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public NullableNumber<TInner> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public NullableNumber<TInner> Call(UnaryOperation operation, in NullableNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner> Call(BinaryOperation operation, in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }
        }
    }
    
    [Serializable]
    public readonly struct NullableNumber<TInner, TPrimitive> : IExtendedNumber<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public TInner? Value { get; }

        public bool IsInvertible => Value?.IsInvertible ?? true;

        public bool IsFinite => Value?.IsFinite ?? true;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public NullableNumber(in TInner value)
        {
            Value = value;
        }

        public NullableNumber(in TInner? value)
        {
            Value = value;
        }

        public NullableNumber<TInner, TPrimitive> Clone()
        {
            return new NullableNumber<TInner, TPrimitive>(Value?.Clone());
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> other)
        {
            return other.Value.HasValue ? Value?.Call(operation, other.Value.Value) : null;
        }

        public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            return Value?.Call(operation, other);
        }

        public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            return Value?.Call(operation, other);
        }

        public NullableNumber<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            return Value?.Call(operation);
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            return Value?.Call(operation) ?? default;
        }

        public override bool Equals(object obj)
        {
            return obj is NullableNumber<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(NullableNumber<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in NullableNumber<TInner, TPrimitive> other)
        {
            return Value.HasValue ? other.Value.HasValue && Value.Value.Equals(other.Value.Value) : !other.Value.HasValue;
        }

        public int CompareTo(NullableNumber<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in NullableNumber<TInner, TPrimitive> other)
        {
            return Value.HasValue ? (other.Value.HasValue ? Value.Value.CompareTo(other.Value.Value) : 1) : (other.Value.HasValue ? -1 : 0);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString() : "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.HasValue ? Value.Value.ToString(format, formatProvider) : "Null";
        }

        public static implicit operator NullableNumber<TInner, TPrimitive>(in TInner value)
        {
            return new NullableNumber<TInner, TPrimitive>(value);
        }

        public static implicit operator NullableNumber<TInner, TPrimitive>(in TInner? value)
        {
            return new NullableNumber<TInner, TPrimitive>(value);
        }

        public static bool operator==(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in NullableNumber<TInner, TPrimitive> a, in NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullableNumber<TInner, TPrimitive>> INumber<NullableNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullableNumber<TInner, TPrimitive>, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<NullableNumber<TInner, TPrimitive>>, INumberOperations<NullableNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public bool IsInvertible(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public NullableNumber<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public NullableNumber<TInner, TPrimitive> Call(UnaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }
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

        int ICollection<TPrimitive>.Count => Value.HasValue ? GetCollectionCount(Value.Value) : 0;

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => Value.HasValue ? GetReadOnlyCollectionCount(Value.Value) : 0;

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                if(!Value.HasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetReadOnlyListItem(Value.Value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get {
                if(!Value.HasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetListItem(Value.Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Value?.IndexOf(item) ?? -1;
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
            return Value?.Contains(item) ?? false;
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Value?.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Value?.GetEnumerator() ?? Enumerable.Empty<TPrimitive>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value?.GetEnumerator() ?? Enumerable.Empty<TPrimitive>().GetEnumerator();
        }
    }
}
