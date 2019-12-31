using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number whose actual value is provided by a generator function.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    [Serializable]
    public readonly struct GeneratedNumber<TInner> : IExtendedNumber<GeneratedNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        public static GeneratedNumber<TInner> Zero => new GeneratedNumber<TInner>(() => HyperMath.Call<TInner>(NullaryOperation.Zero));

        readonly Func<TInner> generator;

        public Func<TInner> Generator => generator ?? Zero.Generator;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public GeneratedNumber(in TInner value)
        {
            generator = new ConstGenerator(value).Get;
        }

        class ConstGenerator : ICloneable
        {
            readonly TInner value;

            public ConstGenerator(in TInner value)
            {
                this.value = value;
            }

            public TInner Get()
            {
                return value;
            }

            public object Clone()
            {
                return new ConstGenerator(HyperMath.Clone(value));
            }
        }

        public GeneratedNumber(Func<TInner> generator)
        {
            this.generator = generator;
        }

        public GeneratedNumber<TInner> Clone()
        {
            if(generator.Target is ICloneable cloneable)
            {
                return new GeneratedNumber<TInner>((Func<TInner>)Delegate.CreateDelegate(typeof(Func<TInner>), cloneable.Clone(), generator.Method));
            }
            return this;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner> Call(BinaryOperation operation, in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, gen1(), gen2()));
        }

        public GeneratedNumber<TInner> Call(BinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, gen(), value));
        }

        public GeneratedNumber<TInner> Call(UnaryOperation operation)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, gen()));
        }

        public override bool Equals(object obj)
        {
            return obj is GeneratedNumber<TInner> value && Equals(in value);
        }

        public bool Equals(GeneratedNumber<TInner> other)
        {
            return Generator.Equals(other.Generator);
        }

        public bool Equals(in GeneratedNumber<TInner> other)
        {
            return Generator.Equals(other.Generator);
        }

        public int CompareTo(GeneratedNumber<TInner> other)
        {
            return 0;
        }

        public int CompareTo(in GeneratedNumber<TInner> other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Generator.GetHashCode();
        }

        public override string ToString()
        {
            return Generator.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Generator.ToString();
        }

        public static implicit operator GeneratedNumber<TInner>(in TInner value)
        {
            return new GeneratedNumber<TInner>(value);
        }

        public static bool operator==(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<GeneratedNumber<TInner>> INumber<GeneratedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<GeneratedNumber<TInner>, TInner> IExtendedNumber<GeneratedNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<GeneratedNumber<TInner>>, IExtendedNumberOperations<GeneratedNumber<TInner>, TInner>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => 0;

            public bool IsInvertible(in GeneratedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in GeneratedNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public GeneratedNumber<TInner> Clone(in GeneratedNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(GeneratedNumber<TInner> num1, GeneratedNumber<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(GeneratedNumber<TInner> num1, GeneratedNumber<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(GeneratedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in GeneratedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public GeneratedNumber<TInner> Call(NullaryOperation operation)
            {
                return new GeneratedNumber<TInner>(() => HyperMath.Call<TInner>(operation));
            }

            public GeneratedNumber<TInner> Call(UnaryOperation operation, in GeneratedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner> Call(BinaryOperation operation, in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner> Call(BinaryOperation operation, in GeneratedNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner> Create(in TInner num)
            {
                return new GeneratedNumber<TInner>(num);
            }
        }
    }

    /// <summary>
    /// Represents a number whose actual value is provided by a generator function.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    [Serializable]
    public readonly struct GeneratedNumber<TInner, TPrimitive> : IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public static GeneratedNumber<TInner, TPrimitive> Zero => new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Call<TInner>(NullaryOperation.Zero));

        readonly Func<TInner> generator;

        public Func<TInner> Generator => generator ?? Zero.Generator;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public GeneratedNumber(in TInner value)
        {
            generator = new ConstGenerator(value).Get;
        }

        class ConstGenerator : ICloneable
        {
            readonly TInner value;

            public ConstGenerator(in TInner value)
            {
                this.value = value;
            }

            public TInner Get()
            {
                return value;
            }

            public object Clone()
            {
                return new ConstGenerator(HyperMath.Clone(value));
            }
        }

        public GeneratedNumber(Func<TInner> generator)
        {
            this.generator = generator;
        }

        public GeneratedNumber<TInner, TPrimitive> Clone()
        {
            if(generator.Target is ICloneable cloneable)
            {
                return new GeneratedNumber<TInner, TPrimitive>((Func<TInner>)Delegate.CreateDelegate(typeof(Func<TInner>), cloneable.Clone(), generator.Method));
            }
            return this;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Call(operation, gen1(), gen2()));
        }

        public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Call(operation, gen(), value));
        }

        public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.CallPrimitive(operation, gen(), other));
        }

        public GeneratedNumber<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Call(operation, gen()));
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            return HyperMath.Call<TInner, TPrimitive>(operation, Generator());
        }

        public override bool Equals(object obj)
        {
            return obj is GeneratedNumber<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(GeneratedNumber<TInner, TPrimitive> other)
        {
            return Generator.Equals(other.Generator);
        }

        public bool Equals(in GeneratedNumber<TInner, TPrimitive> other)
        {
            return Generator.Equals(other.Generator);
        }

        public int CompareTo(GeneratedNumber<TInner, TPrimitive> other)
        {
            return 0;
        }

        public int CompareTo(in GeneratedNumber<TInner, TPrimitive> other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Generator.GetHashCode();
        }

        public override string ToString()
        {
            return Generator.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Generator.ToString();
        }

        public static implicit operator GeneratedNumber<TInner, TPrimitive>(in TInner value)
        {
            return new GeneratedNumber<TInner, TPrimitive>(value);
        }

        public static bool operator==(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in GeneratedNumber<TInner, TPrimitive> a, in GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<GeneratedNumber<TInner, TPrimitive>> INumber<GeneratedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<GeneratedNumber<TInner, TPrimitive>, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, TInner> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<GeneratedNumber<TInner, TPrimitive>>, IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => 0;

            public bool IsInvertible(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public GeneratedNumber<TInner, TPrimitive> Clone(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(GeneratedNumber<TInner, TPrimitive> num1, GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(GeneratedNumber<TInner, TPrimitive> num1, GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in GeneratedNumber<TInner, TPrimitive> num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in GeneratedNumber<TInner, TPrimitive> num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public GeneratedNumber<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Call<TInner>(operation));
            }

            public GeneratedNumber<TInner, TPrimitive> Call(UnaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public bool IsInvertible(in GeneratedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined));
            }

            public GeneratedNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new GeneratedNumber<TInner, TPrimitive>(num);
            }

            public GeneratedNumber<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                return new GeneratedNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }

            public GeneratedNumber<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                return new GeneratedNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
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

        int ICollection<TPrimitive>.Count => GetCollectionCount(Generator());

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Generator());

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Generator(), index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Generator(), index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Generator().IndexOf(item);
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
            return Generator().Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Generator().CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            return Generator().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Generator().GetEnumerator();
        }
    }
}
