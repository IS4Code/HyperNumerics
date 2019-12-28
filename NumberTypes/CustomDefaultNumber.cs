using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct CustomDefaultNumber<TInner, TTraits> : IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
    {
        static TInner defaultValue = default(TTraits).DefaultValue;

        readonly TInner value;
        readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => initialized ? CanInv(value) : defaultValue.IsInvertible;

        public bool IsFinite => initialized ? IsFin(value) : defaultValue.IsFinite;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TTraits> Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        TInner INumber<TInner>.Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator CustomDefaultNumber<TInner, TTraits>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TTraits>(value);
        }

        public static implicit operator TInner(in CustomDefaultNumber<TInner, TTraits> number)
        {
            return number.Value;
        }

        public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Call(operation, value, other.value);
                }
                return HyperMath.Call(operation, value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Call(operation, defaultValue, other.value);
            }
            return HyperMath.Call(operation, defaultValue, defaultValue);
        }

        public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TTraits> Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
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
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Equals(value, other.value);
                }
                return HyperMath.Equals(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Equals(defaultValue, other.value);
            }
            return true;
        }

        public bool Equals(TInner other)
        {
            return Equals(in other);
        }

        public bool Equals(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Equals(value, other);
            }
            return HyperMath.Equals(defaultValue, other);
        }

        public int CompareTo(CustomDefaultNumber<TInner, TTraits> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Compare(value, other.value);
                }
                return HyperMath.Compare(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Compare(defaultValue, other.value);
            }
            return 0;
        }

        public int CompareTo(TInner other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Compare(value, other);
            }
            return HyperMath.Compare(defaultValue, other);
        }

        public override int GetHashCode()
        {
            if(initialized)
            {
                return value.GetHashCode();
            }
            return defaultValue.GetHashCode();
        }

        public override string ToString()
        {
            if(initialized)
            {
                return value.ToString();
            }
            return defaultValue.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(initialized)
            {
                return value.ToString(format, formatProvider);
            }
            return defaultValue.ToString(format, formatProvider);
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

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

        class Operations : NumberOperations<CustomDefaultNumber<TInner, TTraits>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, TInner>
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

            public CustomDefaultNumber<TInner, TTraits> Clone(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.Clone();
            }

            public bool Equals(in CustomDefaultNumber<TInner, TTraits> num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in CustomDefaultNumber<TInner, TTraits> num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.CompareTo(in num2);
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

            public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TTraits> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TTraits>(num);
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
        static TInner defaultValue = default(TTraits).DefaultValue;

        readonly TInner value;
        readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => initialized ? CanInv(value) : defaultValue.IsInvertible;

        public bool IsFinite => initialized ? IsFin(value) : defaultValue.IsFinite;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        TInner INumber<TInner>.Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator CustomDefaultNumber<TInner, TPrimitive, TTraits>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(value);
        }

        public static implicit operator TInner(in CustomDefaultNumber<TInner, TPrimitive, TTraits> number)
        {
            return number.Value;
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Call(operation, value, other.value);
                }
                return HyperMath.Call(operation, value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Call(operation, defaultValue, other.value);
            }
            return HyperMath.Call(operation, defaultValue, defaultValue);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, TPrimitive other)
        {
            if(initialized)
            {
                return HyperMath.CallPrimitive(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner, TPrimitive>.Call(BinaryOperation operation, TPrimitive other)
        {
            if(initialized)
            {
                return HyperMath.CallPrimitive(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call<TInner, TPrimitive>(operation, value);
            }
            return defaultValue.Call(operation);
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
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Equals(value, other.value);
                }
                return HyperMath.Equals(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Equals(defaultValue, other.value);
            }
            return true;
        }

        public bool Equals(TInner other)
        {
            return Equals(in other);
        }

        public bool Equals(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Equals(value, other);
            }
            return HyperMath.Equals(defaultValue, other);
        }

        public int CompareTo(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Compare(value, other.value);
                }
                return HyperMath.Compare(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Compare(defaultValue, other.value);
            }
            return 0;
        }

        public int CompareTo(TInner other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Compare(value, other);
            }
            return HyperMath.Compare(defaultValue, other);
        }

        public override int GetHashCode()
        {
            if(initialized)
            {
                return value.GetHashCode();
            }
            return defaultValue.GetHashCode();
        }

        public override string ToString()
        {
            if(initialized)
            {
                return value.ToString();
            }
            return defaultValue.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(initialized)
            {
                return value.ToString(format, formatProvider);
            }
            return defaultValue.ToString(format, formatProvider);
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

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

        INumberOperations<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetOperations()
        {
            return HyperMath.Operations.For<TInner, TPrimitive>.Instance;
        }

        class Operations : NumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>
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

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Clone(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.Clone();
            }

            public bool Equals(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.CompareTo(in num2);
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

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(num);
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
