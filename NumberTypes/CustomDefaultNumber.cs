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

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
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
    }

    /// <summary>
    /// A utility number type whose default value is different from the default value
    /// of <typeparamref name="TInner"/>, and can be specified using a custom type.
    /// </summary>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    /// <typeparam name="TTraits">A type implementing <see cref="ITraits"/> which is constructed once for every number type and queried for the default value.</typeparam>
    [Serializable]
    public readonly partial struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>, INumber<TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
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

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Clone()
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

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
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

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner>.Call(BinaryOperation operation, in TInner other)
        {
            if(initialized)
            {
                return HyperMath.Call(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(BinaryOperation operation, TPrimitive other)
        {
            if(initialized)
            {
                return HyperMath.CallPrimitive(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        TInner INumber<TInner, TPrimitive>.Call(BinaryOperation operation, TPrimitive other)
        {
            if(initialized)
            {
                return HyperMath.CallPrimitive(operation, value, other);
            }
            return defaultValue.Call(operation, other);
        }

        public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(UnaryOperation operation)
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

        public TPrimitive Call(PrimitiveUnaryOperation operation)
        {
            if(initialized)
            {
                return HyperMath.Call<TInner, TPrimitive>(operation, value);
            }
            return defaultValue.Call(operation);
        }

        public override bool Equals(object obj)
        {
            return obj is CustomDefaultNumber<TInner, TPrimitive, TTraits> value && Equals(in value) || Value.Equals(obj);
        }

        public bool Equals(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
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

        public int CompareTo(in CustomDefaultNumber<TInner, TPrimitive, TTraits> other)
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

        partial class Operations : NumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>>, IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, TInner, TPrimitive>
        {
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension;

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Call(NullaryOperation operation)
            {
                return HyperMath.Call<TInner>(operation);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(TPrimitive realUnit, TPrimitive otherUnits, TPrimitive someUnitsCombined, TPrimitive allUnitsCombined)
            {
                return HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(IEnumerable<TPrimitive> units)
            {
                return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }

            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(IEnumerator<TPrimitive> units)
            {
                return new CustomDefaultNumber<TInner, TPrimitive, TTraits>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units));
            }
        }
        
        /// <summary>
        /// An interface that a user of <see cref="CustomDefaultNumber{TInner, TPrimitive, TTraits}"/> must provide
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
