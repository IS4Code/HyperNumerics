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
    public readonly partial struct BoxedNumber<TInner> : IWrapperNumber<BoxedNumber<TInner>, TInner>, INumber<BoxedNumber<TInner>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner>
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

        public TInner CallComponent(UnaryOperation operation)
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

        partial class Operations : NumberOperations<BoxedNumber<TInner>>, IExtendedNumberOperations<BoxedNumber<TInner>, TInner>, INumberOperations<BoxedNumber<TInner>, TInner>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public virtual BoxedNumber<TInner> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public virtual BoxedNumber<TInner> Create(in TInner realUnit, in TInner otherUnits, in TInner someUnitsCombined, in TInner allUnitsCombined)
            {
                return new BoxedNumber<TInner>(realUnit);
            }

            public virtual BoxedNumber<TInner> Create(IEnumerable<TInner> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public virtual BoxedNumber<TInner> Create(IEnumerator<TInner> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new BoxedNumber<TInner>(value);
            }
        }

        internal class Instance
        {
            public TInner Value;

            public Instance(in TInner value)
            {
                Value = value;
            }
        }
		
        int ICollection<TInner>.Count => 1;

        int IReadOnlyCollection<TInner>.Count => 1;

        TInner IReadOnlyList<TInner>.this[int index] => index == 0 ? Reference : throw new ArgumentOutOfRangeException(nameof(index));

        TInner IList<TInner>.this[int index]
        {
            get{
                return index == 0 ? Reference : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TInner>.IndexOf(TInner item)
        {
            return Reference.Equals(item) ? 0 : -1;
        }

        bool ICollection<TInner>.Contains(TInner item)
        {
            return Reference.Equals(item);
        }

        void ICollection<TInner>.CopyTo(TInner[] array, int arrayIndex)
        {
            array[arrayIndex] = Reference;
        }

        IEnumerator<TInner> IEnumerable<TInner>.GetEnumerator()
        {
            yield return Reference;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Reference.GetEnumerator();
        }
    }

    /// <summary>
    /// Stores a reference to a boxed instance of <typeparamref name="TInner"/> so that it is not copied when the value is reassigned.
    /// </summary>
    /// <typeparam name="TInner">The internal number type that the instance supports.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    [Serializable]
    public readonly partial struct BoxedNumber<TInner, TComponent> : IWrapperNumber<BoxedNumber<TInner, TComponent>, TInner, TComponent>, INumber<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        static TInner defaultValue;

        readonly BoxedNumber<TInner>.Instance instance;

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
            instance = defaultValue.Equals(in value) ? null : new BoxedNumber<TInner>.Instance(value);
        }

        public BoxedNumber<TInner, TComponent> Clone()
        {
            if(instance == null) return default;
            return new BoxedNumber<TInner, TComponent>(instance.Value.Clone());
        }

        TInner INumber<TInner>.Clone()
        {
            return Reference.Clone();
        }

        public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in BoxedNumber<TInner, TComponent> other)
        {
            return Reference.Call(operation, other.Reference);
        }

        public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent other)
        {
            return Reference.Call(operation, other);
        }

        public BoxedNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in TComponent other)
        {
            return Reference.CallReversed(operation, other);
        }

        TInner INumber<TInner, TComponent>.Call(BinaryOperation operation, in TComponent other)
        {
            return Reference.Call(operation, other);
        }

        TInner INumber<TInner, TComponent>.CallReversed(BinaryOperation operation, in TComponent other)
        {
            return Reference.CallReversed(operation, other);
        }

        public BoxedNumber<TInner, TComponent> Call(UnaryOperation operation)
        {
            return Reference.Call(operation);
        }

        public BoxedNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in TInner other)
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

        public TComponent CallComponent(UnaryOperation operation)
        {
            return Reference.CallComponent(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is BoxedNumber<TInner, TComponent> value && Equals(value) || Reference.Equals(obj);
        }

        public bool Equals(in BoxedNumber<TInner, TComponent> other)
        {
            return Reference.Equals(other);
        }

        public bool Equals(in TInner other)
        {
            return Reference.Equals(other);
        }

        public int CompareTo(in BoxedNumber<TInner, TComponent> other)
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

        partial class Operations : NumberOperations<BoxedNumber<TInner, TComponent>>, IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, TInner, TComponent>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public virtual BoxedNumber<TInner, TComponent> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public virtual BoxedNumber<TInner, TComponent> Create(in TComponent num)
            {
                return new BoxedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(num));
            }

            public virtual BoxedNumber<TInner, TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                return HyperMath.Create<TInner, TComponent>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public virtual BoxedNumber<TInner, TComponent> Create(IEnumerable<TComponent> units)
            {
                return new BoxedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public virtual BoxedNumber<TInner, TComponent> Create(IEnumerator<TComponent> units)
            {
                return new BoxedNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public virtual BoxedNumber<TInner, TComponent> Create(in TInner realUnit, in TInner otherUnits, in TInner someUnitsCombined, in TInner allUnitsCombined)
            {
                return new BoxedNumber<TInner, TComponent>(realUnit);
            }

            public virtual BoxedNumber<TInner, TComponent> Create(IEnumerable<TInner> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public virtual BoxedNumber<TInner, TComponent> Create(IEnumerator<TInner> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new BoxedNumber<TInner, TComponent>(value);
            }
        }
    }
}
