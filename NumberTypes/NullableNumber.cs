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
    public readonly partial struct NullableNumber<TInner> : IWrapperNumber<NullableNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
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

        public NullableNumber<TInner> CallReversed(BinaryOperation operation, in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, other, value);
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

        public bool Equals(in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Equals(value, other);
            }
            return false;
        }

        public int CompareTo(in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Compare(value, other);
            }
            return -1;
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

        partial class Operations : NumberOperations<NullableNumber<TInner>>, IExtendedNumberOperations<NullableNumber<TInner>, TInner>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public NullableNumber<TInner> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if(hasValue)
            {
                foreach(var obj in value)
                {
                    yield return obj;
                }
            }
        }
    }

    /// <summary>
    /// Represents a number type constructed from <typeparamref name="TInner"/> with an additional "null" value.
    /// The result of any operation whose operand is null is itself null.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    [Serializable]
    public readonly partial struct NullableNumber<TInner, TComponent> : IWrapperNumber<NullableNumber<TInner, TComponent>, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
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

        public NullableNumber<TInner, TComponent> Clone()
        {
            if(hasValue)
            {
                return HyperMath.Clone(value);
            }
            return default;
        }

        public static implicit operator NullableNumber<TInner, TComponent>(TInner? value)
        {
            return new NullableNumber<TInner, TComponent>(value);
        }

        public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in NullableNumber<TInner, TComponent> other)
        {
            if(hasValue && other.hasValue)
            {
                return HyperMath.Call(operation, value, other.value);
            }
            return default;
        }

        public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, value, other);
            }
            return default;
        }

        public NullableNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, other, value);
            }
            return default;
        }

        public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent other)
        {
            if(hasValue)
            {
                return HyperMath.CallComponent<TInner, TComponent>(operation, value, other);
            }
            return default;
        }

        public NullableNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in TComponent other)
        {
            if(hasValue)
            {
                return HyperMath.CallComponentReversed(operation, other, value);
            }
            return default;
        }

        public NullableNumber<TInner, TComponent> Call(UnaryOperation operation)
        {
            if(hasValue)
            {
                return HyperMath.Call(operation, value);
            }
            return default;
        }

        public TComponent CallComponent(UnaryOperation operation)
        {
            return Value?.CallComponent(operation) ?? default;
        }

        public override bool Equals(object obj)
        {
            return obj is NullableNumber<TInner, TComponent> value && Equals(in value);
        }

        public bool Equals(in NullableNumber<TInner, TComponent> other)
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

        public int CompareTo(in NullableNumber<TInner, TComponent> other)
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

        public bool Equals(in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Equals(value, other);
            }
            return false;
        }

        public int CompareTo(in TInner other)
        {
            if(hasValue)
            {
                return HyperMath.Compare(value, other);
            }
            return -1;
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

        partial class Operations : NumberOperations<NullableNumber<TInner, TComponent>>, IExtendedNumberOperations<NullableNumber<TInner, TComponent>, TInner, TComponent>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public NullableNumber<TInner, TComponent> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public NullableNumber<TInner, TComponent> Create(in TComponent num)
            {
                return new NullableNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(num));
            }

            public NullableNumber<TInner, TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                return HyperMath.Create<TInner, TComponent>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public NullableNumber<TInner, TComponent> Create(IEnumerable<TComponent> units)
            {
                return new NullableNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public NullableNumber<TInner, TComponent> Create(IEnumerator<TComponent> units)
            {
                return new NullableNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }
        }

        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }

        int ICollection<TComponent>.Count => Value.HasValue ? GetCollectionCount(Value.Value) : 0;

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => Value.HasValue ? GetReadOnlyCollectionCount(Value.Value) : 0;

        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                if(!hasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return GetReadOnlyListItem(value, index);
            }
        }

        TComponent IList<TComponent>.this[int index]
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

        int IList<TComponent>.IndexOf(TComponent item)
        {
            if(!hasValue)
            {
                return -1;
            }
            return value.IndexOf(item);
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
            if(!hasValue)
            {
                return false;
            }
            return value.Contains(item);
        }

        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            if(hasValue)
            {
                value.CopyTo(array, arrayIndex);
            }
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
            if(!hasValue)
            {
                return Enumerable.Empty<TComponent>().GetEnumerator();
            }
            return value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if(!hasValue)
            {
                return Enumerable.Empty<TComponent>().GetEnumerator();
            }
            return value.GetEnumerator();
        }
    }
}
