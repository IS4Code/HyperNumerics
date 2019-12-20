using System;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any number type that extends another number.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IExtendedNumber<TNumber, TInner> : INumber<TNumber> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// Calculates the sum of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other summand used in the calculation.</param>
        /// <returns>The sum of the two numbers.</returns>
        TNumber Add(in TInner other);

        /// <summary>
        /// Calculates the difference of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The subtrahend used in the calculation.</param>
        /// <returns>The difference of the two numbers.</returns>
        TNumber Subtract(in TInner other);

        /// <summary>
        /// Calculates the product of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other multiplier used in the calculation.</param>
        /// <returns>The product of the two numbers.</returns>
        TNumber Multiply(in TInner other);

        /// <summary>
        /// Calculates the ratio of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The divisor used in the calculation.</param>
        /// <returns>The ratio of the two numbers.</returns>
        TNumber Divide(in TInner other);

        /// <summary>
        /// Calculates the value of this number to the power of <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The exponent used in the calculation.</param>
        /// <returns>The power of the two numbers.</returns>
        TNumber Power(in TInner other);
    }

    /// <summary>
    /// A general interface for any number type that wraps around another number.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface IExtendedNumber<TNumber, TInner, TPrimitive> : IExtendedNumber<TNumber, TInner>, INumber<TNumber, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {

    }
}
