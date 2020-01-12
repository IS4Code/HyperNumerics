using IS4.HyperNumerics.Operations;
using IS4.HyperNumerics.Utils;
using System;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct AbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public AbstractNumber CallReversed(BinaryOperation operation, in AbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<AbstractNumber>.Equals(AbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<AbstractNumber>.CompareTo(AbstractNumber other)
        {
            return CompareTo(other);
        }

        public static AbstractNumber operator+(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static AbstractNumber operator-(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static AbstractNumber operator*(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static AbstractNumber operator/(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static AbstractNumber operator^(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static AbstractNumber operator-(AbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static AbstractNumber operator~(AbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static AbstractNumber operator++(AbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static AbstractNumber operator--(AbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(AbstractNumber a, AbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(AbstractNumber a, AbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<AbstractNumber> INumber<AbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in AbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in AbstractNumber num)
            {
                return num.IsFinite;
            }

            public AbstractNumber Clone(in AbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(AbstractNumber num1, AbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(AbstractNumber num1, AbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(AbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in AbstractNumber num)
            {
                return num.GetHashCode();
            }

            public AbstractNumber Call(UnaryOperation operation, in AbstractNumber num)
            {
                return num.Call(operation);
            }

            public AbstractNumber Call(BinaryOperation operation, in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ComponentAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ComponentAbstractNumber CallReversed(BinaryOperation operation, in ComponentAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ComponentAbstractNumber>.Equals(ComponentAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<ComponentAbstractNumber>.CompareTo(ComponentAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static ComponentAbstractNumber operator+(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ComponentAbstractNumber operator-(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ComponentAbstractNumber operator*(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ComponentAbstractNumber operator/(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ComponentAbstractNumber operator^(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ComponentAbstractNumber operator-(ComponentAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ComponentAbstractNumber operator~(ComponentAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ComponentAbstractNumber operator++(ComponentAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ComponentAbstractNumber operator--(ComponentAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ComponentAbstractNumber> INumber<ComponentAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ComponentAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ComponentAbstractNumber num)
            {
                return num.IsFinite;
            }

            public ComponentAbstractNumber Clone(in ComponentAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(ComponentAbstractNumber num1, ComponentAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ComponentAbstractNumber num1, ComponentAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ComponentAbstractNumber num1, in ComponentAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ComponentAbstractNumber num1, in ComponentAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ComponentAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ComponentAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public ComponentAbstractNumber Call(UnaryOperation operation, in ComponentAbstractNumber num)
            {
                return num.Call(operation);
            }

            public ComponentAbstractNumber Call(BinaryOperation operation, in ComponentAbstractNumber num1, in ComponentAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct UnaryAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public UnaryAbstractNumber CallReversed(BinaryOperation operation, in UnaryAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<UnaryAbstractNumber>.Equals(UnaryAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<UnaryAbstractNumber>.CompareTo(UnaryAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static UnaryAbstractNumber operator+(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static UnaryAbstractNumber operator*(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static UnaryAbstractNumber operator/(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static UnaryAbstractNumber operator^(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static UnaryAbstractNumber operator~(UnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static UnaryAbstractNumber operator++(UnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static UnaryAbstractNumber operator--(UnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<UnaryAbstractNumber> INumber<UnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in UnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in UnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public UnaryAbstractNumber Clone(in UnaryAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(UnaryAbstractNumber num1, UnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(UnaryAbstractNumber num1, UnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(UnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in UnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public UnaryAbstractNumber Call(UnaryOperation operation, in UnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public UnaryAbstractNumber Call(BinaryOperation operation, in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ComponentUnaryAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ComponentUnaryAbstractNumber CallReversed(BinaryOperation operation, in ComponentUnaryAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ComponentUnaryAbstractNumber>.Equals(ComponentUnaryAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<ComponentUnaryAbstractNumber>.CompareTo(ComponentUnaryAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static ComponentUnaryAbstractNumber operator+(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ComponentUnaryAbstractNumber operator-(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ComponentUnaryAbstractNumber operator*(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ComponentUnaryAbstractNumber operator/(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ComponentUnaryAbstractNumber operator^(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ComponentUnaryAbstractNumber operator-(ComponentUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ComponentUnaryAbstractNumber operator~(ComponentUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ComponentUnaryAbstractNumber operator++(ComponentUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ComponentUnaryAbstractNumber operator--(ComponentUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ComponentUnaryAbstractNumber> INumber<ComponentUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ComponentUnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ComponentUnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public ComponentUnaryAbstractNumber Clone(in ComponentUnaryAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(ComponentUnaryAbstractNumber num1, ComponentUnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ComponentUnaryAbstractNumber num1, ComponentUnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ComponentUnaryAbstractNumber num1, in ComponentUnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ComponentUnaryAbstractNumber num1, in ComponentUnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ComponentUnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ComponentUnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public ComponentUnaryAbstractNumber Call(UnaryOperation operation, in ComponentUnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public ComponentUnaryAbstractNumber Call(BinaryOperation operation, in ComponentUnaryAbstractNumber num1, in ComponentUnaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct BinaryAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public BinaryAbstractNumber CallReversed(BinaryOperation operation, in BinaryAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<BinaryAbstractNumber>.Equals(BinaryAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<BinaryAbstractNumber>.CompareTo(BinaryAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static BinaryAbstractNumber operator+(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BinaryAbstractNumber operator*(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BinaryAbstractNumber operator/(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BinaryAbstractNumber operator^(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static BinaryAbstractNumber operator~(BinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static BinaryAbstractNumber operator++(BinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static BinaryAbstractNumber operator--(BinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BinaryAbstractNumber> INumber<BinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in BinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public BinaryAbstractNumber Clone(in BinaryAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(BinaryAbstractNumber num1, BinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(BinaryAbstractNumber num1, BinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(BinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in BinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public BinaryAbstractNumber Call(UnaryOperation operation, in BinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public BinaryAbstractNumber Call(BinaryOperation operation, in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ComponentBinaryAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ComponentBinaryAbstractNumber CallReversed(BinaryOperation operation, in ComponentBinaryAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ComponentBinaryAbstractNumber>.Equals(ComponentBinaryAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<ComponentBinaryAbstractNumber>.CompareTo(ComponentBinaryAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static ComponentBinaryAbstractNumber operator+(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ComponentBinaryAbstractNumber operator-(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ComponentBinaryAbstractNumber operator*(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ComponentBinaryAbstractNumber operator/(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ComponentBinaryAbstractNumber operator^(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ComponentBinaryAbstractNumber operator-(ComponentBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ComponentBinaryAbstractNumber operator~(ComponentBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ComponentBinaryAbstractNumber operator++(ComponentBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ComponentBinaryAbstractNumber operator--(ComponentBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ComponentBinaryAbstractNumber> INumber<ComponentBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ComponentBinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ComponentBinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public ComponentBinaryAbstractNumber Clone(in ComponentBinaryAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(ComponentBinaryAbstractNumber num1, ComponentBinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ComponentBinaryAbstractNumber num1, ComponentBinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ComponentBinaryAbstractNumber num1, in ComponentBinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ComponentBinaryAbstractNumber num1, in ComponentBinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ComponentBinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ComponentBinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public ComponentBinaryAbstractNumber Call(UnaryOperation operation, in ComponentBinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public ComponentBinaryAbstractNumber Call(BinaryOperation operation, in ComponentBinaryAbstractNumber num1, in ComponentBinaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct BoxedNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public BoxedNumber<TInner> CallReversed(BinaryOperation operation, in BoxedNumber<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<BoxedNumber<TInner>>.Equals(BoxedNumber<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<BoxedNumber<TInner>>.CompareTo(BoxedNumber<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator BoxedNumber<TInner>(TInner value)
        {
            return new BoxedNumber<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(BoxedNumber<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static BoxedNumber<TInner> operator+(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner> operator*(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner> operator/(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner> operator^(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static BoxedNumber<TInner> operator~(BoxedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static BoxedNumber<TInner> operator++(BoxedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static BoxedNumber<TInner> operator--(BoxedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static BoxedNumber<TInner> operator+(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner> operator*(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner> operator/(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner> operator^(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static BoxedNumber<TInner> operator+(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static BoxedNumber<TInner> operator-(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static BoxedNumber<TInner> operator*(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static BoxedNumber<TInner> operator/(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static BoxedNumber<TInner> operator^(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(BoxedNumber<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, BoxedNumber<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, BoxedNumber<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, BoxedNumber<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, BoxedNumber<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, BoxedNumber<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, BoxedNumber<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BoxedNumber<TInner>> INumber<BoxedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<BoxedNumber<TInner>, TInner> IExtendedNumber<BoxedNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in BoxedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BoxedNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public BoxedNumber<TInner> Clone(in BoxedNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(BoxedNumber<TInner> num1, BoxedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(BoxedNumber<TInner> num1, BoxedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(BoxedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in BoxedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public BoxedNumber<TInner> Call(UnaryOperation operation, in BoxedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner> Call(BinaryOperation operation, in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner> Call(BinaryOperation operation, in BoxedNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner> Call(BinaryOperation operation, in TInner num1, in BoxedNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public BoxedNumber<TInner> Create(in TInner num)
            {
                return new BoxedNumber<TInner>(num);
            }
		}
	}

	partial struct BoxedNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public BoxedNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in BoxedNumber<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<BoxedNumber<TInner, TComponent>>.Equals(BoxedNumber<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<BoxedNumber<TInner, TComponent>>.CompareTo(BoxedNumber<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator BoxedNumber<TInner, TComponent>(TInner value)
        {
            return new BoxedNumber<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(BoxedNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static BoxedNumber<TInner, TComponent> operator+(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static BoxedNumber<TInner, TComponent> operator~(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static BoxedNumber<TInner, TComponent> operator++(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static BoxedNumber<TInner, TComponent> operator--(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static BoxedNumber<TInner, TComponent> operator+(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static BoxedNumber<TInner, TComponent> operator+(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BoxedNumber<TInner, TComponent>> INumber<BoxedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<BoxedNumber<TInner, TComponent>, TComponent> INumber<BoxedNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, TInner> IExtendedNumber<BoxedNumber<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<BoxedNumber<TInner, TComponent>, TInner, TComponent> IExtendedNumber<BoxedNumber<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }		

        INumberOperations<TInner, TComponent> INumber<TInner, TComponent>.GetOperations()
        {
            return HyperMath.Operations.For<TInner, TComponent>.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in BoxedNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BoxedNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public BoxedNumber<TInner, TComponent> Clone(in BoxedNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(BoxedNumber<TInner, TComponent> num1, BoxedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(BoxedNumber<TInner, TComponent> num1, BoxedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in BoxedNumber<TInner, TComponent> num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in BoxedNumber<TInner, TComponent> num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(BoxedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in BoxedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public BoxedNumber<TInner, TComponent> Call(UnaryOperation operation, in BoxedNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in BoxedNumber<TInner, TComponent> num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in BoxedNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in BoxedNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in BoxedNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public BoxedNumber<TInner, TComponent> Create(in TInner num)
            {
                return new BoxedNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct CustomDefaultNumber<TInner, TTraits> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TTraits> CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<CustomDefaultNumber<TInner, TTraits>>.Equals(CustomDefaultNumber<TInner, TTraits> other)
        {
            return Equals(other);
        }

        int IComparable<CustomDefaultNumber<TInner, TTraits>>.CompareTo(CustomDefaultNumber<TInner, TTraits> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator CustomDefaultNumber<TInner, TTraits>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TTraits>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(CustomDefaultNumber<TInner, TTraits> value)
        {
            return GetAsWrapper(value);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator+(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator-(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator*(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator/(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator^(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator-(CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator~(CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator++(CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator--(CustomDefaultNumber<TInner, TTraits> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TTraits> a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static CustomDefaultNumber<TInner, TTraits> operator+(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator-(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator*(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator/(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator^(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static CustomDefaultNumber<TInner, TTraits> operator+(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator-(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator*(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator/(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static CustomDefaultNumber<TInner, TTraits> operator^(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TTraits> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, CustomDefaultNumber<TInner, TTraits> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TTraits>> INumber<CustomDefaultNumber<TInner, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.IsFinite;
            }

            public CustomDefaultNumber<TInner, TTraits> Clone(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.Clone();
            }

            public bool Equals(CustomDefaultNumber<TInner, TTraits> num1, CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(CustomDefaultNumber<TInner, TTraits> num1, CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in CustomDefaultNumber<TInner, TTraits> num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in CustomDefaultNumber<TInner, TTraits> num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.GetHashCode();
            }

            public CustomDefaultNumber<TInner, TTraits> Call(UnaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in TInner num1, in CustomDefaultNumber<TInner, TTraits> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public CustomDefaultNumber<TInner, TTraits> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TTraits>(num);
            }
		}
	}

	partial struct CustomDefaultNumber<TInner, TComponent, TTraits> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TTraits : struct, CustomDefaultNumber<TInner, TComponent, TTraits>.ITraits
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<CustomDefaultNumber<TInner, TComponent, TTraits>>.Equals(CustomDefaultNumber<TInner, TComponent, TTraits> other)
        {
            return Equals(other);
        }

        int IComparable<CustomDefaultNumber<TInner, TComponent, TTraits>>.CompareTo(CustomDefaultNumber<TInner, TComponent, TTraits> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator CustomDefaultNumber<TInner, TComponent, TTraits>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TComponent, TTraits>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(CustomDefaultNumber<TInner, TComponent, TTraits> value)
        {
            return GetAsWrapper(value);
        }

        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator+(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator-(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator*(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator/(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator^(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator-(CustomDefaultNumber<TInner, TComponent, TTraits> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator~(CustomDefaultNumber<TInner, TComponent, TTraits> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator++(CustomDefaultNumber<TInner, TComponent, TTraits> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator--(CustomDefaultNumber<TInner, TComponent, TTraits> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TComponent, TTraits> a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator+(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator-(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator*(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator/(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator^(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator+(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator-(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator*(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator/(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TTraits> operator^(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TComponent, TTraits> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, CustomDefaultNumber<TInner, TComponent, TTraits> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TComponent, TTraits>> INumber<CustomDefaultNumber<TInner, TComponent, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<CustomDefaultNumber<TInner, TComponent, TTraits>, TComponent> INumber<CustomDefaultNumber<TInner, TComponent, TTraits>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TTraits>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TTraits>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TTraits>, TInner, TComponent> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TTraits>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }		

        INumberOperations<TInner, TComponent> INumber<TInner, TComponent>.GetOperations()
        {
            return HyperMath.Operations.For<TInner, TComponent>.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.IsFinite;
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Clone(in CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.Clone();
            }

            public bool Equals(CustomDefaultNumber<TInner, TComponent, TTraits> num1, CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(CustomDefaultNumber<TInner, TComponent, TTraits> num1, CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in CustomDefaultNumber<TInner, TComponent, TTraits> num1, in CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in CustomDefaultNumber<TInner, TComponent, TTraits> num1, in CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.GetHashCode();
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(UnaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> num1, in CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in TInner num1, in CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> num)
            {
                return num.CallComponent(operation);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in TComponent num1, in CustomDefaultNumber<TInner, TComponent, TTraits> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TComponent, TTraits>(num);
            }
		}
	}

	partial struct GeneratedNumber<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner> CallReversed(BinaryOperation operation, in GeneratedNumber<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<GeneratedNumber<TInner>>.Equals(GeneratedNumber<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<GeneratedNumber<TInner>>.CompareTo(GeneratedNumber<TInner> other)
        {
            return CompareTo(other);
        }

        public static GeneratedNumber<TInner> operator+(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner> operator*(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner> operator/(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner> operator^(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static GeneratedNumber<TInner> operator~(GeneratedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static GeneratedNumber<TInner> operator++(GeneratedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static GeneratedNumber<TInner> operator--(GeneratedNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static GeneratedNumber<TInner> operator+(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner> operator*(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner> operator/(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner> operator^(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static GeneratedNumber<TInner> operator+(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static GeneratedNumber<TInner> operator-(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static GeneratedNumber<TInner> operator*(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static GeneratedNumber<TInner> operator/(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static GeneratedNumber<TInner> operator^(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<GeneratedNumber<TInner>> INumber<GeneratedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<GeneratedNumber<TInner>, TInner> IExtendedNumber<GeneratedNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in GeneratedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in GeneratedNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public GeneratedNumber<TInner> Clone(in GeneratedNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(GeneratedNumber<TInner> num1, GeneratedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(GeneratedNumber<TInner> num1, GeneratedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(GeneratedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in GeneratedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public GeneratedNumber<TInner> Call(UnaryOperation operation, in GeneratedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner> Call(BinaryOperation operation, in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner> Call(BinaryOperation operation, in GeneratedNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner> Call(BinaryOperation operation, in TInner num1, in GeneratedNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public GeneratedNumber<TInner> Create(in TInner num)
            {
                return new GeneratedNumber<TInner>(num);
            }
		}
	}

	partial struct GeneratedNumber<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in GeneratedNumber<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<GeneratedNumber<TInner, TComponent>>.Equals(GeneratedNumber<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<GeneratedNumber<TInner, TComponent>>.CompareTo(GeneratedNumber<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        public static GeneratedNumber<TInner, TComponent> operator+(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator~(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator++(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator--(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static GeneratedNumber<TInner, TComponent> operator+(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static GeneratedNumber<TInner, TComponent> operator+(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<GeneratedNumber<TInner, TComponent>> INumber<GeneratedNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<GeneratedNumber<TInner, TComponent>, TComponent> INumber<GeneratedNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, TInner> IExtendedNumber<GeneratedNumber<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<GeneratedNumber<TInner, TComponent>, TInner, TComponent> IExtendedNumber<GeneratedNumber<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public GeneratedNumber<TInner, TComponent> Clone(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(GeneratedNumber<TInner, TComponent> num1, GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(GeneratedNumber<TInner, TComponent> num1, GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in GeneratedNumber<TInner, TComponent> num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in GeneratedNumber<TInner, TComponent> num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(GeneratedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public GeneratedNumber<TInner, TComponent> Call(UnaryOperation operation, in GeneratedNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in GeneratedNumber<TInner, TComponent> num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in GeneratedNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in GeneratedNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in GeneratedNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public GeneratedNumber<TInner, TComponent> Create(in TInner num)
            {
                return new GeneratedNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperComplex<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner> CallReversed(BinaryOperation operation, in HyperComplex<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperComplex<TInner>>.Equals(HyperComplex<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<HyperComplex<TInner>>.CompareTo(HyperComplex<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperComplex<TInner>(TInner value)
        {
            return new HyperComplex<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperComplex<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperComplex<TInner> operator+(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner> operator*(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner> operator/(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner> operator^(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperComplex<TInner> operator~(HyperComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperComplex<TInner> operator++(HyperComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperComplex<TInner> operator--(HyperComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperComplex<TInner> operator+(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner> operator*(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner> operator/(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner> operator^(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperComplex<TInner> operator+(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperComplex<TInner> operator-(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperComplex<TInner> operator*(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperComplex<TInner> operator/(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperComplex<TInner> operator^(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperComplex<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperComplex<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperComplex<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperComplex<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperComplex<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperComplex<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperComplex<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperComplex<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperComplex<TInner>> INumber<HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperComplex<TInner>, TInner> IExtendedNumber<HyperComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperComplex<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperComplex<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperComplex<TInner> Clone(in HyperComplex<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperComplex<TInner> num1, HyperComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperComplex<TInner> num1, HyperComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public HyperComplex<TInner> Call(UnaryOperation operation, in HyperComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner> Call(BinaryOperation operation, in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner> Call(BinaryOperation operation, in HyperComplex<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner> Call(BinaryOperation operation, in TInner num1, in HyperComplex<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperComplex<TInner> Create(in TInner num)
            {
                return new HyperComplex<TInner>(num);
            }
		}
	}

	partial struct HyperComplex<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner, TComponent> CallReversed(BinaryOperation operation, in HyperComplex<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperComplex<TInner, TComponent>>.Equals(HyperComplex<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<HyperComplex<TInner, TComponent>>.CompareTo(HyperComplex<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperComplex<TInner, TComponent>(TInner value)
        {
            return new HyperComplex<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperComplex<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperComplex<TInner, TComponent> operator+(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperComplex<TInner, TComponent> operator~(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperComplex<TInner, TComponent> operator++(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperComplex<TInner, TComponent> operator--(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperComplex<TInner, TComponent> operator+(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperComplex<TInner, TComponent> operator+(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperComplex<TInner, TComponent>> INumber<HyperComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperComplex<TInner, TComponent>, TComponent> INumber<HyperComplex<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperComplex<TInner, TComponent>, TInner> IExtendedNumber<HyperComplex<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperComplex<TInner, TComponent>, TInner, TComponent> IExtendedNumber<HyperComplex<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperComplex<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperComplex<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public HyperComplex<TInner, TComponent> Clone(in HyperComplex<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperComplex<TInner, TComponent> num1, HyperComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperComplex<TInner, TComponent> num1, HyperComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperComplex<TInner, TComponent> num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperComplex<TInner, TComponent> num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public HyperComplex<TInner, TComponent> Call(UnaryOperation operation, in HyperComplex<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperComplex<TInner, TComponent> num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperComplex<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in HyperComplex<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public HyperComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperComplex<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperComplex<TInner, TComponent> Create(in TInner num)
            {
                return new HyperComplex<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperDiagonal<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner> CallReversed(BinaryOperation operation, in HyperDiagonal<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperDiagonal<TInner>>.Equals(HyperDiagonal<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<HyperDiagonal<TInner>>.CompareTo(HyperDiagonal<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperDiagonal<TInner>(TInner value)
        {
            return new HyperDiagonal<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDiagonal<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperDiagonal<TInner> operator+(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner> operator*(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner> operator/(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner> operator^(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperDiagonal<TInner> operator~(HyperDiagonal<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperDiagonal<TInner> operator++(HyperDiagonal<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperDiagonal<TInner> operator--(HyperDiagonal<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperDiagonal<TInner> operator+(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner> operator*(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner> operator/(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner> operator^(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperDiagonal<TInner> operator+(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperDiagonal<TInner> operator-(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperDiagonal<TInner> operator*(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperDiagonal<TInner> operator/(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperDiagonal<TInner> operator^(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDiagonal<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDiagonal<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperDiagonal<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperDiagonal<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDiagonal<TInner>> INumber<HyperDiagonal<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDiagonal<TInner>, TInner> IExtendedNumber<HyperDiagonal<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperDiagonal<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDiagonal<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperDiagonal<TInner> Clone(in HyperDiagonal<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperDiagonal<TInner> num1, HyperDiagonal<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperDiagonal<TInner> num1, HyperDiagonal<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperDiagonal<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperDiagonal<TInner> num)
            {
                return num.GetHashCode();
            }

            public HyperDiagonal<TInner> Call(UnaryOperation operation, in HyperDiagonal<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner> Call(BinaryOperation operation, in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner> Call(BinaryOperation operation, in HyperDiagonal<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner> Call(BinaryOperation operation, in TInner num1, in HyperDiagonal<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperDiagonal<TInner> Create(in TInner num)
            {
                return new HyperDiagonal<TInner>(num);
            }
		}
	}

	partial struct HyperDiagonal<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner, TComponent> CallReversed(BinaryOperation operation, in HyperDiagonal<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperDiagonal<TInner, TComponent>>.Equals(HyperDiagonal<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<HyperDiagonal<TInner, TComponent>>.CompareTo(HyperDiagonal<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperDiagonal<TInner, TComponent>(TInner value)
        {
            return new HyperDiagonal<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDiagonal<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperDiagonal<TInner, TComponent> operator+(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator~(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator++(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator--(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperDiagonal<TInner, TComponent> operator+(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperDiagonal<TInner, TComponent> operator+(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDiagonal<TInner, TComponent>> INumber<HyperDiagonal<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperDiagonal<TInner, TComponent>, TComponent> INumber<HyperDiagonal<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, TInner> IExtendedNumber<HyperDiagonal<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDiagonal<TInner, TComponent>, TInner, TComponent> IExtendedNumber<HyperDiagonal<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public HyperDiagonal<TInner, TComponent> Clone(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperDiagonal<TInner, TComponent> num1, HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperDiagonal<TInner, TComponent> num1, HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperDiagonal<TInner, TComponent> num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDiagonal<TInner, TComponent> num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperDiagonal<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public HyperDiagonal<TInner, TComponent> Call(UnaryOperation operation, in HyperDiagonal<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner, TComponent> Call(BinaryOperation operation, in HyperDiagonal<TInner, TComponent> num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TComponent> Call(BinaryOperation operation, in HyperDiagonal<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in HyperDiagonal<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public HyperDiagonal<TInner, TComponent> Call(BinaryOperation operation, in HyperDiagonal<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperDiagonal<TInner, TComponent> Create(in TInner num)
            {
                return new HyperDiagonal<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperDual<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner> CallReversed(BinaryOperation operation, in HyperDual<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperDual<TInner>>.Equals(HyperDual<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<HyperDual<TInner>>.CompareTo(HyperDual<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperDual<TInner>(TInner value)
        {
            return new HyperDual<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDual<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperDual<TInner> operator+(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner> operator*(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner> operator/(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner> operator^(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperDual<TInner> operator~(HyperDual<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperDual<TInner> operator++(HyperDual<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperDual<TInner> operator--(HyperDual<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperDual<TInner> operator+(HyperDual<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner> operator*(HyperDual<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner> operator/(HyperDual<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner> operator^(HyperDual<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperDual<TInner> operator+(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperDual<TInner> operator-(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperDual<TInner> operator*(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperDual<TInner> operator/(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperDual<TInner> operator^(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperDual<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDual<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDual<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDual<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDual<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDual<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperDual<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperDual<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperDual<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperDual<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperDual<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperDual<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDual<TInner>> INumber<HyperDual<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDual<TInner>, TInner> IExtendedNumber<HyperDual<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperDual<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDual<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperDual<TInner> Clone(in HyperDual<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperDual<TInner> num1, HyperDual<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperDual<TInner> num1, HyperDual<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperDual<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperDual<TInner> num)
            {
                return num.GetHashCode();
            }

            public HyperDual<TInner> Call(UnaryOperation operation, in HyperDual<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner> Call(BinaryOperation operation, in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner> Call(BinaryOperation operation, in HyperDual<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner> Call(BinaryOperation operation, in TInner num1, in HyperDual<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperDual<TInner> Create(in TInner num)
            {
                return new HyperDual<TInner>(num);
            }
		}
	}

	partial struct HyperDual<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner, TComponent> CallReversed(BinaryOperation operation, in HyperDual<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperDual<TInner, TComponent>>.Equals(HyperDual<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<HyperDual<TInner, TComponent>>.CompareTo(HyperDual<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperDual<TInner, TComponent>(TInner value)
        {
            return new HyperDual<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDual<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperDual<TInner, TComponent> operator+(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TComponent> operator*(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TComponent> operator/(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TComponent> operator^(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperDual<TInner, TComponent> operator~(HyperDual<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperDual<TInner, TComponent> operator++(HyperDual<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperDual<TInner, TComponent> operator--(HyperDual<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperDual<TInner, TComponent> operator+(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TComponent> operator*(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TComponent> operator/(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TComponent> operator^(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperDual<TInner, TComponent> operator+(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperDual<TInner, TComponent> operator-(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperDual<TInner, TComponent> operator*(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperDual<TInner, TComponent> operator/(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperDual<TInner, TComponent> operator^(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDual<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperDual<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDual<TInner, TComponent>> INumber<HyperDual<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperDual<TInner, TComponent>, TComponent> INumber<HyperDual<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDual<TInner, TComponent>, TInner> IExtendedNumber<HyperDual<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDual<TInner, TComponent>, TInner, TComponent> IExtendedNumber<HyperDual<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperDual<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDual<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public HyperDual<TInner, TComponent> Clone(in HyperDual<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperDual<TInner, TComponent> num1, HyperDual<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperDual<TInner, TComponent> num1, HyperDual<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperDual<TInner, TComponent> num1, in HyperDual<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDual<TInner, TComponent> num1, in HyperDual<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperDual<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperDual<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public HyperDual<TInner, TComponent> Call(UnaryOperation operation, in HyperDual<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in HyperDual<TInner, TComponent> num1, in HyperDual<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in HyperDual<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in HyperDual<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in HyperDual<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in HyperDual<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in HyperDual<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperDual<TInner, TComponent> Create(in TInner num)
            {
                return new HyperDual<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperSplitComplex<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner> CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperSplitComplex<TInner>>.Equals(HyperSplitComplex<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<HyperSplitComplex<TInner>>.CompareTo(HyperSplitComplex<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperSplitComplex<TInner>(TInner value)
        {
            return new HyperSplitComplex<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperSplitComplex<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperSplitComplex<TInner> operator+(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner> operator*(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner> operator/(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner> operator^(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperSplitComplex<TInner> operator~(HyperSplitComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperSplitComplex<TInner> operator++(HyperSplitComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperSplitComplex<TInner> operator--(HyperSplitComplex<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperSplitComplex<TInner> operator+(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner> operator*(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner> operator/(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner> operator^(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperSplitComplex<TInner> operator+(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperSplitComplex<TInner> operator-(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperSplitComplex<TInner> operator*(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperSplitComplex<TInner> operator/(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperSplitComplex<TInner> operator^(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperSplitComplex<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperSplitComplex<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperSplitComplex<TInner>> INumber<HyperSplitComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperSplitComplex<TInner>, TInner> IExtendedNumber<HyperSplitComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperSplitComplex<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperSplitComplex<TInner> num)
            {
                return num.IsFinite;
            }

            public HyperSplitComplex<TInner> Clone(in HyperSplitComplex<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperSplitComplex<TInner> num1, HyperSplitComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperSplitComplex<TInner> num1, HyperSplitComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperSplitComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperSplitComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public HyperSplitComplex<TInner> Call(UnaryOperation operation, in HyperSplitComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner> Call(BinaryOperation operation, in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner> Call(BinaryOperation operation, in HyperSplitComplex<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner> Call(BinaryOperation operation, in TInner num1, in HyperSplitComplex<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperSplitComplex<TInner> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner>(num);
            }
		}
	}

	partial struct HyperSplitComplex<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner, TComponent> CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperSplitComplex<TInner, TComponent>>.Equals(HyperSplitComplex<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<HyperSplitComplex<TInner, TComponent>>.CompareTo(HyperSplitComplex<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator HyperSplitComplex<TInner, TComponent>(TInner value)
        {
            return new HyperSplitComplex<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperSplitComplex<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperSplitComplex<TInner, TComponent> operator+(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator~(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator++(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator--(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperSplitComplex<TInner, TComponent> operator+(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperSplitComplex<TInner, TComponent> operator+(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperSplitComplex<TInner, TComponent>> INumber<HyperSplitComplex<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperSplitComplex<TInner, TComponent>, TComponent> INumber<HyperSplitComplex<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, TInner> IExtendedNumber<HyperSplitComplex<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperSplitComplex<TInner, TComponent>, TInner, TComponent> IExtendedNumber<HyperSplitComplex<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public HyperSplitComplex<TInner, TComponent> Clone(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperSplitComplex<TInner, TComponent> num1, HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperSplitComplex<TInner, TComponent> num1, HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperSplitComplex<TInner, TComponent> num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperSplitComplex<TInner, TComponent> num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperSplitComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public HyperSplitComplex<TInner, TComponent> Call(UnaryOperation operation, in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperSplitComplex<TInner, TComponent> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner, TComponent>(num);
            }
		}
	}

	partial struct NullableNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner> CallReversed(BinaryOperation operation, in NullableNumber<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<NullableNumber<TInner>>.Equals(NullableNumber<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<NullableNumber<TInner>>.CompareTo(NullableNumber<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator NullableNumber<TInner>(TInner value)
        {
            return new NullableNumber<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(NullableNumber<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static NullableNumber<TInner> operator+(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner> operator*(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner> operator/(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner> operator^(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static NullableNumber<TInner> operator~(NullableNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static NullableNumber<TInner> operator++(NullableNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static NullableNumber<TInner> operator--(NullableNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static NullableNumber<TInner> operator+(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner> operator*(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner> operator/(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner> operator^(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static NullableNumber<TInner> operator+(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static NullableNumber<TInner> operator-(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static NullableNumber<TInner> operator*(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static NullableNumber<TInner> operator/(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static NullableNumber<TInner> operator^(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(NullableNumber<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullableNumber<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullableNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullableNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullableNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, NullableNumber<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, NullableNumber<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, NullableNumber<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, NullableNumber<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, NullableNumber<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, NullableNumber<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullableNumber<TInner>> INumber<NullableNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<NullableNumber<TInner>, TInner> IExtendedNumber<NullableNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in NullableNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullableNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public NullableNumber<TInner> Clone(in NullableNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(NullableNumber<TInner> num1, NullableNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(NullableNumber<TInner> num1, NullableNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(NullableNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullableNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public NullableNumber<TInner> Call(UnaryOperation operation, in NullableNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner> Call(BinaryOperation operation, in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner> Call(BinaryOperation operation, in NullableNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner> Call(BinaryOperation operation, in TInner num1, in NullableNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public NullableNumber<TInner> Create(in TInner num)
            {
                return new NullableNumber<TInner>(num);
            }
		}
	}

	partial struct NullableNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in NullableNumber<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<NullableNumber<TInner, TComponent>>.Equals(NullableNumber<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<NullableNumber<TInner, TComponent>>.CompareTo(NullableNumber<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator NullableNumber<TInner, TComponent>(TInner value)
        {
            return new NullableNumber<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(NullableNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static NullableNumber<TInner, TComponent> operator+(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static NullableNumber<TInner, TComponent> operator~(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static NullableNumber<TInner, TComponent> operator++(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static NullableNumber<TInner, TComponent> operator--(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static NullableNumber<TInner, TComponent> operator+(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static NullableNumber<TInner, TComponent> operator+(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullableNumber<TInner, TComponent>> INumber<NullableNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<NullableNumber<TInner, TComponent>, TComponent> INumber<NullableNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<NullableNumber<TInner, TComponent>, TInner> IExtendedNumber<NullableNumber<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<NullableNumber<TInner, TComponent>, TInner, TComponent> IExtendedNumber<NullableNumber<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in NullableNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullableNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public NullableNumber<TInner, TComponent> Clone(in NullableNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(NullableNumber<TInner, TComponent> num1, NullableNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(NullableNumber<TInner, TComponent> num1, NullableNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in NullableNumber<TInner, TComponent> num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in NullableNumber<TInner, TComponent> num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(NullableNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullableNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public NullableNumber<TInner, TComponent> Call(UnaryOperation operation, in NullableNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in NullableNumber<TInner, TComponent> num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in NullableNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in NullableNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in NullableNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public NullableNumber<TInner, TComponent> Create(in TInner num)
            {
                return new NullableNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct NullNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullNumber CallReversed(BinaryOperation operation, in NullNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<NullNumber>.Equals(NullNumber other)
        {
            return Equals(other);
        }

        int IComparable<NullNumber>.CompareTo(NullNumber other)
        {
            return CompareTo(other);
        }

        public static NullNumber operator+(NullNumber a, NullNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullNumber operator-(NullNumber a, NullNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullNumber operator*(NullNumber a, NullNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullNumber operator/(NullNumber a, NullNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullNumber operator^(NullNumber a, NullNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static NullNumber operator-(NullNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static NullNumber operator~(NullNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static NullNumber operator++(NullNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static NullNumber operator--(NullNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(NullNumber a, NullNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullNumber a, NullNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullNumber a, NullNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullNumber a, NullNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullNumber a, NullNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullNumber a, NullNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullNumber> INumber<NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in NullNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullNumber num)
            {
                return num.IsFinite;
            }

            public NullNumber Clone(in NullNumber num)
            {
                return num.Clone();
            }

            public bool Equals(NullNumber num1, NullNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(NullNumber num1, NullNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in NullNumber num1, in NullNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in NullNumber num1, in NullNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(NullNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullNumber num)
            {
                return num.GetHashCode();
            }

            public NullNumber Call(UnaryOperation operation, in NullNumber num)
            {
                return num.Call(operation);
            }

            public NullNumber Call(BinaryOperation operation, in NullNumber num1, in NullNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct NullNumber<TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullNumber<TComponent> CallReversed(BinaryOperation operation, in NullNumber<TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<NullNumber<TComponent>>.Equals(NullNumber<TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<NullNumber<TComponent>>.CompareTo(NullNumber<TComponent> other)
        {
            return CompareTo(other);
        }

        public static NullNumber<TComponent> operator+(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullNumber<TComponent> operator-(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullNumber<TComponent> operator*(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullNumber<TComponent> operator/(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullNumber<TComponent> operator^(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static NullNumber<TComponent> operator-(NullNumber<TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static NullNumber<TComponent> operator~(NullNumber<TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static NullNumber<TComponent> operator++(NullNumber<TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static NullNumber<TComponent> operator--(NullNumber<TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullNumber<TComponent>> INumber<NullNumber<TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<NullNumber<TComponent>, TComponent> INumber<NullNumber<TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in NullNumber<TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullNumber<TComponent> num)
            {
                return num.IsFinite;
            }

            public NullNumber<TComponent> Clone(in NullNumber<TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(NullNumber<TComponent> num1, NullNumber<TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(NullNumber<TComponent> num1, NullNumber<TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in NullNumber<TComponent> num1, in NullNumber<TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in NullNumber<TComponent> num1, in NullNumber<TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(NullNumber<TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullNumber<TComponent> num)
            {
                return num.GetHashCode();
            }

            public NullNumber<TComponent> Call(UnaryOperation operation, in NullNumber<TComponent> num)
            {
                return num.Call(operation);
            }

            public NullNumber<TComponent> Call(BinaryOperation operation, in NullNumber<TComponent> num1, in NullNumber<TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public TComponent CallComponent(UnaryOperation operation, in NullNumber<TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public NullNumber<TComponent> Call(BinaryOperation operation, in NullNumber<TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public NullNumber<TComponent> Call(BinaryOperation operation, in TComponent num1, in NullNumber<TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }
		}
	}

	partial struct ProjectiveNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner> CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ProjectiveNumber<TInner>>.Equals(ProjectiveNumber<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<ProjectiveNumber<TInner>>.CompareTo(ProjectiveNumber<TInner> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator ProjectiveNumber<TInner>(TInner value)
        {
            return new ProjectiveNumber<TInner>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(ProjectiveNumber<TInner> value)
        {
            return GetAsWrapper(value);
        }

        public static ProjectiveNumber<TInner> operator+(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner> operator*(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner> operator/(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner> operator^(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ProjectiveNumber<TInner> operator~(ProjectiveNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ProjectiveNumber<TInner> operator++(ProjectiveNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ProjectiveNumber<TInner> operator--(ProjectiveNumber<TInner> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static ProjectiveNumber<TInner> operator+(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner> operator*(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner> operator/(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner> operator^(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static ProjectiveNumber<TInner> operator+(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static ProjectiveNumber<TInner> operator-(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static ProjectiveNumber<TInner> operator*(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static ProjectiveNumber<TInner> operator/(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static ProjectiveNumber<TInner> operator^(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ProjectiveNumber<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, ProjectiveNumber<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ProjectiveNumber<TInner>> INumber<ProjectiveNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<ProjectiveNumber<TInner>, TInner> IExtendedNumber<ProjectiveNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ProjectiveNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ProjectiveNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public ProjectiveNumber<TInner> Clone(in ProjectiveNumber<TInner> num)
            {
                return num.Clone();
            }

            public bool Equals(ProjectiveNumber<TInner> num1, ProjectiveNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ProjectiveNumber<TInner> num1, ProjectiveNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ProjectiveNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ProjectiveNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public ProjectiveNumber<TInner> Call(UnaryOperation operation, in ProjectiveNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner> Call(BinaryOperation operation, in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner> Call(BinaryOperation operation, in ProjectiveNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner> Call(BinaryOperation operation, in TInner num1, in ProjectiveNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public ProjectiveNumber<TInner> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner>(num);
            }
		}
	}

	partial struct ProjectiveNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner, TComponent> CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ProjectiveNumber<TInner, TComponent>>.Equals(ProjectiveNumber<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<ProjectiveNumber<TInner, TComponent>>.CompareTo(ProjectiveNumber<TInner, TComponent> other)
        {
            return CompareTo(other);
        }

        bool IEquatable<TInner>.Equals(TInner other)
        {
            return Equals(other);
        }

        int IComparable<TInner>.CompareTo(TInner other)
        {
            return CompareTo(other);
        }

        public static implicit operator ProjectiveNumber<TInner, TComponent>(TInner value)
        {
            return new ProjectiveNumber<TInner, TComponent>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(ProjectiveNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(value);
        }

        public static ProjectiveNumber<TInner, TComponent> operator+(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator~(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator++(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator--(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static ProjectiveNumber<TInner, TComponent> operator+(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static ProjectiveNumber<TInner, TComponent> operator+(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ProjectiveNumber<TInner, TComponent>> INumber<ProjectiveNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<ProjectiveNumber<TInner, TComponent>, TComponent> INumber<ProjectiveNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, TInner> IExtendedNumber<ProjectiveNumber<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, TInner, TComponent> IExtendedNumber<ProjectiveNumber<TInner, TComponent>, TInner, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public ProjectiveNumber<TInner, TComponent> Clone(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public bool Equals(ProjectiveNumber<TInner, TComponent> num1, ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ProjectiveNumber<TInner, TComponent> num1, ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ProjectiveNumber<TInner, TComponent> num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ProjectiveNumber<TInner, TComponent> num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ProjectiveNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public ProjectiveNumber<TInner, TComponent> Call(UnaryOperation operation, in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner, TComponent> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TComponent> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TComponent> Call(BinaryOperation operation, in TInner num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TComponent CallComponent(UnaryOperation operation, in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public ProjectiveNumber<TInner, TComponent> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TComponent> Call(BinaryOperation operation, in TComponent num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public ProjectiveNumber<TInner, TComponent> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct Real
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public Real CallReversed(BinaryOperation operation, in Real other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<Real>.Equals(Real other)
        {
            return Equals(other);
        }

        int IComparable<Real>.CompareTo(Real other)
        {
            return CompareTo(other);
        }

        public static Real operator+(Real a, Real b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static Real operator-(Real a, Real b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static Real operator*(Real a, Real b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static Real operator/(Real a, Real b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static Real operator^(Real a, Real b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static Real operator-(Real a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static Real operator~(Real a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static Real operator++(Real a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static Real operator--(Real a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(Real a, Real b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Real a, Real b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Real a, Real b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(Real a, Real b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(Real a, Real b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(Real a, Real b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<Real> INumber<Real>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in Real num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in Real num)
            {
                return num.IsFinite;
            }

            public Real Clone(in Real num)
            {
                return num.Clone();
            }

            public bool Equals(Real num1, Real num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(Real num1, Real num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in Real num1, in Real num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in Real num1, in Real num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(Real num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in Real num)
            {
                return num.GetHashCode();
            }

            public Real Call(UnaryOperation operation, in Real num)
            {
                return num.Call(operation);
            }

            public Real Call(BinaryOperation operation, in Real num1, in Real num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ExtendedReal
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ExtendedReal CallReversed(BinaryOperation operation, in ExtendedReal other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ExtendedReal>.Equals(ExtendedReal other)
        {
            return Equals(other);
        }

        int IComparable<ExtendedReal>.CompareTo(ExtendedReal other)
        {
            return CompareTo(other);
        }

        public static ExtendedReal operator+(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ExtendedReal operator-(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ExtendedReal operator*(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ExtendedReal operator/(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ExtendedReal operator^(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ExtendedReal operator-(ExtendedReal a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ExtendedReal operator~(ExtendedReal a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ExtendedReal operator++(ExtendedReal a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ExtendedReal operator--(ExtendedReal a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ExtendedReal a, ExtendedReal b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ExtendedReal a, ExtendedReal b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ExtendedReal a, ExtendedReal b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ExtendedReal> INumber<ExtendedReal>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ExtendedReal num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ExtendedReal num)
            {
                return num.IsFinite;
            }

            public ExtendedReal Clone(in ExtendedReal num)
            {
                return num.Clone();
            }

            public bool Equals(ExtendedReal num1, ExtendedReal num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ExtendedReal num1, ExtendedReal num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ExtendedReal num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ExtendedReal num)
            {
                return num.GetHashCode();
            }

            public ExtendedReal Call(UnaryOperation operation, in ExtendedReal num)
            {
                return num.Call(operation);
            }

            public ExtendedReal Call(BinaryOperation operation, in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

}