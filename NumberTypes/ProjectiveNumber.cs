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
    public readonly partial struct ProjectiveNumber<TInner> : IWrapperNumber<ProjectiveNumber<TInner>, TInner>, INumber<ProjectiveNumber<TInner>, TInner> where TInner : struct, INumber<TInner>
    {
        readonly TInner value;

        public TInner Value => value;

        TInner IWrapperNumber<TInner>.Value => !IsInfinity ? value : throw new InvalidOperationException("The number is infinite.");

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

        public ProjectiveNumber<TInner> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner> other)
        {
            if(!other.IsInfinity)
            {
                return Call(operation, other.value);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Add(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner>(other.value, true);
                case StandardBinaryOperation.Subtract:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Sub(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner>(other.value, true);
                case StandardBinaryOperation.Multiply:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other.value), true);
                    }
                    return new ProjectiveNumber<TInner>(HyperMath.Div(value, other.value), true);
                case StandardBinaryOperation.Divide:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner>(HyperMath.Div(value, other.value));
                    }
                    return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other.value));
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner> Call(StandardBinaryOperation operation, in TInner other)
        {
            if(!IsInfinity)
            {
                if(operation == StandardBinaryOperation.Divide && !HyperMath.CanInv(other))
                {
                    return Call(StandardBinaryOperation.Multiply, new ProjectiveNumber<TInner>(other, true));
                }
                return HyperMath.Call<TInner>(operation, value, other);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new ProjectiveNumber<TInner>(value, true);
                case StandardBinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner>(value, true);
                case StandardBinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner>(HyperMath.Div(value, other), true);
                case StandardBinaryOperation.Divide:
                    return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other), true);
                case StandardBinaryOperation.Power:
                    return new ProjectiveNumber<TInner>(HyperMath.Pow<TInner>(value, other), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            if(!IsInfinity)
            {
                return HyperMath.Call(operation, other, value);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new ProjectiveNumber<TInner>(value, true);
                case StandardBinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner>(HyperMath.Neg(value), true);
                case StandardBinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner>(HyperMath.Div(value, other), true);
                case StandardBinaryOperation.Divide:
                    return new ProjectiveNumber<TInner>(HyperMath.Mul(value, other));
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner> Call(StandardUnaryOperation operation)
        {
            if(!IsInfinity)
            {
                if(operation == StandardUnaryOperation.Inverse && !HyperMath.CanInv(value))
                {
                    return new ProjectiveNumber<TInner>(value, true);
                }
                return HyperMath.Call(operation, value);
            }
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new ProjectiveNumber<TInner>(HyperMath.Neg(value), true);
                case StandardUnaryOperation.Increment:
                    return new ProjectiveNumber<TInner>(value, true);
                case StandardUnaryOperation.Decrement:
                    return new ProjectiveNumber<TInner>(value, true);
                case StandardUnaryOperation.Inverse:
                    return new ProjectiveNumber<TInner>(value, false);
                case StandardUnaryOperation.Conjugate:
                    return new ProjectiveNumber<TInner>(HyperMath.Con(value), true);
                case StandardUnaryOperation.Modulus:
                    return new ProjectiveNumber<TInner>(HyperMath.Mods(value), true);
                case StandardUnaryOperation.Double:
                    return new ProjectiveNumber<TInner>(HyperMath.Div2(value), true);
                case StandardUnaryOperation.Half:
                    return new ProjectiveNumber<TInner>(HyperMath.Mul2(value), true);
                case StandardUnaryOperation.Square:
                    return new ProjectiveNumber<TInner>(HyperMath.Pow2(value), true);
                case StandardUnaryOperation.SquareRoot:
                    return new ProjectiveNumber<TInner>(HyperMath.Sqrt(value), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public TInner CallComponent(StandardUnaryOperation operation)
        {
            ThrowIfInfinity();
            return HyperMath.Call(operation, value);
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectiveNumber<TInner> value && Equals(in value);
        }

        public bool Equals(in ProjectiveNumber<TInner> other)
        {
            return IsInfinity == other.IsInfinity && HyperMath.Equals(value, other.value);
        }

        public int CompareTo(in ProjectiveNumber<TInner> other)
        {
            return HyperMath.Compare(value, other.value);
        }

        public bool Equals(in TInner other)
        {
            return !IsInfinity && HyperMath.Equals(value, other);
        }

        public int CompareTo(in TInner other)
        {
            return HyperMath.Compare(value, other);
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

        partial class Operations : NumberOperations<ProjectiveNumber<TInner>>, IExtendedNumberOperations<ProjectiveNumber<TInner>, TInner>, INumberOperations<ProjectiveNumber<TInner>, TInner>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public virtual ProjectiveNumber<TInner> Create(StandardNumber num)
            {
                return HyperMath.Create<TInner>(num);
            }

            public virtual ProjectiveNumber<TInner> Create(in TInner realUnit, in TInner otherUnits, in TInner someUnitsCombined, in TInner allUnitsCombined)
            {
                return new ProjectiveNumber<TInner>(realUnit);
            }

            public virtual ProjectiveNumber<TInner> Create(IEnumerable<TInner> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public virtual ProjectiveNumber<TInner> Create(IEnumerator<TInner> units)
            {
                var value = units.Current;
                units.MoveNext();
                return new ProjectiveNumber<TInner>(value);
            }
        }

        void ThrowIfInfinity()
        {
            if(IsInfinity)
            {
                throw new InvalidOperationException("Cannot obtain the numeric representation of an infinity.");
            }
        }
		
        int ICollection<TInner>.Count => 1;

        int IReadOnlyCollection<TInner>.Count => 1;

        TInner IReadOnlyList<TInner>.this[int index]
        {
            get{
                if(index == 0)
                {
                    ThrowIfInfinity();
                    return value;
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        TInner IList<TInner>.this[int index]
        {
            get{
                if(index == 0)
                {
                    ThrowIfInfinity();
                    return value;
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TInner>.IndexOf(TInner item)
        {
            return !IsInfinity && item.Equals(in value) ? 0 : -1;
        }

        bool ICollection<TInner>.Contains(TInner item)
        {
            return !IsInfinity && item.Equals(in value);
        }

        void ICollection<TInner>.CopyTo(TInner[] array, int arrayIndex)
        {
            ThrowIfInfinity();
            array[arrayIndex] = value;
        }

        IEnumerator<TInner> IEnumerable<TInner>.GetEnumerator()
        {
            ThrowIfInfinity();
            yield return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            ThrowIfInfinity();
            return value.GetEnumerator();
        }
    }

    /// <summary>
    /// Represents a number in a projective space where the inverse of a number is always defined (an infinity of some sort for every non-invertible number).
    /// </summary>
    /// <typeparam name="TInner">The original number type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    /// <remarks>
    /// Even though taking the inverse of a number of this type is always
    /// supported, not all types of operations are possible on the result,
    /// namely multiplication with zero, addition, and subtraction.
    /// </remarks>
    [Serializable]
    public readonly partial struct ProjectiveNumber<TInner, TComponent> : IWrapperNumber<ProjectiveNumber<TInner, TComponent>, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        readonly TInner value;

        public TInner Value => value;

        TInner IWrapperNumber<TInner>.Value => !IsInfinity ? value : throw new InvalidOperationException("The number is infinite.");

        public bool IsInfinity { get; }

        public bool IsInvertible => true;

        public bool IsFinite => !IsInfinity && IsFin(value);

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

        public ProjectiveNumber(in TInner value, bool isInfinity = false)
        {
            this.value = value;
            IsInfinity = isInfinity;
        }

        public ProjectiveNumber<TInner, TComponent> Clone()
        {
            return new ProjectiveNumber<TInner, TComponent>(HyperMath.Clone(value), IsInfinity);
        }

        public ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in ProjectiveNumber<TInner, TComponent> other)
        {
            if(!other.IsInfinity)
            {
                return Call(operation, other.value);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Add(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner, TComponent>(other.value, true);
                case StandardBinaryOperation.Subtract:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div(HyperMath.Mul(value, other.value), HyperMath.Sub(other.value, value)), true);
                    }
                    return new ProjectiveNumber<TInner, TComponent>(other.value, true);
                case StandardBinaryOperation.Multiply:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TComponent>(HyperMath.Mul(value, other.value), true);
                    }
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div(value, other.value), true);
                case StandardBinaryOperation.Divide:
                    if(IsInfinity)
                    {
                        return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div(value, other.value));
                    }
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Mul(value, other.value));
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner other)
        {
            if(!IsInfinity)
            {
                if(operation == StandardBinaryOperation.Divide && !HyperMath.CanInv(other))
                {
                    return Call(StandardBinaryOperation.Multiply, new ProjectiveNumber<TInner, TComponent>(other, true));
                }
                return HyperMath.Call<TInner>(operation, value, other);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardBinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardBinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div(value, other), true);
                case StandardBinaryOperation.Divide:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Mul(value, other), true);
                case StandardBinaryOperation.Power:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Pow(value, other), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            if(!IsInfinity)
            {
                return HyperMath.Call(operation, other, value);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardBinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Neg(value), true);
                case StandardBinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div(value, other), true);
                case StandardBinaryOperation.Divide:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Mul(other, value));
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TComponent> Call(StandardUnaryOperation operation)
        {
            if(!IsInfinity)
            {
                if(operation == StandardUnaryOperation.Inverse && !HyperMath.CanInv(value))
                {
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                }
                return HyperMath.Call(operation, value);
            }
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Neg(value), true);
                case StandardUnaryOperation.Increment:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardUnaryOperation.Decrement:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardUnaryOperation.Inverse:
                    return new ProjectiveNumber<TInner, TComponent>(value, false);
                case StandardUnaryOperation.Conjugate:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Con(value), true);
                case StandardUnaryOperation.Modulus:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Mods(value), true);
                case StandardUnaryOperation.Double:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Div2(value), true);
                case StandardUnaryOperation.Half:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Mul2(value), true);
                case StandardUnaryOperation.Square:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Pow2(value), true);
                case StandardUnaryOperation.SquareRoot:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Sqrt(value), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            if(!IsInfinity)
            {
                if(operation == StandardBinaryOperation.Divide)
                {
                    return Call(StandardBinaryOperation.Divide, HyperMath.Create<TInner, TComponent>(other));
                }
                return HyperMath.CallComponent(operation, value, other);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardBinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardBinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.DivVal(value, other), true);
                case StandardBinaryOperation.Divide:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.MulVal(value, other), true);
                case StandardBinaryOperation.Power:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.PowVal(value, other), true);
                default:
                    throw new NotSupportedException();
            }
        }

        public ProjectiveNumber<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            if(!IsInfinity)
            {
                return HyperMath.CallComponentReversed(operation, other, value);
            }
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new ProjectiveNumber<TInner, TComponent>(value, true);
                case StandardBinaryOperation.Subtract:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.Neg(value), true);
                case StandardBinaryOperation.Multiply:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.DivVal(value, other), true);
                case StandardBinaryOperation.Divide:
                    return new ProjectiveNumber<TInner, TComponent>(HyperMath.MulVal(value, other));
                default:
                    throw new NotSupportedException();
            }
        }

        public TComponent CallComponent(StandardUnaryOperation operation)
        {
            if(IsInfinity)
            {
                throw new NotSupportedException();
            }
            return HyperMath.CallComponent<TInner, TComponent>(operation, value);
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectiveNumber<TInner, TComponent> value && Equals(in value);
        }

        public bool Equals(in ProjectiveNumber<TInner, TComponent> other)
        {
            return IsInfinity == other.IsInfinity && HyperMath.Equals(value, other.value);
        }

        public int CompareTo(in ProjectiveNumber<TInner, TComponent> other)
        {
            return HyperMath.Compare(value, other.value);
        }

        public bool Equals(in TInner other)
        {
            return !IsInfinity && HyperMath.Equals(value, other);
        }

        public int CompareTo(in TInner other)
        {
            return HyperMath.Compare(value, other);
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

        partial class Operations : NumberOperations<ProjectiveNumber<TInner, TComponent>>, IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, TInner, TComponent>, IExtendedNumberOperations<ProjectiveNumber<TInner, TComponent>, ProjectiveNumber<TInner, TComponent>, TComponent>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public virtual ProjectiveNumber<TInner, TComponent> Create(StandardNumber num)
            {
                return HyperMath.Create<TInner>(num);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(in TComponent num)
            {
                return new ProjectiveNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(num));
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                return HyperMath.Create<TInner, TComponent>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(IEnumerable<TComponent> units)
            {
                return new ProjectiveNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public virtual ProjectiveNumber<TInner, TComponent> Create(IEnumerator<TComponent> units)
            {
                return new ProjectiveNumber<TInner, TComponent>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }
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

        void ThrowIfInfinity()
        {
            if(IsInfinity)
            {
                throw new InvalidOperationException("Cannot obtain the numeric representation of an infinity.");
            }
        }

        int ICollection<TComponent>.Count{
            get{
                ThrowIfInfinity();
                return GetCollectionCount(value);
            }
        }

        bool ICollection<TComponent>.IsReadOnly => true;

        int IReadOnlyCollection<TComponent>.Count{
            get{
                ThrowIfInfinity();
                return GetReadOnlyCollectionCount(value);
            }
        }

        TComponent IReadOnlyList<TComponent>.this[int index]
        {
            get{
                ThrowIfInfinity();
                return GetReadOnlyListItem(value, index);
            }
        }

        TComponent IList<TComponent>.this[int index]
        {
            get{
                ThrowIfInfinity();
                return GetListItem(value, index);
            }
            set{
                throw new NotSupportedException();
            }
        }

        int IList<TComponent>.IndexOf(TComponent item)
        {
            if(IsInfinity)
            {
                return -1;
            }
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
            if(IsInfinity)
            {
                return false;
            }
            return value.Contains(item);
        }

        void ICollection<TComponent>.CopyTo(TComponent[] array, int arrayIndex)
        {
            ThrowIfInfinity();
            value.CopyTo(array, arrayIndex);
        }

        bool ICollection<TComponent>.Remove(TComponent item)
        {
            throw new NotSupportedException();
        }

        IEnumerator<TComponent> IEnumerable<TComponent>.GetEnumerator()
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
