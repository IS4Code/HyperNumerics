using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Stores a reference to a boxed instance of <typeparamref name="TInner"/> so that it is not copied when the value is reassigned.
    /// </summary>
    /// <typeparam name="TInner">The internal number type that the instance supports.</typeparam>
    [Serializable]
    public readonly struct BoxedNumber<TInner> : IExtendedNumber<BoxedNumber<TInner>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner>
    {
        static TInner defaultValue;

        readonly Instance instance;

        ref TInner Reference{
            get{
                if(instance != null)
                {
                    return ref instance.Value;
                }
                return ref defaultValue;
            }
        }

        public bool IsInvertible => Reference.IsInvertible;

        public bool IsFinite => Reference.IsFinite;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public BoxedNumber(in TInner value)
        {
            instance = defaultValue.Equals(in value) ? null : new Instance(value);
        }

        public BoxedNumber<TInner> Clone()
        {
            if(instance == null) return default;
            return new BoxedNumber<TInner>(instance.Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Reference.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator BoxedNumber<TInner>(TInner value)
        {
            return new BoxedNumber<TInner>(value);
        }

        public static implicit operator TInner(BoxedNumber<TInner> value)
        {
            return value.Reference;
        }

        public BoxedNumber<TInner> Call(BinaryOperation operation, in BoxedNumber<TInner> other)
        {
            return Reference.Call(operation, other.Reference);
        }

        public BoxedNumber<TInner> Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner> Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is BoxedNumber<TInner> value && Equals(value) || Reference.Equals(obj);
        }

        public bool Equals(BoxedNumber<TInner> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in BoxedNumber<TInner> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(TInner other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(BoxedNumber<TInner> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(in BoxedNumber<TInner> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(TInner other)
        {
            return Reference.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Reference.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        public override string ToString()
        {
            return Reference.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Reference.ToString(format, formatProvider);
        }

        public static bool operator==(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BoxedNumber<TInner>> INumber<BoxedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

        class Operations : NumberOperations<BoxedNumber<TInner>>, INumberOperations<BoxedNumber<TInner>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public bool IsInvertible(in BoxedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BoxedNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public BoxedNumber<TInner> Clone(in BoxedNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public BoxedNumber<TInner> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public BoxedNumber<TInner> Call(UnaryOperation operation, in BoxedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner> Call(BinaryOperation operation, in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }
        }

        class Instance
        {
            public TInner Value;

            public Instance(in TInner value)
            {
                Value = value;
            }
        }
    }

    /// <summary>
    /// Stores a reference to a boxed instance of <typeparamref name="TInner"/> so that it is not copied when the value is reassigned.
    /// </summary>
    /// <typeparam name="TInner">The internal number type that the instance supports.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    [Serializable]
    public readonly struct BoxedNumber<TInner, TPrimitive> : IExtendedNumber<BoxedNumber<TInner, TPrimitive>, TInner, TPrimitive>, INumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        static TInner defaultValue;

        readonly Instance instance;

        ref TInner Reference{
            get{
                if(instance != null)
                {
                    return ref instance.Value;
                }
                return ref defaultValue;
            }
        }

        public bool IsInvertible => Reference.IsInvertible;

        public bool IsFinite => Reference.IsFinite;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public BoxedNumber(in TInner value)
        {
            instance = defaultValue.Equals(in value) ? null : new Instance(value);
        }

        public BoxedNumber<TInner, TPrimitive> Clone()
        {
            if(instance == null) return default;
            return new BoxedNumber<TInner, TPrimitive>(instance.Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Reference.Clone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator BoxedNumber<TInner, TPrimitive>(TInner value)
        {
            return new BoxedNumber<TInner, TPrimitive>(value);
        }

        public static implicit operator TInner(BoxedNumber<TInner, TPrimitive> value)
        {
            return value.Reference;
        }

        public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Call(operation, other.Reference);
        }

        public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner, TPrimitive>.Call(BinaryOperation operation, TPrimitive other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is BoxedNumber<TInner, TPrimitive> value && Equals(value) || Reference.Equals(obj);
        }

        public bool Equals(BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(TInner other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.CompareTo(other.Reference);
        }

        public int CompareTo(TInner other)
        {
            return Reference.CompareTo(other);
        }

        public int CompareTo(in TInner other)
        {
            return Reference.CompareTo(other);
        }

        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        public override string ToString()
        {
            return Reference.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Reference.ToString(format, formatProvider);
        }

        public static bool operator==(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BoxedNumber<TInner, TPrimitive>> INumber<BoxedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BoxedNumber<TInner, TPrimitive>, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return Reference.GetOperations();
        }

        INumberOperations<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetOperations()
        {
            return Reference.GetOperations();
        }

        class Operations : NumberOperations<BoxedNumber<TInner, TPrimitive>>, INumberOperations<BoxedNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public bool IsInvertible(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public BoxedNumber<TInner, TPrimitive> Clone(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(in BoxedNumber<TInner, TPrimitive> num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in BoxedNumber<TInner, TPrimitive> num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public BoxedNumber<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Call(UnaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }
        }

        class Instance
        {
            public TInner Value;

            public Instance(in TInner value)
            {
                Value = value;
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(Reference);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Reference);

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Reference, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Reference, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Reference.IndexOf(item);
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
            return Reference.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Reference.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Reference.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Reference.GetEnumerator();
        }
    }
}
