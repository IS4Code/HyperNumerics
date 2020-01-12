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

	partial struct PrimitiveAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public PrimitiveAbstractNumber CallReversed(BinaryOperation operation, in PrimitiveAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<PrimitiveAbstractNumber>.Equals(PrimitiveAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<PrimitiveAbstractNumber>.CompareTo(PrimitiveAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static PrimitiveAbstractNumber operator+(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static PrimitiveAbstractNumber operator-(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static PrimitiveAbstractNumber operator*(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static PrimitiveAbstractNumber operator/(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static PrimitiveAbstractNumber operator^(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static PrimitiveAbstractNumber operator-(PrimitiveAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static PrimitiveAbstractNumber operator~(PrimitiveAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static PrimitiveAbstractNumber operator++(PrimitiveAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static PrimitiveAbstractNumber operator--(PrimitiveAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<PrimitiveAbstractNumber> INumber<PrimitiveAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in PrimitiveAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in PrimitiveAbstractNumber num)
            {
                return num.IsFinite;
            }

            public PrimitiveAbstractNumber Clone(in PrimitiveAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(PrimitiveAbstractNumber num1, PrimitiveAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(PrimitiveAbstractNumber num1, PrimitiveAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in PrimitiveAbstractNumber num1, in PrimitiveAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in PrimitiveAbstractNumber num1, in PrimitiveAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(PrimitiveAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in PrimitiveAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public PrimitiveAbstractNumber Call(UnaryOperation operation, in PrimitiveAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveAbstractNumber Call(BinaryOperation operation, in PrimitiveAbstractNumber num1, in PrimitiveAbstractNumber num2)
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

	partial struct PrimitiveUnaryAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public PrimitiveUnaryAbstractNumber CallReversed(BinaryOperation operation, in PrimitiveUnaryAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<PrimitiveUnaryAbstractNumber>.Equals(PrimitiveUnaryAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<PrimitiveUnaryAbstractNumber>.CompareTo(PrimitiveUnaryAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static PrimitiveUnaryAbstractNumber operator+(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static PrimitiveUnaryAbstractNumber operator-(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static PrimitiveUnaryAbstractNumber operator*(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static PrimitiveUnaryAbstractNumber operator/(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static PrimitiveUnaryAbstractNumber operator^(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static PrimitiveUnaryAbstractNumber operator-(PrimitiveUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static PrimitiveUnaryAbstractNumber operator~(PrimitiveUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static PrimitiveUnaryAbstractNumber operator++(PrimitiveUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static PrimitiveUnaryAbstractNumber operator--(PrimitiveUnaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<PrimitiveUnaryAbstractNumber> INumber<PrimitiveUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in PrimitiveUnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in PrimitiveUnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public PrimitiveUnaryAbstractNumber Clone(in PrimitiveUnaryAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(PrimitiveUnaryAbstractNumber num1, PrimitiveUnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(PrimitiveUnaryAbstractNumber num1, PrimitiveUnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in PrimitiveUnaryAbstractNumber num1, in PrimitiveUnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in PrimitiveUnaryAbstractNumber num1, in PrimitiveUnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(PrimitiveUnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in PrimitiveUnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public PrimitiveUnaryAbstractNumber Call(UnaryOperation operation, in PrimitiveUnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveUnaryAbstractNumber Call(BinaryOperation operation, in PrimitiveUnaryAbstractNumber num1, in PrimitiveUnaryAbstractNumber num2)
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

	partial struct PrimitiveBinaryAbstractNumber
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public PrimitiveBinaryAbstractNumber CallReversed(BinaryOperation operation, in PrimitiveBinaryAbstractNumber other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<PrimitiveBinaryAbstractNumber>.Equals(PrimitiveBinaryAbstractNumber other)
        {
            return Equals(other);
        }

        int IComparable<PrimitiveBinaryAbstractNumber>.CompareTo(PrimitiveBinaryAbstractNumber other)
        {
            return CompareTo(other);
        }

        public static PrimitiveBinaryAbstractNumber operator+(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static PrimitiveBinaryAbstractNumber operator-(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static PrimitiveBinaryAbstractNumber operator*(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static PrimitiveBinaryAbstractNumber operator/(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static PrimitiveBinaryAbstractNumber operator^(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static PrimitiveBinaryAbstractNumber operator-(PrimitiveBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static PrimitiveBinaryAbstractNumber operator~(PrimitiveBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static PrimitiveBinaryAbstractNumber operator++(PrimitiveBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static PrimitiveBinaryAbstractNumber operator--(PrimitiveBinaryAbstractNumber a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<PrimitiveBinaryAbstractNumber> INumber<PrimitiveBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in PrimitiveBinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in PrimitiveBinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public PrimitiveBinaryAbstractNumber Clone(in PrimitiveBinaryAbstractNumber num)
            {
                return num.Clone();
            }

            public bool Equals(PrimitiveBinaryAbstractNumber num1, PrimitiveBinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(PrimitiveBinaryAbstractNumber num1, PrimitiveBinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in PrimitiveBinaryAbstractNumber num1, in PrimitiveBinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in PrimitiveBinaryAbstractNumber num1, in PrimitiveBinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(PrimitiveBinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in PrimitiveBinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public PrimitiveBinaryAbstractNumber Call(UnaryOperation operation, in PrimitiveBinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveBinaryAbstractNumber Call(BinaryOperation operation, in PrimitiveBinaryAbstractNumber num1, in PrimitiveBinaryAbstractNumber num2)
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

	partial struct BoxedNumber<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public BoxedNumber<TInner, TPrimitive> CallReversed(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<BoxedNumber<TInner, TPrimitive>>.Equals(BoxedNumber<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<BoxedNumber<TInner, TPrimitive>>.CompareTo(BoxedNumber<TInner, TPrimitive> other)
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

        public static implicit operator BoxedNumber<TInner, TPrimitive>(TInner value)
        {
            return new BoxedNumber<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(BoxedNumber<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static BoxedNumber<TInner, TPrimitive> operator+(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator-(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator*(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator/(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator^(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator-(BoxedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator~(BoxedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator++(BoxedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator--(BoxedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TPrimitive> a, BoxedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static BoxedNumber<TInner, TPrimitive> operator+(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator-(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator*(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator/(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator^(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static BoxedNumber<TInner, TPrimitive> operator+(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator-(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator*(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator/(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static BoxedNumber<TInner, TPrimitive> operator^(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, BoxedNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BoxedNumber<TInner, TPrimitive>> INumber<BoxedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<BoxedNumber<TInner, TPrimitive>, TPrimitive> INumber<BoxedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, TInner> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }		

        INumberOperations<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetOperations()
        {
            return HyperMath.Operations.For<TInner, TPrimitive>.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public BoxedNumber<TInner, TPrimitive> Clone(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(BoxedNumber<TInner, TPrimitive> num1, BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(BoxedNumber<TInner, TPrimitive> num1, BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in BoxedNumber<TInner, TPrimitive> num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in BoxedNumber<TInner, TPrimitive> num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(BoxedNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public BoxedNumber<TInner, TPrimitive> Call(UnaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public BoxedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in BoxedNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public BoxedNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new BoxedNumber<TInner, TPrimitive>(num);
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

	partial struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Equals(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
        {
            return Equals(other);
        }

        int IComparable<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.CompareTo(CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
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

        public static implicit operator CustomDefaultNumber<TInner, TPrimitive, TTraits>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(CustomDefaultNumber<TInner, TPrimitive, TTraits> value)
        {
            return GetAsWrapper(value);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator+(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator-(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator*(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator/(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator^(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator-(CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator~(CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator++(CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator--(CustomDefaultNumber<TInner, TPrimitive, TTraits> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator+(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator-(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator*(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator/(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator^(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator+(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator-(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator*(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator/(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static CustomDefaultNumber<TInner, TPrimitive, TTraits> operator^(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TPrimitive, TTraits> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, CustomDefaultNumber<TInner, TPrimitive, TTraits> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> INumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }		

        INumberOperations<TInner, TPrimitive> INumber<TInner, TPrimitive>.GetOperations()
        {
            return HyperMath.Operations.For<TInner, TPrimitive>.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.IsFinite;
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Clone(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.Clone();
            }

            public bool Equals(CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.GetHashCode();
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(UnaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.Call(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in TInner num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num.CallComponent(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in TPrimitive num1, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(num);
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

	partial struct GeneratedNumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner, TPrimitive> CallReversed(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<GeneratedNumber<TInner, TPrimitive>>.Equals(GeneratedNumber<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<GeneratedNumber<TInner, TPrimitive>>.CompareTo(GeneratedNumber<TInner, TPrimitive> other)
        {
            return CompareTo(other);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator+(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator-(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator*(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator/(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator^(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator-(GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator~(GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator++(GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator--(GeneratedNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner, TPrimitive> a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static GeneratedNumber<TInner, TPrimitive> operator+(GeneratedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator-(GeneratedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator*(GeneratedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator/(GeneratedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator^(GeneratedNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static GeneratedNumber<TInner, TPrimitive> operator+(TInner a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator-(TInner a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator*(TInner a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator/(TInner a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static GeneratedNumber<TInner, TPrimitive> operator^(TInner a, GeneratedNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<GeneratedNumber<TInner, TPrimitive>> INumber<GeneratedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<GeneratedNumber<TInner, TPrimitive>, TPrimitive> INumber<GeneratedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, TInner> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public GeneratedNumber<TInner, TPrimitive> Clone(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(GeneratedNumber<TInner, TPrimitive> num1, GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(GeneratedNumber<TInner, TPrimitive> num1, GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in GeneratedNumber<TInner, TPrimitive> num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in GeneratedNumber<TInner, TPrimitive> num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public GeneratedNumber<TInner, TPrimitive> Call(UnaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public GeneratedNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in GeneratedNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public GeneratedNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new GeneratedNumber<TInner, TPrimitive>(num);
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

	partial struct HyperComplex<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner, TPrimitive> CallReversed(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperComplex<TInner, TPrimitive>>.Equals(HyperComplex<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<HyperComplex<TInner, TPrimitive>>.CompareTo(HyperComplex<TInner, TPrimitive> other)
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

        public static implicit operator HyperComplex<TInner, TPrimitive>(TInner value)
        {
            return new HyperComplex<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperComplex<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperComplex<TInner, TPrimitive> operator+(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator-(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator*(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator/(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator^(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator-(HyperComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator~(HyperComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator++(HyperComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator--(HyperComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner, TPrimitive> a, HyperComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperComplex<TInner, TPrimitive> operator+(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator-(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator*(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator/(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator^(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperComplex<TInner, TPrimitive> operator+(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator-(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator*(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator/(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperComplex<TInner, TPrimitive> operator^(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperComplex<TInner, TPrimitive>> INumber<HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperComplex<TInner, TPrimitive>, TPrimitive> INumber<HyperComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, TInner> IExtendedNumber<HyperComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperComplex<TInner, TPrimitive> Clone(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperComplex<TInner, TPrimitive> num1, HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperComplex<TInner, TPrimitive> num1, HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperComplex<TInner, TPrimitive> num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperComplex<TInner, TPrimitive> num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public HyperComplex<TInner, TPrimitive> Call(UnaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperComplex<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in HyperComplex<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperComplex<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperComplex<TInner, TPrimitive>(num);
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

	partial struct HyperDiagonal<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner, TPrimitive> CallReversed(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperDiagonal<TInner, TPrimitive>>.Equals(HyperDiagonal<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<HyperDiagonal<TInner, TPrimitive>>.CompareTo(HyperDiagonal<TInner, TPrimitive> other)
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

        public static implicit operator HyperDiagonal<TInner, TPrimitive>(TInner value)
        {
            return new HyperDiagonal<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDiagonal<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator-(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator*(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator/(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator^(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator-(HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator~(HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator++(HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator--(HyperDiagonal<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner, TPrimitive> a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperDiagonal<TInner, TPrimitive> operator+(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator-(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator*(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator/(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator^(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperDiagonal<TInner, TPrimitive> operator+(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator-(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator*(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator/(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperDiagonal<TInner, TPrimitive> operator^(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperDiagonal<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDiagonal<TInner, TPrimitive>> INumber<HyperDiagonal<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperDiagonal<TInner, TPrimitive>, TPrimitive> INumber<HyperDiagonal<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, TInner> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperDiagonal<TInner, TPrimitive> Clone(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperDiagonal<TInner, TPrimitive> num1, HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperDiagonal<TInner, TPrimitive> num1, HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperDiagonal<TInner, TPrimitive> num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDiagonal<TInner, TPrimitive> num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public HyperDiagonal<TInner, TPrimitive> Call(UnaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDiagonal<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in HyperDiagonal<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperDiagonal<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperDiagonal<TInner, TPrimitive>(num);
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

	partial struct HyperDual<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner, TPrimitive> CallReversed(BinaryOperation operation, in HyperDual<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperDual<TInner, TPrimitive>>.Equals(HyperDual<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<HyperDual<TInner, TPrimitive>>.CompareTo(HyperDual<TInner, TPrimitive> other)
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

        public static implicit operator HyperDual<TInner, TPrimitive>(TInner value)
        {
            return new HyperDual<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDual<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperDual<TInner, TPrimitive> operator+(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator-(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator*(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator/(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator^(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator-(HyperDual<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperDual<TInner, TPrimitive> operator~(HyperDual<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperDual<TInner, TPrimitive> operator++(HyperDual<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperDual<TInner, TPrimitive> operator--(HyperDual<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDual<TInner, TPrimitive> a, HyperDual<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperDual<TInner, TPrimitive> operator+(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator-(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator*(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator/(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TPrimitive> operator^(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperDual<TInner, TPrimitive> operator+(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperDual<TInner, TPrimitive> operator-(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperDual<TInner, TPrimitive> operator*(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperDual<TInner, TPrimitive> operator/(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperDual<TInner, TPrimitive> operator^(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperDual<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperDual<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperDual<TInner, TPrimitive>> INumber<HyperDual<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperDual<TInner, TPrimitive>, TPrimitive> INumber<HyperDual<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, TInner> IExtendedNumber<HyperDual<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperDual<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperDual<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperDual<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperDual<TInner, TPrimitive> Clone(in HyperDual<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperDual<TInner, TPrimitive> num1, HyperDual<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperDual<TInner, TPrimitive> num1, HyperDual<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperDual<TInner, TPrimitive> num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperDual<TInner, TPrimitive> num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperDual<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperDual<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public HyperDual<TInner, TPrimitive> Call(UnaryOperation operation, in HyperDual<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in HyperDual<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperDual<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in HyperDual<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperDual<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperDual<TInner, TPrimitive>(num);
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

	partial struct HyperSplitComplex<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner, TPrimitive> CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<HyperSplitComplex<TInner, TPrimitive>>.Equals(HyperSplitComplex<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<HyperSplitComplex<TInner, TPrimitive>>.CompareTo(HyperSplitComplex<TInner, TPrimitive> other)
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

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>(TInner value)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperSplitComplex<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator+(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator-(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator*(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator/(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator^(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator-(HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator~(HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator++(HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator--(HyperSplitComplex<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner, TPrimitive> a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static HyperSplitComplex<TInner, TPrimitive> operator+(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator-(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator*(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator/(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator^(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static HyperSplitComplex<TInner, TPrimitive> operator+(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator-(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator*(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator/(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static HyperSplitComplex<TInner, TPrimitive> operator^(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, HyperSplitComplex<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<HyperSplitComplex<TInner, TPrimitive>> INumber<HyperSplitComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<HyperSplitComplex<TInner, TPrimitive>, TPrimitive> INumber<HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public HyperSplitComplex<TInner, TPrimitive> Clone(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(HyperSplitComplex<TInner, TPrimitive> num1, HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(HyperSplitComplex<TInner, TPrimitive> num1, HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in HyperSplitComplex<TInner, TPrimitive> num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in HyperSplitComplex<TInner, TPrimitive> num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(UnaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public HyperSplitComplex<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in HyperSplitComplex<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(num);
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

	partial struct NullableNumber<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner, TPrimitive> CallReversed(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<NullableNumber<TInner, TPrimitive>>.Equals(NullableNumber<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<NullableNumber<TInner, TPrimitive>>.CompareTo(NullableNumber<TInner, TPrimitive> other)
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

        public static implicit operator NullableNumber<TInner, TPrimitive>(TInner value)
        {
            return new NullableNumber<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(NullableNumber<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static NullableNumber<TInner, TPrimitive> operator+(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator-(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator*(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator/(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator^(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator-(NullableNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator~(NullableNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator++(NullableNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator--(NullableNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner, TPrimitive> a, NullableNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static NullableNumber<TInner, TPrimitive> operator+(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator-(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator*(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator/(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator^(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static NullableNumber<TInner, TPrimitive> operator+(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator-(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator*(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator/(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static NullableNumber<TInner, TPrimitive> operator^(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, NullableNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullableNumber<TInner, TPrimitive>> INumber<NullableNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<NullableNumber<TInner, TPrimitive>, TPrimitive> INumber<NullableNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, TInner> IExtendedNumber<NullableNumber<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<NullableNumber<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public NullableNumber<TInner, TPrimitive> Clone(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(NullableNumber<TInner, TPrimitive> num1, NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(NullableNumber<TInner, TPrimitive> num1, NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in NullableNumber<TInner, TPrimitive> num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in NullableNumber<TInner, TPrimitive> num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(NullableNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullableNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public NullableNumber<TInner, TPrimitive> Call(UnaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public NullableNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in NullableNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public NullableNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new NullableNumber<TInner, TPrimitive>(num);
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

	partial struct NullNumber<TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullNumber<TPrimitive> CallReversed(BinaryOperation operation, in NullNumber<TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<NullNumber<TPrimitive>>.Equals(NullNumber<TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<NullNumber<TPrimitive>>.CompareTo(NullNumber<TPrimitive> other)
        {
            return CompareTo(other);
        }

        public static NullNumber<TPrimitive> operator+(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static NullNumber<TPrimitive> operator-(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static NullNumber<TPrimitive> operator*(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static NullNumber<TPrimitive> operator/(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static NullNumber<TPrimitive> operator^(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static NullNumber<TPrimitive> operator-(NullNumber<TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static NullNumber<TPrimitive> operator~(NullNumber<TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static NullNumber<TPrimitive> operator++(NullNumber<TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static NullNumber<TPrimitive> operator--(NullNumber<TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(NullNumber<TPrimitive> a, NullNumber<TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<NullNumber<TPrimitive>> INumber<NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<NullNumber<TPrimitive>, TPrimitive> INumber<NullNumber<TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in NullNumber<TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in NullNumber<TPrimitive> num)
            {
                return num.IsFinite;
            }

            public NullNumber<TPrimitive> Clone(in NullNumber<TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(NullNumber<TPrimitive> num1, NullNumber<TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(NullNumber<TPrimitive> num1, NullNumber<TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in NullNumber<TPrimitive> num1, in NullNumber<TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in NullNumber<TPrimitive> num1, in NullNumber<TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(NullNumber<TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in NullNumber<TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public NullNumber<TPrimitive> Call(UnaryOperation operation, in NullNumber<TPrimitive> num)
            {
                return num.Call(operation);
            }

            public NullNumber<TPrimitive> Call(BinaryOperation operation, in NullNumber<TPrimitive> num1, in NullNumber<TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in NullNumber<TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public NullNumber<TPrimitive> Call(BinaryOperation operation, in NullNumber<TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public NullNumber<TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in NullNumber<TPrimitive> num2)
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

	partial struct ProjectiveNumber<TInner, TPrimitive> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner, TPrimitive> CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<ProjectiveNumber<TInner, TPrimitive>>.Equals(ProjectiveNumber<TInner, TPrimitive> other)
        {
            return Equals(other);
        }

        int IComparable<ProjectiveNumber<TInner, TPrimitive>>.CompareTo(ProjectiveNumber<TInner, TPrimitive> other)
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

        public static implicit operator ProjectiveNumber<TInner, TPrimitive>(TInner value)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(value);
        }
		
		private static TInner GetAsWrapper<T>(in T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(ProjectiveNumber<TInner, TPrimitive> value)
        {
            return GetAsWrapper(value);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator+(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator-(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator*(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator/(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator^(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Call(BinaryOperation.Power, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator-(ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Negate);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator~(ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Inverse);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator++(ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Increment);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator--(ProjectiveNumber<TInner, TPrimitive> a)
        {
            return a.Call(UnaryOperation.Decrement);
        }

        public static bool operator==(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner, TPrimitive> a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static ProjectiveNumber<TInner, TPrimitive> operator+(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator-(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator*(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator/(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator^(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Call(BinaryOperation.Power, b);
        }

        public static ProjectiveNumber<TInner, TPrimitive> operator+(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Add, a);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator-(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Subtract, a);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator*(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Multiply, a);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator/(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Divide, a);
        }
		
        public static ProjectiveNumber<TInner, TPrimitive> operator^(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CallReversed(BinaryOperation.Power, a);
        }		

        public static bool operator==(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner, TPrimitive> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, ProjectiveNumber<TInner, TPrimitive> b)
        {
            return b.CompareTo(a) >= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<ProjectiveNumber<TInner, TPrimitive>> INumber<ProjectiveNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<ProjectiveNumber<TInner, TPrimitive>, TPrimitive> INumber<ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, TInner> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, TInner, TPrimitive> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public bool IsInvertible(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.IsFinite;
            }

            public ProjectiveNumber<TInner, TPrimitive> Clone(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.Clone();
            }

            public bool Equals(ProjectiveNumber<TInner, TPrimitive> num1, ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(ProjectiveNumber<TInner, TPrimitive> num1, ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public bool Equals(in ProjectiveNumber<TInner, TPrimitive> num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(num2);
            }

            public int Compare(in ProjectiveNumber<TInner, TPrimitive> num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(num2);
            }

            public int GetHashCode(ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(UnaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public TPrimitive CallComponent(UnaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.CallComponent(operation);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num1, in TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TPrimitive num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(num);
            }
		}
	}

}