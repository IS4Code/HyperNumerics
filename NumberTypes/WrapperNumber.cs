using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// A number type containing a single value of <typeparamref name="TInner"/>, without any modifications.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    [Serializable]
    public readonly partial struct WrapperNumber<TInner> : IWrapperNumber<WrapperNumber<TInner>, TInner>, INumber<WrapperNumber<TInner>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner>
    {
        readonly TInner value;

        public TInner Value => value;

        public bool IsInvertible => CanInv(value);

        public bool IsFinite => IsFin(value);

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public WrapperNumber(in TInner value)
        {
            this.value = value;
        }

        public WrapperNumber<TInner> Clone()
        {
            return HyperMath.Clone(value);
        }

        TInner INumber<TInner>.Clone()
        {
            return HyperMath.Clone(value);
        }

        public WrapperNumber<TInner> Call(StandardBinaryOperation operation, in WrapperNumber<TInner> other)
        {
            return HyperMath.Call(operation, value, other.value);
        }

        public WrapperNumber<TInner> Call(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, value, other);
        }

        public WrapperNumber<TInner> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, other, value);
        }

        TInner INumber<TInner>.Call(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, value, other);
        }

        TInner INumber<TInner>.CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, other, value);
        }

        public WrapperNumber<TInner> Call(StandardUnaryOperation operation)
        {
            return HyperMath.Call(operation, value);
        }

        TInner INumber<TInner>.Call(StandardUnaryOperation operation)
        {
            return HyperMath.Call(operation, value);
        }

        public TInner CallComponent(StandardUnaryOperation operation)
        {
            return HyperMath.Call(operation, value);
        }

        public override bool Equals(object obj)
        {
            return obj is WrapperNumber<TInner> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(in WrapperNumber<TInner> other)
        {
            return HyperMath.Equals(value, other.value);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(value, other);
        }

        public int CompareTo(in WrapperNumber<TInner> other)
        {
            return HyperMath.Compare(value, other.value);
        }

        public int CompareTo(in TInner other)
        {
            return HyperMath.Compare(value, other);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return value.ToString(format, formatProvider);
        }

        partial class Operations : NumberOperations<WrapperNumber<TInner>>, IExtendedNumberOperations<WrapperNumber<TInner>, TInner>, INumberOperations<WrapperNumber<TInner>, TInner>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public virtual WrapperNumber<TInner> Create(StandardNumber num)
            {
                return HyperMath.Create<TInner>(num);
            }

            public virtual WrapperNumber<TInner> Create(in TInner realUnit, in TInner otherUnits, in TInner someUnitsCombined, in TInner allUnitsCombined)
            {
                return new WrapperNumber<TInner>(realUnit);
            }

            public virtual WrapperNumber<TInner> Create(IEnumerable<TInner> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public virtual WrapperNumber<TInner> Create(IEnumerator<TInner> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new WrapperNumber<TInner>(value);
            }
        }

        /// <summary>
        /// An interface that a user of <see cref="WrapperNumber{TInner}"/> must provide
        /// to specify the default value of the type.
        /// </summary>
        public interface IDefaultValueProvider
        {
            /// <summary>
            /// Obtains the default value of the type.
            /// </summary>
            TInner DefaultValue { get; }
        }
		
        int ICollection<TInner>.Count => 1;

        int IReadOnlyCollection<TInner>.Count => 1;

        TInner IReadOnlyList<TInner>.this[int index] => index == 0 ? Value : throw new ArgumentOutOfRangeException(nameof(index));

        TInner IList<TInner>.this[int index]
        {
            get{
                return index == 0 ? Value : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TInner>.IndexOf(TInner item)
        {
            return Value.Equals(item) ? 0 : -1;
        }

        bool ICollection<TInner>.Contains(TInner item)
        {
            return Value.Equals(item);
        }

        void ICollection<TInner>.CopyTo(TInner[] array, int arrayIndex)
        {
            array[arrayIndex] = Value;
        }

        IEnumerator<TInner> IEnumerable<TInner>.GetEnumerator()
        {
            yield return Value;
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
            return Value.GetEnumerator();
        }
    }

    /// <summary>
    /// A number type containing a single value of <typeparamref name="TInner"/>, without any modifications.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    [Serializable]
    public readonly partial struct WrapperNumber<TInner, TComponent> : IWrapperNumber<WrapperNumber<TInner, TComponent>, TInner, TComponent>, INumber<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        readonly TInner value;

        public TInner Value => value;

        public bool IsInvertible => CanInv(value);

        public bool IsFinite => IsFin(value);

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public WrapperNumber(in TInner value)
        {
            this.value = value;
        }

        public WrapperNumber<TInner, TComponent> Clone()
        {
            return HyperMath.Clone(value);
        }

        TInner INumber<TInner>.Clone()
        {
            return HyperMath.Clone(value);
        }

        public WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in WrapperNumber<TInner, TComponent> other)
        {
            return HyperMath.Call(operation, value, other.value);
        }

        public WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, value, other);
        }

        public WrapperNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, other, value);
        }

        TInner INumber<TInner>.Call(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, value, other);
        }

        TInner INumber<TInner>.CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            return HyperMath.Call(operation, other, value);
        }

        public WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            return HyperMath.CallComponent(operation, value, other);
        }

        public WrapperNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            return HyperMath.CallComponentReversed(operation, other, value);
        }

        TInner INumber<TInner, TComponent>.Call(StandardBinaryOperation operation, in TComponent other)
        {
            return HyperMath.CallComponent(operation, value, other);
        }

        TInner INumber<TInner, TComponent>.CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            return HyperMath.CallComponentReversed(operation, other, value);
        }

        public WrapperNumber<TInner, TComponent> Call(StandardUnaryOperation operation)
        {
            return HyperMath.Call(operation, value);
        }

        TInner INumber<TInner>.Call(StandardUnaryOperation operation)
        {
            return HyperMath.Call(operation, value);
        }

        public TComponent CallComponent(StandardUnaryOperation operation)
        {
            return HyperMath.CallComponent<TInner, TComponent>(operation, value);
        }

        public override bool Equals(object obj)
        {
            return obj is WrapperNumber<TInner, TComponent> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(in WrapperNumber<TInner, TComponent> other)
        {
            return HyperMath.Equals(value, other.value);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(value, other);
        }

        public int CompareTo(in WrapperNumber<TInner, TComponent> other)
        {
            return HyperMath.Compare(value, other.value);
        }

        public int CompareTo(in TInner other)
        {
            return HyperMath.Compare(value, other);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return value.ToString(format, formatProvider);
        }

        partial class Operations : NumberOperations<WrapperNumber<TInner, TComponent>>, IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, TInner, TComponent>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public virtual WrapperNumber<TInner, TComponent> Create(StandardNumber num)
            {
                return HyperMath.Create<TInner>(num);
            }

            public virtual WrapperNumber<TInner, TComponent> Create(in TComponent num)
            {
                return new WrapperNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(num));
            }

            public virtual WrapperNumber<TInner, TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                return HyperMath.Create<TInner, TComponent>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public virtual WrapperNumber<TInner, TComponent> Create(IEnumerable<TComponent> units)
            {
                return new WrapperNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public virtual WrapperNumber<TInner, TComponent> Create(IEnumerator<TComponent> units)
            {
                return new WrapperNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }
        }
    }
}
