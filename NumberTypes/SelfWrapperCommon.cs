using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct AbstractNumber : IWrapperNumber<AbstractNumber, AbstractNumber>, IWrapperNumber<AbstractNumber, AbstractNumber, AbstractNumber>
	{
        AbstractNumber IWrapperNumber<AbstractNumber>.Value => this;

		AbstractNumber IExtendedNumber<AbstractNumber, AbstractNumber>.CallReversed(BinaryOperation operation, in AbstractNumber num)
		{
			return num.Call(operation, this);
		}

		AbstractNumber INumber<AbstractNumber, AbstractNumber>.CallComponent(UnaryOperation operation)
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
            AbstractNumber INumberOperations<AbstractNumber, AbstractNumber>.CallComponent(UnaryOperation operation, in AbstractNumber num)
            {
                return num.Call(operation);
            }

            public AbstractNumber Create(in AbstractNumber num)
            {
                return num;
            }

            public AbstractNumber Create(in AbstractNumber realUnit, in AbstractNumber otherUnits, in AbstractNumber someUnitsCombined, in AbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public AbstractNumber Create(IEnumerable<AbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public AbstractNumber Create(IEnumerator<AbstractNumber> units)
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

	partial struct PrimitiveAbstractNumber : IWrapperNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>, IWrapperNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber, PrimitiveAbstractNumber>
	{
        PrimitiveAbstractNumber IWrapperNumber<PrimitiveAbstractNumber>.Value => this;

		PrimitiveAbstractNumber IExtendedNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.CallReversed(BinaryOperation operation, in PrimitiveAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber> IExtendedNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber> INumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber, PrimitiveAbstractNumber> IExtendedNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber, PrimitiveAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber>, IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber, PrimitiveAbstractNumber>
		{
            PrimitiveAbstractNumber INumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.CallComponent(UnaryOperation operation, in PrimitiveAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveAbstractNumber Create(in PrimitiveAbstractNumber num)
            {
                return num;
            }

            public PrimitiveAbstractNumber Create(in PrimitiveAbstractNumber realUnit, in PrimitiveAbstractNumber otherUnits, in PrimitiveAbstractNumber someUnitsCombined, in PrimitiveAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public PrimitiveAbstractNumber Create(IEnumerable<PrimitiveAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public PrimitiveAbstractNumber Create(IEnumerator<PrimitiveAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<PrimitiveAbstractNumber>.Count => 1;

        bool ICollection<PrimitiveAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<PrimitiveAbstractNumber>.Count => 1;

        PrimitiveAbstractNumber IReadOnlyList<PrimitiveAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        PrimitiveAbstractNumber IList<PrimitiveAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<PrimitiveAbstractNumber>.IndexOf(PrimitiveAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<PrimitiveAbstractNumber>.Insert(int index, PrimitiveAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<PrimitiveAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<PrimitiveAbstractNumber>.Add(PrimitiveAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<PrimitiveAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<PrimitiveAbstractNumber>.Contains(PrimitiveAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<PrimitiveAbstractNumber>.CopyTo(PrimitiveAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<PrimitiveAbstractNumber>.Remove(PrimitiveAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<PrimitiveAbstractNumber> IEnumerable<PrimitiveAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct UnaryAbstractNumber : IWrapperNumber<UnaryAbstractNumber, UnaryAbstractNumber>, IWrapperNumber<UnaryAbstractNumber, UnaryAbstractNumber, UnaryAbstractNumber>
	{
        UnaryAbstractNumber IWrapperNumber<UnaryAbstractNumber>.Value => this;

		UnaryAbstractNumber IExtendedNumber<UnaryAbstractNumber, UnaryAbstractNumber>.CallReversed(BinaryOperation operation, in UnaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		UnaryAbstractNumber INumber<UnaryAbstractNumber, UnaryAbstractNumber>.CallComponent(UnaryOperation operation)
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
            UnaryAbstractNumber INumberOperations<UnaryAbstractNumber, UnaryAbstractNumber>.CallComponent(UnaryOperation operation, in UnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public UnaryAbstractNumber Create(in UnaryAbstractNumber num)
            {
                return num;
            }

            public UnaryAbstractNumber Create(in UnaryAbstractNumber realUnit, in UnaryAbstractNumber otherUnits, in UnaryAbstractNumber someUnitsCombined, in UnaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public UnaryAbstractNumber Create(IEnumerable<UnaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public UnaryAbstractNumber Create(IEnumerator<UnaryAbstractNumber> units)
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

	partial struct PrimitiveUnaryAbstractNumber : IWrapperNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>, IWrapperNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>
	{
        PrimitiveUnaryAbstractNumber IWrapperNumber<PrimitiveUnaryAbstractNumber>.Value => this;

		PrimitiveUnaryAbstractNumber IExtendedNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.CallReversed(BinaryOperation operation, in PrimitiveUnaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber> IExtendedNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber> INumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber> IExtendedNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>, IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>
		{
            PrimitiveUnaryAbstractNumber INumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.CallComponent(UnaryOperation operation, in PrimitiveUnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveUnaryAbstractNumber Create(in PrimitiveUnaryAbstractNumber num)
            {
                return num;
            }

            public PrimitiveUnaryAbstractNumber Create(in PrimitiveUnaryAbstractNumber realUnit, in PrimitiveUnaryAbstractNumber otherUnits, in PrimitiveUnaryAbstractNumber someUnitsCombined, in PrimitiveUnaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public PrimitiveUnaryAbstractNumber Create(IEnumerable<PrimitiveUnaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public PrimitiveUnaryAbstractNumber Create(IEnumerator<PrimitiveUnaryAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<PrimitiveUnaryAbstractNumber>.Count => 1;

        bool ICollection<PrimitiveUnaryAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<PrimitiveUnaryAbstractNumber>.Count => 1;

        PrimitiveUnaryAbstractNumber IReadOnlyList<PrimitiveUnaryAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        PrimitiveUnaryAbstractNumber IList<PrimitiveUnaryAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<PrimitiveUnaryAbstractNumber>.IndexOf(PrimitiveUnaryAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<PrimitiveUnaryAbstractNumber>.Insert(int index, PrimitiveUnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<PrimitiveUnaryAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<PrimitiveUnaryAbstractNumber>.Add(PrimitiveUnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<PrimitiveUnaryAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<PrimitiveUnaryAbstractNumber>.Contains(PrimitiveUnaryAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<PrimitiveUnaryAbstractNumber>.CopyTo(PrimitiveUnaryAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<PrimitiveUnaryAbstractNumber>.Remove(PrimitiveUnaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<PrimitiveUnaryAbstractNumber> IEnumerable<PrimitiveUnaryAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct BinaryAbstractNumber : IWrapperNumber<BinaryAbstractNumber, BinaryAbstractNumber>, IWrapperNumber<BinaryAbstractNumber, BinaryAbstractNumber, BinaryAbstractNumber>
	{
        BinaryAbstractNumber IWrapperNumber<BinaryAbstractNumber>.Value => this;

		BinaryAbstractNumber IExtendedNumber<BinaryAbstractNumber, BinaryAbstractNumber>.CallReversed(BinaryOperation operation, in BinaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		BinaryAbstractNumber INumber<BinaryAbstractNumber, BinaryAbstractNumber>.CallComponent(UnaryOperation operation)
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
            BinaryAbstractNumber INumberOperations<BinaryAbstractNumber, BinaryAbstractNumber>.CallComponent(UnaryOperation operation, in BinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public BinaryAbstractNumber Create(in BinaryAbstractNumber num)
            {
                return num;
            }

            public BinaryAbstractNumber Create(in BinaryAbstractNumber realUnit, in BinaryAbstractNumber otherUnits, in BinaryAbstractNumber someUnitsCombined, in BinaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public BinaryAbstractNumber Create(IEnumerable<BinaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public BinaryAbstractNumber Create(IEnumerator<BinaryAbstractNumber> units)
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

	partial struct PrimitiveBinaryAbstractNumber : IWrapperNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>, IWrapperNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>
	{
        PrimitiveBinaryAbstractNumber IWrapperNumber<PrimitiveBinaryAbstractNumber>.Value => this;

		PrimitiveBinaryAbstractNumber IExtendedNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.CallReversed(BinaryOperation operation, in PrimitiveBinaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}

		PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber> IExtendedNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber> INumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber> IExtendedNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>, IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>
		{
            PrimitiveBinaryAbstractNumber INumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.CallComponent(UnaryOperation operation, in PrimitiveBinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveBinaryAbstractNumber Create(in PrimitiveBinaryAbstractNumber num)
            {
                return num;
            }

            public PrimitiveBinaryAbstractNumber Create(in PrimitiveBinaryAbstractNumber realUnit, in PrimitiveBinaryAbstractNumber otherUnits, in PrimitiveBinaryAbstractNumber someUnitsCombined, in PrimitiveBinaryAbstractNumber allUnitsCombined)
            {
                return realUnit;
            }

            public PrimitiveBinaryAbstractNumber Create(IEnumerable<PrimitiveBinaryAbstractNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public PrimitiveBinaryAbstractNumber Create(IEnumerator<PrimitiveBinaryAbstractNumber> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<PrimitiveBinaryAbstractNumber>.Count => 1;

        bool ICollection<PrimitiveBinaryAbstractNumber>.IsReadOnly => true;

        int IReadOnlyCollection<PrimitiveBinaryAbstractNumber>.Count => 1;

        PrimitiveBinaryAbstractNumber IReadOnlyList<PrimitiveBinaryAbstractNumber>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        PrimitiveBinaryAbstractNumber IList<PrimitiveBinaryAbstractNumber>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<PrimitiveBinaryAbstractNumber>.IndexOf(PrimitiveBinaryAbstractNumber item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<PrimitiveBinaryAbstractNumber>.Insert(int index, PrimitiveBinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void IList<PrimitiveBinaryAbstractNumber>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<PrimitiveBinaryAbstractNumber>.Add(PrimitiveBinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        void ICollection<PrimitiveBinaryAbstractNumber>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<PrimitiveBinaryAbstractNumber>.Contains(PrimitiveBinaryAbstractNumber item)
        {
            return Equals(item);
        }

        void ICollection<PrimitiveBinaryAbstractNumber>.CopyTo(PrimitiveBinaryAbstractNumber[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<PrimitiveBinaryAbstractNumber>.Remove(PrimitiveBinaryAbstractNumber item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<PrimitiveBinaryAbstractNumber> IEnumerable<PrimitiveBinaryAbstractNumber>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct BoxedNumber<TInner> : IWrapperNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>, IWrapperNumber<BoxedNumber<TInner>, BoxedNumber<TInner>, BoxedNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        BoxedNumber<TInner> IWrapperNumber<BoxedNumber<TInner>>.Value => this;

		BoxedNumber<TInner> IExtendedNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallReversed(BinaryOperation operation, in BoxedNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		BoxedNumber<TInner> INumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallComponent(UnaryOperation operation)
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
            BoxedNumber<TInner> INumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallComponent(UnaryOperation operation, in BoxedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner> Create(in BoxedNumber<TInner> num)
            {
                return num;
            }

            public BoxedNumber<TInner> Create(in BoxedNumber<TInner> realUnit, in BoxedNumber<TInner> otherUnits, in BoxedNumber<TInner> someUnitsCombined, in BoxedNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public BoxedNumber<TInner> Create(IEnumerable<BoxedNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public BoxedNumber<TInner> Create(IEnumerator<BoxedNumber<TInner>> units)
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

	partial struct BoxedNumber<TInner, TPrimitive> : IWrapperNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        BoxedNumber<TInner, TPrimitive> IWrapperNumber<BoxedNumber<TInner, TPrimitive>>.Value => this;

		BoxedNumber<TInner, TPrimitive> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		BoxedNumber<TInner, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>> INumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>
		{
            BoxedNumber<TInner, TPrimitive> INumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Create(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num;
            }

            public BoxedNumber<TInner, TPrimitive> Create(in BoxedNumber<TInner, TPrimitive> realUnit, in BoxedNumber<TInner, TPrimitive> otherUnits, in BoxedNumber<TInner, TPrimitive> someUnitsCombined, in BoxedNumber<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public BoxedNumber<TInner, TPrimitive> Create(IEnumerable<BoxedNumber<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public BoxedNumber<TInner, TPrimitive> Create(IEnumerator<BoxedNumber<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<BoxedNumber<TInner, TPrimitive>>.Count => 1;

        bool ICollection<BoxedNumber<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<BoxedNumber<TInner, TPrimitive>>.Count => 1;

        BoxedNumber<TInner, TPrimitive> IReadOnlyList<BoxedNumber<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        BoxedNumber<TInner, TPrimitive> IList<BoxedNumber<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<BoxedNumber<TInner, TPrimitive>>.IndexOf(BoxedNumber<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<BoxedNumber<TInner, TPrimitive>>.Insert(int index, BoxedNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<BoxedNumber<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<BoxedNumber<TInner, TPrimitive>>.Add(BoxedNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<BoxedNumber<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<BoxedNumber<TInner, TPrimitive>>.Contains(BoxedNumber<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<BoxedNumber<TInner, TPrimitive>>.CopyTo(BoxedNumber<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<BoxedNumber<TInner, TPrimitive>>.Remove(BoxedNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<BoxedNumber<TInner, TPrimitive>> IEnumerable<BoxedNumber<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct CustomDefaultNumber<TInner, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>, IWrapperNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
	{
        CustomDefaultNumber<TInner, TTraits> IWrapperNumber<CustomDefaultNumber<TInner, TTraits>>.Value => this;

		CustomDefaultNumber<TInner, TTraits> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num)
		{
			return num.Call(operation, this);
		}

		CustomDefaultNumber<TInner, TTraits> INumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>> INumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>
		{
            CustomDefaultNumber<TInner, TTraits> INumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.CallComponent(UnaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TTraits> Create(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num;
            }

            public CustomDefaultNumber<TInner, TTraits> Create(in CustomDefaultNumber<TInner, TTraits> realUnit, in CustomDefaultNumber<TInner, TTraits> otherUnits, in CustomDefaultNumber<TInner, TTraits> someUnitsCombined, in CustomDefaultNumber<TInner, TTraits> allUnitsCombined)
            {
                return realUnit;
            }

            public CustomDefaultNumber<TInner, TTraits> Create(IEnumerable<CustomDefaultNumber<TInner, TTraits>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public CustomDefaultNumber<TInner, TTraits> Create(IEnumerator<CustomDefaultNumber<TInner, TTraits>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<CustomDefaultNumber<TInner, TTraits>>.Count => 1;

        bool ICollection<CustomDefaultNumber<TInner, TTraits>>.IsReadOnly => true;

        int IReadOnlyCollection<CustomDefaultNumber<TInner, TTraits>>.Count => 1;

        CustomDefaultNumber<TInner, TTraits> IReadOnlyList<CustomDefaultNumber<TInner, TTraits>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        CustomDefaultNumber<TInner, TTraits> IList<CustomDefaultNumber<TInner, TTraits>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<CustomDefaultNumber<TInner, TTraits>>.IndexOf(CustomDefaultNumber<TInner, TTraits> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<CustomDefaultNumber<TInner, TTraits>>.Insert(int index, CustomDefaultNumber<TInner, TTraits> item)
        {
            throw new NotSupportedException();
        }

        void IList<CustomDefaultNumber<TInner, TTraits>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TTraits>>.Add(CustomDefaultNumber<TInner, TTraits> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TTraits>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<CustomDefaultNumber<TInner, TTraits>>.Contains(CustomDefaultNumber<TInner, TTraits> item)
        {
            return Equals(item);
        }

        void ICollection<CustomDefaultNumber<TInner, TTraits>>.CopyTo(CustomDefaultNumber<TInner, TTraits>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<CustomDefaultNumber<TInner, TTraits>>.Remove(CustomDefaultNumber<TInner, TTraits> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<CustomDefaultNumber<TInner, TTraits>> IEnumerable<CustomDefaultNumber<TInner, TTraits>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>, IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
	{
        CustomDefaultNumber<TInner, TPrimitive, TTraits> IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Value => this;

		CustomDefaultNumber<TInner, TPrimitive, TTraits> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
		{
			return num.Call(operation, this);
		}

		CustomDefaultNumber<TInner, TPrimitive, TTraits> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>
		{
            CustomDefaultNumber<TInner, TPrimitive, TTraits> INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.CallComponent(UnaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num;
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(in CustomDefaultNumber<TInner, TPrimitive, TTraits> realUnit, in CustomDefaultNumber<TInner, TPrimitive, TTraits> otherUnits, in CustomDefaultNumber<TInner, TPrimitive, TTraits> someUnitsCombined, in CustomDefaultNumber<TInner, TPrimitive, TTraits> allUnitsCombined)
            {
                return realUnit;
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(IEnumerable<CustomDefaultNumber<TInner, TPrimitive, TTraits>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(IEnumerator<CustomDefaultNumber<TInner, TPrimitive, TTraits>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Count => 1;

        bool ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.IsReadOnly => true;

        int IReadOnlyCollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Count => 1;

        CustomDefaultNumber<TInner, TPrimitive, TTraits> IReadOnlyList<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        CustomDefaultNumber<TInner, TPrimitive, TTraits> IList<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.IndexOf(CustomDefaultNumber<TInner, TPrimitive, TTraits> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Insert(int index, CustomDefaultNumber<TInner, TPrimitive, TTraits> item)
        {
            throw new NotSupportedException();
        }

        void IList<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Add(CustomDefaultNumber<TInner, TPrimitive, TTraits> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Contains(CustomDefaultNumber<TInner, TPrimitive, TTraits> item)
        {
            return Equals(item);
        }

        void ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.CopyTo(CustomDefaultNumber<TInner, TPrimitive, TTraits>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Remove(CustomDefaultNumber<TInner, TPrimitive, TTraits> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<CustomDefaultNumber<TInner, TPrimitive, TTraits>> IEnumerable<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct GeneratedNumber<TInner> : IWrapperNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>, IWrapperNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>, GeneratedNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        GeneratedNumber<TInner> IWrapperNumber<GeneratedNumber<TInner>>.Value => this;

		GeneratedNumber<TInner> IExtendedNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallReversed(BinaryOperation operation, in GeneratedNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		GeneratedNumber<TInner> INumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallComponent(UnaryOperation operation)
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
            GeneratedNumber<TInner> INumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallComponent(UnaryOperation operation, in GeneratedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner> Create(in GeneratedNumber<TInner> num)
            {
                return num;
            }

            public GeneratedNumber<TInner> Create(in GeneratedNumber<TInner> realUnit, in GeneratedNumber<TInner> otherUnits, in GeneratedNumber<TInner> someUnitsCombined, in GeneratedNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public GeneratedNumber<TInner> Create(IEnumerable<GeneratedNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public GeneratedNumber<TInner> Create(IEnumerator<GeneratedNumber<TInner>> units)
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

	partial struct GeneratedNumber<TInner, TPrimitive> : IWrapperNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        GeneratedNumber<TInner, TPrimitive> IWrapperNumber<GeneratedNumber<TInner, TPrimitive>>.Value => this;

		GeneratedNumber<TInner, TPrimitive> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		GeneratedNumber<TInner, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>> INumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>
		{
            GeneratedNumber<TInner, TPrimitive> INumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner, TPrimitive> Create(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num;
            }

            public GeneratedNumber<TInner, TPrimitive> Create(in GeneratedNumber<TInner, TPrimitive> realUnit, in GeneratedNumber<TInner, TPrimitive> otherUnits, in GeneratedNumber<TInner, TPrimitive> someUnitsCombined, in GeneratedNumber<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public GeneratedNumber<TInner, TPrimitive> Create(IEnumerable<GeneratedNumber<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public GeneratedNumber<TInner, TPrimitive> Create(IEnumerator<GeneratedNumber<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<GeneratedNumber<TInner, TPrimitive>>.Count => 1;

        bool ICollection<GeneratedNumber<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<GeneratedNumber<TInner, TPrimitive>>.Count => 1;

        GeneratedNumber<TInner, TPrimitive> IReadOnlyList<GeneratedNumber<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        GeneratedNumber<TInner, TPrimitive> IList<GeneratedNumber<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<GeneratedNumber<TInner, TPrimitive>>.IndexOf(GeneratedNumber<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<GeneratedNumber<TInner, TPrimitive>>.Insert(int index, GeneratedNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<GeneratedNumber<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<GeneratedNumber<TInner, TPrimitive>>.Add(GeneratedNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<GeneratedNumber<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<GeneratedNumber<TInner, TPrimitive>>.Contains(GeneratedNumber<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<GeneratedNumber<TInner, TPrimitive>>.CopyTo(GeneratedNumber<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<GeneratedNumber<TInner, TPrimitive>>.Remove(GeneratedNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<GeneratedNumber<TInner, TPrimitive>> IEnumerable<GeneratedNumber<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperComplex<TInner> : IWrapperNumber<HyperComplex<TInner>, HyperComplex<TInner>>, IWrapperNumber<HyperComplex<TInner>, HyperComplex<TInner>, HyperComplex<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperComplex<TInner> IWrapperNumber<HyperComplex<TInner>>.Value => this;

		HyperComplex<TInner> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>>.CallReversed(BinaryOperation operation, in HyperComplex<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperComplex<TInner> INumber<HyperComplex<TInner>, HyperComplex<TInner>>.CallComponent(UnaryOperation operation)
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
            HyperComplex<TInner> INumberOperations<HyperComplex<TInner>, HyperComplex<TInner>>.CallComponent(UnaryOperation operation, in HyperComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner> Create(in HyperComplex<TInner> num)
            {
                return num;
            }

            public HyperComplex<TInner> Create(in HyperComplex<TInner> realUnit, in HyperComplex<TInner> otherUnits, in HyperComplex<TInner> someUnitsCombined, in HyperComplex<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperComplex<TInner> Create(IEnumerable<HyperComplex<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperComplex<TInner> Create(IEnumerator<HyperComplex<TInner>> units)
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

	partial struct HyperComplex<TInner, TPrimitive> : IWrapperNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperComplex<TInner, TPrimitive> IWrapperNumber<HyperComplex<TInner, TPrimitive>>.Value => this;

		HyperComplex<TInner, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		HyperComplex<TInner, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>> INumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>
		{
            HyperComplex<TInner, TPrimitive> INumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner, TPrimitive> Create(in HyperComplex<TInner, TPrimitive> num)
            {
                return num;
            }

            public HyperComplex<TInner, TPrimitive> Create(in HyperComplex<TInner, TPrimitive> realUnit, in HyperComplex<TInner, TPrimitive> otherUnits, in HyperComplex<TInner, TPrimitive> someUnitsCombined, in HyperComplex<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperComplex<TInner, TPrimitive> Create(IEnumerable<HyperComplex<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperComplex<TInner, TPrimitive> Create(IEnumerator<HyperComplex<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperComplex<TInner, TPrimitive>>.Count => 1;

        bool ICollection<HyperComplex<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperComplex<TInner, TPrimitive>>.Count => 1;

        HyperComplex<TInner, TPrimitive> IReadOnlyList<HyperComplex<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperComplex<TInner, TPrimitive> IList<HyperComplex<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperComplex<TInner, TPrimitive>>.IndexOf(HyperComplex<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperComplex<TInner, TPrimitive>>.Insert(int index, HyperComplex<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperComplex<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperComplex<TInner, TPrimitive>>.Add(HyperComplex<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperComplex<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperComplex<TInner, TPrimitive>>.Contains(HyperComplex<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<HyperComplex<TInner, TPrimitive>>.CopyTo(HyperComplex<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperComplex<TInner, TPrimitive>>.Remove(HyperComplex<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperComplex<TInner, TPrimitive>> IEnumerable<HyperComplex<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperDiagonal<TInner> : IWrapperNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>, IWrapperNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>, HyperDiagonal<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperDiagonal<TInner> IWrapperNumber<HyperDiagonal<TInner>>.Value => this;

		HyperDiagonal<TInner> IExtendedNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallReversed(BinaryOperation operation, in HyperDiagonal<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperDiagonal<TInner> INumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallComponent(UnaryOperation operation)
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
            HyperDiagonal<TInner> INumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallComponent(UnaryOperation operation, in HyperDiagonal<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner> Create(in HyperDiagonal<TInner> num)
            {
                return num;
            }

            public HyperDiagonal<TInner> Create(in HyperDiagonal<TInner> realUnit, in HyperDiagonal<TInner> otherUnits, in HyperDiagonal<TInner> someUnitsCombined, in HyperDiagonal<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperDiagonal<TInner> Create(IEnumerable<HyperDiagonal<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperDiagonal<TInner> Create(IEnumerator<HyperDiagonal<TInner>> units)
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

	partial struct HyperDiagonal<TInner, TPrimitive> : IWrapperNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperDiagonal<TInner, TPrimitive> IWrapperNumber<HyperDiagonal<TInner, TPrimitive>>.Value => this;

		HyperDiagonal<TInner, TPrimitive> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		HyperDiagonal<TInner, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>> INumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>
		{
            HyperDiagonal<TInner, TPrimitive> INumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner, TPrimitive> Create(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num;
            }

            public HyperDiagonal<TInner, TPrimitive> Create(in HyperDiagonal<TInner, TPrimitive> realUnit, in HyperDiagonal<TInner, TPrimitive> otherUnits, in HyperDiagonal<TInner, TPrimitive> someUnitsCombined, in HyperDiagonal<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperDiagonal<TInner, TPrimitive> Create(IEnumerable<HyperDiagonal<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperDiagonal<TInner, TPrimitive> Create(IEnumerator<HyperDiagonal<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperDiagonal<TInner, TPrimitive>>.Count => 1;

        bool ICollection<HyperDiagonal<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperDiagonal<TInner, TPrimitive>>.Count => 1;

        HyperDiagonal<TInner, TPrimitive> IReadOnlyList<HyperDiagonal<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperDiagonal<TInner, TPrimitive> IList<HyperDiagonal<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperDiagonal<TInner, TPrimitive>>.IndexOf(HyperDiagonal<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperDiagonal<TInner, TPrimitive>>.Insert(int index, HyperDiagonal<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperDiagonal<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDiagonal<TInner, TPrimitive>>.Add(HyperDiagonal<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDiagonal<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperDiagonal<TInner, TPrimitive>>.Contains(HyperDiagonal<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<HyperDiagonal<TInner, TPrimitive>>.CopyTo(HyperDiagonal<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperDiagonal<TInner, TPrimitive>>.Remove(HyperDiagonal<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperDiagonal<TInner, TPrimitive>> IEnumerable<HyperDiagonal<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperDual<TInner> : IWrapperNumber<HyperDual<TInner>, HyperDual<TInner>>, IWrapperNumber<HyperDual<TInner>, HyperDual<TInner>, HyperDual<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperDual<TInner> IWrapperNumber<HyperDual<TInner>>.Value => this;

		HyperDual<TInner> IExtendedNumber<HyperDual<TInner>, HyperDual<TInner>>.CallReversed(BinaryOperation operation, in HyperDual<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperDual<TInner> INumber<HyperDual<TInner>, HyperDual<TInner>>.CallComponent(UnaryOperation operation)
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
            HyperDual<TInner> INumberOperations<HyperDual<TInner>, HyperDual<TInner>>.CallComponent(UnaryOperation operation, in HyperDual<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner> Create(in HyperDual<TInner> num)
            {
                return num;
            }

            public HyperDual<TInner> Create(in HyperDual<TInner> realUnit, in HyperDual<TInner> otherUnits, in HyperDual<TInner> someUnitsCombined, in HyperDual<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperDual<TInner> Create(IEnumerable<HyperDual<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperDual<TInner> Create(IEnumerator<HyperDual<TInner>> units)
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

	partial struct HyperDual<TInner, TPrimitive> : IWrapperNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperDual<TInner, TPrimitive> IWrapperNumber<HyperDual<TInner, TPrimitive>>.Value => this;

		HyperDual<TInner, TPrimitive> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		HyperDual<TInner, TPrimitive> INumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>> INumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>
		{
            HyperDual<TInner, TPrimitive> INumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in HyperDual<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner, TPrimitive> Create(in HyperDual<TInner, TPrimitive> num)
            {
                return num;
            }

            public HyperDual<TInner, TPrimitive> Create(in HyperDual<TInner, TPrimitive> realUnit, in HyperDual<TInner, TPrimitive> otherUnits, in HyperDual<TInner, TPrimitive> someUnitsCombined, in HyperDual<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperDual<TInner, TPrimitive> Create(IEnumerable<HyperDual<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperDual<TInner, TPrimitive> Create(IEnumerator<HyperDual<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperDual<TInner, TPrimitive>>.Count => 1;

        bool ICollection<HyperDual<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperDual<TInner, TPrimitive>>.Count => 1;

        HyperDual<TInner, TPrimitive> IReadOnlyList<HyperDual<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperDual<TInner, TPrimitive> IList<HyperDual<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperDual<TInner, TPrimitive>>.IndexOf(HyperDual<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperDual<TInner, TPrimitive>>.Insert(int index, HyperDual<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperDual<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDual<TInner, TPrimitive>>.Add(HyperDual<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperDual<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperDual<TInner, TPrimitive>>.Contains(HyperDual<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<HyperDual<TInner, TPrimitive>>.CopyTo(HyperDual<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperDual<TInner, TPrimitive>>.Remove(HyperDual<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperDual<TInner, TPrimitive>> IEnumerable<HyperDual<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct HyperSplitComplex<TInner> : IWrapperNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>, IWrapperNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperSplitComplex<TInner> IWrapperNumber<HyperSplitComplex<TInner>>.Value => this;

		HyperSplitComplex<TInner> IExtendedNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner> num)
		{
			return num.Call(operation, this);
		}

		HyperSplitComplex<TInner> INumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallComponent(UnaryOperation operation)
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
            HyperSplitComplex<TInner> INumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallComponent(UnaryOperation operation, in HyperSplitComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner> Create(in HyperSplitComplex<TInner> num)
            {
                return num;
            }

            public HyperSplitComplex<TInner> Create(in HyperSplitComplex<TInner> realUnit, in HyperSplitComplex<TInner> otherUnits, in HyperSplitComplex<TInner> someUnitsCombined, in HyperSplitComplex<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperSplitComplex<TInner> Create(IEnumerable<HyperSplitComplex<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperSplitComplex<TInner> Create(IEnumerator<HyperSplitComplex<TInner>> units)
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

	partial struct HyperSplitComplex<TInner, TPrimitive> : IWrapperNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperSplitComplex<TInner, TPrimitive> IWrapperNumber<HyperSplitComplex<TInner, TPrimitive>>.Value => this;

		HyperSplitComplex<TInner, TPrimitive> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		HyperSplitComplex<TInner, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>> INumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>
		{
            HyperSplitComplex<TInner, TPrimitive> INumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num;
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in HyperSplitComplex<TInner, TPrimitive> realUnit, in HyperSplitComplex<TInner, TPrimitive> otherUnits, in HyperSplitComplex<TInner, TPrimitive> someUnitsCombined, in HyperSplitComplex<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(IEnumerable<HyperSplitComplex<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(IEnumerator<HyperSplitComplex<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<HyperSplitComplex<TInner, TPrimitive>>.Count => 1;

        bool ICollection<HyperSplitComplex<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<HyperSplitComplex<TInner, TPrimitive>>.Count => 1;

        HyperSplitComplex<TInner, TPrimitive> IReadOnlyList<HyperSplitComplex<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        HyperSplitComplex<TInner, TPrimitive> IList<HyperSplitComplex<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<HyperSplitComplex<TInner, TPrimitive>>.IndexOf(HyperSplitComplex<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<HyperSplitComplex<TInner, TPrimitive>>.Insert(int index, HyperSplitComplex<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<HyperSplitComplex<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperSplitComplex<TInner, TPrimitive>>.Add(HyperSplitComplex<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<HyperSplitComplex<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<HyperSplitComplex<TInner, TPrimitive>>.Contains(HyperSplitComplex<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<HyperSplitComplex<TInner, TPrimitive>>.CopyTo(HyperSplitComplex<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<HyperSplitComplex<TInner, TPrimitive>>.Remove(HyperSplitComplex<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<HyperSplitComplex<TInner, TPrimitive>> IEnumerable<HyperSplitComplex<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct NullableNumber<TInner> : IWrapperNumber<NullableNumber<TInner>, NullableNumber<TInner>>, IWrapperNumber<NullableNumber<TInner>, NullableNumber<TInner>, NullableNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        NullableNumber<TInner> IWrapperNumber<NullableNumber<TInner>>.Value => this;

		NullableNumber<TInner> IExtendedNumber<NullableNumber<TInner>, NullableNumber<TInner>>.CallReversed(BinaryOperation operation, in NullableNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		NullableNumber<TInner> INumber<NullableNumber<TInner>, NullableNumber<TInner>>.CallComponent(UnaryOperation operation)
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
            NullableNumber<TInner> INumberOperations<NullableNumber<TInner>, NullableNumber<TInner>>.CallComponent(UnaryOperation operation, in NullableNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner> Create(in NullableNumber<TInner> num)
            {
                return num;
            }

            public NullableNumber<TInner> Create(in NullableNumber<TInner> realUnit, in NullableNumber<TInner> otherUnits, in NullableNumber<TInner> someUnitsCombined, in NullableNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public NullableNumber<TInner> Create(IEnumerable<NullableNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public NullableNumber<TInner> Create(IEnumerator<NullableNumber<TInner>> units)
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

	partial struct NullableNumber<TInner, TPrimitive> : IWrapperNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        NullableNumber<TInner, TPrimitive> IWrapperNumber<NullableNumber<TInner, TPrimitive>>.Value => this;

		NullableNumber<TInner, TPrimitive> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		NullableNumber<TInner, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>> INumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>
		{
            NullableNumber<TInner, TPrimitive> INumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner, TPrimitive> Create(in NullableNumber<TInner, TPrimitive> num)
            {
                return num;
            }

            public NullableNumber<TInner, TPrimitive> Create(in NullableNumber<TInner, TPrimitive> realUnit, in NullableNumber<TInner, TPrimitive> otherUnits, in NullableNumber<TInner, TPrimitive> someUnitsCombined, in NullableNumber<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public NullableNumber<TInner, TPrimitive> Create(IEnumerable<NullableNumber<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public NullableNumber<TInner, TPrimitive> Create(IEnumerator<NullableNumber<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<NullableNumber<TInner, TPrimitive>>.Count => 1;

        bool ICollection<NullableNumber<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<NullableNumber<TInner, TPrimitive>>.Count => 1;

        NullableNumber<TInner, TPrimitive> IReadOnlyList<NullableNumber<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        NullableNumber<TInner, TPrimitive> IList<NullableNumber<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<NullableNumber<TInner, TPrimitive>>.IndexOf(NullableNumber<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<NullableNumber<TInner, TPrimitive>>.Insert(int index, NullableNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<NullableNumber<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullableNumber<TInner, TPrimitive>>.Add(NullableNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullableNumber<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<NullableNumber<TInner, TPrimitive>>.Contains(NullableNumber<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<NullableNumber<TInner, TPrimitive>>.CopyTo(NullableNumber<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<NullableNumber<TInner, TPrimitive>>.Remove(NullableNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<NullableNumber<TInner, TPrimitive>> IEnumerable<NullableNumber<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct NullNumber : IWrapperNumber<NullNumber, NullNumber>, IWrapperNumber<NullNumber, NullNumber, NullNumber>
	{
        NullNumber IWrapperNumber<NullNumber>.Value => this;

		NullNumber IExtendedNumber<NullNumber, NullNumber>.CallReversed(BinaryOperation operation, in NullNumber num)
		{
			return num.Call(operation, this);
		}

		NullNumber INumber<NullNumber, NullNumber>.CallComponent(UnaryOperation operation)
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
            NullNumber INumberOperations<NullNumber, NullNumber>.CallComponent(UnaryOperation operation, in NullNumber num)
            {
                return num.Call(operation);
            }

            public NullNumber Create(in NullNumber num)
            {
                return num;
            }

            public NullNumber Create(in NullNumber realUnit, in NullNumber otherUnits, in NullNumber someUnitsCombined, in NullNumber allUnitsCombined)
            {
                return realUnit;
            }

            public NullNumber Create(IEnumerable<NullNumber> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public NullNumber Create(IEnumerator<NullNumber> units)
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

	partial struct NullNumber<TPrimitive> : IWrapperNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>, IWrapperNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, NullNumber<TPrimitive>> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        NullNumber<TPrimitive> IWrapperNumber<NullNumber<TPrimitive>>.Value => this;

		NullNumber<TPrimitive> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.CallReversed(BinaryOperation operation, in NullNumber<TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		NullNumber<TPrimitive> INumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>> INumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, NullNumber<TPrimitive>> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>, IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, NullNumber<TPrimitive>>
		{
            NullNumber<TPrimitive> INumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.CallComponent(UnaryOperation operation, in NullNumber<TPrimitive> num)
            {
                return num.Call(operation);
            }

            public NullNumber<TPrimitive> Create(in NullNumber<TPrimitive> num)
            {
                return num;
            }

            public NullNumber<TPrimitive> Create(in NullNumber<TPrimitive> realUnit, in NullNumber<TPrimitive> otherUnits, in NullNumber<TPrimitive> someUnitsCombined, in NullNumber<TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public NullNumber<TPrimitive> Create(IEnumerable<NullNumber<TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public NullNumber<TPrimitive> Create(IEnumerator<NullNumber<TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<NullNumber<TPrimitive>>.Count => 1;

        bool ICollection<NullNumber<TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<NullNumber<TPrimitive>>.Count => 1;

        NullNumber<TPrimitive> IReadOnlyList<NullNumber<TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        NullNumber<TPrimitive> IList<NullNumber<TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<NullNumber<TPrimitive>>.IndexOf(NullNumber<TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<NullNumber<TPrimitive>>.Insert(int index, NullNumber<TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<NullNumber<TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullNumber<TPrimitive>>.Add(NullNumber<TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<NullNumber<TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<NullNumber<TPrimitive>>.Contains(NullNumber<TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<NullNumber<TPrimitive>>.CopyTo(NullNumber<TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<NullNumber<TPrimitive>>.Remove(NullNumber<TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<NullNumber<TPrimitive>> IEnumerable<NullNumber<TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

	partial struct ProjectiveNumber<TInner> : IWrapperNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>, IWrapperNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        ProjectiveNumber<TInner> IWrapperNumber<ProjectiveNumber<TInner>>.Value => this;

		ProjectiveNumber<TInner> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner> num)
		{
			return num.Call(operation, this);
		}

		ProjectiveNumber<TInner> INumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallComponent(UnaryOperation operation)
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
            ProjectiveNumber<TInner> INumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallComponent(UnaryOperation operation, in ProjectiveNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner> Create(in ProjectiveNumber<TInner> num)
            {
                return num;
            }

            public ProjectiveNumber<TInner> Create(in ProjectiveNumber<TInner> realUnit, in ProjectiveNumber<TInner> otherUnits, in ProjectiveNumber<TInner> someUnitsCombined, in ProjectiveNumber<TInner> allUnitsCombined)
            {
                return realUnit;
            }

            public ProjectiveNumber<TInner> Create(IEnumerable<ProjectiveNumber<TInner>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public ProjectiveNumber<TInner> Create(IEnumerator<ProjectiveNumber<TInner>> units)
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

	partial struct ProjectiveNumber<TInner, TPrimitive> : IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>, IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        ProjectiveNumber<TInner, TPrimitive> IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>>.Value => this;

		ProjectiveNumber<TInner, TPrimitive> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}

		ProjectiveNumber<TInner, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation)
		{
			return Call(operation);
		}
		
        IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

		INumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>> INumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>, IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>
		{
            ProjectiveNumber<TInner, TPrimitive> INumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.CallComponent(UnaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num;
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(in ProjectiveNumber<TInner, TPrimitive> realUnit, in ProjectiveNumber<TInner, TPrimitive> otherUnits, in ProjectiveNumber<TInner, TPrimitive> someUnitsCombined, in ProjectiveNumber<TInner, TPrimitive> allUnitsCombined)
            {
                return realUnit;
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(IEnumerable<ProjectiveNumber<TInner, TPrimitive>> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return ienum.Current;
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(IEnumerator<ProjectiveNumber<TInner, TPrimitive>> units)
            {
                var value = units.Current;
                units.MoveNext();
                return value;
            }
		}
		
        int ICollection<ProjectiveNumber<TInner, TPrimitive>>.Count => 1;

        bool ICollection<ProjectiveNumber<TInner, TPrimitive>>.IsReadOnly => true;

        int IReadOnlyCollection<ProjectiveNumber<TInner, TPrimitive>>.Count => 1;

        ProjectiveNumber<TInner, TPrimitive> IReadOnlyList<ProjectiveNumber<TInner, TPrimitive>>.this[int index] => index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));

        ProjectiveNumber<TInner, TPrimitive> IList<ProjectiveNumber<TInner, TPrimitive>>.this[int index]
        {
            get{
                return index == 0 ? this : throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<ProjectiveNumber<TInner, TPrimitive>>.IndexOf(ProjectiveNumber<TInner, TPrimitive> item)
        {
            return Equals(item) ? 0 : -1;
        }

        void IList<ProjectiveNumber<TInner, TPrimitive>>.Insert(int index, ProjectiveNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void IList<ProjectiveNumber<TInner, TPrimitive>>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<ProjectiveNumber<TInner, TPrimitive>>.Add(ProjectiveNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        void ICollection<ProjectiveNumber<TInner, TPrimitive>>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<ProjectiveNumber<TInner, TPrimitive>>.Contains(ProjectiveNumber<TInner, TPrimitive> item)
        {
            return Equals(item);
        }

        void ICollection<ProjectiveNumber<TInner, TPrimitive>>.CopyTo(ProjectiveNumber<TInner, TPrimitive>[] array, int arrayIndex)
        {
            array[arrayIndex] = this;
        }

        bool ICollection<ProjectiveNumber<TInner, TPrimitive>>.Remove(ProjectiveNumber<TInner, TPrimitive> item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<ProjectiveNumber<TInner, TPrimitive>> IEnumerable<ProjectiveNumber<TInner, TPrimitive>>.GetEnumerator()
        {
            yield return this;
        }
	}

}