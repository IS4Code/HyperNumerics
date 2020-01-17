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
    public readonly partial struct GeneratedNumber<TInner> : IExtendedNumber<GeneratedNumber<TInner>, TInner>, INumber<GeneratedNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        public static GeneratedNumber<TInner> Zero => new GeneratedNumber<TInner>(() => HyperMath.Create<TInner>(StandardNumber.Zero));

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

        public GeneratedNumber<TInner> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, gen1(), gen2()));
        }

        public GeneratedNumber<TInner> Call(StandardBinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, gen(), value));
        }

        public GeneratedNumber<TInner> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, value, gen()));
        }

        public GeneratedNumber<TInner> Call(StandardUnaryOperation operation)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, gen()));
        }

        public TInner CallComponent(StandardUnaryOperation operation)
        {
            throw new NotSupportedException();
        }

        public override bool Equals(object obj)
        {
            return obj is GeneratedNumber<TInner> value && Equals(in value);
        }

        public bool Equals(in GeneratedNumber<TInner> other)
        {
            return Generator.Equals(other.Generator);
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

        partial class Operations : NumberOperations<GeneratedNumber<TInner>>, IExtendedNumberOperations<GeneratedNumber<TInner>, TInner>, INumberOperations<GeneratedNumber<TInner>, TInner>
        {
            public override int Dimension => 0;

            public virtual GeneratedNumber<TInner> Create(StandardNumber num)
            {
                return new GeneratedNumber<TInner>(() => HyperMath.Create<TInner>(num));
            }

            public virtual GeneratedNumber<TInner> Create(in TInner realUnit, in TInner otherUnits, in TInner someUnitsCombined, in TInner allUnitsCombined)
            {
                return new GeneratedNumber<TInner>(realUnit);
            }

            public virtual GeneratedNumber<TInner> Create(IEnumerable<TInner> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public virtual GeneratedNumber<TInner> Create(IEnumerator<TInner> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new GeneratedNumber<TInner>(value);
            }
        }
		
        int ICollection<TInner>.Count => 1;

        int IReadOnlyCollection<TInner>.Count => 1;

        TInner IReadOnlyList<TInner>.this[int index] => throw new NotSupportedException();

        TInner IList<TInner>.this[int index]
        {
            get{
                throw new NotSupportedException();
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TInner>.IndexOf(TInner item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Contains(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.CopyTo(TInner[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TInner> IEnumerable<TInner>.GetEnumerator()
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Represents a number whose actual value is provided by a generator function.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    [Serializable]
    public readonly partial struct GeneratedNumber<TInner, TComponent> : IExtendedNumber<GeneratedNumber<TInner, TComponent>, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        public static GeneratedNumber<TInner, TComponent> Zero => new GeneratedNumber<TInner, TComponent>(() => HyperMath.Create<TInner>(StandardNumber.Zero));

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

        public GeneratedNumber<TInner, TComponent> Clone()
        {
            if(generator.Target is ICloneable cloneable)
            {
                return new GeneratedNumber<TInner, TComponent>((Func<TInner>)Delegate.CreateDelegate(typeof(Func<TInner>), cloneable.Clone(), generator.Method));
            }
            return this;
        }

        public GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner, TComponent> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, gen1(), gen2()));
        }

        public GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, gen(), value));
        }

        public GeneratedNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, value, gen()));
        }

        public GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.CallComponent(operation, gen(), value));
        }

        public GeneratedNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.CallComponentReversed(operation, value, gen()));
        }

        public GeneratedNumber<TInner, TComponent> Call(StandardUnaryOperation operation)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, gen()));
        }

        public TComponent CallComponent(StandardUnaryOperation operation)
        {
            return HyperMath.CallComponent<TInner, TComponent>(operation, Generator());
        }

        public override bool Equals(object obj)
        {
            return obj is GeneratedNumber<TInner, TComponent> value && Equals(in value);
        }

        public bool Equals(in GeneratedNumber<TInner, TComponent> other)
        {
            return Generator.Equals(other.Generator);
        }

        public int CompareTo(in GeneratedNumber<TInner, TComponent> other)
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

        partial class Operations : NumberOperations<GeneratedNumber<TInner, TComponent>>, IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, TInner, TComponent>
        {
            public override int Dimension => 0;

            public virtual GeneratedNumber<TInner, TComponent> Create(StandardNumber num)
            {
                return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Create<TInner>(num));
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(in TComponent num)
            {
                var numCopy = num;
                return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Operations.For<TInner, TComponent>.Instance.Create(numCopy));
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                var realUnitCopy = realUnit;
                var otherUnitsCopy = otherUnits;
                var someUnitsCombinedCopy = someUnitsCombined;
                var allUnitsCombinedCopy = allUnitsCombined;
                return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Create<TInner, TComponent>(realUnitCopy, otherUnitsCopy, someUnitsCombinedCopy, allUnitsCombinedCopy));
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(IEnumerable<TComponent> units)
            {
                return new GeneratedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(IEnumerator<TComponent> units)
            {
                return new GeneratedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }
        }
    }
}
