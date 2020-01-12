using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// A utility number type whose default value is different from the default value
    /// of <typeparamref name="TInner"/>, and can be specified using a custom type.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TTraits">A type implementing <see cref="ITraits"/> which is constructed once for every number type and queried for the default value.</typeparam>
    [Serializable]
    public readonly partial struct CustomDefaultNumber<TInner, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TTraits>, TInner>, INumber<TInner> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
    {
        static TInner defaultValue = default(TTraits).DefaultValue;

        readonly TInner value;
        readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => initialized ? CanInv(value) : defaultValue.IsInvertible;

        public bool IsFinite => initialized ? IsFin(value) : defaultValue.IsFinite;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TTraits> Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        TInner INumber<TInner>.Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Call(operation, value, other.value);
                }
                return HyperMath.Call(operation, value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Call(operation, defaultValue, other.value);
            }
            return HyperMath.Call(operation, defaultValue, defaultValue);
        }

        public CustomDefaultNumber<TInner, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TTraits> CallReversed(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, other, value);
            }
            return defaultValue.CallReversed(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner>.CallReversed(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, other, value);
            }
            return defaultValue.CallReversed(operation, other);
        }

        public CustomDefaultNumber<TInner, TTraits> Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Equals(value, other.value);
                }
                return HyperMath.Equals(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Equals(defaultValue, other.value);
            }
            return true;
        }

        public bool Equals(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Equals(value, other);
            }
            return HyperMath.Equals(defaultValue, other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Compare(value, other.value);
                }
                return HyperMath.Compare(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Compare(defaultValue, other.value);
            }
            return 0;
        }

        public int CompareTo(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Compare(value, other);
            }
            return HyperMath.Compare(defaultValue, other);
        }

        public override int GetHashCode()
        {
            if(initialized)
            {
                return value.GetHashCode();
            }
            return defaultValue.GetHashCode();
        }

        public override string ToString()
        {
            if(initialized)
            {
                return value.ToString();
            }
            return defaultValue.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(initialized)
            {
                return value.ToString(format, formatProvider);
            }
            return defaultValue.ToString(format, formatProvider);
        }

        partial class Operations : NumberOperations<CustomDefaultNumber<TInner, TTraits>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, TInner>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public CustomDefaultNumber<TInner, TTraits> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }
        }

        /// <summary>
        /// An interface that a user of <see cref="CustomDefaultNumber{TInner, TTraits}"/> must provide
        /// to specify the default value of the type.
        /// </summary>
        public interface ITraits
        {
            /// <summary>
            /// Obtains the default value of the type.
            /// </summary>
            TInner DefaultValue { get; }
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
            return Value.GetEnumerator();
        }
    }

    /// <summary>
    /// A utility number type whose default value is different from the default value
    /// of <typeparamref name="TInner"/>, and can be specified using a custom type.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    /// <typeparam name="TTraits">A type implementing <see cref="ITraits"/> which is constructed once for every number type and queried for the default value.</typeparam>
    [Serializable]
    public readonly partial struct CustomDefaultNumber<TInner, TComponent, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TComponent, TTraits>, TInner, TComponent>, INumber<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent> where TTraits : struct, CustomDefaultNumber<TInner, TComponent, TTraits>.ITraits
    {
        static TInner defaultValue = default(TTraits).DefaultValue;

        readonly TInner value;
        readonly bool initialized;

        public TInner Value => initialized ? value : defaultValue;

        public bool IsInvertible => initialized ? CanInv(value) : defaultValue.IsInvertible;

        public bool IsFinite => initialized ? IsFin(value) : defaultValue.IsFinite;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;
        
        public CustomDefaultNumber(in TInner value)
        {
            this.value = value;
            this.initialized = true;
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        TInner INumber<TInner>.Clone()
        {
            if(initialized)
            {
                return HyperMath.Clone(value);
            }
            return defaultValue.Clone();
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TComponent, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Call(operation, value, other.value);
                }
                return HyperMath.Call(operation, value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Call(operation, defaultValue, other.value);
            }
            return HyperMath.Call(operation, defaultValue, defaultValue);
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> CallReversed(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, other, value);
            }
            return defaultValue.CallReversed(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner>.CallReversed(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, other, value);
            }
            return defaultValue.CallReversed(operation, other);
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> Call(BinaryOperation operation, in TComponent other)
        {
            if(initialized)
            {
                return HyperMath.CallComponent(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> CallReversed(BinaryOperation operation, in TComponent other)
        {
            if(initialized)
            {
                return HyperMath.CallComponentReversed(operation, other, value);
            }
            return defaultValue.CallReversed(operation, other);
        }

        TInner INumber<TInner, TComponent>.Call(BinaryOperation operation, in TComponent other)
        {
            if(initialized)
            {
                return HyperMath.CallComponent(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner, TComponent>.CallReversed(BinaryOperation operation, in TComponent other)
        {
            if(initialized)
            {
                return HyperMath.CallComponentReversed(operation, other, value);
            }
            return defaultValue.CallReversed(operation, other);
        }

        public CustomDefaultNumber<TInner, TComponent, TTraits> Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        TInner INumber<TInner>.Call(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value);
            }
            return defaultValue.Call(operation);
        }

        public TComponent CallComponent(UnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.CallComponent<TInner, TComponent>(operation, value);
            }
            return defaultValue.CallComponent(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TComponent, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TComponent, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Equals(value, other.value);
                }
                return HyperMath.Equals(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Equals(defaultValue, other.value);
            }
            return true;
        }

        public bool Equals(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Equals(value, other);
            }
            return HyperMath.Equals(defaultValue, other);
        }

        public int CompareTo(in CustomDefaultNumber<TInner, TComponent, TTraits> other)
        {
            if(initialized)
            {
                if(other.initialized)
                {
                    return HyperMath.Compare(value, other.value);
                }
                return HyperMath.Compare(value, defaultValue);
            }
            if(other.initialized)
            {
                return HyperMath.Compare(defaultValue, other.value);
            }
            return 0;
        }

        public int CompareTo(in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Compare(value, other);
            }
            return HyperMath.Compare(defaultValue, other);
        }

        public override int GetHashCode()
        {
            if(initialized)
            {
                return value.GetHashCode();
            }
            return defaultValue.GetHashCode();
        }

        public override string ToString()
        {
            if(initialized)
            {
                return value.ToString();
            }
            return defaultValue.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if(initialized)
            {
                return value.ToString(format, formatProvider);
            }
            return defaultValue.ToString(format, formatProvider);
        }

        partial class Operations : NumberOperations<CustomDefaultNumber<TInner, TComponent, TTraits>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TComponent, TTraits>, TInner, TComponent>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public CustomDefaultNumber<TInner, TComponent, TTraits> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Create(in TComponent num)
            {
                return new CustomDefaultNumber<TInner, TComponent, TTraits>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(num));
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Create(in TComponent realUnit, in TComponent otherUnits, in TComponent someUnitsCombined, in TComponent allUnitsCombined)
            {
                return HyperMath.Create<TInner, TComponent>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Create(IEnumerable<TComponent> units)
            {
                return new CustomDefaultNumber<TInner, TComponent, TTraits>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }

            public CustomDefaultNumber<TInner, TComponent, TTraits> Create(IEnumerator<TComponent> units)
            {
                return new CustomDefaultNumber<TInner, TComponent, TTraits>(HyperMath.Operations.For<TInner, TComponent>.Instance.Create(units));
            }
        }
        
        /// <summary>
        /// An interface that a user of <see cref="CustomDefaultNumber{TInner, TComponent, TTraits}"/> must provide
        /// to specify the default value of the type.
        /// </summary>
        public interface ITraits
        {
            /// <summary>
            /// Obtains the default value of the type.
            /// </summary>
            TInner DefaultValue { get; }
        }
    }
}
