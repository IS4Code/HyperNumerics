using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct CustomDefaultNumber<TInner, TTraits> : IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
    {
        static readonly TInner defaultValue = default(TTraits).DefaultValue;

        private readonly TInner value;
        private readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => Value.IsInvertible;

        public bool IsFinite => Value.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TTraits> Clone()
        {
            return new CustomDefaultNumber<TInner, TTraits>(Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Value.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> other)
        {
            return HyperMath.Call(operation, Value, other.Value);
        }

        public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, Value, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, Value, other);
        }

        public CustomDefaultNumber<TInner, TTraits> Call(UnaryOperation operation)
        {
            return HyperMath.Call(operation, Value);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            return HyperMath.Call(operation, Value);
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(CustomDefaultNumber<TInner, TTraits> other)
        {
            return Equals(in other);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return Value.Equals(other.Value);
        }

        public bool Equals(TInner other)
        {
            return Value.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Value.Equals(other);
        }

        public int CompareTo(CustomDefaultNumber<TInner, TTraits> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TTraits> other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(TInner other)
        {
            return Value.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Value.CompareTo(other);
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

        public static implicit operator CustomDefaultNumber<TInner, TTraits>(in TInner value)
        {
            return new CustomDefaultNumber<TInner, TTraits>(value);
        }

        public static implicit operator TInner(in CustomDefaultNumber<TInner, TTraits> number)
        {
            return number.Value;
        }

        public static bool operator==(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in CustomDefaultNumber<TInner, TTraits> a, in CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TTraits>> INumber<CustomDefaultNumber<TInner, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return Value.GetOperations();
        }

        class Operations : NumberOperations<CustomDefaultNumber<TInner, TTraits>>, INumberOperations<CustomDefaultNumber<TInner, TTraits>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public bool IsInvertible(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.IsFinite;
            }

            public CustomDefaultNumber<TInner, TTraits> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public CustomDefaultNumber<TInner, TTraits> Call(UnaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.Call(operation, num2);
            }
        }

        public interface ITraits
        {
            TInner DefaultValue { get; }
        }
    }
    
    [Serializable]
    public readonly struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>, INumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
    {
        static readonly TInner defaultValue = default(TTraits).DefaultValue;

        private readonly TInner value;
        private readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => Value.IsInvertible;

        public bool IsFinite => Value.IsFinite;

        static readonly Lazy<int> DimensionLazy = new Lazy<int>(() => default(TInner).Dimension);
        public static int Dimension => DimensionLazy.Value;
        int INumber.Dimension => Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Clone()
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Value.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return HyperMath.Call(operation, Value, other.Value);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, Value, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, Value, other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, TPrimitive other)
        {
            return HyperMath.CallPrimitive(operation, Value, other);
        }

        TInner INumber<TInner, TPrimitive>.Call(BinaryOperation operation, TPrimitive other)
        {
            return HyperMath.CallPrimitive(operation, Value, other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(UnaryOperation operation)
        {
            return HyperMath.Call(operation, Value);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            return HyperMath.Call(operation, Value);
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            return HyperMath.Call<TInner, TPrimitive>(operation, Value);
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TPrimitive, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Equals(in other);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Value.Equals(other.Value);
        }

        public bool Equals(TInner other)
        {
            return Value.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Value.Equals(other);
        }

        public int CompareTo(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(TInner other)
        {
            return Value.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Value.CompareTo(other);
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

        public static implicit operator CustomDefaultNumber<TInner, TPrimitive, TTraits>(in TInner value)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(value);
        }

        public static implicit operator TInner(in CustomDefaultNumber<TInner, TPrimitive, TTraits> number)
        {
            return number.Value;
        }

        public static bool operator==(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in CustomDefaultNumber<TInner, TPrimitive, TTraits> a, in CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return Value.GetOperations();
        }

        INumberOperations<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetOperations()
        {
            return Value.GetOperations();
        }

        class Operations : NumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>>, INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public bool IsInvertible(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.IsFinite;
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(UnaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }
        }

        public interface ITraits
        {
            TInner DefaultValue { get; }
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(Value);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Value);

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Value.IndexOf(item);
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
            return Value.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
