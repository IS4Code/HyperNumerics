using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct BoxedNumber<TInner, TComponent> : IWrapperNumber<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, BoxedNumber<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(Reference);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(Reference);
		
        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Reference, index);
            }
        }

        TComponent IList<TComponent>.this[int index]
        {
            get{
                return GetListItem(Reference, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            return Reference.IndexOf(item);
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return Reference.Contains(item);
        }
		
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            Reference.CopyTo(array, arrayIndex);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
			return Reference.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return Reference.GetEnumerator();
        }
	}

	partial struct CustomDefaultNumber<TInner, TComponent, TProvider> : IWrapperNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TProvider : struct, CustomDefaultNumber<TInner, TProvider>.IDefaultValueProvider
	{
		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(Value);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(Value);
		
        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Value, index);
            }
        }

        TComponent IList<TComponent>.this[int index]
        {
            get{
                return GetListItem(Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            return Value.IndexOf(item);
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return Value.Contains(item);
        }
		
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
			return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return Value.GetEnumerator();
        }
	}

	partial struct GeneratedNumber<TInner, TComponent> : IWrapperNumber<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, GeneratedNumber<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(Generator());

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(Generator());
		
        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Generator(), index);
            }
        }

        TComponent IList<TComponent>.this[int index]
        {
            get{
                return GetListItem(Generator(), index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            return Generator().IndexOf(item);
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return Generator().Contains(item);
        }
		
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            Generator().CopyTo(array, arrayIndex);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
			return Generator().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return Generator().GetEnumerator();
        }
	}

	partial struct HyperComplex<TInner, TComponent> : IWrapperNumber<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner, TComponent>, HyperComplex<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TComponent IReadOnlyList<TComponent>.this[int index]
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

        TComponent IList<TComponent>.this[int index]
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

        int IList<TComponent>.IndexOf(TComponent item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
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
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }
	}

	partial struct HyperDiagonal<TInner, TComponent> : IWrapperNumber<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, HyperDiagonal<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TComponent IReadOnlyList<TComponent>.this[int index]
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

        TComponent IList<TComponent>.this[int index]
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

        int IList<TComponent>.IndexOf(TComponent item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
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
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }
	}

	partial struct HyperDual<TInner, TComponent> : IWrapperNumber<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<HyperDual<TInner, TComponent>, HyperDual<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TComponent IReadOnlyList<TComponent>.this[int index]
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

        TComponent IList<TComponent>.this[int index]
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

        int IList<TComponent>.IndexOf(TComponent item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
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
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }
	}

	partial struct HyperSplitComplex<TInner, TComponent> : IWrapperNumber<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, HyperSplitComplex<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(first) + GetCollectionCount(second);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(first) + GetReadOnlyCollectionCount(second);
				
        TComponent IReadOnlyList<TComponent>.this[int index]
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

        TComponent IList<TComponent>.this[int index]
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

        int IList<TComponent>.IndexOf(TComponent item)
        {
            int index = first.IndexOf(item);
            if(index == -1)
            {
                int offset = GetCollectionCount(first);
                return offset + second.IndexOf(item);
            }
            return index;
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return first.Contains(item) || second.Contains(item);
        }
				
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
			int offset = 0;
            first.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(first);
            second.CopyTo(array, arrayIndex + offset);
			offset += GetCollectionCount(second);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
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
            foreach(var num in first)
            {
                yield return num;
            }
            foreach(var num in second)
            {
                yield return num;
            }
        }
	}

	partial struct TransformedNumber<TInner, TComponent, TTransformation> : IWrapperNumber<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TTransformation : struct, TransformedNumber<TInner, TTransformation>.ITransformation
	{
		partial class Operations : IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TransformedNumber<TInner, TComponent, TTransformation>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(Value);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(Value);
		
        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                return GetReadOnlyListItem(Value, index);
            }
        }

        TComponent IList<TComponent>.this[int index]
        {
            get{
                return GetListItem(Value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            return Value.IndexOf(item);
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return Value.Contains(item);
        }
		
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
			return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return Value.GetEnumerator();
        }
	}

	partial struct WrapperNumber<TInner, TComponent> : IWrapperNumber<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		partial class Operations : IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, WrapperNumber<TInner, TComponent>, TComponent>
		{
			
		}
        
        static int GetCollectionCount<T>(in T value) where T : struct, ICollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetListItem<T>(in T value, int index) where T : struct, IList<TComponent>
        {
            return value[index];
        }

        static int GetReadOnlyCollectionCount<T>(in T value) where T : struct, IReadOnlyCollection<TComponent>
        {
            return value.Count;
        }

        static TComponent GetReadOnlyListItem<T>(in T value, int index) where T : struct, IReadOnlyList<TComponent>
        {
            return value[index];
        }
		
        int ICollection<TComponent>.Count => GetCollectionCount(value);

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count => GetReadOnlyCollectionCount(value);
		
        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                return GetReadOnlyListItem(value, index);
            }
        }

        TComponent IList<TComponent>.this[int index]
        {
            get{
                return GetListItem(value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            return value.IndexOf(item);
        }

        void IList<TComponent>.Insert(int index, TComponent item)
        {
            throw new NotSupportedException();
        }

        void IList<TComponent>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Add(TComponent item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TComponent>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TComponent>.Contains(TComponent item)
        {
            return value.Contains(item);
        }
		
        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }
		
        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
        {
			return value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return value.GetEnumerator();
        }
	}

}