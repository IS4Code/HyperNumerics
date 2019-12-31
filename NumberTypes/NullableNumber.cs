using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number type constructed from <typeparamref name="TInner"/> with an additional "null" value.
    /// The result of any operation whose operand is null is itself null.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    [Serializable]
    public readonly struct NullableNumber<TInner> : IWrapperNumber<NullableNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        readonly bool hasValue;
        readonly TInner value;

        public TInner? Value => hasValue ? (TInner?)value : null;

        public bool IsInvertible => hasValue ? CanInv(value) : true;

        public bool IsFinite => hasValue ? IsFin(value) : true;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        TInner IWrapperNumber<TInner>.Value => hasValue ? value : throw new InvalidOperationException("The number is null.");

        public NullableNumber(in TInner value)
        {
            hasValue = true;
            this.value = value;
        }

        public NullableNumber(in TInner? value)
        {
            hasValue = value.HasValue;
            this.value = value.GetValueOrDefault();
        }

        public NullableNumber<TInner> Clone()
        {
            if(hasValue)
            {
                return HyperMath.Clone(value);
            }
            return default;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator NullableNumber<TInner>(TInner value)
        {
            return new NullableNumber<TInner>(value);
        }

        public static implicit operator NullableNumber<TInner>(TInner? value)
        {
            return new NullableNumber<TInner>(value);
        }

        public NullableNumber<TInner> Call(BinaryOperation operation, in NullableNumber<TInner> other)
        {
            if(hasValue && other.hasValue)
            {
                return HyperMath.Call(operation, value, other.value);
            }
            return default;
        }

        public NullableNumber<TInner> Call(BinaryOperation operation, in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, value, other);
            }
            return default;
        }

        public NullableNumber<TInner> Call(UnaryOperation operation)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, value);
            }
            return default;
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
            if(hasValue)
            {
                if(other.hasValue)
                {
                    return HyperMath.Equals(value, other.value);
                }
                return false;
            }
            return !other.hasValue;
        }

        public int CompareTo(NullableNumber<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in NullableNumber<TInner> other)
        {
            if(hasValue)
            {
                if(other.hasValue)
                {
                    return HyperMath.Compare(value, other.value);
                }
                return 1;
            }
            return other.hasValue ? -1 : 0;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return hasValue ? value.ToString() : "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return hasValue ? value.ToString(format, formatProvider) : "Null";
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

        IExtendedNumberOperations<NullableNumber<TInner>, TInner> IExtendedNumber<NullableNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<NullableNumber<TInner>>, IExtendedNumberOperations<NullableNumber<TInner>, TInner>
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

            public NullableNumber<TInner> Clone(in NullableNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(NullableNumber<TInner> num1, NullableNumber<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(NullableNumber<TInner> num1, NullableNumber<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(NullableNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullableNumber<TInner> num)
            {
                return num.GetHashCode();
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

            public NullableNumber<TInner> Call(BinaryOperation operation, in NullableNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner> Create(in TInner num)
            {
                return new NullableNumber<TInner>(num);
            }
        }
    }

    /// <summary>
    /// Represents a number type constructed from <typeparamref name="TInner"/> with an additional "null" value.
    /// The result of any operation whose operand is null is itself null.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    [Serializable]
    public readonly struct NullableNumber<TInner, TPrimitive> : IWrapperNumber<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        readonly bool hasValue;
        readonly TInner value;

        public TInner? Value => hasValue ? (TInner?)value : null;

        public bool IsInvertible => hasValue ? CanInv(value) : true;

        public bool IsFinite => hasValue ? IsFin(value) : true;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        TInner IWrapperNumber<TInner>.Value => hasValue ? value : throw new InvalidOperationException("The number is null.");

        public NullableNumber(in TInner value)
        {
            hasValue = true;
            this.value = value;
        }

        public NullableNumber(in TInner? value)
        {
            hasValue = value.HasValue;
            this.value = value.GetValueOrDefault();
        }

        public NullableNumber<TInner, TPrimitive> Clone()
        {
            if(hasValue)
            {
                return HyperMath.Clone(value);
            }
            return default;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator NullableNumber<TInner, TPrimitive>(TInner value)
        {
            return new NullableNumber<TInner, TPrimitive>(value);
        }

        public static implicit operator NullableNumber<TInner, TPrimitive>(TInner? value)
        {
            return new NullableNumber<TInner, TPrimitive>(value);
        }

        public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> other)
        {
            if(hasValue && other.hasValue)
            {
                return HyperMath.Call(operation, value, other.value);
            }
            return default;
        }

        public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, value, other);
            }
            return default;
        }

        public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            if(hasValue)
            {
                return HyperMath.CallPrimitive<TInner, TPrimitive>(operation, value, other);
            }
            return default;
        }

        public NullableNumber<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, value);
            }
            return default;
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
            if(hasValue)
            {
                if(other.hasValue)
                {
                    return HyperMath.Equals(value, other.value);
                }
                return false;
            }
            return !other.hasValue;
        }

        public int CompareTo(NullableNumber<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in NullableNumber<TInner, TPrimitive> other)
        {
            if(hasValue)
            {
                if(other.hasValue)
                {
                    return HyperMath.Compare(value, other.value);
                }
                return 1;
            }
            return other.hasValue ? -1 : 0;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return hasValue ? value.ToString() : "Null";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return hasValue ? value.ToString(format, formatProvider) : "Null";
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

        IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, TInner> IExtendedNumber<NullableNumber<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<NullableNumber<TInner, TPrimitive>>, IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive>
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

            public NullableNumber<TInner, TPrimitive> Clone(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(NullableNumber<TInner, TPrimitive> num1, NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(NullableNumber<TInner, TPrimitive> num1, NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in NullableNumber<TInner, TPrimitive> num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in NullableNumber<TInner, TPrimitive> num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(NullableNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
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

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public NullableNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new NullableNumber<TInner, TPrimitive>(num);
            }

            public NullableNumber<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                return new NullableNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }

            public NullableNumber<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                return new NullableNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
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
                if(!hasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetReadOnlyListItem(value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get {
                if(!hasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetListItem(value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            if(!hasValue)
            {
                return -1;
            }
            return value.IndexOf(item);
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
            if(!hasValue)
            {
                return false;
            }
            return value.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            if(hasValue)
            {
                value.CopyTo(array, arrayIndex);
            }
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            if(!hasValue)
            {
                return Enumerable.Empty<TPrimitive>().GetEnumerator();
            }
            return value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if(!hasValue)
            {
                return Enumerable.Empty<TPrimitive>().GetEnumerator();
            }
            return value.GetEnumerator();
        }
    }
}
