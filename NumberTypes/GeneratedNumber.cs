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
    public readonly partial struct GeneratedNumber<TInner> : IExtendedNumber<GeneratedNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
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

        public GeneratedNumber<TInner> CallReversed(BinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner>(() => HyperMath.Call(operation, value, gen()));
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

        partial class Operations : NumberOperations<GeneratedNumber<TInner>>, IExtendedNumberOperations<GeneratedNumber<TInner>, TInner>
        {
            public override int Dimension => 0;

            public GeneratedNumber<TInner> Call(NullaryOperation operation)
            {
                return new GeneratedNumber<TInner>(() => HyperMath.Call<TInner>(operation));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Generator().GetEnumerator();
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
        public static GeneratedNumber<TInner, TComponent> Zero => new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call<TInner>(NullaryOperation.Zero));

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

        public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in GeneratedNumber<TInner, TComponent> other)
        {
            var gen1 = Generator;
            var gen2 = other.Generator;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, gen1(), gen2()));
        }

        public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, gen(), value));
        }

        public GeneratedNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in TInner other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, value, gen()));
        }

        public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.CallComponent(operation, gen(), value));
        }

        public GeneratedNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in TComponent other)
        {
            var gen = Generator;
            var value = other;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.CallComponentReversed(operation, value, gen()));
        }

        public GeneratedNumber<TInner, TComponent> Call(UnaryOperation operation)
        {
            var gen = Generator;
            return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call(operation, gen()));
        }

        public TComponent CallComponent(UnaryOperation operation)
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

            public GeneratedNumber<TInner, TComponent> Call(NullaryOperation operation)
            {
                return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Call<TInner>(operation));
            }

            public GeneratedNumber<TInner, TComponent> Create(in TComponent num)
            {
                var numCopy = num;
                return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Operations.For<TInner, TComponent>.Instance.Create(numCopy));
            }

            public GeneratedNumber<TInner, TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                var realUnitCopy = realUnit;
                var otherUnitsCopy = otherUnits;
                var someUnitsCombinedCopy = someUnitsCombined;
                var allUnitsCombinedCopy = allUnitsCombined;
                return new GeneratedNumber<TInner, TComponent>(() => HyperMath.Create<TInner, TComponent>(realUnitCopy, otherUnitsCopy, someUnitsCombinedCopy, allUnitsCombinedCopy));
            }

            public GeneratedNumber<TInner, TComponent> Create(IEnumerable<TComponent> units)
            {
                return new GeneratedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public GeneratedNumber<TInner, TComponent> Create(IEnumerator<TComponent> units)
            {
                return new GeneratedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }
        }
    }
}
