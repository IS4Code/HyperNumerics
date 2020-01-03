using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number in a projective space where the inverse of a number is always defined (an infinity of some sort for every non-invertible number).
    /// </summary>
    /// <typeparam name="TInner">The original number type.</typeparam>
    /// <remarks>
    /// Even though taking the inverse of a number of this type is always
    /// supported, not all types of operations are possible on the result,
    /// namely multiplication with zero, and addition and subtraction of infinities.
    /// </remarks>
    [Serializable]
    public readonly struct ProjectiveNumber<TInner> : IWrapperNumber<ProjectiveNumber<TInner>, TInner>, IWrapperNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> where TInner : struct, INumber<TInner>
    {
        readonly TInner value;

        public TInner Value => value;

        TInner IWrapperNumber<TInner>.Value => !IsInfinity ? value : throw new InvalidOperationException("The number is infinite.");

        ProjectiveNumber<TInner> IWrapperNumber<ProjectiveNumber<TInner>>.Value => this;

        public bool IsInfinity { get; }

        public bool IsInvertible => true;

        public bool IsFinite => !IsInfinity && IsFin(value);

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public ProjectiveNumber(in TInner value, bool isInfinity = false)
        {
            this.value = value;
            IsInfinity = isInfinity;
        }

        public ProjectiveNumber<TInner> Clone()
        {
            return new ProjectiveNumber<TInner>(HyperMath.Clone(value), IsInfinity);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator ProjectiveNumber<TInner>(TInner value)
        {
            return new ProjectiveNumber<TInner>(value);
        }

        public ProjectiveNumber<TInner> Call(BinaryOperation operation, in ProjectiveNumber<TInner> other)
        {
            if(!other.IsInfinity)
            {
                return Call(operation, other.value);
            }
            switch(operation)
            {
                case BinaryOperation.Add:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Add(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner>(other.value, true);
                case BinaryOperation.Subtract:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Sub(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner>(other.value, true);
                case BinaryOperation.Multiply:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other.value), true);
                    }
                    return new ProjectiveNumber<TInner>(HyperMath.Div(value, other.value), true);
                case BinaryOperation.Divide:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Div(value, other.value));
                    }
                    return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other.value));
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner> Call(BinaryOperation operation, in TInner other)
        {
            if(!IsInfinity)
            {
                if(operation == BinaryOperation.Divide && !HyperMath.CanInv(other))
                {
                    return Call(BinaryOperation.Multiply, new ProjectiveNumber<TInner>(other, true));
                }
                return HyperMath.Call<TInner>(operation, value, other);
            }
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new ProjectiveNumber<TInner>(value, true);
                case BinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner>(value, true);
                case BinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner>(HyperMath.Div(value, other), true);
                case BinaryOperation.Divide:
                    return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other), true);
                case BinaryOperation.Power:
                    return new ProjectiveNumber<TInner>(HyperMath.Pow<TInner>(value, other), true);
                default:
                    throw new NotSupportedException();
            }
            
        }

        public ProjectiveNumber<TInner> Call(UnaryOperation operation)
        {
            if(!IsInfinity)
            {
                if(operation == UnaryOperation.Inverse && !HyperMath.CanInv(value))
                {
                    return new ProjectiveNumber<TInner>(value, true);
                }
                return HyperMath.Call(operation, value);
            }
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new ProjectiveNumber<TInner>(HyperMath.Neg(value), true);
                case UnaryOperation.Increment:
                    return new ProjectiveNumber<TInner>(value, true);
                case UnaryOperation.Decrement:
                    return new ProjectiveNumber<TInner>(value, true);
                case UnaryOperation.Inverse:
                    return new ProjectiveNumber<TInner>(value, false);
                case UnaryOperation.Conjugate:
                    return new ProjectiveNumber<TInner>(HyperMath.Con(value), true);
                case UnaryOperation.Modulus:
                    return new ProjectiveNumber<TInner>(HyperMath.Mods(value), true);
                case UnaryOperation.Double:
                    return new ProjectiveNumber<TInner>(HyperMath.Div2(value), true);
                case UnaryOperation.Half:
                    return new ProjectiveNumber<TInner>(HyperMath.Mul2(value), true);
                case UnaryOperation.Square:
                    return new ProjectiveNumber<TInner>(HyperMath.Pow2(value), true);
                case UnaryOperation.SquareRoot:
                    return new ProjectiveNumber<TInner>(HyperMath.Sqrt(value), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectiveNumber<TInner> value && Equals(in value);
        }

        public bool Equals(ProjectiveNumber<TInner> other)
        {
            return Equals(in other);
        }

        public bool Equals(in ProjectiveNumber<TInner> other)
        {
            return HyperMath.Equals(value, other.value) && IsInfinity == other.IsInfinity;
        }

        public int CompareTo(ProjectiveNumber<TInner> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in ProjectiveNumber<TInner> other)
        {
            return HyperMath.Compare(value, other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode() * 17 + IsInfinity.GetHashCode();
        }

        public override string ToString()
        {
            return IsInfinity ? "Infinity(" + value.ToString() + ")" : value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return IsInfinity ? "Infinity(" + value.ToString(format, formatProvider) + ")" : value.ToString(format, formatProvider);
        }

        public static bool operator==(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in ProjectiveNumber<TInner> a, in ProjectiveNumber<TInner> b)
        {
            return a.CompareTo(in b) <= 0;
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

        IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<ProjectiveNumber<TInner>>, IExtendedNumberOperations<ProjectiveNumber<TInner>, TInner>, IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

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
                return num1.Equals(in num2);
            }

            public int Compare(ProjectiveNumber<TInner> num1, ProjectiveNumber<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in ProjectiveNumber<TInner> num1, in ProjectiveNumber<TInner> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(ProjectiveNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ProjectiveNumber<TInner> num)
            {
                return num.GetHashCode();
            }

            public ProjectiveNumber<TInner> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
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

            public ProjectiveNumber<TInner> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner>(num);
            }

            public ProjectiveNumber<TInner> Create(in ProjectiveNumber<TInner> num)
            {
                return num;
            }
        }
    }

    /// <summary>
    /// Represents a number in a projective space where the inverse of a number is always defined (an infinity of some sort for every non-invertible number).
    /// </summary>
    /// <typeparam name="TInner">The original number type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <remarks>
    /// Even though taking the inverse of a number of this type is always
    /// supported, not all types of operations are possible on the result,
    /// namely multiplication with zero, addition, and subtraction.
    /// </remarks>
    [Serializable]
    public readonly struct ProjectiveNumber<TInner, TPrimitive> : IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>, TInner, TPrimitive>, IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        readonly TInner value;

        public TInner Value => value;

        TInner IWrapperNumber<TInner>.Value => !IsInfinity ? value : throw new InvalidOperationException("The number is infinite.");

        ProjectiveNumber<TInner, TPrimitive> IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>>.Value => this;

        public bool IsInfinity { get; }

        public bool IsInvertible => true;

        public bool IsFinite => !IsInfinity && IsFin(value);

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public ProjectiveNumber(in TInner value, bool isInfinity = false)
        {
            this.value = value;
            IsInfinity = isInfinity;
        }

        public ProjectiveNumber<TInner, TPrimitive> Clone()
        {
            return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Clone(value), IsInfinity);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static implicit operator ProjectiveNumber<TInner, TPrimitive>(TInner value)
        {
            return new ProjectiveNumber<TInner, TPrimitive>(value);
        }

        public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> other)
        {
            if(!other.IsInfinity)
            {
                return Call(operation, other.value);
            }
            switch(operation)
            {
                case BinaryOperation.Add:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Add(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner, TPrimitive>(other.value, true);
                case BinaryOperation.Subtract:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Sub(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner, TPrimitive>(other.value, true);
                case BinaryOperation.Multiply:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Mul(value, other.value), true);
                    }
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Div(value, other.value), true);
                case BinaryOperation.Divide:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Div(value, other.value));
                    }
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Mul(value, other.value));
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in TInner other)
        {
            if(!IsInfinity)
            {
                if(operation == BinaryOperation.Divide && !HyperMath.CanInv(other))
                {
                    return Call(BinaryOperation.Multiply, new ProjectiveNumber<TInner, TPrimitive>(other, true));
                }
                return HyperMath.Call<TInner>(operation, value, other);
            }
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                case BinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                case BinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Div(value, other), true);
                case BinaryOperation.Divide:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Mul(value, other), true);
                case BinaryOperation.Power:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Pow(value, other), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TPrimitive> Call(UnaryOperation operation)
        {
            if(!IsInfinity)
            {
                if(operation == UnaryOperation.Inverse && !HyperMath.CanInv(value))
                {
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                }
                return HyperMath.Call(operation, value);
            }
            switch(operation)
            {
                case UnaryOperation.Negate:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Neg(value), true);
                case UnaryOperation.Increment:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                case UnaryOperation.Decrement:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                case UnaryOperation.Inverse:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, false);
                case UnaryOperation.Conjugate:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Con(value), true);
                case UnaryOperation.Modulus:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Mods(value), true);
                case UnaryOperation.Double:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Div2(value), true);
                case UnaryOperation.Half:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Mul2(value), true);
                case UnaryOperation.Square:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Pow2(value), true);
                case UnaryOperation.SquareRoot:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Sqrt(value), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, TPrimitive other)
        {
            if(!IsInfinity)
            {
                if(operation == BinaryOperation.Divide)
                {
                    return Call(BinaryOperation.Divide, HyperMath.Create<TInner, TPrimitive>(other));
                }
                return HyperMath.CallPrimitive(operation, value, other);
            }
            switch(operation)
            {
                case BinaryOperation.Add:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                case BinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner, TPrimitive>(value, true);
                case BinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.DivVal(value, other), true);
                case BinaryOperation.Divide:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.MulVal(value, other), true);
                case BinaryOperation.Power:
                    return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.PowVal(value, other), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return HyperMath.Call<TInner, TPrimitive>(operation, value);
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectiveNumber<TInner, TPrimitive> value && Equals(in value);
        }

        public bool Equals(ProjectiveNumber<TInner, TPrimitive> other)
        {
            return Equals(in other);
        }

        public bool Equals(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            return HyperMath.Equals(value, other.value) && IsInfinity == other.IsInfinity;
        }

        public int CompareTo(ProjectiveNumber<TInner, TPrimitive> other)
        {
            return CompareTo(in other);
        }

        public int CompareTo(in ProjectiveNumber<TInner, TPrimitive> other)
        {
            return HyperMath.Compare(value, other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode() * 17 + IsInfinity.GetHashCode();
        }

        public override string ToString()
        {
            return IsInfinity ? "Infinity(" + value.ToString() + ")" : value.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return IsInfinity ? "Infinity(" + value.ToString(format, formatProvider) + ")" : value.ToString(format, formatProvider);
        }

        public static bool operator==(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(in ProjectiveNumber<TInner, TPrimitive> a, in ProjectiveNumber<TInner, TPrimitive> b)
        {
            return a.CompareTo(in b) <= 0;
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

        IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

        IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<ProjectiveNumber<TInner, TPrimitive>>, IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, TInner, TPrimitive>, IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

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
                return num1.Equals(in num2);
            }

            public int Compare(ProjectiveNumber<TInner, TPrimitive> num1, ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public bool Equals(in ProjectiveNumber<TInner, TPrimitive> num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.Equals(in num2);
            }

            public int Compare(in ProjectiveNumber<TInner, TPrimitive> num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.CompareTo(in num2);
            }

            public int GetHashCode(ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public int GetHashCode(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.GetHashCode();
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(UnaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num1, in ProjectiveNumber<TInner, TPrimitive> num2)
            {
                return num1.Call(operation, num2);
            }

            public TPrimitive Call(PrimitiveUnaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num.Call(operation);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num1, TPrimitive num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TPrimitive> Call(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num1, in TInner num2)
            {
                return num1.Call(operation, num2);
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(in TInner num)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(num);
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num;
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }

            public ProjectiveNumber<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                return new ProjectiveNumber<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }
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

        void ThrowIfInfinity()
        {
            if(IsInfinity)
            {
                throw new InvalidOperationException("Cannot obtain the numeric representation of an infinity.");
            }
        }

        int ICollection<TPrimitive>.Count{
            get{
                ThrowIfInfinity();
                return GetCollectionCount(value);
            }
        }

        bool ICollection<TPrimitive>.IsReadOnly => true;

        int IReadOnlyCollection<TPrimitive>.Count{
            get{
                ThrowIfInfinity();
                return GetReadOnlyCollectionCount(value);
            }
        }

        TPrimitive IReadOnlyList<TPrimitive>.this[int index]
        {
            get{
                ThrowIfInfinity();
                return GetReadOnlyListItem(value, index);
            }
        }

        TPrimitive IList<TPrimitive>.this[int index]
        {
            get{
                ThrowIfInfinity();
                return GetListItem(value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TPrimitive>.IndexOf(TPrimitive item)
        {
            if(IsInfinity)
            {
                return -1;
            }
            return value.IndexOf(item);
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
            if(IsInfinity)
            {
                return false;
            }
            return value.Contains(item);
        }

        void ICollection<TPrimitive>.CopyTo(TPrimitive[] array, int arrayIndex)
        {
            ThrowIfInfinity();
            value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TPrimitive>.Remove(TPrimitive item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TPrimitive> IEnumerable<TPrimitive>.GetEnumerator()
        {
            ThrowIfInfinity();
            return value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            ThrowIfInfinity();
            return value.GetEnumerator();
        }
    }
}
