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
    }

    /// <summary>
    /// Represents a number whose actual value is provided by a generator function.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    [Serializable]
    public readonly partial struct GeneratedNumber<TInner, TPrimitive> : IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
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

        public bool Equals(in GeneratedNumber<TInner, TPrimitive> other)
        {
            return Generator.Equals(other.Generator);
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

        partial class Operations : NumberOperations<GeneratedNumber<TInner, TPrimitive>>, IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive>
        {
            public override int Dimension => 0;

            public GeneratedNumber<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Call<TInner>(operation));
            }

            public GeneratedNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return new GeneratedNumber<TInner, TPrimitive>(() => HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined));
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
    }
}
