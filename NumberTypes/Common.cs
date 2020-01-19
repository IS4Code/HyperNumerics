using IS4.HyperNumerics.Operations;
using IS4.HyperNumerics.Utils;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct AbstractNumber
	{
		public static readonly AbstractNumber Zero = Create(StandardNumber.Zero);
		public static readonly AbstractNumber One = Create(StandardNumber.One);
		public static readonly AbstractNumber Two = Create(StandardNumber.Two);
		public static readonly AbstractNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly AbstractNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static AbstractNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public AbstractNumber CallReversed(StandardBinaryOperation operation, in AbstractNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static AbstractNumber operator-(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static AbstractNumber operator*(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static AbstractNumber operator/(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static AbstractNumber operator^(AbstractNumber a, AbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static AbstractNumber operator-(AbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static AbstractNumber operator~(AbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static AbstractNumber operator++(AbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static AbstractNumber operator--(AbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static AbstractNumber operator+(AbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static AbstractNumber operator-(AbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static AbstractNumber operator*(AbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static AbstractNumber operator/(AbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static AbstractNumber operator^(AbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static AbstractNumber operator+(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static AbstractNumber operator-(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static AbstractNumber operator*(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static AbstractNumber operator/(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static AbstractNumber operator^(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(AbstractNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(AbstractNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(AbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(AbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(AbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(AbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, AbstractNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, AbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in AbstractNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in AbstractNumber num)
            {
                return num.IsFinite;
            }

            public virtual AbstractNumber Clone(in AbstractNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(AbstractNumber num1, AbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(AbstractNumber num1, AbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(AbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in AbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual AbstractNumber Call(StandardUnaryOperation operation, in AbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual AbstractNumber Call(StandardBinaryOperation operation, in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ComponentAbstractNumber
	{
		public static readonly ComponentAbstractNumber Zero = Create(StandardNumber.Zero);
		public static readonly ComponentAbstractNumber One = Create(StandardNumber.One);
		public static readonly ComponentAbstractNumber Two = Create(StandardNumber.Two);
		public static readonly ComponentAbstractNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly ComponentAbstractNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static ComponentAbstractNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ComponentAbstractNumber CallReversed(StandardBinaryOperation operation, in ComponentAbstractNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ComponentAbstractNumber operator-(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ComponentAbstractNumber operator*(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ComponentAbstractNumber operator/(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ComponentAbstractNumber operator^(ComponentAbstractNumber a, ComponentAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static ComponentAbstractNumber operator-(ComponentAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static ComponentAbstractNumber operator~(ComponentAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static ComponentAbstractNumber operator++(ComponentAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static ComponentAbstractNumber operator--(ComponentAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static ComponentAbstractNumber operator+(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static ComponentAbstractNumber operator-(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static ComponentAbstractNumber operator*(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static ComponentAbstractNumber operator/(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static ComponentAbstractNumber operator^(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static ComponentAbstractNumber operator+(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static ComponentAbstractNumber operator-(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ComponentAbstractNumber operator*(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ComponentAbstractNumber operator/(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ComponentAbstractNumber operator^(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(ComponentAbstractNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(ComponentAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, ComponentAbstractNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, ComponentAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in ComponentAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ComponentAbstractNumber num)
            {
                return num.IsFinite;
            }

            public virtual ComponentAbstractNumber Clone(in ComponentAbstractNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(ComponentAbstractNumber num1, ComponentAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(ComponentAbstractNumber num1, ComponentAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in ComponentAbstractNumber num1, in ComponentAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in ComponentAbstractNumber num1, in ComponentAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(ComponentAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ComponentAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual ComponentAbstractNumber Call(StandardUnaryOperation operation, in ComponentAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual ComponentAbstractNumber Call(StandardBinaryOperation operation, in ComponentAbstractNumber num1, in ComponentAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct UnaryAbstractNumber
	{
		public static readonly UnaryAbstractNumber Zero = Create(StandardNumber.Zero);
		public static readonly UnaryAbstractNumber One = Create(StandardNumber.One);
		public static readonly UnaryAbstractNumber Two = Create(StandardNumber.Two);
		public static readonly UnaryAbstractNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly UnaryAbstractNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static UnaryAbstractNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public UnaryAbstractNumber CallReversed(StandardBinaryOperation operation, in UnaryAbstractNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static UnaryAbstractNumber operator*(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static UnaryAbstractNumber operator/(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static UnaryAbstractNumber operator^(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static UnaryAbstractNumber operator~(UnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static UnaryAbstractNumber operator++(UnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static UnaryAbstractNumber operator--(UnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static UnaryAbstractNumber operator+(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static UnaryAbstractNumber operator*(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static UnaryAbstractNumber operator/(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static UnaryAbstractNumber operator^(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static UnaryAbstractNumber operator+(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static UnaryAbstractNumber operator-(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static UnaryAbstractNumber operator*(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static UnaryAbstractNumber operator/(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static UnaryAbstractNumber operator^(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(UnaryAbstractNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(UnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, UnaryAbstractNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, UnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in UnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in UnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public virtual UnaryAbstractNumber Clone(in UnaryAbstractNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(UnaryAbstractNumber num1, UnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(UnaryAbstractNumber num1, UnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(UnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in UnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual UnaryAbstractNumber Call(StandardUnaryOperation operation, in UnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual UnaryAbstractNumber Call(StandardBinaryOperation operation, in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ComponentUnaryAbstractNumber
	{
		public static readonly ComponentUnaryAbstractNumber Zero = Create(StandardNumber.Zero);
		public static readonly ComponentUnaryAbstractNumber One = Create(StandardNumber.One);
		public static readonly ComponentUnaryAbstractNumber Two = Create(StandardNumber.Two);
		public static readonly ComponentUnaryAbstractNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly ComponentUnaryAbstractNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static ComponentUnaryAbstractNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ComponentUnaryAbstractNumber CallReversed(StandardBinaryOperation operation, in ComponentUnaryAbstractNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ComponentUnaryAbstractNumber operator-(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ComponentUnaryAbstractNumber operator*(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ComponentUnaryAbstractNumber operator/(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ComponentUnaryAbstractNumber operator^(ComponentUnaryAbstractNumber a, ComponentUnaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static ComponentUnaryAbstractNumber operator-(ComponentUnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static ComponentUnaryAbstractNumber operator~(ComponentUnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static ComponentUnaryAbstractNumber operator++(ComponentUnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static ComponentUnaryAbstractNumber operator--(ComponentUnaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static ComponentUnaryAbstractNumber operator+(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static ComponentUnaryAbstractNumber operator-(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static ComponentUnaryAbstractNumber operator*(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static ComponentUnaryAbstractNumber operator/(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static ComponentUnaryAbstractNumber operator^(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static ComponentUnaryAbstractNumber operator+(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static ComponentUnaryAbstractNumber operator-(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ComponentUnaryAbstractNumber operator*(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ComponentUnaryAbstractNumber operator/(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ComponentUnaryAbstractNumber operator^(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(ComponentUnaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, ComponentUnaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in ComponentUnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ComponentUnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public virtual ComponentUnaryAbstractNumber Clone(in ComponentUnaryAbstractNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(ComponentUnaryAbstractNumber num1, ComponentUnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(ComponentUnaryAbstractNumber num1, ComponentUnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in ComponentUnaryAbstractNumber num1, in ComponentUnaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in ComponentUnaryAbstractNumber num1, in ComponentUnaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(ComponentUnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ComponentUnaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual ComponentUnaryAbstractNumber Call(StandardUnaryOperation operation, in ComponentUnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual ComponentUnaryAbstractNumber Call(StandardBinaryOperation operation, in ComponentUnaryAbstractNumber num1, in ComponentUnaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct BinaryAbstractNumber
	{
		public static readonly BinaryAbstractNumber Zero = Create(StandardNumber.Zero);
		public static readonly BinaryAbstractNumber One = Create(StandardNumber.One);
		public static readonly BinaryAbstractNumber Two = Create(StandardNumber.Two);
		public static readonly BinaryAbstractNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly BinaryAbstractNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static BinaryAbstractNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public BinaryAbstractNumber CallReversed(StandardBinaryOperation operation, in BinaryAbstractNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BinaryAbstractNumber operator*(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BinaryAbstractNumber operator/(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BinaryAbstractNumber operator^(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static BinaryAbstractNumber operator~(BinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static BinaryAbstractNumber operator++(BinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static BinaryAbstractNumber operator--(BinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static BinaryAbstractNumber operator+(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static BinaryAbstractNumber operator*(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static BinaryAbstractNumber operator/(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static BinaryAbstractNumber operator^(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static BinaryAbstractNumber operator+(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static BinaryAbstractNumber operator-(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BinaryAbstractNumber operator*(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BinaryAbstractNumber operator/(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BinaryAbstractNumber operator^(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(BinaryAbstractNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(BinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, BinaryAbstractNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, BinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in BinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in BinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public virtual BinaryAbstractNumber Clone(in BinaryAbstractNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(BinaryAbstractNumber num1, BinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(BinaryAbstractNumber num1, BinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(BinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in BinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual BinaryAbstractNumber Call(StandardUnaryOperation operation, in BinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual BinaryAbstractNumber Call(StandardBinaryOperation operation, in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ComponentBinaryAbstractNumber
	{
		public static readonly ComponentBinaryAbstractNumber Zero = Create(StandardNumber.Zero);
		public static readonly ComponentBinaryAbstractNumber One = Create(StandardNumber.One);
		public static readonly ComponentBinaryAbstractNumber Two = Create(StandardNumber.Two);
		public static readonly ComponentBinaryAbstractNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly ComponentBinaryAbstractNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static ComponentBinaryAbstractNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ComponentBinaryAbstractNumber CallReversed(StandardBinaryOperation operation, in ComponentBinaryAbstractNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ComponentBinaryAbstractNumber operator-(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ComponentBinaryAbstractNumber operator*(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ComponentBinaryAbstractNumber operator/(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ComponentBinaryAbstractNumber operator^(ComponentBinaryAbstractNumber a, ComponentBinaryAbstractNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static ComponentBinaryAbstractNumber operator-(ComponentBinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static ComponentBinaryAbstractNumber operator~(ComponentBinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static ComponentBinaryAbstractNumber operator++(ComponentBinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static ComponentBinaryAbstractNumber operator--(ComponentBinaryAbstractNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static ComponentBinaryAbstractNumber operator+(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static ComponentBinaryAbstractNumber operator-(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static ComponentBinaryAbstractNumber operator*(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static ComponentBinaryAbstractNumber operator/(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static ComponentBinaryAbstractNumber operator^(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static ComponentBinaryAbstractNumber operator+(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static ComponentBinaryAbstractNumber operator-(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ComponentBinaryAbstractNumber operator*(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ComponentBinaryAbstractNumber operator/(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ComponentBinaryAbstractNumber operator^(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(ComponentBinaryAbstractNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, ComponentBinaryAbstractNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in ComponentBinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ComponentBinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public virtual ComponentBinaryAbstractNumber Clone(in ComponentBinaryAbstractNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(ComponentBinaryAbstractNumber num1, ComponentBinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(ComponentBinaryAbstractNumber num1, ComponentBinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in ComponentBinaryAbstractNumber num1, in ComponentBinaryAbstractNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in ComponentBinaryAbstractNumber num1, in ComponentBinaryAbstractNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(ComponentBinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ComponentBinaryAbstractNumber num)
            {
                return num.GetHashCode();
            }

            public virtual ComponentBinaryAbstractNumber Call(StandardUnaryOperation operation, in ComponentBinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public virtual ComponentBinaryAbstractNumber Call(StandardBinaryOperation operation, in ComponentBinaryAbstractNumber num1, in ComponentBinaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct BoxedNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly BoxedNumber<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly BoxedNumber<TInner> One = Create(StandardNumber.One);
		public static readonly BoxedNumber<TInner> Two = Create(StandardNumber.Two);
		public static readonly BoxedNumber<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly BoxedNumber<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static BoxedNumber<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public BoxedNumber<TInner> CallReversed(StandardBinaryOperation operation, in BoxedNumber<TInner> other)
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

        public static implicit operator BoxedNumber<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(BoxedNumber<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static BoxedNumber<TInner> operator+(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner> operator*(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner> operator/(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner> operator^(BoxedNumber<TInner> a, BoxedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static BoxedNumber<TInner> operator~(BoxedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static BoxedNumber<TInner> operator++(BoxedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static BoxedNumber<TInner> operator--(BoxedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner> operator*(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner> operator/(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner> operator^(BoxedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static BoxedNumber<TInner> operator+(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static BoxedNumber<TInner> operator-(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static BoxedNumber<TInner> operator*(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static BoxedNumber<TInner> operator/(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static BoxedNumber<TInner> operator^(TInner a, BoxedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static BoxedNumber<TInner> operator+(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner> operator-(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner> operator*(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner> operator/(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner> operator^(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static BoxedNumber<TInner> operator+(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner> operator-(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner> operator*(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner> operator/(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner> operator^(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(BoxedNumber<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, BoxedNumber<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, BoxedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<BoxedNumber<TInner>, TInner> INumber<BoxedNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in BoxedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in BoxedNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual BoxedNumber<TInner> Clone(in BoxedNumber<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(BoxedNumber<TInner> num1, BoxedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(BoxedNumber<TInner> num1, BoxedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(BoxedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in BoxedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual BoxedNumber<TInner> Call(StandardUnaryOperation operation, in BoxedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual BoxedNumber<TInner> Call(StandardBinaryOperation operation, in BoxedNumber<TInner> num1, in BoxedNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual BoxedNumber<TInner> Call(StandardBinaryOperation operation, in BoxedNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual BoxedNumber<TInner> Call(StandardBinaryOperation operation, in TInner num1, in BoxedNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<BoxedNumber<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in BoxedNumber<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual BoxedNumber<TInner> Create(in TInner num)
            {
                return new BoxedNumber<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct BoxedNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly BoxedNumber<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly BoxedNumber<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly BoxedNumber<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly BoxedNumber<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly BoxedNumber<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static BoxedNumber<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public BoxedNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in BoxedNumber<TInner, TComponent> other)
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

        public static implicit operator BoxedNumber<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(BoxedNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static BoxedNumber<TInner, TComponent> operator+(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(BoxedNumber<TInner, TComponent> a, BoxedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static BoxedNumber<TInner, TComponent> operator~(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static BoxedNumber<TInner, TComponent> operator++(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static BoxedNumber<TInner, TComponent> operator--(BoxedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(BoxedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static BoxedNumber<TInner, TComponent> operator+(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(TInner a, BoxedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static BoxedNumber<TInner, TComponent> operator+(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static BoxedNumber<TInner, TComponent> operator+(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator-(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator*(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator/(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static BoxedNumber<TInner, TComponent> operator^(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(BoxedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, BoxedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in BoxedNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in BoxedNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual BoxedNumber<TInner, TComponent> Clone(in BoxedNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(BoxedNumber<TInner, TComponent> num1, BoxedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(BoxedNumber<TInner, TComponent> num1, BoxedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in BoxedNumber<TInner, TComponent> num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in BoxedNumber<TInner, TComponent> num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(BoxedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in BoxedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual BoxedNumber<TInner, TComponent> Call(StandardUnaryOperation operation, in BoxedNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual BoxedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in BoxedNumber<TInner, TComponent> num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual BoxedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in BoxedNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual BoxedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in BoxedNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual BoxedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in BoxedNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual BoxedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in BoxedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual BoxedNumber<TInner, TComponent> Create(in TInner num)
            {
                return new BoxedNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct CustomDefaultNumber<TInner, TProvider> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner> where TProvider : struct, CustomDefaultNumber<TInner, TProvider>.IDefaultValueProvider
	{
		public static readonly CustomDefaultNumber<TInner, TProvider> Zero = Create(StandardNumber.Zero);
		public static readonly CustomDefaultNumber<TInner, TProvider> One = Create(StandardNumber.One);
		public static readonly CustomDefaultNumber<TInner, TProvider> Two = Create(StandardNumber.Two);
		public static readonly CustomDefaultNumber<TInner, TProvider> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly CustomDefaultNumber<TInner, TProvider> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static CustomDefaultNumber<TInner, TProvider> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TProvider> CallReversed(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TProvider> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<CustomDefaultNumber<TInner, TProvider>>.Equals(CustomDefaultNumber<TInner, TProvider> other)
        {
            return Equals(other);
        }

        int IComparable<CustomDefaultNumber<TInner, TProvider>>.CompareTo(CustomDefaultNumber<TInner, TProvider> other)
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

        public static implicit operator CustomDefaultNumber<TInner, TProvider>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TProvider>(value);
        }

        public static implicit operator CustomDefaultNumber<TInner, TProvider>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(CustomDefaultNumber<TInner, TProvider> value)
        {
            return GetAsWrapper(ref value);
        }

        public static CustomDefaultNumber<TInner, TProvider> operator+(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator-(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator*(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator/(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator^(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator-(CustomDefaultNumber<TInner, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator~(CustomDefaultNumber<TInner, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator++(CustomDefaultNumber<TInner, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator--(CustomDefaultNumber<TInner, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TProvider> a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static CustomDefaultNumber<TInner, TProvider> operator+(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator-(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator*(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator/(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator^(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static CustomDefaultNumber<TInner, TProvider> operator+(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator-(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator*(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator/(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator^(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }		

        public static bool operator==(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TProvider> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return b.CompareTo(a) >= 0;
        }

		public static CustomDefaultNumber<TInner, TProvider> operator+(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator-(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator*(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator/(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator^(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static CustomDefaultNumber<TInner, TProvider> operator+(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator-(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator*(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator/(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TProvider> operator^(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, CustomDefaultNumber<TInner, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TProvider>> INumber<CustomDefaultNumber<TInner, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TProvider>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TProvider>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

		INumberOperations<CustomDefaultNumber<TInner, TProvider>, TInner> INumber<CustomDefaultNumber<TInner, TProvider>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.IsFinite;
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Clone(in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(CustomDefaultNumber<TInner, TProvider> num1, CustomDefaultNumber<TInner, TProvider> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(CustomDefaultNumber<TInner, TProvider> num1, CustomDefaultNumber<TInner, TProvider> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in CustomDefaultNumber<TInner, TProvider> num1, in CustomDefaultNumber<TInner, TProvider> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in CustomDefaultNumber<TInner, TProvider> num1, in CustomDefaultNumber<TInner, TProvider> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.GetHashCode();
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Call(StandardUnaryOperation operation, in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.Call(operation);
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Call(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TProvider> num1, in CustomDefaultNumber<TInner, TProvider> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Call(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TProvider> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Call(StandardBinaryOperation operation, in TInner num1, in CustomDefaultNumber<TInner, TProvider> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<CustomDefaultNumber<TInner, TProvider>, TInner>.CallComponent(StandardUnaryOperation operation, in CustomDefaultNumber<TInner, TProvider> num)
            {
                return num.CallComponent(operation);
            }

            public virtual CustomDefaultNumber<TInner, TProvider> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TProvider>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct CustomDefaultNumber<TInner, TComponent, TProvider> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TProvider : struct, CustomDefaultNumber<TInner, TProvider>.IDefaultValueProvider
	{
		public static readonly CustomDefaultNumber<TInner, TComponent, TProvider> Zero = Create(StandardNumber.Zero);
		public static readonly CustomDefaultNumber<TInner, TComponent, TProvider> One = Create(StandardNumber.One);
		public static readonly CustomDefaultNumber<TInner, TComponent, TProvider> Two = Create(StandardNumber.Two);
		public static readonly CustomDefaultNumber<TInner, TComponent, TProvider> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly CustomDefaultNumber<TInner, TComponent, TProvider> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomDefaultNumber<TInner, TComponent, TProvider> CallReversed(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<CustomDefaultNumber<TInner, TComponent, TProvider>>.Equals(CustomDefaultNumber<TInner, TComponent, TProvider> other)
        {
            return Equals(other);
        }

        int IComparable<CustomDefaultNumber<TInner, TComponent, TProvider>>.CompareTo(CustomDefaultNumber<TInner, TComponent, TProvider> other)
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

        public static implicit operator CustomDefaultNumber<TInner, TComponent, TProvider>(TInner value)
        {
            return new CustomDefaultNumber<TInner, TComponent, TProvider>(value);
        }

        public static implicit operator CustomDefaultNumber<TInner, TComponent, TProvider>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(CustomDefaultNumber<TInner, TComponent, TProvider> value)
        {
            return GetAsWrapper(ref value);
        }

        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator+(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator-(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator*(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator/(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator^(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator-(CustomDefaultNumber<TInner, TComponent, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator~(CustomDefaultNumber<TInner, TComponent, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator++(CustomDefaultNumber<TInner, TComponent, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator--(CustomDefaultNumber<TInner, TComponent, TProvider> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TComponent, TProvider> a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator+(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator-(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator*(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator/(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator^(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator+(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator-(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator*(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator/(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator^(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }		

        public static bool operator==(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TComponent, TProvider> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return b.CompareTo(a) >= 0;
        }

		public static CustomDefaultNumber<TInner, TComponent, TProvider> operator+(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator-(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator*(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator/(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator^(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator+(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator-(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator*(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator/(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static CustomDefaultNumber<TInner, TComponent, TProvider> operator^(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(CustomDefaultNumber<TInner, TComponent, TProvider> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, CustomDefaultNumber<TInner, TComponent, TProvider> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>> INumber<CustomDefaultNumber<TInner, TComponent, TProvider>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent> INumber<CustomDefaultNumber<TInner, TComponent, TProvider>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, TInner> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TProvider>, TInner, TComponent> IExtendedNumber<CustomDefaultNumber<TInner, TComponent, TProvider>, TInner, TComponent>.GetOperations()
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
			
            public virtual bool IsInvertible(in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.IsFinite;
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Clone(in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(CustomDefaultNumber<TInner, TComponent, TProvider> num1, CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(CustomDefaultNumber<TInner, TComponent, TProvider> num1, CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in CustomDefaultNumber<TInner, TComponent, TProvider> num1, in CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in CustomDefaultNumber<TInner, TComponent, TProvider> num1, in CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.GetHashCode();
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Call(StandardUnaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.Call(operation);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Call(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num1, in CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Call(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Call(StandardBinaryOperation operation, in TInner num1, in CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num)
            {
                return num.CallComponent(operation);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Call(StandardBinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TProvider> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Call(StandardBinaryOperation operation, in TComponent num1, in CustomDefaultNumber<TInner, TComponent, TProvider> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual CustomDefaultNumber<TInner, TComponent, TProvider> Create(in TInner num)
            {
                return new CustomDefaultNumber<TInner, TComponent, TProvider>(num);
            }
		}
	}

	partial struct GeneratedNumber<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly GeneratedNumber<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly GeneratedNumber<TInner> One = Create(StandardNumber.One);
		public static readonly GeneratedNumber<TInner> Two = Create(StandardNumber.Two);
		public static readonly GeneratedNumber<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly GeneratedNumber<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static GeneratedNumber<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner> CallReversed(StandardBinaryOperation operation, in GeneratedNumber<TInner> other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner> operator*(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner> operator/(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner> operator^(GeneratedNumber<TInner> a, GeneratedNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static GeneratedNumber<TInner> operator~(GeneratedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static GeneratedNumber<TInner> operator++(GeneratedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static GeneratedNumber<TInner> operator--(GeneratedNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner> operator*(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner> operator/(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner> operator^(GeneratedNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static GeneratedNumber<TInner> operator+(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static GeneratedNumber<TInner> operator-(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static GeneratedNumber<TInner> operator*(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static GeneratedNumber<TInner> operator/(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static GeneratedNumber<TInner> operator^(TInner a, GeneratedNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }

		public static GeneratedNumber<TInner> operator+(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner> operator-(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner> operator*(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner> operator/(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner> operator^(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static GeneratedNumber<TInner> operator+(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner> operator-(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner> operator*(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner> operator/(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner> operator^(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, GeneratedNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<GeneratedNumber<TInner>, TInner> INumber<GeneratedNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in GeneratedNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in GeneratedNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual GeneratedNumber<TInner> Clone(in GeneratedNumber<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(GeneratedNumber<TInner> num1, GeneratedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(GeneratedNumber<TInner> num1, GeneratedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(GeneratedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in GeneratedNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual GeneratedNumber<TInner> Call(StandardUnaryOperation operation, in GeneratedNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual GeneratedNumber<TInner> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner> num1, in GeneratedNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual GeneratedNumber<TInner> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual GeneratedNumber<TInner> Call(StandardBinaryOperation operation, in TInner num1, in GeneratedNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<GeneratedNumber<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in GeneratedNumber<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual GeneratedNumber<TInner> Create(in TInner num)
            {
                return new GeneratedNumber<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct GeneratedNumber<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly GeneratedNumber<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly GeneratedNumber<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly GeneratedNumber<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly GeneratedNumber<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly GeneratedNumber<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static GeneratedNumber<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public GeneratedNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in GeneratedNumber<TInner, TComponent> other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(GeneratedNumber<TInner, TComponent> a, GeneratedNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator~(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator++(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator--(GeneratedNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(GeneratedNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static GeneratedNumber<TInner, TComponent> operator+(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(TInner a, GeneratedNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }

		public static GeneratedNumber<TInner, TComponent> operator+(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static GeneratedNumber<TInner, TComponent> operator+(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator-(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator*(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator/(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static GeneratedNumber<TInner, TComponent> operator^(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(GeneratedNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, GeneratedNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual GeneratedNumber<TInner, TComponent> Clone(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(GeneratedNumber<TInner, TComponent> num1, GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(GeneratedNumber<TInner, TComponent> num1, GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in GeneratedNumber<TInner, TComponent> num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in GeneratedNumber<TInner, TComponent> num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(GeneratedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in GeneratedNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual GeneratedNumber<TInner, TComponent> Call(StandardUnaryOperation operation, in GeneratedNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner, TComponent> num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in GeneratedNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in GeneratedNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual GeneratedNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in GeneratedNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual GeneratedNumber<TInner, TComponent> Create(in TInner num)
            {
                return new GeneratedNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperComplex<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly HyperComplex<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly HyperComplex<TInner> One = Create(StandardNumber.One);
		public static readonly HyperComplex<TInner> Two = Create(StandardNumber.Two);
		public static readonly HyperComplex<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperComplex<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperComplex<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner> CallReversed(StandardBinaryOperation operation, in HyperComplex<TInner> other)
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

        public static implicit operator HyperComplex<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperComplex<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperComplex<TInner> operator+(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner> operator*(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner> operator/(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner> operator^(HyperComplex<TInner> a, HyperComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperComplex<TInner> operator~(HyperComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperComplex<TInner> operator++(HyperComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperComplex<TInner> operator--(HyperComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner> operator*(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner> operator/(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner> operator^(HyperComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperComplex<TInner> operator+(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperComplex<TInner> operator-(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperComplex<TInner> operator*(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperComplex<TInner> operator/(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperComplex<TInner> operator^(TInner a, HyperComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperComplex<TInner> operator+(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner> operator-(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner> operator*(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner> operator/(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner> operator^(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperComplex<TInner> operator+(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner> operator-(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner> operator*(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner> operator/(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner> operator^(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperComplex<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperComplex<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<HyperComplex<TInner>, TInner> INumber<HyperComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in HyperComplex<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperComplex<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual HyperComplex<TInner> Clone(in HyperComplex<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperComplex<TInner> num1, HyperComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperComplex<TInner> num1, HyperComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperComplex<TInner> Call(StandardUnaryOperation operation, in HyperComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperComplex<TInner> Call(StandardBinaryOperation operation, in HyperComplex<TInner> num1, in HyperComplex<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperComplex<TInner> Call(StandardBinaryOperation operation, in HyperComplex<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperComplex<TInner> Call(StandardBinaryOperation operation, in TInner num1, in HyperComplex<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<HyperComplex<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in HyperComplex<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperComplex<TInner> Create(in TInner num)
            {
                return new HyperComplex<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct HyperComplex<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly HyperComplex<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly HyperComplex<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly HyperComplex<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly HyperComplex<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperComplex<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperComplex<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperComplex<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in HyperComplex<TInner, TComponent> other)
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

        public static implicit operator HyperComplex<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperComplex<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperComplex<TInner, TComponent> operator+(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(HyperComplex<TInner, TComponent> a, HyperComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperComplex<TInner, TComponent> operator~(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperComplex<TInner, TComponent> operator++(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperComplex<TInner, TComponent> operator--(HyperComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(HyperComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperComplex<TInner, TComponent> operator+(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(TInner a, HyperComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperComplex<TInner, TComponent> operator+(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner, TComponent> operator-(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner, TComponent> operator*(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner, TComponent> operator/(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperComplex<TInner, TComponent> operator^(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperComplex<TInner, TComponent> operator+(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator-(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator*(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator/(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperComplex<TInner, TComponent> operator^(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in HyperComplex<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperComplex<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual HyperComplex<TInner, TComponent> Clone(in HyperComplex<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperComplex<TInner, TComponent> num1, HyperComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperComplex<TInner, TComponent> num1, HyperComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperComplex<TInner, TComponent> num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperComplex<TInner, TComponent> num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperComplex<TInner, TComponent> Call(StandardUnaryOperation operation, in HyperComplex<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperComplex<TInner, TComponent> num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperComplex<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in HyperComplex<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperComplex<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in HyperComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual HyperComplex<TInner, TComponent> Create(in TInner num)
            {
                return new HyperComplex<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperDiagonal<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly HyperDiagonal<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly HyperDiagonal<TInner> One = Create(StandardNumber.One);
		public static readonly HyperDiagonal<TInner> Two = Create(StandardNumber.Two);
		public static readonly HyperDiagonal<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperDiagonal<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperDiagonal<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner> CallReversed(StandardBinaryOperation operation, in HyperDiagonal<TInner> other)
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

        public static implicit operator HyperDiagonal<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDiagonal<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperDiagonal<TInner> operator+(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner> operator*(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner> operator/(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner> operator^(HyperDiagonal<TInner> a, HyperDiagonal<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperDiagonal<TInner> operator~(HyperDiagonal<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperDiagonal<TInner> operator++(HyperDiagonal<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperDiagonal<TInner> operator--(HyperDiagonal<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner> operator*(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner> operator/(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner> operator^(HyperDiagonal<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperDiagonal<TInner> operator+(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperDiagonal<TInner> operator-(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperDiagonal<TInner> operator*(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperDiagonal<TInner> operator/(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperDiagonal<TInner> operator^(TInner a, HyperDiagonal<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperDiagonal<TInner> operator+(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner> operator-(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner> operator*(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner> operator/(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner> operator^(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperDiagonal<TInner> operator+(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner> operator-(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner> operator*(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner> operator/(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner> operator^(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperDiagonal<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<HyperDiagonal<TInner>, TInner> INumber<HyperDiagonal<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in HyperDiagonal<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperDiagonal<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual HyperDiagonal<TInner> Clone(in HyperDiagonal<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperDiagonal<TInner> num1, HyperDiagonal<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperDiagonal<TInner> num1, HyperDiagonal<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperDiagonal<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperDiagonal<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperDiagonal<TInner> Call(StandardUnaryOperation operation, in HyperDiagonal<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDiagonal<TInner> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner> num1, in HyperDiagonal<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDiagonal<TInner> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDiagonal<TInner> Call(StandardBinaryOperation operation, in TInner num1, in HyperDiagonal<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<HyperDiagonal<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in HyperDiagonal<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperDiagonal<TInner> Create(in TInner num)
            {
                return new HyperDiagonal<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct HyperDiagonal<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly HyperDiagonal<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly HyperDiagonal<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly HyperDiagonal<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly HyperDiagonal<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperDiagonal<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperDiagonal<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDiagonal<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in HyperDiagonal<TInner, TComponent> other)
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

        public static implicit operator HyperDiagonal<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDiagonal<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperDiagonal<TInner, TComponent> operator+(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(HyperDiagonal<TInner, TComponent> a, HyperDiagonal<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator~(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator++(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator--(HyperDiagonal<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(HyperDiagonal<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperDiagonal<TInner, TComponent> operator+(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(TInner a, HyperDiagonal<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperDiagonal<TInner, TComponent> operator+(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperDiagonal<TInner, TComponent> operator+(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator-(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator*(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator/(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDiagonal<TInner, TComponent> operator^(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperDiagonal<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperDiagonal<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual HyperDiagonal<TInner, TComponent> Clone(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperDiagonal<TInner, TComponent> num1, HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperDiagonal<TInner, TComponent> num1, HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperDiagonal<TInner, TComponent> num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperDiagonal<TInner, TComponent> num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperDiagonal<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperDiagonal<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperDiagonal<TInner, TComponent> Call(StandardUnaryOperation operation, in HyperDiagonal<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner, TComponent> num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in HyperDiagonal<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in HyperDiagonal<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual HyperDiagonal<TInner, TComponent> Create(in TInner num)
            {
                return new HyperDiagonal<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperDual<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly HyperDual<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly HyperDual<TInner> One = Create(StandardNumber.One);
		public static readonly HyperDual<TInner> Two = Create(StandardNumber.Two);
		public static readonly HyperDual<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperDual<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperDual<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner> CallReversed(StandardBinaryOperation operation, in HyperDual<TInner> other)
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

        public static implicit operator HyperDual<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDual<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperDual<TInner> operator+(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner> operator*(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner> operator/(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner> operator^(HyperDual<TInner> a, HyperDual<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperDual<TInner> operator~(HyperDual<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperDual<TInner> operator++(HyperDual<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperDual<TInner> operator--(HyperDual<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner> operator*(HyperDual<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner> operator/(HyperDual<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner> operator^(HyperDual<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperDual<TInner> operator+(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperDual<TInner> operator-(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperDual<TInner> operator*(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperDual<TInner> operator/(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperDual<TInner> operator^(TInner a, HyperDual<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperDual<TInner> operator+(HyperDual<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner> operator-(HyperDual<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner> operator*(HyperDual<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner> operator/(HyperDual<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner> operator^(HyperDual<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperDual<TInner> operator+(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner> operator-(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner> operator*(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner> operator/(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner> operator^(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperDual<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperDual<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperDual<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperDual<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperDual<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperDual<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperDual<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperDual<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<HyperDual<TInner>, TInner> INumber<HyperDual<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in HyperDual<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperDual<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual HyperDual<TInner> Clone(in HyperDual<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperDual<TInner> num1, HyperDual<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperDual<TInner> num1, HyperDual<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperDual<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperDual<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperDual<TInner> Call(StandardUnaryOperation operation, in HyperDual<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDual<TInner> Call(StandardBinaryOperation operation, in HyperDual<TInner> num1, in HyperDual<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDual<TInner> Call(StandardBinaryOperation operation, in HyperDual<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDual<TInner> Call(StandardBinaryOperation operation, in TInner num1, in HyperDual<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<HyperDual<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in HyperDual<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperDual<TInner> Create(in TInner num)
            {
                return new HyperDual<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct HyperDual<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly HyperDual<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly HyperDual<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly HyperDual<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly HyperDual<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperDual<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperDual<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperDual<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in HyperDual<TInner, TComponent> other)
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

        public static implicit operator HyperDual<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperDual<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperDual<TInner, TComponent> operator+(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TComponent> operator*(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TComponent> operator/(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TComponent> operator^(HyperDual<TInner, TComponent> a, HyperDual<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperDual<TInner, TComponent> operator~(HyperDual<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperDual<TInner, TComponent> operator++(HyperDual<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperDual<TInner, TComponent> operator--(HyperDual<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TComponent> operator*(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TComponent> operator/(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TComponent> operator^(HyperDual<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperDual<TInner, TComponent> operator+(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperDual<TInner, TComponent> operator-(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperDual<TInner, TComponent> operator*(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperDual<TInner, TComponent> operator/(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperDual<TInner, TComponent> operator^(TInner a, HyperDual<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperDual<TInner, TComponent> operator+(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner, TComponent> operator-(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner, TComponent> operator*(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner, TComponent> operator/(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperDual<TInner, TComponent> operator^(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperDual<TInner, TComponent> operator+(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperDual<TInner, TComponent> operator-(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperDual<TInner, TComponent> operator*(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperDual<TInner, TComponent> operator/(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperDual<TInner, TComponent> operator^(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperDual<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperDual<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in HyperDual<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperDual<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual HyperDual<TInner, TComponent> Clone(in HyperDual<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperDual<TInner, TComponent> num1, HyperDual<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperDual<TInner, TComponent> num1, HyperDual<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperDual<TInner, TComponent> num1, in HyperDual<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperDual<TInner, TComponent> num1, in HyperDual<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperDual<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperDual<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperDual<TInner, TComponent> Call(StandardUnaryOperation operation, in HyperDual<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperDual<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDual<TInner, TComponent> num1, in HyperDual<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDual<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDual<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDual<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in HyperDual<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in HyperDual<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperDual<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDual<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperDual<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in HyperDual<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual HyperDual<TInner, TComponent> Create(in TInner num)
            {
                return new HyperDual<TInner, TComponent>(num);
            }
		}
	}

	partial struct HyperSplitComplex<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly HyperSplitComplex<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly HyperSplitComplex<TInner> One = Create(StandardNumber.One);
		public static readonly HyperSplitComplex<TInner> Two = Create(StandardNumber.Two);
		public static readonly HyperSplitComplex<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperSplitComplex<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperSplitComplex<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner> CallReversed(StandardBinaryOperation operation, in HyperSplitComplex<TInner> other)
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

        public static implicit operator HyperSplitComplex<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperSplitComplex<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperSplitComplex<TInner> operator+(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner> operator*(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner> operator/(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner> operator^(HyperSplitComplex<TInner> a, HyperSplitComplex<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperSplitComplex<TInner> operator~(HyperSplitComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperSplitComplex<TInner> operator++(HyperSplitComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperSplitComplex<TInner> operator--(HyperSplitComplex<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner> operator*(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner> operator/(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner> operator^(HyperSplitComplex<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperSplitComplex<TInner> operator+(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperSplitComplex<TInner> operator-(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperSplitComplex<TInner> operator*(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperSplitComplex<TInner> operator/(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperSplitComplex<TInner> operator^(TInner a, HyperSplitComplex<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperSplitComplex<TInner> operator+(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner> operator-(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner> operator*(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner> operator/(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner> operator^(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperSplitComplex<TInner> operator+(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner> operator-(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner> operator*(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner> operator/(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner> operator^(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperSplitComplex<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<HyperSplitComplex<TInner>, TInner> INumber<HyperSplitComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in HyperSplitComplex<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperSplitComplex<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual HyperSplitComplex<TInner> Clone(in HyperSplitComplex<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperSplitComplex<TInner> num1, HyperSplitComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperSplitComplex<TInner> num1, HyperSplitComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperSplitComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperSplitComplex<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperSplitComplex<TInner> Call(StandardUnaryOperation operation, in HyperSplitComplex<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual HyperSplitComplex<TInner> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner> num1, in HyperSplitComplex<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperSplitComplex<TInner> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperSplitComplex<TInner> Call(StandardBinaryOperation operation, in TInner num1, in HyperSplitComplex<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<HyperSplitComplex<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in HyperSplitComplex<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperSplitComplex<TInner> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct HyperSplitComplex<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly HyperSplitComplex<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly HyperSplitComplex<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly HyperSplitComplex<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly HyperSplitComplex<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly HyperSplitComplex<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static HyperSplitComplex<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public HyperSplitComplex<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in HyperSplitComplex<TInner, TComponent> other)
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

        public static implicit operator HyperSplitComplex<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(HyperSplitComplex<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static HyperSplitComplex<TInner, TComponent> operator+(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(HyperSplitComplex<TInner, TComponent> a, HyperSplitComplex<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator~(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator++(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator--(HyperSplitComplex<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(HyperSplitComplex<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static HyperSplitComplex<TInner, TComponent> operator+(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(TInner a, HyperSplitComplex<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static HyperSplitComplex<TInner, TComponent> operator+(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static HyperSplitComplex<TInner, TComponent> operator+(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator-(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator*(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator/(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static HyperSplitComplex<TInner, TComponent> operator^(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(HyperSplitComplex<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, HyperSplitComplex<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual HyperSplitComplex<TInner, TComponent> Clone(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(HyperSplitComplex<TInner, TComponent> num1, HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(HyperSplitComplex<TInner, TComponent> num1, HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in HyperSplitComplex<TInner, TComponent> num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in HyperSplitComplex<TInner, TComponent> num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(HyperSplitComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual HyperSplitComplex<TInner, TComponent> Call(StandardUnaryOperation operation, in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in HyperSplitComplex<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperSplitComplex<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in HyperSplitComplex<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual HyperSplitComplex<TInner, TComponent> Create(in TInner num)
            {
                return new HyperSplitComplex<TInner, TComponent>(num);
            }
		}
	}

	partial struct NullableNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly NullableNumber<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly NullableNumber<TInner> One = Create(StandardNumber.One);
		public static readonly NullableNumber<TInner> Two = Create(StandardNumber.Two);
		public static readonly NullableNumber<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly NullableNumber<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static NullableNumber<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner> CallReversed(StandardBinaryOperation operation, in NullableNumber<TInner> other)
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

        public static implicit operator NullableNumber<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(NullableNumber<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static NullableNumber<TInner> operator+(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner> operator*(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner> operator/(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner> operator^(NullableNumber<TInner> a, NullableNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static NullableNumber<TInner> operator~(NullableNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static NullableNumber<TInner> operator++(NullableNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static NullableNumber<TInner> operator--(NullableNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner> operator*(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner> operator/(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner> operator^(NullableNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static NullableNumber<TInner> operator+(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static NullableNumber<TInner> operator-(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static NullableNumber<TInner> operator*(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static NullableNumber<TInner> operator/(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static NullableNumber<TInner> operator^(TInner a, NullableNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static NullableNumber<TInner> operator+(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner> operator-(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner> operator*(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner> operator/(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner> operator^(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static NullableNumber<TInner> operator+(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner> operator-(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner> operator*(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner> operator/(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner> operator^(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(NullableNumber<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, NullableNumber<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, NullableNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<NullableNumber<TInner>, TInner> INumber<NullableNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in NullableNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in NullableNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual NullableNumber<TInner> Clone(in NullableNumber<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(NullableNumber<TInner> num1, NullableNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(NullableNumber<TInner> num1, NullableNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(NullableNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in NullableNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual NullableNumber<TInner> Call(StandardUnaryOperation operation, in NullableNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual NullableNumber<TInner> Call(StandardBinaryOperation operation, in NullableNumber<TInner> num1, in NullableNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual NullableNumber<TInner> Call(StandardBinaryOperation operation, in NullableNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual NullableNumber<TInner> Call(StandardBinaryOperation operation, in TInner num1, in NullableNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<NullableNumber<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in NullableNumber<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual NullableNumber<TInner> Create(in TInner num)
            {
                return new NullableNumber<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct NullableNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly NullableNumber<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly NullableNumber<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly NullableNumber<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly NullableNumber<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly NullableNumber<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static NullableNumber<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullableNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in NullableNumber<TInner, TComponent> other)
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

        public static implicit operator NullableNumber<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(NullableNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static NullableNumber<TInner, TComponent> operator+(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(NullableNumber<TInner, TComponent> a, NullableNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static NullableNumber<TInner, TComponent> operator~(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static NullableNumber<TInner, TComponent> operator++(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static NullableNumber<TInner, TComponent> operator--(NullableNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(NullableNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static NullableNumber<TInner, TComponent> operator+(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(TInner a, NullableNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static NullableNumber<TInner, TComponent> operator+(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner, TComponent> operator-(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner, TComponent> operator*(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner, TComponent> operator/(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static NullableNumber<TInner, TComponent> operator^(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static NullableNumber<TInner, TComponent> operator+(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator-(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator*(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator/(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullableNumber<TInner, TComponent> operator^(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(NullableNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, NullableNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in NullableNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in NullableNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual NullableNumber<TInner, TComponent> Clone(in NullableNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(NullableNumber<TInner, TComponent> num1, NullableNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(NullableNumber<TInner, TComponent> num1, NullableNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in NullableNumber<TInner, TComponent> num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in NullableNumber<TInner, TComponent> num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(NullableNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in NullableNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual NullableNumber<TInner, TComponent> Call(StandardUnaryOperation operation, in NullableNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual NullableNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in NullableNumber<TInner, TComponent> num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual NullableNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in NullableNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual NullableNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in NullableNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual NullableNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in NullableNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual NullableNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in NullableNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual NullableNumber<TInner, TComponent> Create(in TInner num)
            {
                return new NullableNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct NullNumber
	{
		public static readonly NullNumber Zero = Create(StandardNumber.Zero);
		public static readonly NullNumber One = Create(StandardNumber.One);
		public static readonly NullNumber Two = Create(StandardNumber.Two);
		public static readonly NullNumber NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly NullNumber SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static NullNumber Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullNumber CallReversed(StandardBinaryOperation operation, in NullNumber other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullNumber operator-(NullNumber a, NullNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullNumber operator*(NullNumber a, NullNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullNumber operator/(NullNumber a, NullNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullNumber operator^(NullNumber a, NullNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static NullNumber operator-(NullNumber a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static NullNumber operator~(NullNumber a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static NullNumber operator++(NullNumber a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static NullNumber operator--(NullNumber a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static NullNumber operator+(NullNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static NullNumber operator-(NullNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static NullNumber operator*(NullNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static NullNumber operator/(NullNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static NullNumber operator^(NullNumber a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static NullNumber operator+(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullNumber operator-(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullNumber operator*(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullNumber operator/(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullNumber operator^(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(NullNumber a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(NullNumber a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(NullNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(NullNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(NullNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(NullNumber a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, NullNumber b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, NullNumber b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in NullNumber num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in NullNumber num)
            {
                return num.IsFinite;
            }

            public virtual NullNumber Clone(in NullNumber num)
            {
                return num.Clone();
            }

            public virtual bool Equals(NullNumber num1, NullNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(NullNumber num1, NullNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in NullNumber num1, in NullNumber num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in NullNumber num1, in NullNumber num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(NullNumber num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in NullNumber num)
            {
                return num.GetHashCode();
            }

            public virtual NullNumber Call(StandardUnaryOperation operation, in NullNumber num)
            {
                return num.Call(operation);
            }

            public virtual NullNumber Call(StandardBinaryOperation operation, in NullNumber num1, in NullNumber num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct NullNumber<TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly NullNumber<TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly NullNumber<TComponent> One = Create(StandardNumber.One);
		public static readonly NullNumber<TComponent> Two = Create(StandardNumber.Two);
		public static readonly NullNumber<TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly NullNumber<TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static NullNumber<TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public NullNumber<TComponent> CallReversed(StandardBinaryOperation operation, in NullNumber<TComponent> other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullNumber<TComponent> operator-(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullNumber<TComponent> operator*(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullNumber<TComponent> operator/(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullNumber<TComponent> operator^(NullNumber<TComponent> a, NullNumber<TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static NullNumber<TComponent> operator-(NullNumber<TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static NullNumber<TComponent> operator~(NullNumber<TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static NullNumber<TComponent> operator++(NullNumber<TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static NullNumber<TComponent> operator--(NullNumber<TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static NullNumber<TComponent> operator+(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static NullNumber<TComponent> operator-(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static NullNumber<TComponent> operator*(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static NullNumber<TComponent> operator/(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static NullNumber<TComponent> operator^(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static NullNumber<TComponent> operator+(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static NullNumber<TComponent> operator-(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static NullNumber<TComponent> operator*(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static NullNumber<TComponent> operator/(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static NullNumber<TComponent> operator^(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(NullNumber<TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(NullNumber<TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, NullNumber<TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, NullNumber<TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in NullNumber<TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in NullNumber<TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual NullNumber<TComponent> Clone(in NullNumber<TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(NullNumber<TComponent> num1, NullNumber<TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(NullNumber<TComponent> num1, NullNumber<TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in NullNumber<TComponent> num1, in NullNumber<TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in NullNumber<TComponent> num1, in NullNumber<TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(NullNumber<TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in NullNumber<TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual NullNumber<TComponent> Call(StandardUnaryOperation operation, in NullNumber<TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual NullNumber<TComponent> Call(StandardBinaryOperation operation, in NullNumber<TComponent> num1, in NullNumber<TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in NullNumber<TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual NullNumber<TComponent> Call(StandardBinaryOperation operation, in NullNumber<TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual NullNumber<TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in NullNumber<TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }
		}
	}

	partial struct ProjectiveNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly ProjectiveNumber<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly ProjectiveNumber<TInner> One = Create(StandardNumber.One);
		public static readonly ProjectiveNumber<TInner> Two = Create(StandardNumber.Two);
		public static readonly ProjectiveNumber<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly ProjectiveNumber<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static ProjectiveNumber<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner> CallReversed(StandardBinaryOperation operation, in ProjectiveNumber<TInner> other)
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

        public static implicit operator ProjectiveNumber<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(ProjectiveNumber<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static ProjectiveNumber<TInner> operator+(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner> operator*(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner> operator/(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner> operator^(ProjectiveNumber<TInner> a, ProjectiveNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static ProjectiveNumber<TInner> operator~(ProjectiveNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static ProjectiveNumber<TInner> operator++(ProjectiveNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static ProjectiveNumber<TInner> operator--(ProjectiveNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner> operator*(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner> operator/(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner> operator^(ProjectiveNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static ProjectiveNumber<TInner> operator+(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static ProjectiveNumber<TInner> operator-(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static ProjectiveNumber<TInner> operator*(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static ProjectiveNumber<TInner> operator/(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static ProjectiveNumber<TInner> operator^(TInner a, ProjectiveNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static ProjectiveNumber<TInner> operator+(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner> operator-(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner> operator*(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner> operator/(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner> operator^(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static ProjectiveNumber<TInner> operator+(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner> operator-(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner> operator*(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner> operator/(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner> operator^(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, ProjectiveNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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

		INumberOperations<ProjectiveNumber<TInner>, TInner> INumber<ProjectiveNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in ProjectiveNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ProjectiveNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual ProjectiveNumber<TInner> Clone(in ProjectiveNumber<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(ProjectiveNumber<TInner> num1, ProjectiveNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(ProjectiveNumber<TInner> num1, ProjectiveNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(ProjectiveNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ProjectiveNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual ProjectiveNumber<TInner> Call(StandardUnaryOperation operation, in ProjectiveNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual ProjectiveNumber<TInner> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ProjectiveNumber<TInner> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ProjectiveNumber<TInner> Call(StandardBinaryOperation operation, in TInner num1, in ProjectiveNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<ProjectiveNumber<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in ProjectiveNumber<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual ProjectiveNumber<TInner> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct ProjectiveNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly ProjectiveNumber<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly ProjectiveNumber<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly ProjectiveNumber<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly ProjectiveNumber<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly ProjectiveNumber<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static ProjectiveNumber<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ProjectiveNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in ProjectiveNumber<TInner, TComponent> other)
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

        public static implicit operator ProjectiveNumber<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static explicit operator TInner(ProjectiveNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static ProjectiveNumber<TInner, TComponent> operator+(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(ProjectiveNumber<TInner, TComponent> a, ProjectiveNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator~(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator++(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator--(ProjectiveNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(ProjectiveNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static ProjectiveNumber<TInner, TComponent> operator+(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(TInner a, ProjectiveNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
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

		public static ProjectiveNumber<TInner, TComponent> operator+(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static ProjectiveNumber<TInner, TComponent> operator+(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator-(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator*(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator/(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ProjectiveNumber<TInner, TComponent> operator^(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(ProjectiveNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, ProjectiveNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual ProjectiveNumber<TInner, TComponent> Clone(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(ProjectiveNumber<TInner, TComponent> num1, ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(ProjectiveNumber<TInner, TComponent> num1, ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in ProjectiveNumber<TInner, TComponent> num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in ProjectiveNumber<TInner, TComponent> num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(ProjectiveNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual ProjectiveNumber<TInner, TComponent> Call(StandardUnaryOperation operation, in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in ProjectiveNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in ProjectiveNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner, TComponent>(num);
            }
		}
	}

	partial struct Real
	{
		public static readonly Real Zero = Create(StandardNumber.Zero);
		public static readonly Real One = Create(StandardNumber.One);
		public static readonly Real Two = Create(StandardNumber.Two);
		public static readonly Real NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly Real SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static Real Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Real CallReversed(StandardBinaryOperation operation, in Real other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static Real operator-(Real a, Real b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static Real operator*(Real a, Real b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static Real operator/(Real a, Real b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static Real operator^(Real a, Real b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static Real operator-(Real a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static Real operator~(Real a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static Real operator++(Real a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static Real operator--(Real a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static Real operator+(Real a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static Real operator-(Real a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static Real operator*(Real a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static Real operator/(Real a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static Real operator^(Real a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static Real operator+(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static Real operator-(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static Real operator*(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static Real operator/(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static Real operator^(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(Real a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(Real a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(Real a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(Real a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(Real a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(Real a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, Real b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, Real b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in Real num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in Real num)
            {
                return num.IsFinite;
            }

            public virtual Real Clone(in Real num)
            {
                return num.Clone();
            }

            public virtual bool Equals(Real num1, Real num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(Real num1, Real num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in Real num1, in Real num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in Real num1, in Real num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(Real num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in Real num)
            {
                return num.GetHashCode();
            }

            public virtual Real Call(StandardUnaryOperation operation, in Real num)
            {
                return num.Call(operation);
            }

            public virtual Real Call(StandardBinaryOperation operation, in Real num1, in Real num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct ExtendedReal
	{
		public static readonly ExtendedReal Zero = Create(StandardNumber.Zero);
		public static readonly ExtendedReal One = Create(StandardNumber.One);
		public static readonly ExtendedReal Two = Create(StandardNumber.Two);
		public static readonly ExtendedReal NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly ExtendedReal SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static ExtendedReal Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public ExtendedReal CallReversed(StandardBinaryOperation operation, in ExtendedReal other)
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
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static ExtendedReal operator-(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ExtendedReal operator*(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ExtendedReal operator/(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ExtendedReal operator^(ExtendedReal a, ExtendedReal b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static ExtendedReal operator-(ExtendedReal a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static ExtendedReal operator~(ExtendedReal a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static ExtendedReal operator++(ExtendedReal a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static ExtendedReal operator--(ExtendedReal a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
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

		public static ExtendedReal operator+(ExtendedReal a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static ExtendedReal operator-(ExtendedReal a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static ExtendedReal operator*(ExtendedReal a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static ExtendedReal operator/(ExtendedReal a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static ExtendedReal operator^(ExtendedReal a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static ExtendedReal operator+(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static ExtendedReal operator-(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static ExtendedReal operator*(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static ExtendedReal operator/(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static ExtendedReal operator^(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(ExtendedReal a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(ExtendedReal a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(ExtendedReal a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(ExtendedReal a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(ExtendedReal a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(ExtendedReal a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, ExtendedReal b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, ExtendedReal b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
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
			
            public virtual bool IsInvertible(in ExtendedReal num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in ExtendedReal num)
            {
                return num.IsFinite;
            }

            public virtual ExtendedReal Clone(in ExtendedReal num)
            {
                return num.Clone();
            }

            public virtual bool Equals(ExtendedReal num1, ExtendedReal num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(ExtendedReal num1, ExtendedReal num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(ExtendedReal num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in ExtendedReal num)
            {
                return num.GetHashCode();
            }

            public virtual ExtendedReal Call(StandardUnaryOperation operation, in ExtendedReal num)
            {
                return num.Call(operation);
            }

            public virtual ExtendedReal Call(StandardBinaryOperation operation, in ExtendedReal num1, in ExtendedReal num2)
            {
                return num1.Call(operation, num2);
            }
		}
	}

	partial struct TransformedNumber<TInner, TTransformation> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner> where TTransformation : struct, TransformedNumber<TInner, TTransformation>.ITransformation
	{
		public static readonly TransformedNumber<TInner, TTransformation> Zero = Create(StandardNumber.Zero);
		public static readonly TransformedNumber<TInner, TTransformation> One = Create(StandardNumber.One);
		public static readonly TransformedNumber<TInner, TTransformation> Two = Create(StandardNumber.Two);
		public static readonly TransformedNumber<TInner, TTransformation> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly TransformedNumber<TInner, TTransformation> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static TransformedNumber<TInner, TTransformation> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public TransformedNumber<TInner, TTransformation> CallReversed(StandardBinaryOperation operation, in TransformedNumber<TInner, TTransformation> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<TransformedNumber<TInner, TTransformation>>.Equals(TransformedNumber<TInner, TTransformation> other)
        {
            return Equals(other);
        }

        int IComparable<TransformedNumber<TInner, TTransformation>>.CompareTo(TransformedNumber<TInner, TTransformation> other)
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

        public static implicit operator TransformedNumber<TInner, TTransformation>(TInner value)
        {
            return new TransformedNumber<TInner, TTransformation>(value);
        }

        public static implicit operator TransformedNumber<TInner, TTransformation>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(TransformedNumber<TInner, TTransformation> value)
        {
            return GetAsWrapper(ref value);
        }

        public static TransformedNumber<TInner, TTransformation> operator+(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator-(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator*(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator/(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator^(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator-(TransformedNumber<TInner, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator~(TransformedNumber<TInner, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator++(TransformedNumber<TInner, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator--(TransformedNumber<TInner, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
        }

        public static bool operator==(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(TransformedNumber<TInner, TTransformation> a, TransformedNumber<TInner, TTransformation> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static TransformedNumber<TInner, TTransformation> operator+(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator-(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator*(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator/(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator^(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static TransformedNumber<TInner, TTransformation> operator+(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator-(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator*(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator/(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator^(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }		

        public static bool operator==(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(TransformedNumber<TInner, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, TransformedNumber<TInner, TTransformation> b)
        {
            return b.CompareTo(a) >= 0;
        }

		public static TransformedNumber<TInner, TTransformation> operator+(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TTransformation> operator-(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TTransformation> operator*(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TTransformation> operator/(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TTransformation> operator^(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static TransformedNumber<TInner, TTransformation> operator+(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator-(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator*(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator/(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static TransformedNumber<TInner, TTransformation> operator^(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(TransformedNumber<TInner, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, TransformedNumber<TInner, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TransformedNumber<TInner, TTransformation>> INumber<TransformedNumber<TInner, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<TransformedNumber<TInner, TTransformation>, TInner> IExtendedNumber<TransformedNumber<TInner, TTransformation>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

		INumberOperations<TransformedNumber<TInner, TTransformation>, TInner> INumber<TransformedNumber<TInner, TTransformation>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in TransformedNumber<TInner, TTransformation> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in TransformedNumber<TInner, TTransformation> num)
            {
                return num.IsFinite;
            }

            public virtual TransformedNumber<TInner, TTransformation> Clone(in TransformedNumber<TInner, TTransformation> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(TransformedNumber<TInner, TTransformation> num1, TransformedNumber<TInner, TTransformation> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(TransformedNumber<TInner, TTransformation> num1, TransformedNumber<TInner, TTransformation> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in TransformedNumber<TInner, TTransformation> num1, in TransformedNumber<TInner, TTransformation> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in TransformedNumber<TInner, TTransformation> num1, in TransformedNumber<TInner, TTransformation> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(TransformedNumber<TInner, TTransformation> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in TransformedNumber<TInner, TTransformation> num)
            {
                return num.GetHashCode();
            }

            public virtual TransformedNumber<TInner, TTransformation> Call(StandardUnaryOperation operation, in TransformedNumber<TInner, TTransformation> num)
            {
                return num.Call(operation);
            }

            public virtual TransformedNumber<TInner, TTransformation> Call(StandardBinaryOperation operation, in TransformedNumber<TInner, TTransformation> num1, in TransformedNumber<TInner, TTransformation> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual TransformedNumber<TInner, TTransformation> Call(StandardBinaryOperation operation, in TransformedNumber<TInner, TTransformation> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual TransformedNumber<TInner, TTransformation> Call(StandardBinaryOperation operation, in TInner num1, in TransformedNumber<TInner, TTransformation> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<TransformedNumber<TInner, TTransformation>, TInner>.CallComponent(StandardUnaryOperation operation, in TransformedNumber<TInner, TTransformation> num)
            {
                return num.CallComponent(operation);
            }

            public virtual TransformedNumber<TInner, TTransformation> Create(in TInner num)
            {
                return new TransformedNumber<TInner, TTransformation>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct TransformedNumber<TInner, TComponent, TTransformation> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TTransformation : struct, TransformedNumber<TInner, TTransformation>.ITransformation
	{
		public static readonly TransformedNumber<TInner, TComponent, TTransformation> Zero = Create(StandardNumber.Zero);
		public static readonly TransformedNumber<TInner, TComponent, TTransformation> One = Create(StandardNumber.One);
		public static readonly TransformedNumber<TInner, TComponent, TTransformation> Two = Create(StandardNumber.Two);
		public static readonly TransformedNumber<TInner, TComponent, TTransformation> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly TransformedNumber<TInner, TComponent, TTransformation> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static TransformedNumber<TInner, TComponent, TTransformation> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public TransformedNumber<TInner, TComponent, TTransformation> CallReversed(StandardBinaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<TransformedNumber<TInner, TComponent, TTransformation>>.Equals(TransformedNumber<TInner, TComponent, TTransformation> other)
        {
            return Equals(other);
        }

        int IComparable<TransformedNumber<TInner, TComponent, TTransformation>>.CompareTo(TransformedNumber<TInner, TComponent, TTransformation> other)
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

        public static implicit operator TransformedNumber<TInner, TComponent, TTransformation>(TInner value)
        {
            return new TransformedNumber<TInner, TComponent, TTransformation>(value);
        }

        public static implicit operator TransformedNumber<TInner, TComponent, TTransformation>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(TransformedNumber<TInner, TComponent, TTransformation> value)
        {
            return GetAsWrapper(ref value);
        }

        public static TransformedNumber<TInner, TComponent, TTransformation> operator+(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator-(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator*(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator/(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator^(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator-(TransformedNumber<TInner, TComponent, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator~(TransformedNumber<TInner, TComponent, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator++(TransformedNumber<TInner, TComponent, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator--(TransformedNumber<TInner, TComponent, TTransformation> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
        }

        public static bool operator==(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(TransformedNumber<TInner, TComponent, TTransformation> a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static TransformedNumber<TInner, TComponent, TTransformation> operator+(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator-(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator*(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator/(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator^(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static TransformedNumber<TInner, TComponent, TTransformation> operator+(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator-(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator*(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator/(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator^(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }		

        public static bool operator==(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(TransformedNumber<TInner, TComponent, TTransformation> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return b.CompareTo(a) >= 0;
        }

		public static TransformedNumber<TInner, TComponent, TTransformation> operator+(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator-(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator*(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator/(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator^(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static TransformedNumber<TInner, TComponent, TTransformation> operator+(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator-(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator*(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator/(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static TransformedNumber<TInner, TComponent, TTransformation> operator^(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(TransformedNumber<TInner, TComponent, TTransformation> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, TransformedNumber<TInner, TComponent, TTransformation> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<TransformedNumber<TInner, TComponent, TTransformation>> INumber<TransformedNumber<TInner, TComponent, TTransformation>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TComponent> INumber<TransformedNumber<TInner, TComponent, TTransformation>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TInner> IExtendedNumber<TransformedNumber<TInner, TComponent, TTransformation>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<TransformedNumber<TInner, TComponent, TTransformation>, TInner, TComponent> IExtendedNumber<TransformedNumber<TInner, TComponent, TTransformation>, TInner, TComponent>.GetOperations()
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
			
            public virtual bool IsInvertible(in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.IsFinite;
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Clone(in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(TransformedNumber<TInner, TComponent, TTransformation> num1, TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(TransformedNumber<TInner, TComponent, TTransformation> num1, TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in TransformedNumber<TInner, TComponent, TTransformation> num1, in TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in TransformedNumber<TInner, TComponent, TTransformation> num1, in TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.GetHashCode();
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Call(StandardUnaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.Call(operation);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Call(StandardBinaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num1, in TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Call(StandardBinaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Call(StandardBinaryOperation operation, in TInner num1, in TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num)
            {
                return num.CallComponent(operation);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Call(StandardBinaryOperation operation, in TransformedNumber<TInner, TComponent, TTransformation> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Call(StandardBinaryOperation operation, in TComponent num1, in TransformedNumber<TInner, TComponent, TTransformation> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TransformedNumber<TInner, TComponent, TTransformation> Create(in TInner num)
            {
                return new TransformedNumber<TInner, TComponent, TTransformation>(num);
            }
		}
	}

	partial struct WrapperNumber<TInner> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner>
	{
		public static readonly WrapperNumber<TInner> Zero = Create(StandardNumber.Zero);
		public static readonly WrapperNumber<TInner> One = Create(StandardNumber.One);
		public static readonly WrapperNumber<TInner> Two = Create(StandardNumber.Two);
		public static readonly WrapperNumber<TInner> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly WrapperNumber<TInner> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static WrapperNumber<TInner> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public WrapperNumber<TInner> CallReversed(StandardBinaryOperation operation, in WrapperNumber<TInner> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<WrapperNumber<TInner>>.Equals(WrapperNumber<TInner> other)
        {
            return Equals(other);
        }

        int IComparable<WrapperNumber<TInner>>.CompareTo(WrapperNumber<TInner> other)
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

        public static implicit operator WrapperNumber<TInner>(TInner value)
        {
            return new WrapperNumber<TInner>(value);
        }

        public static implicit operator WrapperNumber<TInner>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(WrapperNumber<TInner> value)
        {
            return GetAsWrapper(ref value);
        }

        public static WrapperNumber<TInner> operator+(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static WrapperNumber<TInner> operator-(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static WrapperNumber<TInner> operator*(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static WrapperNumber<TInner> operator/(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static WrapperNumber<TInner> operator^(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static WrapperNumber<TInner> operator-(WrapperNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static WrapperNumber<TInner> operator~(WrapperNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static WrapperNumber<TInner> operator++(WrapperNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static WrapperNumber<TInner> operator--(WrapperNumber<TInner> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
        }

        public static bool operator==(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(WrapperNumber<TInner> a, WrapperNumber<TInner> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static WrapperNumber<TInner> operator+(WrapperNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static WrapperNumber<TInner> operator-(WrapperNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static WrapperNumber<TInner> operator*(WrapperNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static WrapperNumber<TInner> operator/(WrapperNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static WrapperNumber<TInner> operator^(WrapperNumber<TInner> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static WrapperNumber<TInner> operator+(TInner a, WrapperNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static WrapperNumber<TInner> operator-(TInner a, WrapperNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static WrapperNumber<TInner> operator*(TInner a, WrapperNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static WrapperNumber<TInner> operator/(TInner a, WrapperNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static WrapperNumber<TInner> operator^(TInner a, WrapperNumber<TInner> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }		

        public static bool operator==(WrapperNumber<TInner> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(WrapperNumber<TInner> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(WrapperNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(WrapperNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(WrapperNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(WrapperNumber<TInner> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, WrapperNumber<TInner> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, WrapperNumber<TInner> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, WrapperNumber<TInner> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, WrapperNumber<TInner> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, WrapperNumber<TInner> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, WrapperNumber<TInner> b)
        {
            return b.CompareTo(a) >= 0;
        }

		public static WrapperNumber<TInner> operator+(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner> operator-(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner> operator*(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner> operator/(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner> operator^(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static WrapperNumber<TInner> operator+(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static WrapperNumber<TInner> operator-(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static WrapperNumber<TInner> operator*(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static WrapperNumber<TInner> operator/(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static WrapperNumber<TInner> operator^(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(WrapperNumber<TInner> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(WrapperNumber<TInner> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, WrapperNumber<TInner> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, WrapperNumber<TInner> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<WrapperNumber<TInner>> INumber<WrapperNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<WrapperNumber<TInner>, TInner> IExtendedNumber<WrapperNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }
		
        INumberOperations<TInner> INumber<TInner>.GetOperations()
        {
            return HyperMath.Operations.For<TInner>.Instance;
        }

		INumberOperations<WrapperNumber<TInner>, TInner> INumber<WrapperNumber<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations
		{
			public static readonly Operations Instance = new Operations();
			
            public virtual bool IsInvertible(in WrapperNumber<TInner> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in WrapperNumber<TInner> num)
            {
                return num.IsFinite;
            }

            public virtual WrapperNumber<TInner> Clone(in WrapperNumber<TInner> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(WrapperNumber<TInner> num1, WrapperNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(WrapperNumber<TInner> num1, WrapperNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in WrapperNumber<TInner> num1, in WrapperNumber<TInner> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in WrapperNumber<TInner> num1, in WrapperNumber<TInner> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(WrapperNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in WrapperNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public virtual WrapperNumber<TInner> Call(StandardUnaryOperation operation, in WrapperNumber<TInner> num)
            {
                return num.Call(operation);
            }

            public virtual WrapperNumber<TInner> Call(StandardBinaryOperation operation, in WrapperNumber<TInner> num1, in WrapperNumber<TInner> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual WrapperNumber<TInner> Call(StandardBinaryOperation operation, in WrapperNumber<TInner> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual WrapperNumber<TInner> Call(StandardBinaryOperation operation, in TInner num1, in WrapperNumber<TInner> num2)
            {
                return num2.CallReversed(operation, num1);
            }			

			TInner INumberOperations<WrapperNumber<TInner>, TInner>.CallComponent(StandardUnaryOperation operation, in WrapperNumber<TInner> num)
            {
                return num.CallComponent(operation);
            }

            public virtual WrapperNumber<TInner> Create(in TInner num)
            {
                return new WrapperNumber<TInner>(num);
            }
		}
		
        bool ICollection<TInner>.IsReadOnly => true;

        void IList<TInner>.Insert(int index, TInner item)
        {
            throw new NotSupportedException();
        }

        void IList<TInner>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Add(TInner item)
        {
            throw new NotSupportedException();
        }

        void ICollection<TInner>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<TInner>.Remove(TInner item)
        {
            throw new NotSupportedException();
        }
	}

	partial struct WrapperNumber<TInner, TComponent> : IReadOnlyRefEquatable<TInner>, IReadOnlyRefComparable<TInner> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
	{
		public static readonly WrapperNumber<TInner, TComponent> Zero = Create(StandardNumber.Zero);
		public static readonly WrapperNumber<TInner, TComponent> One = Create(StandardNumber.One);
		public static readonly WrapperNumber<TInner, TComponent> Two = Create(StandardNumber.Two);
		public static readonly WrapperNumber<TInner, TComponent> NegativeOne = Create(StandardNumber.NegativeOne);
		public static readonly WrapperNumber<TInner, TComponent> SpecialOne = Create(StandardNumber.SpecialOne);
		
        public static WrapperNumber<TInner, TComponent> Create(StandardNumber num)
        {
            return Operations.Instance.Create(num);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public WrapperNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in WrapperNumber<TInner, TComponent> other)
        {
            return other.Call(operation, this);
        }

        bool IEquatable<WrapperNumber<TInner, TComponent>>.Equals(WrapperNumber<TInner, TComponent> other)
        {
            return Equals(other);
        }

        int IComparable<WrapperNumber<TInner, TComponent>>.CompareTo(WrapperNumber<TInner, TComponent> other)
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

        public static implicit operator WrapperNumber<TInner, TComponent>(TInner value)
        {
            return new WrapperNumber<TInner, TComponent>(value);
        }

        public static implicit operator WrapperNumber<TInner, TComponent>(StandardNumber num)
        {
            return Create(num);
        }
		
		private static TInner GetAsWrapper<T>(ref T obj) where T : IWrapperNumber<TInner>
		{
			return obj.Value;
		}

		public static implicit operator TInner(WrapperNumber<TInner, TComponent> value)
        {
            return GetAsWrapper(ref value);
        }

        public static WrapperNumber<TInner, TComponent> operator+(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator-(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator*(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator/(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator^(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator-(WrapperNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Negate);
        }
		
        public static WrapperNumber<TInner, TComponent> operator~(WrapperNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Inverse);
        }
		
        public static WrapperNumber<TInner, TComponent> operator++(WrapperNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Increment);
        }
		
        public static WrapperNumber<TInner, TComponent> operator--(WrapperNumber<TInner, TComponent> a)
        {
            return a.Call(StandardUnaryOperation.Decrement);
        }

        public static bool operator==(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(WrapperNumber<TInner, TComponent> a, WrapperNumber<TInner, TComponent> b)
        {
            return a.CompareTo(b) <= 0;
        }		

        public static WrapperNumber<TInner, TComponent> operator+(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Add, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator-(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator*(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator/(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Divide, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator^(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.Call(StandardBinaryOperation.Power, b);
        }

        public static WrapperNumber<TInner, TComponent> operator+(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Add, a);
        }
		
        public static WrapperNumber<TInner, TComponent> operator-(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Subtract, a);
        }
		
        public static WrapperNumber<TInner, TComponent> operator*(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Multiply, a);
        }
		
        public static WrapperNumber<TInner, TComponent> operator/(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Divide, a);
        }
		
        public static WrapperNumber<TInner, TComponent> operator^(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CallReversed(StandardBinaryOperation.Power, a);
        }		

        public static bool operator==(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator<(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator>=(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static bool operator<=(WrapperNumber<TInner, TComponent> a, TInner b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator==(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.Equals(a);
        }

        public static bool operator!=(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return !b.Equals(a);
        }

        public static bool operator>(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) < 0;
        }

        public static bool operator<(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) > 0;
        }

        public static bool operator>=(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) <= 0;
        }

        public static bool operator<=(TInner a, WrapperNumber<TInner, TComponent> b)
        {
            return b.CompareTo(a) >= 0;
        }

		public static WrapperNumber<TInner, TComponent> operator+(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Add, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner, TComponent> operator-(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Subtract, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner, TComponent> operator*(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Multiply, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner, TComponent> operator/(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Divide, Operations.Instance.Create(b));
        }
		
        public static WrapperNumber<TInner, TComponent> operator^(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Call(StandardBinaryOperation.Power, Operations.Instance.Create(b));
        }

        public static WrapperNumber<TInner, TComponent> operator+(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Add, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator-(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Subtract, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator*(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Multiply, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator/(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Divide, b);
        }
		
        public static WrapperNumber<TInner, TComponent> operator^(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Call(StandardBinaryOperation.Power, b);
        }

        public static bool operator==(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator!=(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return !a.Equals(Operations.Instance.Create(b));
        }

        public static bool operator>(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) > 0;
        }

        public static bool operator<(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) < 0;
        }

        public static bool operator>=(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) >= 0;
        }

        public static bool operator<=(WrapperNumber<TInner, TComponent> a, StandardNumber b)
        {
            return a.CompareTo(Operations.Instance.Create(b)) <= 0;
        }

        public static bool operator==(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator!=(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return !Operations.Instance.Create(a).Equals(b);
        }

        public static bool operator>(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) > 0;
        }

        public static bool operator<(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) < 0;
        }

        public static bool operator>=(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) >= 0;
        }

        public static bool operator<=(StandardNumber a, WrapperNumber<TInner, TComponent> b)
        {
            return Operations.Instance.Create(a).CompareTo(b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<WrapperNumber<TInner, TComponent>> INumber<WrapperNumber<TInner, TComponent>>.GetOperations()
        {
            return Operations.Instance;
        }		

        INumberOperations<WrapperNumber<TInner, TComponent>, TComponent> INumber<WrapperNumber<TInner, TComponent>, TComponent>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, TInner> IExtendedNumber<WrapperNumber<TInner, TComponent>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IExtendedNumberOperations<WrapperNumber<TInner, TComponent>, TInner, TComponent> IExtendedNumber<WrapperNumber<TInner, TComponent>, TInner, TComponent>.GetOperations()
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
			
            public virtual bool IsInvertible(in WrapperNumber<TInner, TComponent> num)
            {
                return num.IsInvertible;
            }

            public virtual bool IsFinite(in WrapperNumber<TInner, TComponent> num)
            {
                return num.IsFinite;
            }

            public virtual WrapperNumber<TInner, TComponent> Clone(in WrapperNumber<TInner, TComponent> num)
            {
                return num.Clone();
            }

            public virtual bool Equals(WrapperNumber<TInner, TComponent> num1, WrapperNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(WrapperNumber<TInner, TComponent> num1, WrapperNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual bool Equals(in WrapperNumber<TInner, TComponent> num1, in WrapperNumber<TInner, TComponent> num2)
            {
                return num1.Equals(num2);
            }

            public virtual int Compare(in WrapperNumber<TInner, TComponent> num1, in WrapperNumber<TInner, TComponent> num2)
            {
                return num1.CompareTo(num2);
            }

            public virtual int GetHashCode(WrapperNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual int GetHashCode(in WrapperNumber<TInner, TComponent> num)
            {
                return num.GetHashCode();
            }

            public virtual WrapperNumber<TInner, TComponent> Call(StandardUnaryOperation operation, in WrapperNumber<TInner, TComponent> num)
            {
                return num.Call(operation);
            }

            public virtual WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in WrapperNumber<TInner, TComponent> num1, in WrapperNumber<TInner, TComponent> num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in WrapperNumber<TInner, TComponent> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner num1, in WrapperNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual TComponent CallComponent(StandardUnaryOperation operation, in WrapperNumber<TInner, TComponent> num)
            {
                return num.CallComponent(operation);
            }

            public virtual WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in WrapperNumber<TInner, TComponent> num1, in TComponent num2)
            {
                return num1.Call(operation, num2);
            }

            public virtual WrapperNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent num1, in WrapperNumber<TInner, TComponent> num2)
            {
                return num2.CallReversed(operation, num1);
            }

            public virtual WrapperNumber<TInner, TComponent> Create(in TInner num)
            {
                return new WrapperNumber<TInner, TComponent>(num);
            }
		}
	}

}