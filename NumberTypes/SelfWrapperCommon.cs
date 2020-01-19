using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct AbstractNumber : IWrapperNumber<AbstractNumber, AbstractNumber>, IWrapperNumber<AbstractNumber, AbstractNumber, AbstractNumber>
	{
        AbstractNumber IWrapperNumber<AbstractNumber>.Value => this;

		AbstractNumber IExtendedNumber<AbstractNumber, AbstractNumber>.CallReversed(StandardBinaryOperation operation, in AbstractNumber num)
		{
			return num.Call(operation, this);
		}

		AbstractNumber INumber<AbstractNumber, AbstractNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<AbstractNumber, AbstractNumber> IExtendedNumber<AbstractNumber, AbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<AbstractNumber, AbstractNumber> INumber<AbstractNumber, AbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<AbstractNumber, AbstractNumber, AbstractNumber> IExtendedNumber<AbstractNumber, AbstractNumber, AbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<AbstractNumber, AbstractNumber>, IExtendedNumberOperations<AbstractNumber, AbstractNumber, AbstractNumber>
		{
            AbstractNumber INumberOperations<AbstractNumber, AbstractNumber>.CallComponent(StandardUnaryOperation operation, in AbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual AbstractNumber Create(in AbstractNumber num)
            {
                return num;
            }

            public virtual AbstractNumber Create(in AbstractNumber realUnit, in AbstractNumber otherUnits, in AbstractNumber someUnitsCombined, in AbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual AbstractNumber Create(IEnumerable<AbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual AbstractNumber Create(IEnumerator<AbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<AbstractNumber>.Count => 1;

        bool ICollection<AbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<AbstractNumber>.Count => 1;

        AbstractNumber IReadOnlyList<AbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        AbstractNumber IList<AbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<AbstractNumber>.IndexOf(AbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<AbstractNumber>.Insert(int index, AbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<AbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<AbstractNumber>.Add(AbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<AbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<AbstractNumber>.Contains(AbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<AbstractNumber>.CopyTo(AbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<AbstractNumber>.Remove(AbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<AbstractNumber> IEnumerable<AbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct ComponentAbstractNumber : IWrapperNumber<ComponentAbstractNumber, ComponentAbstractNumber>, IWrapperNumber<ComponentAbstractNumber, ComponentAbstractNumber, ComponentAbstractNumber>
	{
        ComponentAbstractNumber IWrapperNumber<ComponentAbstractNumber>.Value => this;

		ComponentAbstractNumber IExtendedNumber<ComponentAbstractNumber, ComponentAbstractNumber>.CallReversed(StandardBinaryOperation operation, in ComponentAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		ComponentAbstractNumber INumber<ComponentAbstractNumber, ComponentAbstractNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<ComponentAbstractNumber, ComponentAbstractNumber> IExtendedNumber<ComponentAbstractNumber, ComponentAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<ComponentAbstractNumber, ComponentAbstractNumber> INumber<ComponentAbstractNumber, ComponentAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ComponentAbstractNumber, ComponentAbstractNumber, ComponentAbstractNumber> IExtendedNumber<ComponentAbstractNumber, ComponentAbstractNumber, ComponentAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ComponentAbstractNumber, ComponentAbstractNumber>, IExtendedNumberOperations<ComponentAbstractNumber, ComponentAbstractNumber, ComponentAbstractNumber>
		{
            ComponentAbstractNumber INumberOperations<ComponentAbstractNumber, ComponentAbstractNumber>.CallComponent(StandardUnaryOperation operation, in ComponentAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual ComponentAbstractNumber Create(in ComponentAbstractNumber num)
            {
                return num;
            }

            public virtual ComponentAbstractNumber Create(in ComponentAbstractNumber realUnit, in ComponentAbstractNumber otherUnits, in ComponentAbstractNumber someUnitsCombined, in ComponentAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual ComponentAbstractNumber Create(IEnumerable<ComponentAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual ComponentAbstractNumber Create(IEnumerator<ComponentAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<ComponentAbstractNumber>.Count => 1;

        bool ICollection<ComponentAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<ComponentAbstractNumber>.Count => 1;

        ComponentAbstractNumber IReadOnlyList<ComponentAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        ComponentAbstractNumber IList<ComponentAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ComponentAbstractNumber>.IndexOf(ComponentAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<ComponentAbstractNumber>.Insert(int index, ComponentAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<ComponentAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ComponentAbstractNumber>.Add(ComponentAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ComponentAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ComponentAbstractNumber>.Contains(ComponentAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<ComponentAbstractNumber>.CopyTo(ComponentAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<ComponentAbstractNumber>.Remove(ComponentAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ComponentAbstractNumber> IEnumerable<ComponentAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct UnaryAbstractNumber : IWrapperNumber<UnaryAbstractNumber, UnaryAbstractNumber>, IWrapperNumber<UnaryAbstractNumber, UnaryAbstractNumber, UnaryAbstractNumber>
	{
        UnaryAbstractNumber IWrapperNumber<UnaryAbstractNumber>.Value => this;

		UnaryAbstractNumber IExtendedNumber<UnaryAbstractNumber, UnaryAbstractNumber>.CallReversed(StandardBinaryOperation operation, in UnaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		UnaryAbstractNumber INumber<UnaryAbstractNumber, UnaryAbstractNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber> IExtendedNumber<UnaryAbstractNumber, UnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<UnaryAbstractNumber, UnaryAbstractNumber> INumber<UnaryAbstractNumber, UnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber, UnaryAbstractNumber> IExtendedNumber<UnaryAbstractNumber, UnaryAbstractNumber, UnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber>, IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber, UnaryAbstractNumber>
		{
            UnaryAbstractNumber INumberOperations<UnaryAbstractNumber, UnaryAbstractNumber>.CallComponent(StandardUnaryOperation operation, in UnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual UnaryAbstractNumber Create(in UnaryAbstractNumber num)
            {
                return num;
            }

            public virtual UnaryAbstractNumber Create(in UnaryAbstractNumber realUnit, in UnaryAbstractNumber otherUnits, in UnaryAbstractNumber someUnitsCombined, in UnaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual UnaryAbstractNumber Create(IEnumerable<UnaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual UnaryAbstractNumber Create(IEnumerator<UnaryAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<UnaryAbstractNumber>.Count => 1;

        bool ICollection<UnaryAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<UnaryAbstractNumber>.Count => 1;

        UnaryAbstractNumber IReadOnlyList<UnaryAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        UnaryAbstractNumber IList<UnaryAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<UnaryAbstractNumber>.IndexOf(UnaryAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<UnaryAbstractNumber>.Insert(int index, UnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<UnaryAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<UnaryAbstractNumber>.Add(UnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<UnaryAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<UnaryAbstractNumber>.Contains(UnaryAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<UnaryAbstractNumber>.CopyTo(UnaryAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<UnaryAbstractNumber>.Remove(UnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<UnaryAbstractNumber> IEnumerable<UnaryAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct ComponentUnaryAbstractNumber : IWrapperNumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>, IWrapperNumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>
	{
        ComponentUnaryAbstractNumber IWrapperNumber<ComponentUnaryAbstractNumber>.Value => this;

		ComponentUnaryAbstractNumber IExtendedNumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>.CallReversed(StandardBinaryOperation operation, in ComponentUnaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		ComponentUnaryAbstractNumber INumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber> IExtendedNumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber> INumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber> IExtendedNumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>, IExtendedNumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>
		{
            ComponentUnaryAbstractNumber INumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>.CallComponent(StandardUnaryOperation operation, in ComponentUnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual ComponentUnaryAbstractNumber Create(in ComponentUnaryAbstractNumber num)
            {
                return num;
            }

            public virtual ComponentUnaryAbstractNumber Create(in ComponentUnaryAbstractNumber realUnit, in ComponentUnaryAbstractNumber otherUnits, in ComponentUnaryAbstractNumber someUnitsCombined, in ComponentUnaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual ComponentUnaryAbstractNumber Create(IEnumerable<ComponentUnaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual ComponentUnaryAbstractNumber Create(IEnumerator<ComponentUnaryAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<ComponentUnaryAbstractNumber>.Count => 1;

        bool ICollection<ComponentUnaryAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<ComponentUnaryAbstractNumber>.Count => 1;

        ComponentUnaryAbstractNumber IReadOnlyList<ComponentUnaryAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        ComponentUnaryAbstractNumber IList<ComponentUnaryAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ComponentUnaryAbstractNumber>.IndexOf(ComponentUnaryAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<ComponentUnaryAbstractNumber>.Insert(int index, ComponentUnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<ComponentUnaryAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ComponentUnaryAbstractNumber>.Add(ComponentUnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ComponentUnaryAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ComponentUnaryAbstractNumber>.Contains(ComponentUnaryAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<ComponentUnaryAbstractNumber>.CopyTo(ComponentUnaryAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<ComponentUnaryAbstractNumber>.Remove(ComponentUnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ComponentUnaryAbstractNumber> IEnumerable<ComponentUnaryAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct BinaryAbstractNumber : IWrapperNumber<BinaryAbstractNumber, BinaryAbstractNumber>, IWrapperNumber<BinaryAbstractNumber, BinaryAbstractNumber, BinaryAbstractNumber>
	{
        BinaryAbstractNumber IWrapperNumber<BinaryAbstractNumber>.Value => this;

		BinaryAbstractNumber IExtendedNumber<BinaryAbstractNumber, BinaryAbstractNumber>.CallReversed(StandardBinaryOperation operation, in BinaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		BinaryAbstractNumber INumber<BinaryAbstractNumber, BinaryAbstractNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber> IExtendedNumber<BinaryAbstractNumber, BinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<BinaryAbstractNumber, BinaryAbstractNumber> INumber<BinaryAbstractNumber, BinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber, BinaryAbstractNumber> IExtendedNumber<BinaryAbstractNumber, BinaryAbstractNumber, BinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber>, IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber, BinaryAbstractNumber>
		{
            BinaryAbstractNumber INumberOperations<BinaryAbstractNumber, BinaryAbstractNumber>.CallComponent(StandardUnaryOperation operation, in BinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual BinaryAbstractNumber Create(in BinaryAbstractNumber num)
            {
                return num;
            }

            public virtual BinaryAbstractNumber Create(in BinaryAbstractNumber realUnit, in BinaryAbstractNumber otherUnits, in BinaryAbstractNumber someUnitsCombined, in BinaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual BinaryAbstractNumber Create(IEnumerable<BinaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual BinaryAbstractNumber Create(IEnumerator<BinaryAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<BinaryAbstractNumber>.Count => 1;

        bool ICollection<BinaryAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<BinaryAbstractNumber>.Count => 1;

        BinaryAbstractNumber IReadOnlyList<BinaryAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        BinaryAbstractNumber IList<BinaryAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<BinaryAbstractNumber>.IndexOf(BinaryAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<BinaryAbstractNumber>.Insert(int index, BinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<BinaryAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<BinaryAbstractNumber>.Add(BinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<BinaryAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<BinaryAbstractNumber>.Contains(BinaryAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<BinaryAbstractNumber>.CopyTo(BinaryAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<BinaryAbstractNumber>.Remove(BinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<BinaryAbstractNumber> IEnumerable<BinaryAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct ComponentBinaryAbstractNumber : IWrapperNumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>, IWrapperNumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>
	{
        ComponentBinaryAbstractNumber IWrapperNumber<ComponentBinaryAbstractNumber>.Value => this;

		ComponentBinaryAbstractNumber IExtendedNumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>.CallReversed(StandardBinaryOperation operation, in ComponentBinaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		ComponentBinaryAbstractNumber INumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber> IExtendedNumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber> INumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber> IExtendedNumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>, IExtendedNumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>
		{
            ComponentBinaryAbstractNumber INumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>.CallComponent(StandardUnaryOperation operation, in ComponentBinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual ComponentBinaryAbstractNumber Create(in ComponentBinaryAbstractNumber num)
            {
                return num;
            }

            public virtual ComponentBinaryAbstractNumber Create(in ComponentBinaryAbstractNumber realUnit, in ComponentBinaryAbstractNumber otherUnits, in ComponentBinaryAbstractNumber someUnitsCombined, in ComponentBinaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual ComponentBinaryAbstractNumber Create(IEnumerable<ComponentBinaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual ComponentBinaryAbstractNumber Create(IEnumerator<ComponentBinaryAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<ComponentBinaryAbstractNumber>.Count => 1;

        bool ICollection<ComponentBinaryAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<ComponentBinaryAbstractNumber>.Count => 1;

        ComponentBinaryAbstractNumber IReadOnlyList<ComponentBinaryAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        ComponentBinaryAbstractNumber IList<ComponentBinaryAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ComponentBinaryAbstractNumber>.IndexOf(ComponentBinaryAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<ComponentBinaryAbstractNumber>.Insert(int index, ComponentBinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<ComponentBinaryAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ComponentBinaryAbstractNumber>.Add(ComponentBinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ComponentBinaryAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ComponentBinaryAbstractNumber>.Contains(ComponentBinaryAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<ComponentBinaryAbstractNumber>.CopyTo(ComponentBinaryAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<ComponentBinaryAbstractNumber>.Remove(ComponentBinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ComponentBinaryAbstractNumber> IEnumerable<ComponentBinaryAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct BoxedNumber<TInner> : IWrapperNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>, IWrapperNumber<BoxedNumber<TInner>, BoxedNumber<TInner>, BoxedNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        BoxedNumber<TInner> IWrapperNumber<BoxedNumber<TInner>>.Value => this;

		BoxedNumber<TInner> IExtendedNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallReversed(StandardBinaryOperation operation, in BoxedNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		BoxedNumber<TInner> INumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>> IExtendedNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>> INumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>, BoxedNumber<TInner>> IExtendedNumber<BoxedNumber<TInner>, BoxedNumber<TInner>, BoxedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>>, IExtendedNumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>, BoxedNumber<TInner>>
		{
            BoxedNumber<TInner> INumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallComponent(StandardUnaryOperation operation, in BoxedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual BoxedNumber<TInner> Create(in BoxedNumber<TInner> num)
            {
                return num;
            }

            public virtual BoxedNumber<TInner> Create(in BoxedNumber<TInner> realUnit, in BoxedNumber<TInner> otherUnits, in BoxedNumber<TInner> someUnitsCombined, in BoxedNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual BoxedNumber<TInner> Create(IEnumerable<BoxedNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual BoxedNumber<TInner> Create(IEnumerator<BoxedNumber<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<BoxedNumber<TInner>>.Count => 1;

        bool ICollection<BoxedNumber<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<BoxedNumber<TInner>>.Count => 1;

        BoxedNumber<TInner> IReadOnlyList<BoxedNumber<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        BoxedNumber<TInner> IList<BoxedNumber<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<BoxedNumber<TInner>>.IndexOf(BoxedNumber<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<BoxedNumber<TInner>>.Insert(int index, BoxedNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<BoxedNumber<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<BoxedNumber<TInner>>.Add(BoxedNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<BoxedNumber<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<BoxedNumber<TInner>>.Contains(BoxedNumber<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<BoxedNumber<TInner>>.CopyTo(BoxedNumber<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<BoxedNumber<TInner>>.Remove(BoxedNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<BoxedNumber<TInner>> IEnumerable<BoxedNumber<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct BoxedNumber<TInner, TComponent> : IWrapperNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, TComponent>, IWrapperNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        BoxedNumber<TInner, TComponent> IWrapperNumber<BoxedNumber<TInner, TComponent>>.Value => this;

		BoxedNumber<TInner, TComponent> IExtendedNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in BoxedNumber<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		BoxedNumber<TInner, TComponent> INumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>> IExtendedNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, TComponent> IExtendedNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>> INumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>> IExtendedNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, TComponent>, IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>
		{
            BoxedNumber<TInner, TComponent> INumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in BoxedNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual BoxedNumber<TInner, TComponent> Create(in BoxedNumber<TInner, TComponent> num)
            {
                return num;
            }

            public virtual BoxedNumber<TInner, TComponent> Create(in BoxedNumber<TInner, TComponent> realUnit, in BoxedNumber<TInner, TComponent> otherUnits, in BoxedNumber<TInner, TComponent> someUnitsCombined, in BoxedNumber<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual BoxedNumber<TInner, TComponent> Create(IEnumerable<BoxedNumber<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual BoxedNumber<TInner, TComponent> Create(IEnumerator<BoxedNumber<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<BoxedNumber<TInner, TComponent>>.Count => 1;

        bool ICollection<BoxedNumber<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<BoxedNumber<TInner, TComponent>>.Count => 1;

        BoxedNumber<TInner, TComponent> IReadOnlyList<BoxedNumber<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        BoxedNumber<TInner, TComponent> IList<BoxedNumber<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<BoxedNumber<TInner, TComponent>>.IndexOf(BoxedNumber<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<BoxedNumber<TInner, TComponent>>.Insert(int index, BoxedNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<BoxedNumber<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<BoxedNumber<TInner, TComponent>>.Add(BoxedNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<BoxedNumber<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<BoxedNumber<TInner, TComponent>>.Contains(BoxedNumber<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<BoxedNumber<TInner, TComponent>>.CopyTo(BoxedNumber<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<BoxedNumber<TInner, TComponent>>.Remove(BoxedNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<BoxedNumber<TInner, TComponent>> IEnumerable<BoxedNumber<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct CustomDefaultNumber<TInner, TProvider> : IWrapperNumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>, IWrapperNumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>> where TInner : struct, INumber<TInner> where TProvider : struct, CustomDefaultNumber<TInner, TProvider>.IDefaultValueProvider
	{
        CustomDefaultNumber<TInner, TProvider> IWrapperNumber<CustomDefaultNumber<TInner, TProvider>>.Value => this;

		CustomDefaultNumber<TInner, TProvider> IExtendedNumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>.CallReversed(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TProvider> num)
		{
			return num.Call(operation, this);
		}

		CustomDefaultNumber<TInner, TProvider> INumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>> IExtendedNumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>> INumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>> IExtendedNumber<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>
		{
            CustomDefaultNumber<TInner, TProvider> INumberOperations<CustomDefaultNumber<TInner, TProvider>, CustomDefaultNumber<TInner, TProvider>>.CallComponent(StandardUnaryOperation operation, in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.Call(operation);
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Create(in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num;
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Create(in CustomDefaultNumber<TInner, TProvider> realUnit, in CustomDefaultNumber<TInner, TProvider> otherUnits, in CustomDefaultNumber<TInner, TProvider> someUnitsCombined, in CustomDefaultNumber<TInner, TProvider> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Create(IEnumerable<CustomDefaultNumber<TInner, TProvider>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Create(IEnumerator<CustomDefaultNumber<TInner, TProvider>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<CustomDefaultNumber<TInner, TProvider>>.Count => 1;

        bool ICollection<CustomDefaultNumber<TInner, TProvider>>.IsReadOnly => true;

        int IReadOnlyCollection<CustomDefaultNumber<TInner, TProvider>>.Count => 1;

        CustomDefaultNumber<TInner, TProvider> IReadOnlyList<CustomDefaultNumber<TInner, TProvider>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        CustomDefaultNumber<TInner, TProvider> IList<CustomDefaultNumber<TInner, TProvider>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<CustomDefaultNumber<TInner, TProvider>>.IndexOf(CustomDefaultNumber<TInner, TProvider> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<CustomDefaultNumber<TInner, TProvider>>.Insert(int index, CustomDefaultNumber<TInner, TProvider> item)
        {
            throw new NotSupportedException();
        }

        void IList<CustomDefaultNumber<TInner, TProvider>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TProvider>>.Add(CustomDefaultNumber<TInner, TProvider> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TProvider>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<CustomDefaultNumber<TInner, TProvider>>.Contains(CustomDefaultNumber<TInner, TProvider> item)
        {
            return Equals(item);
        }

        void ICollection<CustomDefaultNumber<TInner, TProvider>>.CopyTo(CustomDefaultNumber<TInner, TProvider>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<CustomDefaultNumber<TInner, TProvider>>.Remove(CustomDefaultNumber<TInner, TProvider> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<CustomDefaultNumber<TInner, TProvider>> IEnumerable<CustomDefaultNumber<TInner, TProvider>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct CustomDefaultNumber<TInner, TComponent, TProvider> : IWrapperNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent>, IWrapperNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TProvider : struct, CustomDefaultNumber<TInner, TProvider>.IDefaultValueProvider
	{
        CustomDefaultNumber<TInner, TComponent, TProvider> IWrapperNumber<CustomDefaultNumber<TInner, TComponent, TProvider>>.Value => this;

		CustomDefaultNumber<TInner, TComponent, TProvider> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>.CallReversed(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num)
		{
			return num.Call(operation, this);
		}

		CustomDefaultNumber<TInner, TComponent, TProvider> INumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>> INumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>
		{
            CustomDefaultNumber<TInner, TComponent, TProvider> INumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>>.CallComponent(StandardUnaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.Call(operation);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Create(in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num;
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Create(in CustomDefaultNumber<TInner, TComponent, TProvider> realUnit, in CustomDefaultNumber<TInner, TComponent, TProvider> otherUnits, in CustomDefaultNumber<TInner, TComponent, TProvider> someUnitsCombined, in CustomDefaultNumber<TInner, TComponent, TProvider> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Create(IEnumerable<CustomDefaultNumber<TInner, TComponent, TProvider>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Create(IEnumerator<CustomDefaultNumber<TInner, TComponent, TProvider>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.Count => 1;

        bool ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.IsReadOnly => true;

        int IReadOnlyCollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.Count => 1;

        CustomDefaultNumber<TInner, TComponent, TProvider> IReadOnlyList<CustomDefaultNumber<TInner, TComponent, TProvider>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        CustomDefaultNumber<TInner, TComponent, TProvider> IList<CustomDefaultNumber<TInner, TComponent, TProvider>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<CustomDefaultNumber<TInner, TComponent, TProvider>>.IndexOf(CustomDefaultNumber<TInner, TComponent, TProvider> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<CustomDefaultNumber<TInner, TComponent, TProvider>>.Insert(int index, CustomDefaultNumber<TInner, TComponent, TProvider> item)
        {
            throw new NotSupportedException();
        }

        void IList<CustomDefaultNumber<TInner, TComponent, TProvider>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.Add(CustomDefaultNumber<TInner, TComponent, TProvider> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.Contains(CustomDefaultNumber<TInner, TComponent, TProvider> item)
        {
            return Equals(item);
        }

        void ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.CopyTo(CustomDefaultNumber<TInner, TComponent, TProvider>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<CustomDefaultNumber<TInner, TComponent, TProvider>>.Remove(CustomDefaultNumber<TInner, TComponent, TProvider> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<CustomDefaultNumber<TInner, TComponent, TProvider>> IEnumerable<CustomDefaultNumber<TInner, TComponent, TProvider>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct GeneratedNumber<TInner> : IWrapperNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>, IWrapperNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>, GeneratedNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        GeneratedNumber<TInner> IWrapperNumber<GeneratedNumber<TInner>>.Value => this;

		GeneratedNumber<TInner> IExtendedNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallReversed(StandardBinaryOperation operation, in GeneratedNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>> IExtendedNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>> INumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>, GeneratedNumber<TInner>> IExtendedNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>, GeneratedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>>, IExtendedNumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>, GeneratedNumber<TInner>>
		{
            GeneratedNumber<TInner> INumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallComponent(StandardUnaryOperation operation, in GeneratedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual GeneratedNumber<TInner> Create(in GeneratedNumber<TInner> num)
            {
                return num;
            }

            public virtual GeneratedNumber<TInner> Create(in GeneratedNumber<TInner> realUnit, in GeneratedNumber<TInner> otherUnits, in GeneratedNumber<TInner> someUnitsCombined, in GeneratedNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual GeneratedNumber<TInner> Create(IEnumerable<GeneratedNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual GeneratedNumber<TInner> Create(IEnumerator<GeneratedNumber<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<GeneratedNumber<TInner>>.Count => 1;

        bool ICollection<GeneratedNumber<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<GeneratedNumber<TInner>>.Count => 1;

        GeneratedNumber<TInner> IReadOnlyList<GeneratedNumber<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        GeneratedNumber<TInner> IList<GeneratedNumber<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<GeneratedNumber<TInner>>.IndexOf(GeneratedNumber<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<GeneratedNumber<TInner>>.Insert(int index, GeneratedNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<GeneratedNumber<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<GeneratedNumber<TInner>>.Add(GeneratedNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<GeneratedNumber<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<GeneratedNumber<TInner>>.Contains(GeneratedNumber<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<GeneratedNumber<TInner>>.CopyTo(GeneratedNumber<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<GeneratedNumber<TInner>>.Remove(GeneratedNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<GeneratedNumber<TInner>> IEnumerable<GeneratedNumber<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct GeneratedNumber<TInner, TComponent> : IWrapperNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, TComponent>, IWrapperNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        GeneratedNumber<TInner, TComponent> IWrapperNumber<GeneratedNumber<TInner, TComponent>>.Value => this;

		GeneratedNumber<TInner, TComponent> IExtendedNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in GeneratedNumber<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		GeneratedNumber<TInner, TComponent> INumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>> IExtendedNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, TComponent> IExtendedNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>> INumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>> IExtendedNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, TComponent>, IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>
		{
            GeneratedNumber<TInner, TComponent> INumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in GeneratedNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(in GeneratedNumber<TInner, TComponent> num)
            {
                return num;
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(in GeneratedNumber<TInner, TComponent> realUnit, in GeneratedNumber<TInner, TComponent> otherUnits, in GeneratedNumber<TInner, TComponent> someUnitsCombined, in GeneratedNumber<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(IEnumerable<GeneratedNumber<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(IEnumerator<GeneratedNumber<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<GeneratedNumber<TInner, TComponent>>.Count => 1;

        bool ICollection<GeneratedNumber<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<GeneratedNumber<TInner, TComponent>>.Count => 1;

        GeneratedNumber<TInner, TComponent> IReadOnlyList<GeneratedNumber<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        GeneratedNumber<TInner, TComponent> IList<GeneratedNumber<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<GeneratedNumber<TInner, TComponent>>.IndexOf(GeneratedNumber<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<GeneratedNumber<TInner, TComponent>>.Insert(int index, GeneratedNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<GeneratedNumber<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<GeneratedNumber<TInner, TComponent>>.Add(GeneratedNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<GeneratedNumber<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<GeneratedNumber<TInner, TComponent>>.Contains(GeneratedNumber<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<GeneratedNumber<TInner, TComponent>>.CopyTo(GeneratedNumber<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<GeneratedNumber<TInner, TComponent>>.Remove(GeneratedNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<GeneratedNumber<TInner, TComponent>> IEnumerable<GeneratedNumber<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperComplex<TInner> : IWrapperNumber<HyperComplex<TInner>, HyperComplex<TInner>>, IWrapperNumber<HyperComplex<TInner>, HyperComplex<TInner>, HyperComplex<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperComplex<TInner> IWrapperNumber<HyperComplex<TInner>>.Value => this;

		HyperComplex<TInner> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>>.CallReversed(StandardBinaryOperation operation, in HyperComplex<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperComplex<TInner> INumber<HyperComplex<TInner>, HyperComplex<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperComplex<TInner>, HyperComplex<TInner>> INumber<HyperComplex<TInner>, HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>, HyperComplex<TInner>> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>, HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>>, IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>, HyperComplex<TInner>>
		{
            HyperComplex<TInner> INumberOperations<HyperComplex<TInner>, HyperComplex<TInner>>.CallComponent(StandardUnaryOperation operation, in HyperComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperComplex<TInner> Create(in HyperComplex<TInner> num)
            {
                return num;
            }

            public virtual HyperComplex<TInner> Create(in HyperComplex<TInner> realUnit, in HyperComplex<TInner> otherUnits, in HyperComplex<TInner> someUnitsCombined, in HyperComplex<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperComplex<TInner> Create(IEnumerable<HyperComplex<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperComplex<TInner> Create(IEnumerator<HyperComplex<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperComplex<TInner>>.Count => 1;

        bool ICollection<HyperComplex<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperComplex<TInner>>.Count => 1;

        HyperComplex<TInner> IReadOnlyList<HyperComplex<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperComplex<TInner> IList<HyperComplex<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperComplex<TInner>>.IndexOf(HyperComplex<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperComplex<TInner>>.Insert(int index, HyperComplex<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperComplex<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperComplex<TInner>>.Add(HyperComplex<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperComplex<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperComplex<TInner>>.Contains(HyperComplex<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<HyperComplex<TInner>>.CopyTo(HyperComplex<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperComplex<TInner>>.Remove(HyperComplex<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperComplex<TInner>> IEnumerable<HyperComplex<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperComplex<TInner, TComponent> : IWrapperNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, TComponent>, IWrapperNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        HyperComplex<TInner, TComponent> IWrapperNumber<HyperComplex<TInner, TComponent>>.Value => this;

		HyperComplex<TInner, TComponent> IExtendedNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in HyperComplex<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		HyperComplex<TInner, TComponent> INumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>> IExtendedNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, TComponent> IExtendedNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>> INumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>> IExtendedNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, TComponent>, IExtendedNumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>
		{
            HyperComplex<TInner, TComponent> INumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in HyperComplex<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperComplex<TInner, TComponent> Create(in HyperComplex<TInner, TComponent> num)
            {
                return num;
            }

            public virtual HyperComplex<TInner, TComponent> Create(in HyperComplex<TInner, TComponent> realUnit, in HyperComplex<TInner, TComponent> otherUnits, in HyperComplex<TInner, TComponent> someUnitsCombined, in HyperComplex<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperComplex<TInner, TComponent> Create(IEnumerable<HyperComplex<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperComplex<TInner, TComponent> Create(IEnumerator<HyperComplex<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperComplex<TInner, TComponent>>.Count => 1;

        bool ICollection<HyperComplex<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperComplex<TInner, TComponent>>.Count => 1;

        HyperComplex<TInner, TComponent> IReadOnlyList<HyperComplex<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperComplex<TInner, TComponent> IList<HyperComplex<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperComplex<TInner, TComponent>>.IndexOf(HyperComplex<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperComplex<TInner, TComponent>>.Insert(int index, HyperComplex<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperComplex<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperComplex<TInner, TComponent>>.Add(HyperComplex<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperComplex<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperComplex<TInner, TComponent>>.Contains(HyperComplex<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<HyperComplex<TInner, TComponent>>.CopyTo(HyperComplex<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperComplex<TInner, TComponent>>.Remove(HyperComplex<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperComplex<TInner, TComponent>> IEnumerable<HyperComplex<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperDiagonal<TInner> : IWrapperNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>, IWrapperNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>, HyperDiagonal<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperDiagonal<TInner> IWrapperNumber<HyperDiagonal<TInner>>.Value => this;

		HyperDiagonal<TInner> IExtendedNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallReversed(StandardBinaryOperation operation, in HyperDiagonal<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>> IExtendedNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>> INumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>, HyperDiagonal<TInner>> IExtendedNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>, HyperDiagonal<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>>, IExtendedNumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>, HyperDiagonal<TInner>>
		{
            HyperDiagonal<TInner> INumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallComponent(StandardUnaryOperation operation, in HyperDiagonal<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDiagonal<TInner> Create(in HyperDiagonal<TInner> num)
            {
                return num;
            }

            public virtual HyperDiagonal<TInner> Create(in HyperDiagonal<TInner> realUnit, in HyperDiagonal<TInner> otherUnits, in HyperDiagonal<TInner> someUnitsCombined, in HyperDiagonal<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperDiagonal<TInner> Create(IEnumerable<HyperDiagonal<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperDiagonal<TInner> Create(IEnumerator<HyperDiagonal<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperDiagonal<TInner>>.Count => 1;

        bool ICollection<HyperDiagonal<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperDiagonal<TInner>>.Count => 1;

        HyperDiagonal<TInner> IReadOnlyList<HyperDiagonal<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperDiagonal<TInner> IList<HyperDiagonal<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperDiagonal<TInner>>.IndexOf(HyperDiagonal<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperDiagonal<TInner>>.Insert(int index, HyperDiagonal<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperDiagonal<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDiagonal<TInner>>.Add(HyperDiagonal<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDiagonal<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperDiagonal<TInner>>.Contains(HyperDiagonal<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<HyperDiagonal<TInner>>.CopyTo(HyperDiagonal<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperDiagonal<TInner>>.Remove(HyperDiagonal<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperDiagonal<TInner>> IEnumerable<HyperDiagonal<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperDiagonal<TInner, TComponent> : IWrapperNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, TComponent>, IWrapperNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        HyperDiagonal<TInner, TComponent> IWrapperNumber<HyperDiagonal<TInner, TComponent>>.Value => this;

		HyperDiagonal<TInner, TComponent> IExtendedNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in HyperDiagonal<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		HyperDiagonal<TInner, TComponent> INumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>> IExtendedNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, TComponent> IExtendedNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>> INumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>> IExtendedNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, TComponent>, IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>
		{
            HyperDiagonal<TInner, TComponent> INumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in HyperDiagonal<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDiagonal<TInner, TComponent> Create(in HyperDiagonal<TInner, TComponent> num)
            {
                return num;
            }

            public virtual HyperDiagonal<TInner, TComponent> Create(in HyperDiagonal<TInner, TComponent> realUnit, in HyperDiagonal<TInner, TComponent> otherUnits, in HyperDiagonal<TInner, TComponent> someUnitsCombined, in HyperDiagonal<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperDiagonal<TInner, TComponent> Create(IEnumerable<HyperDiagonal<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperDiagonal<TInner, TComponent> Create(IEnumerator<HyperDiagonal<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperDiagonal<TInner, TComponent>>.Count => 1;

        bool ICollection<HyperDiagonal<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperDiagonal<TInner, TComponent>>.Count => 1;

        HyperDiagonal<TInner, TComponent> IReadOnlyList<HyperDiagonal<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperDiagonal<TInner, TComponent> IList<HyperDiagonal<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperDiagonal<TInner, TComponent>>.IndexOf(HyperDiagonal<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperDiagonal<TInner, TComponent>>.Insert(int index, HyperDiagonal<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperDiagonal<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDiagonal<TInner, TComponent>>.Add(HyperDiagonal<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDiagonal<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperDiagonal<TInner, TComponent>>.Contains(HyperDiagonal<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<HyperDiagonal<TInner, TComponent>>.CopyTo(HyperDiagonal<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperDiagonal<TInner, TComponent>>.Remove(HyperDiagonal<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperDiagonal<TInner, TComponent>> IEnumerable<HyperDiagonal<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperDual<TInner> : IWrapperNumber<HyperDual<TInner>, HyperDual<TInner>>, IWrapperNumber<HyperDual<TInner>, HyperDual<TInner>, HyperDual<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperDual<TInner> IWrapperNumber<HyperDual<TInner>>.Value => this;

		HyperDual<TInner> IExtendedNumber<HyperDual<TInner>, HyperDual<TInner>>.CallReversed(StandardBinaryOperation operation, in HyperDual<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperDual<TInner> INumber<HyperDual<TInner>, HyperDual<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperDual<TInner>, HyperDual<TInner>> IExtendedNumber<HyperDual<TInner>, HyperDual<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperDual<TInner>, HyperDual<TInner>> INumber<HyperDual<TInner>, HyperDual<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDual<TInner>, HyperDual<TInner>, HyperDual<TInner>> IExtendedNumber<HyperDual<TInner>, HyperDual<TInner>, HyperDual<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDual<TInner>, HyperDual<TInner>>, IExtendedNumberOperations<HyperDual<TInner>, HyperDual<TInner>, HyperDual<TInner>>
		{
            HyperDual<TInner> INumberOperations<HyperDual<TInner>, HyperDual<TInner>>.CallComponent(StandardUnaryOperation operation, in HyperDual<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDual<TInner> Create(in HyperDual<TInner> num)
            {
                return num;
            }

            public virtual HyperDual<TInner> Create(in HyperDual<TInner> realUnit, in HyperDual<TInner> otherUnits, in HyperDual<TInner> someUnitsCombined, in HyperDual<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperDual<TInner> Create(IEnumerable<HyperDual<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperDual<TInner> Create(IEnumerator<HyperDual<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperDual<TInner>>.Count => 1;

        bool ICollection<HyperDual<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperDual<TInner>>.Count => 1;

        HyperDual<TInner> IReadOnlyList<HyperDual<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperDual<TInner> IList<HyperDual<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperDual<TInner>>.IndexOf(HyperDual<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperDual<TInner>>.Insert(int index, HyperDual<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperDual<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDual<TInner>>.Add(HyperDual<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDual<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperDual<TInner>>.Contains(HyperDual<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<HyperDual<TInner>>.CopyTo(HyperDual<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperDual<TInner>>.Remove(HyperDual<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperDual<TInner>> IEnumerable<HyperDual<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperDual<TInner, TComponent> : IWrapperNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, TComponent>, IWrapperNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        HyperDual<TInner, TComponent> IWrapperNumber<HyperDual<TInner, TComponent>>.Value => this;

		HyperDual<TInner, TComponent> IExtendedNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in HyperDual<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		HyperDual<TInner, TComponent> INumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>> IExtendedNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, TComponent> IExtendedNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>> INumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>> IExtendedNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, TComponent>, IExtendedNumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>
		{
            HyperDual<TInner, TComponent> INumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in HyperDual<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDual<TInner, TComponent> Create(in HyperDual<TInner, TComponent> num)
            {
                return num;
            }

            public virtual HyperDual<TInner, TComponent> Create(in HyperDual<TInner, TComponent> realUnit, in HyperDual<TInner, TComponent> otherUnits, in HyperDual<TInner, TComponent> someUnitsCombined, in HyperDual<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperDual<TInner, TComponent> Create(IEnumerable<HyperDual<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperDual<TInner, TComponent> Create(IEnumerator<HyperDual<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperDual<TInner, TComponent>>.Count => 1;

        bool ICollection<HyperDual<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperDual<TInner, TComponent>>.Count => 1;

        HyperDual<TInner, TComponent> IReadOnlyList<HyperDual<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperDual<TInner, TComponent> IList<HyperDual<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperDual<TInner, TComponent>>.IndexOf(HyperDual<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperDual<TInner, TComponent>>.Insert(int index, HyperDual<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperDual<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDual<TInner, TComponent>>.Add(HyperDual<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDual<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperDual<TInner, TComponent>>.Contains(HyperDual<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<HyperDual<TInner, TComponent>>.CopyTo(HyperDual<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperDual<TInner, TComponent>>.Remove(HyperDual<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperDual<TInner, TComponent>> IEnumerable<HyperDual<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperSplitComplex<TInner> : IWrapperNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>, IWrapperNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperSplitComplex<TInner> IWrapperNumber<HyperSplitComplex<TInner>>.Value => this;

		HyperSplitComplex<TInner> IExtendedNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallReversed(StandardBinaryOperation operation, in HyperSplitComplex<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> IExtendedNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> INumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> IExtendedNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>, IExtendedNumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>
		{
            HyperSplitComplex<TInner> INumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallComponent(StandardUnaryOperation operation, in HyperSplitComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperSplitComplex<TInner> Create(in HyperSplitComplex<TInner> num)
            {
                return num;
            }

            public virtual HyperSplitComplex<TInner> Create(in HyperSplitComplex<TInner> realUnit, in HyperSplitComplex<TInner> otherUnits, in HyperSplitComplex<TInner> someUnitsCombined, in HyperSplitComplex<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperSplitComplex<TInner> Create(IEnumerable<HyperSplitComplex<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperSplitComplex<TInner> Create(IEnumerator<HyperSplitComplex<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperSplitComplex<TInner>>.Count => 1;

        bool ICollection<HyperSplitComplex<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperSplitComplex<TInner>>.Count => 1;

        HyperSplitComplex<TInner> IReadOnlyList<HyperSplitComplex<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperSplitComplex<TInner> IList<HyperSplitComplex<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperSplitComplex<TInner>>.IndexOf(HyperSplitComplex<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperSplitComplex<TInner>>.Insert(int index, HyperSplitComplex<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperSplitComplex<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperSplitComplex<TInner>>.Add(HyperSplitComplex<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperSplitComplex<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperSplitComplex<TInner>>.Contains(HyperSplitComplex<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<HyperSplitComplex<TInner>>.CopyTo(HyperSplitComplex<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperSplitComplex<TInner>>.Remove(HyperSplitComplex<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperSplitComplex<TInner>> IEnumerable<HyperSplitComplex<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperSplitComplex<TInner, TComponent> : IWrapperNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, TComponent>, IWrapperNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        HyperSplitComplex<TInner, TComponent> IWrapperNumber<HyperSplitComplex<TInner, TComponent>>.Value => this;

		HyperSplitComplex<TInner, TComponent> IExtendedNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		HyperSplitComplex<TInner, TComponent> INumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>> IExtendedNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, TComponent> IExtendedNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>> INumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>> IExtendedNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, TComponent>, IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>
		{
            HyperSplitComplex<TInner, TComponent> INumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Create(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num;
            }

            public virtual HyperSplitComplex<TInner, TComponent> Create(in HyperSplitComplex<TInner, TComponent> realUnit, in HyperSplitComplex<TInner, TComponent> otherUnits, in HyperSplitComplex<TInner, TComponent> someUnitsCombined, in HyperSplitComplex<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual HyperSplitComplex<TInner, TComponent> Create(IEnumerable<HyperSplitComplex<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual HyperSplitComplex<TInner, TComponent> Create(IEnumerator<HyperSplitComplex<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperSplitComplex<TInner, TComponent>>.Count => 1;

        bool ICollection<HyperSplitComplex<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperSplitComplex<TInner, TComponent>>.Count => 1;

        HyperSplitComplex<TInner, TComponent> IReadOnlyList<HyperSplitComplex<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperSplitComplex<TInner, TComponent> IList<HyperSplitComplex<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperSplitComplex<TInner, TComponent>>.IndexOf(HyperSplitComplex<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperSplitComplex<TInner, TComponent>>.Insert(int index, HyperSplitComplex<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperSplitComplex<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperSplitComplex<TInner, TComponent>>.Add(HyperSplitComplex<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperSplitComplex<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperSplitComplex<TInner, TComponent>>.Contains(HyperSplitComplex<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<HyperSplitComplex<TInner, TComponent>>.CopyTo(HyperSplitComplex<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperSplitComplex<TInner, TComponent>>.Remove(HyperSplitComplex<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperSplitComplex<TInner, TComponent>> IEnumerable<HyperSplitComplex<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct NullableNumber<TInner> : IWrapperNumber<NullableNumber<TInner>, NullableNumber<TInner>>, IWrapperNumber<NullableNumber<TInner>, NullableNumber<TInner>, NullableNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        NullableNumber<TInner> IWrapperNumber<NullableNumber<TInner>>.Value => this;

		NullableNumber<TInner> IExtendedNumber<NullableNumber<TInner>, NullableNumber<TInner>>.CallReversed(StandardBinaryOperation operation, in NullableNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		NullableNumber<TInner> INumber<NullableNumber<TInner>, NullableNumber<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<NullableNumber<TInner>, NullableNumber<TInner>> IExtendedNumber<NullableNumber<TInner>, NullableNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<NullableNumber<TInner>, NullableNumber<TInner>> INumber<NullableNumber<TInner>, NullableNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullableNumber<TInner>, NullableNumber<TInner>, NullableNumber<TInner>> IExtendedNumber<NullableNumber<TInner>, NullableNumber<TInner>, NullableNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullableNumber<TInner>, NullableNumber<TInner>>, IExtendedNumberOperations<NullableNumber<TInner>, NullableNumber<TInner>, NullableNumber<TInner>>
		{
            NullableNumber<TInner> INumberOperations<NullableNumber<TInner>, NullableNumber<TInner>>.CallComponent(StandardUnaryOperation operation, in NullableNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual NullableNumber<TInner> Create(in NullableNumber<TInner> num)
            {
                return num;
            }

            public virtual NullableNumber<TInner> Create(in NullableNumber<TInner> realUnit, in NullableNumber<TInner> otherUnits, in NullableNumber<TInner> someUnitsCombined, in NullableNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual NullableNumber<TInner> Create(IEnumerable<NullableNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual NullableNumber<TInner> Create(IEnumerator<NullableNumber<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<NullableNumber<TInner>>.Count => 1;

        bool ICollection<NullableNumber<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<NullableNumber<TInner>>.Count => 1;

        NullableNumber<TInner> IReadOnlyList<NullableNumber<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        NullableNumber<TInner> IList<NullableNumber<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<NullableNumber<TInner>>.IndexOf(NullableNumber<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<NullableNumber<TInner>>.Insert(int index, NullableNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<NullableNumber<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullableNumber<TInner>>.Add(NullableNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullableNumber<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<NullableNumber<TInner>>.Contains(NullableNumber<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<NullableNumber<TInner>>.CopyTo(NullableNumber<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<NullableNumber<TInner>>.Remove(NullableNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<NullableNumber<TInner>> IEnumerable<NullableNumber<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct NullableNumber<TInner, TComponent> : IWrapperNumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, TComponent>, IWrapperNumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        NullableNumber<TInner, TComponent> IWrapperNumber<NullableNumber<TInner, TComponent>>.Value => this;

		NullableNumber<TInner, TComponent> IExtendedNumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in NullableNumber<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		NullableNumber<TInner, TComponent> INumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>> IExtendedNumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, TComponent> IExtendedNumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>> INumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>> IExtendedNumber<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, TComponent>, IExtendedNumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>
		{
            NullableNumber<TInner, TComponent> INumberOperations<NullableNumber<TInner, TComponent>, NullableNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in NullableNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual NullableNumber<TInner, TComponent> Create(in NullableNumber<TInner, TComponent> num)
            {
                return num;
            }

            public virtual NullableNumber<TInner, TComponent> Create(in NullableNumber<TInner, TComponent> realUnit, in NullableNumber<TInner, TComponent> otherUnits, in NullableNumber<TInner, TComponent> someUnitsCombined, in NullableNumber<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual NullableNumber<TInner, TComponent> Create(IEnumerable<NullableNumber<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual NullableNumber<TInner, TComponent> Create(IEnumerator<NullableNumber<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<NullableNumber<TInner, TComponent>>.Count => 1;

        bool ICollection<NullableNumber<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<NullableNumber<TInner, TComponent>>.Count => 1;

        NullableNumber<TInner, TComponent> IReadOnlyList<NullableNumber<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        NullableNumber<TInner, TComponent> IList<NullableNumber<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<NullableNumber<TInner, TComponent>>.IndexOf(NullableNumber<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<NullableNumber<TInner, TComponent>>.Insert(int index, NullableNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<NullableNumber<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullableNumber<TInner, TComponent>>.Add(NullableNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullableNumber<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<NullableNumber<TInner, TComponent>>.Contains(NullableNumber<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<NullableNumber<TInner, TComponent>>.CopyTo(NullableNumber<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<NullableNumber<TInner, TComponent>>.Remove(NullableNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<NullableNumber<TInner, TComponent>> IEnumerable<NullableNumber<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct NullNumber : IWrapperNumber<NullNumber, NullNumber>, IWrapperNumber<NullNumber, NullNumber, NullNumber>
	{
        NullNumber IWrapperNumber<NullNumber>.Value => this;

		NullNumber IExtendedNumber<NullNumber, NullNumber>.CallReversed(StandardBinaryOperation operation, in NullNumber num)
		{
			return num.Call(operation, this);
		}

		NullNumber INumber<NullNumber, NullNumber>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<NullNumber, NullNumber> IExtendedNumber<NullNumber, NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<NullNumber, NullNumber> INumber<NullNumber, NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullNumber, NullNumber, NullNumber> IExtendedNumber<NullNumber, NullNumber, NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullNumber, NullNumber>, IExtendedNumberOperations<NullNumber, NullNumber, NullNumber>
		{
            NullNumber INumberOperations<NullNumber, NullNumber>.CallComponent(StandardUnaryOperation operation, in NullNumber num)
            {
                return num.Call(operation);
            }

            public virtual NullNumber Create(in NullNumber num)
            {
                return num;
            }

            public virtual NullNumber Create(in NullNumber realUnit, in NullNumber otherUnits, in NullNumber someUnitsCombined, in NullNumber allUnitsCombined)
            {
                return realUnit;
            }

            public virtual NullNumber Create(IEnumerable<NullNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual NullNumber Create(IEnumerator<NullNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<NullNumber>.Count => 1;

        bool ICollection<NullNumber>.IsReadOnly => true;

        int IReadOnlyCollection<NullNumber>.Count => 1;

        NullNumber IReadOnlyList<NullNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        NullNumber IList<NullNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<NullNumber>.IndexOf(NullNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<NullNumber>.Insert(int index, NullNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<NullNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullNumber>.Add(NullNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<NullNumber>.Contains(NullNumber item)
        {
            return Equals(item);
        }

        void ICollection<NullNumber>.CopyTo(NullNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<NullNumber>.Remove(NullNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<NullNumber> IEnumerable<NullNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct NullNumber<TComponent> : IWrapperNumber<NullNumber<TComponent>, NullNumber<TComponent>, TComponent>, IWrapperNumber<NullNumber<TComponent>, NullNumber<TComponent>, NullNumber<TComponent>> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        NullNumber<TComponent> IWrapperNumber<NullNumber<TComponent>>.Value => this;

		NullNumber<TComponent> IExtendedNumber<NullNumber<TComponent>, NullNumber<TComponent>>.CallReversed(StandardBinaryOperation operation, in NullNumber<TComponent> num)
		{
			return num.Call(operation, this);
		}

		NullNumber<TComponent> INumber<NullNumber<TComponent>, NullNumber<TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<NullNumber<TComponent>, NullNumber<TComponent>> IExtendedNumber<NullNumber<TComponent>, NullNumber<TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullNumber<TComponent>, NullNumber<TComponent>, TComponent> IExtendedNumber<NullNumber<TComponent>, NullNumber<TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<NullNumber<TComponent>, NullNumber<TComponent>> INumber<NullNumber<TComponent>, NullNumber<TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullNumber<TComponent>, NullNumber<TComponent>, NullNumber<TComponent>> IExtendedNumber<NullNumber<TComponent>, NullNumber<TComponent>, NullNumber<TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullNumber<TComponent>, NullNumber<TComponent>, TComponent>, IExtendedNumberOperations<NullNumber<TComponent>, NullNumber<TComponent>, NullNumber<TComponent>>
		{
            NullNumber<TComponent> INumberOperations<NullNumber<TComponent>, NullNumber<TComponent>>.CallComponent(StandardUnaryOperation operation, in NullNumber<TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual NullNumber<TComponent> Create(in NullNumber<TComponent> num)
            {
                return num;
            }

            public virtual NullNumber<TComponent> Create(in NullNumber<TComponent> realUnit, in NullNumber<TComponent> otherUnits, in NullNumber<TComponent> someUnitsCombined, in NullNumber<TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual NullNumber<TComponent> Create(IEnumerable<NullNumber<TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual NullNumber<TComponent> Create(IEnumerator<NullNumber<TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<NullNumber<TComponent>>.Count => 1;

        bool ICollection<NullNumber<TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<NullNumber<TComponent>>.Count => 1;

        NullNumber<TComponent> IReadOnlyList<NullNumber<TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        NullNumber<TComponent> IList<NullNumber<TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<NullNumber<TComponent>>.IndexOf(NullNumber<TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<NullNumber<TComponent>>.Insert(int index, NullNumber<TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<NullNumber<TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullNumber<TComponent>>.Add(NullNumber<TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullNumber<TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<NullNumber<TComponent>>.Contains(NullNumber<TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<NullNumber<TComponent>>.CopyTo(NullNumber<TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<NullNumber<TComponent>>.Remove(NullNumber<TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<NullNumber<TComponent>> IEnumerable<NullNumber<TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct ProjectiveNumber<TInner> : IWrapperNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>, IWrapperNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        ProjectiveNumber<TInner> IWrapperNumber<ProjectiveNumber<TInner>>.Value => this;

		ProjectiveNumber<TInner> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallReversed(StandardBinaryOperation operation, in ProjectiveNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> INumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>, IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>
		{
            ProjectiveNumber<TInner> INumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallComponent(StandardUnaryOperation operation, in ProjectiveNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual ProjectiveNumber<TInner> Create(in ProjectiveNumber<TInner> num)
            {
                return num;
            }

            public virtual ProjectiveNumber<TInner> Create(in ProjectiveNumber<TInner> realUnit, in ProjectiveNumber<TInner> otherUnits, in ProjectiveNumber<TInner> someUnitsCombined, in ProjectiveNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual ProjectiveNumber<TInner> Create(IEnumerable<ProjectiveNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual ProjectiveNumber<TInner> Create(IEnumerator<ProjectiveNumber<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<ProjectiveNumber<TInner>>.Count => 1;

        bool ICollection<ProjectiveNumber<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<ProjectiveNumber<TInner>>.Count => 1;

        ProjectiveNumber<TInner> IReadOnlyList<ProjectiveNumber<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        ProjectiveNumber<TInner> IList<ProjectiveNumber<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ProjectiveNumber<TInner>>.IndexOf(ProjectiveNumber<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<ProjectiveNumber<TInner>>.Insert(int index, ProjectiveNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<ProjectiveNumber<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ProjectiveNumber<TInner>>.Add(ProjectiveNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ProjectiveNumber<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ProjectiveNumber<TInner>>.Contains(ProjectiveNumber<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<ProjectiveNumber<TInner>>.CopyTo(ProjectiveNumber<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<ProjectiveNumber<TInner>>.Remove(ProjectiveNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ProjectiveNumber<TInner>> IEnumerable<ProjectiveNumber<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct ProjectiveNumber<TInner, TComponent> : IWrapperNumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, TComponent>, IWrapperNumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        ProjectiveNumber<TInner, TComponent> IWrapperNumber<ProjectiveNumber<TInner, TComponent>>.Value => this;

		ProjectiveNumber<TInner, TComponent> IExtendedNumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		ProjectiveNumber<TInner, TComponent> INumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>> IExtendedNumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, TComponent> IExtendedNumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>> INumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>> IExtendedNumber<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, TComponent>, IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>
		{
            ProjectiveNumber<TInner, TComponent> INumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num;
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(in ProjectiveNumber<TInner, TComponent> realUnit, in ProjectiveNumber<TInner, TComponent> otherUnits, in ProjectiveNumber<TInner, TComponent> someUnitsCombined, in ProjectiveNumber<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(IEnumerable<ProjectiveNumber<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(IEnumerator<ProjectiveNumber<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<ProjectiveNumber<TInner, TComponent>>.Count => 1;

        bool ICollection<ProjectiveNumber<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<ProjectiveNumber<TInner, TComponent>>.Count => 1;

        ProjectiveNumber<TInner, TComponent> IReadOnlyList<ProjectiveNumber<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        ProjectiveNumber<TInner, TComponent> IList<ProjectiveNumber<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ProjectiveNumber<TInner, TComponent>>.IndexOf(ProjectiveNumber<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<ProjectiveNumber<TInner, TComponent>>.Insert(int index, ProjectiveNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<ProjectiveNumber<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ProjectiveNumber<TInner, TComponent>>.Add(ProjectiveNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ProjectiveNumber<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ProjectiveNumber<TInner, TComponent>>.Contains(ProjectiveNumber<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<ProjectiveNumber<TInner, TComponent>>.CopyTo(ProjectiveNumber<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<ProjectiveNumber<TInner, TComponent>>.Remove(ProjectiveNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ProjectiveNumber<TInner, TComponent>> IEnumerable<ProjectiveNumber<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct TransformedNumber<TInner, TTransformation> : IWrapperNumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>, IWrapperNumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>> where TInner : struct, INumber<TInner> where TTransformation : struct, TransformedNumber<TInner, TTransformation>.ITransformation
	{
        TransformedNumber<TInner, TTransformation> IWrapperNumber<TransformedNumber<TInner, TTransformation>>.Value => this;

		TransformedNumber<TInner, TTransformation> IExtendedNumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>.CallReversed(StandardBinaryOperation operation, in TransformedNumber<TInner, TTransformation> num)
		{
			return num.Call(operation, this);
		}

		TransformedNumber<TInner, TTransformation> INumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>> IExtendedNumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>> INumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>> IExtendedNumber<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>, IExtendedNumberOperations<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>
		{
            TransformedNumber<TInner, TTransformation> INumberOperations<TransformedNumber<TInner, TTransformation>, TransformedNumber<TInner, TTransformation>>.CallComponent(StandardUnaryOperation operation, in TransformedNumber<TInner, TTransformation> num)
            {
                return num.Call(operation);
            }

            public virtual TransformedNumber<TInner, TTransformation> Create(in TransformedNumber<TInner, TTransformation> num)
            {
                return num;
            }

            public virtual TransformedNumber<TInner, TTransformation> Create(in TransformedNumber<TInner, TTransformation> realUnit, in TransformedNumber<TInner, TTransformation> otherUnits, in TransformedNumber<TInner, TTransformation> someUnitsCombined, in TransformedNumber<TInner, TTransformation> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual TransformedNumber<TInner, TTransformation> Create(IEnumerable<TransformedNumber<TInner, TTransformation>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual TransformedNumber<TInner, TTransformation> Create(IEnumerator<TransformedNumber<TInner, TTransformation>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<TransformedNumber<TInner, TTransformation>>.Count => 1;

        bool ICollection<TransformedNumber<TInner, TTransformation>>.IsReadOnly => true;

        int IReadOnlyCollection<TransformedNumber<TInner, TTransformation>>.Count => 1;

        TransformedNumber<TInner, TTransformation> IReadOnlyList<TransformedNumber<TInner, TTransformation>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        TransformedNumber<TInner, TTransformation> IList<TransformedNumber<TInner, TTransformation>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TransformedNumber<TInner, TTransformation>>.IndexOf(TransformedNumber<TInner, TTransformation> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<TransformedNumber<TInner, TTransformation>>.Insert(int index, TransformedNumber<TInner, TTransformation> item)
        {
            throw new NotSupportedException();
        }

        void IList<TransformedNumber<TInner, TTransformation>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TransformedNumber<TInner, TTransformation>>.Add(TransformedNumber<TInner, TTransformation> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TransformedNumber<TInner, TTransformation>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TransformedNumber<TInner, TTransformation>>.Contains(TransformedNumber<TInner, TTransformation> item)
        {
            return Equals(item);
        }

        void ICollection<TransformedNumber<TInner, TTransformation>>.CopyTo(TransformedNumber<TInner, TTransformation>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<TransformedNumber<TInner, TTransformation>>.Remove(TransformedNumber<TInner, TTransformation> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TransformedNumber<TInner, TTransformation>> IEnumerable<TransformedNumber<TInner, TTransformation>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct TransformedNumber<TInner, TComponent, TTransformation> : IWrapperNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TComponent>, IWrapperNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TTransformation : struct, TransformedNumber<TInner, TTransformation>.ITransformation
	{
        TransformedNumber<TInner, TComponent, TTransformation> IWrapperNumber<TransformedNumber<TInner, TComponent, TTransformation>>.Value => this;

		TransformedNumber<TInner, TComponent, TTransformation> IExtendedNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>.CallReversed(StandardBinaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num)
		{
			return num.Call(operation, this);
		}

		TransformedNumber<TInner, TComponent, TTransformation> INumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>> IExtendedNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TComponent> IExtendedNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>> INumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>> IExtendedNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TComponent>, IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>
		{
            TransformedNumber<TInner, TComponent, TTransformation> INumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>>.CallComponent(StandardUnaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.Call(operation);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Create(in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num;
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Create(in TransformedNumber<TInner, TComponent, TTransformation> realUnit, in TransformedNumber<TInner, TComponent, TTransformation> otherUnits, in TransformedNumber<TInner, TComponent, TTransformation> someUnitsCombined, in TransformedNumber<TInner, TComponent, TTransformation> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Create(IEnumerable<TransformedNumber<TInner, TComponent, TTransformation>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Create(IEnumerator<TransformedNumber<TInner, TComponent, TTransformation>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.Count => 1;

        bool ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.IsReadOnly => true;

        int IReadOnlyCollection<TransformedNumber<TInner, TComponent, TTransformation>>.Count => 1;

        TransformedNumber<TInner, TComponent, TTransformation> IReadOnlyList<TransformedNumber<TInner, TComponent, TTransformation>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        TransformedNumber<TInner, TComponent, TTransformation> IList<TransformedNumber<TInner, TComponent, TTransformation>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TransformedNumber<TInner, TComponent, TTransformation>>.IndexOf(TransformedNumber<TInner, TComponent, TTransformation> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<TransformedNumber<TInner, TComponent, TTransformation>>.Insert(int index, TransformedNumber<TInner, TComponent, TTransformation> item)
        {
            throw new NotSupportedException();
        }

        void IList<TransformedNumber<TInner, TComponent, TTransformation>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.Add(TransformedNumber<TInner, TComponent, TTransformation> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.Contains(TransformedNumber<TInner, TComponent, TTransformation> item)
        {
            return Equals(item);
        }

        void ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.CopyTo(TransformedNumber<TInner, TComponent, TTransformation>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<TransformedNumber<TInner, TComponent, TTransformation>>.Remove(TransformedNumber<TInner, TComponent, TTransformation> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TransformedNumber<TInner, TComponent, TTransformation>> IEnumerable<TransformedNumber<TInner, TComponent, TTransformation>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct WrapperNumber<TInner> : IWrapperNumber<WrapperNumber<TInner>, WrapperNumber<TInner>>, IWrapperNumber<WrapperNumber<TInner>, WrapperNumber<TInner>, WrapperNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        WrapperNumber<TInner> IWrapperNumber<WrapperNumber<TInner>>.Value => this;

		WrapperNumber<TInner> IExtendedNumber<WrapperNumber<TInner>, WrapperNumber<TInner>>.CallReversed(StandardBinaryOperation operation, in WrapperNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		WrapperNumber<TInner> INumber<WrapperNumber<TInner>, WrapperNumber<TInner>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<WrapperNumber<TInner>, WrapperNumber<TInner>> IExtendedNumber<WrapperNumber<TInner>, WrapperNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<WrapperNumber<TInner>, WrapperNumber<TInner>> INumber<WrapperNumber<TInner>, WrapperNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<WrapperNumber<TInner>, WrapperNumber<TInner>, WrapperNumber<TInner>> IExtendedNumber<WrapperNumber<TInner>, WrapperNumber<TInner>, WrapperNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<WrapperNumber<TInner>, WrapperNumber<TInner>>, IExtendedNumberOperations<WrapperNumber<TInner>, WrapperNumber<TInner>, WrapperNumber<TInner>>
		{
            WrapperNumber<TInner> INumberOperations<WrapperNumber<TInner>, WrapperNumber<TInner>>.CallComponent(StandardUnaryOperation operation, in WrapperNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual WrapperNumber<TInner> Create(in WrapperNumber<TInner> num)
            {
                return num;
            }

            public virtual WrapperNumber<TInner> Create(in WrapperNumber<TInner> realUnit, in WrapperNumber<TInner> otherUnits, in WrapperNumber<TInner> someUnitsCombined, in WrapperNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual WrapperNumber<TInner> Create(IEnumerable<WrapperNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual WrapperNumber<TInner> Create(IEnumerator<WrapperNumber<TInner>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<WrapperNumber<TInner>>.Count => 1;

        bool ICollection<WrapperNumber<TInner>>.IsReadOnly => true;

        int IReadOnlyCollection<WrapperNumber<TInner>>.Count => 1;

        WrapperNumber<TInner> IReadOnlyList<WrapperNumber<TInner>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        WrapperNumber<TInner> IList<WrapperNumber<TInner>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<WrapperNumber<TInner>>.IndexOf(WrapperNumber<TInner> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<WrapperNumber<TInner>>.Insert(int index, WrapperNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void IList<WrapperNumber<TInner>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<WrapperNumber<TInner>>.Add(WrapperNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<WrapperNumber<TInner>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<WrapperNumber<TInner>>.Contains(WrapperNumber<TInner> item)
        {
            return Equals(item);
        }

        void ICollection<WrapperNumber<TInner>>.CopyTo(WrapperNumber<TInner>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<WrapperNumber<TInner>>.Remove(WrapperNumber<TInner> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<WrapperNumber<TInner>> IEnumerable<WrapperNumber<TInner>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct WrapperNumber<TInner, TComponent> : IWrapperNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, TComponent>, IWrapperNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        WrapperNumber<TInner, TComponent> IWrapperNumber<WrapperNumber<TInner, TComponent>>.Value => this;

		WrapperNumber<TInner, TComponent> IExtendedNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>.CallReversed(StandardBinaryOperation operation, in WrapperNumber<TInner, TComponent> num)
		{
			return num.Call(operation, this);
		}

		WrapperNumber<TInner, TComponent> INumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>> IExtendedNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, TComponent> IExtendedNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>> INumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>> IExtendedNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, TComponent>, IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>
		{
            WrapperNumber<TInner, TComponent> INumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>>.CallComponent(StandardUnaryOperation operation, in WrapperNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual WrapperNumber<TInner, TComponent> Create(in WrapperNumber<TInner, TComponent> num)
            {
                return num;
            }

            public virtual WrapperNumber<TInner, TComponent> Create(in WrapperNumber<TInner, TComponent> realUnit, in WrapperNumber<TInner, TComponent> otherUnits, in WrapperNumber<TInner, TComponent> someUnitsCombined, in WrapperNumber<TInner, TComponent> allUnitsCombined)
            {
                return realUnit;
            }

            public virtual WrapperNumber<TInner, TComponent> Create(IEnumerable<WrapperNumber<TInner, TComponent>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public virtual WrapperNumber<TInner, TComponent> Create(IEnumerator<WrapperNumber<TInner, TComponent>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<WrapperNumber<TInner, TComponent>>.Count => 1;

        bool ICollection<WrapperNumber<TInner, TComponent>>.IsReadOnly => true;

        int IReadOnlyCollection<WrapperNumber<TInner, TComponent>>.Count => 1;

        WrapperNumber<TInner, TComponent> IReadOnlyList<WrapperNumber<TInner, TComponent>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        WrapperNumber<TInner, TComponent> IList<WrapperNumber<TInner, TComponent>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<WrapperNumber<TInner, TComponent>>.IndexOf(WrapperNumber<TInner, TComponent> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<WrapperNumber<TInner, TComponent>>.Insert(int index, WrapperNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void IList<WrapperNumber<TInner, TComponent>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<WrapperNumber<TInner, TComponent>>.Add(WrapperNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<WrapperNumber<TInner, TComponent>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<WrapperNumber<TInner, TComponent>>.Contains(WrapperNumber<TInner, TComponent> item)
        {
            return Equals(item);
        }

        void ICollection<WrapperNumber<TInner, TComponent>>.CopyTo(WrapperNumber<TInner, TComponent>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<WrapperNumber<TInner, TComponent>>.Remove(WrapperNumber<TInner, TComponent> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<WrapperNumber<TInner, TComponent>> IEnumerable<WrapperNumber<TInner, TComponent>>.GetEnumerator()
        {
            yield return this;
        }
	}

}