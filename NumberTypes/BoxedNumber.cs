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
    public readonly partial struct BoxedNumber<TInner> : IWrapperNumber<BoxedNumber<TInner>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner>
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

        public ref readonly TInner Value => ref Reference;

        TInner IWrapperNumber<TInner>.Value => Reference;

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

        public BoxedNumber<TInner> Call(BinaryOperation operation, in BoxedNumber<TInner> other)
        {
            return Reference.Call(operation, other.Reference);
        }

        public BoxedNumber<TInner> Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner> CallReversed(BinaryOperation operation, in TInner other)
        {
            return Reference.CallReversed(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner>.CallReversed(BinaryOperation operation, in TInner other)
        {
            return Reference.CallReversed(operation, other);
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

        public bool Equals(in BoxedNumber<TInner> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(in BoxedNumber<TInner> other)
        {
            return Reference.CompareTo(other.Reference);
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

        partial class Operations : NumberOperations<BoxedNumber<TInner>>, IExtendedNumberOperations<BoxedNumber<TInner>, TInner>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public BoxedNumber<TInner> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
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
    public readonly partial struct BoxedNumber<TInner, TPrimitive> : IWrapperNumber<BoxedNumber<TInner, TPrimitive>, TInner, TPrimitive>, INumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
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

        public ref readonly TInner Value => ref Reference;

        TInner IWrapperNumber<TInner>.Value => Reference;

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

        public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner, TPrimitive> CallReversed(BinaryOperation operation, in TPrimitive other)
        {
            return Reference.CallReversed(operation, other);
        }

        TInner INumber<TInner, TPrimitive>.Call(BinaryOperation operation, in TPrimitive other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner, TPrimitive>.CallReversed(BinaryOperation operation, in TPrimitive other)
        {
            return Reference.CallReversed(operation, other);
        }

        public BoxedNumber<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        public BoxedNumber<TInner, TPrimitive> CallReversed(BinaryOperation operation, in TInner other)
        {
            return Reference.CallReversed(operation, other);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        TInner INumber<TInner>.CallReversed(BinaryOperation operation, in TInner other)
        {
            return Reference.CallReversed(operation, other);
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is BoxedNumber<TInner, TPrimitive> value && Equals(value) || Reference.Equals(obj);
        }

        public bool Equals(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(in BoxedNumber<TInner, TPrimitive> other)
        {
            return Reference.CompareTo(other.Reference);
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

        partial class Operations : NumberOperations<BoxedNumber<TInner, TPrimitive>>, IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, TInner, TPrimitive>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public BoxedNumber<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Create(in TPrimitive realUnit, in TPrimitive otherUnits, in TPrimitive someUnitsCombined, in TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public BoxedNumber<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                return new BoxedNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }

            public BoxedNumber<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                return new BoxedNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
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
}
