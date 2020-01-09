using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct BoxedNumber<TInner, TPrimitive> : IWrapperNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
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

	partial struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
	{
		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
		}
		
        int ICollection<TPrimitive>.Count => GetCollectionCount(Value);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(Value);
		
        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                return GetListItem(Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            return Value.IndexOf(item);
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
            return Value.Contains(item);
        }
		
        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
			return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return Value.GetEnumerator();
        }
	}

	partial struct GeneratedNumber<TInner, TPrimitive> : IWrapperNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
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

	partial struct HyperComplex<TInner, TPrimitive> : IWrapperNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
		}
		
        int ICollection<TPrimitive>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetReadOnlyCollectionCount(first);
                if(index >= offset)
                {
                    return GetReadOnlyListItem(second, index - offset);
                }
                return GetReadOnlyListItem(first, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetCollectionCount(first);
                if(index >= offset)
                {
                    return GetListItem(second, index - offset);
                }
                return GetListItem(first, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
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
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetBaseEnumerator(this);
        }
	}

	partial struct HyperDiagonal<TInner, TPrimitive> : IWrapperNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
		}
		
        int ICollection<TPrimitive>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetReadOnlyCollectionCount(first);
                if(index >= offset)
                {
                    return GetReadOnlyListItem(second, index - offset);
                }
                return GetReadOnlyListItem(first, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetCollectionCount(first);
                if(index >= offset)
                {
                    return GetListItem(second, index - offset);
                }
                return GetListItem(first, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
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
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetBaseEnumerator(this);
        }
	}

	partial struct HyperDual<TInner, TPrimitive> : IWrapperNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
		partial class Operations : IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
		}
		
        int ICollection<TPrimitive>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetReadOnlyCollectionCount(first);
                if(index >= offset)
                {
                    return GetReadOnlyListItem(second, index - offset);
                }
                return GetReadOnlyListItem(first, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetCollectionCount(first);
                if(index >= offset)
                {
                    return GetListItem(second, index - offset);
                }
                return GetListItem(first, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
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
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetBaseEnumerator(this);
        }
	}

	partial struct HyperSplitComplex<TInner, TPrimitive> : IWrapperNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive>
		{
			
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

		static IEnumerator GetBaseEnumerator<T>(in T value) where T : struct, IEnumerable
		{
		    return value.GetEnumerator();
		}
		
        int ICollection<TPrimitive>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetReadOnlyCollectionCount(first);
                if(index >= offset)
                {
                    return GetReadOnlyListItem(second, index - offset);
                }
                return GetReadOnlyListItem(first, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                int offset = GetCollectionCount(first);
                if(index >= offset)
                {
                    return GetListItem(second, index - offset);
                }
                return GetListItem(first, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
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
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetBaseEnumerator(this);
        }
	}

}