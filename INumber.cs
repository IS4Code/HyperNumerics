using IS4.HyperNumerics.AdditionalInterfaces;
using System;
using System.Collections.Generic;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface for any number type.
    /// </summary>
    public interface INumber : IFormattable, ICloneable
    {
        /// <summary>
        /// If the number can be expressed as an element of a vector space, returns its dimension (-1 if infinite).
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// Returns true if the number is invertible (usually equivalent to being non-zero), i.e. its inverse can be calculated.
        /// </summary>
        bool IsInvertible { get; }

        /// <summary>
        /// Returns true if the number is finite (meaning depends on the actual number type).
        /// </summary>
        bool IsFinite { get; }

        /// <summary>
        /// Returns the factory object responsible for providing instances of this number type.
        /// </summary>
        /// <returns>An object that can be used to construct instances of the same type as this value.</returns>
        INumberFactory GetFactory();
    }

    /// <summary>
    /// A general interface for any number type supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    public interface INumber<TNumber> : INumber, IReadOnlyRefEquatable<TNumber>, IReadOnlyRefComparable<TNumber> where TNumber : struct, INumber<TNumber>
    {
        /// <summary>
        /// Obtains a deep copy of the number.
        /// </summary>
        /// <returns></returns>
        new TNumber Clone();

        /// <summary>
        /// Calculates the sum of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other summand used in the calculation.</param>
        /// <returns>The sum of the two numbers.</returns>
        TNumber Add(in TNumber other);

        /// <summary>
        /// Calculates the difference of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The subtrahend used in the calculation.</param>
        /// <returns>The difference of the two numbers.</returns>
        TNumber Subtract(in TNumber other);

        /// <summary>
        /// Calculates the product of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other multiplier used in the calculation.</param>
        /// <returns>The product of the two numbers.</returns>
        TNumber Multiply(in TNumber other);

        /// <summary>
        /// Calculates the ratio of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The divisor used in the calculation.</param>
        /// <returns>The ratio of the two numbers.</returns>
        TNumber Divide(in TNumber other);

        /// <summary>
        /// Calculates the value of this number to the power of <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The exponent used in the calculation.</param>
        /// <returns>The power of the two numbers.</returns>
        TNumber Power(in TNumber other);

        /// <summary>
        /// Calculates the negation of the number, i.e. the additive inverse.
        /// </summary>
        /// <returns>The additive inverse of the number.</returns>
        TNumber Negate();

        /// <summary>
        /// Increments the number by 1.
        /// </summary>
        /// <returns>The value incremented by 1.</returns>
        TNumber Increment();

        /// <summary>
        /// Decrements the number by 1.
        /// </summary>
        /// <returns>The value decremented by 1.</returns>
        TNumber Decrement();

        /// <summary>
        /// Calculates the multiplicative inverse of the number. The value is available if <see cref="INumber.IsInvertible"/> is true.
        /// </summary>
        /// <returns>The multiplicative inverse.</returns>
        TNumber Inverse();

        /// <summary>
        /// Returns the conjugate of the number.
        /// </summary>
        /// <returns>The conjugate, if available, or the original number</returns>
        TNumber Conjugate();

        /// <summary>
        /// Returns the modulus or the "absolute value" of the number, expressed in the same type.
        /// </summary>
        /// <returns>The modulus of the number.</returns>
        TNumber Modulus();

        /// <summary>
        /// Multiplies the number by 2.
        /// </summary>
        /// <returns>The value multiplied by 2.</returns>
        TNumber Double();

        /// <summary>
        /// Divides the number by 2.
        /// </summary>
        /// <returns>The value divided by 2.</returns>
        TNumber Half();

        /// <summary>
        /// Calculates the square of the number.
        /// </summary>
        /// <returns>The square of the number</returns>
        TNumber Square();

        /// <summary>
        /// Calculates the square root of the number.
        /// </summary>
        /// <returns>The square root of the number</returns>
        TNumber SquareRoot();

        /// <summary>
        /// Calculates the exponentiation of the number.
        /// </summary>
        /// <returns>The value of exp(this).</returns>
        TNumber Exponentiate();

        /// <summary>
        /// Calculates the natural logarithm of the number.
        /// </summary>
        /// <returns>The value of ln(this).</returns>
        TNumber Logarithm();

        /// <summary>
        /// Calculates the sine of the number.
        /// </summary>
        /// <returns>The value of sin(this).</returns>
        TNumber Sine();

        /// <summary>
        /// Calculates the cosine of the number.
        /// </summary>
        /// <returns>The value of cos(this).</returns>
        TNumber Cosine();

        /// <summary>
        /// Calculates the tangent of the number.
        /// </summary>
        /// <returns>The value of tan(this).</returns>
        TNumber Tangent();

        /// <summary>
        /// Calculates the hyperbolic sine of the number.
        /// </summary>
        /// <returns>The value of sinh(this).</returns>
        TNumber HyperbolicSine();

        /// <summary>
        /// Calculates the hyperbolic cosine of the number.
        /// </summary>
        /// <returns>The value of cosh(this).</returns>
        TNumber HyperbolicCosine();

        /// <summary>
        /// Calculates the hyperbolic tangent of the number.
        /// </summary>
        /// <returns>The value of tanh(this).</returns>
        TNumber HyperbolicTangent();

        /// <summary>
        /// Calculates the arc sine of the number.
        /// </summary>
        /// <returns>The value of asin(this).</returns>
        TNumber ArcSine();

        /// <summary>
        /// Calculates the arc cosine of the number.
        /// </summary>
        /// <returns>The value of acos(this).</returns>
        TNumber ArcCosine();

        /// <summary>
        /// Calculates the arc tangent of the number.
        /// </summary>
        /// <returns>The value of atan(this).</returns>
        TNumber ArcTangent();

        /// <summary>
        /// Returns the factory object responsible for providing instances of this number type.
        /// </summary>
        /// <returns>An object that can be used to construct instances of the same type as this value.</returns>
        new INumberFactory<TNumber> GetFactory();
    }

    /// <summary>
    /// A general interface for any number type supporting the common set of standard operations, represented internally with a specific primitive type.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TPrimitive">The primitive type the number uses.</typeparam>
    public interface INumber<TNumber, TPrimitive> : INumber<TNumber>, IList<TPrimitive>, IReadOnlyList<TPrimitive> where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        /// <summary>
        /// Returns the real component of the number.
        /// </summary>
        /// <returns>The real component as the primitive type.</returns>
        TPrimitive RealValue();

        /// <summary>
        /// Computes the absolute value of the number.
        /// </summary>
        /// <returns>The absolute value as the primitive type.</returns>
        TPrimitive AbsoluteValue();

        /// <summary>
        /// Calculates the sum of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other summand used in the calculation.</param>
        /// <returns>The sum of the two numbers.</returns>
        new TNumber Add(TPrimitive other);

        /// <summary>
        /// Calculates the difference of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The subtrahend used in the calculation.</param>
        /// <returns>The difference of the two numbers.</returns>
        TNumber Subtract(TPrimitive other);

        /// <summary>
        /// Calculates the product of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The other multiplier used in the calculation.</param>
        /// <returns>The product of the two numbers.</returns>
        TNumber Multiply(TPrimitive other);

        /// <summary>
        /// Calculates the ratio of this number and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The divisor used in the calculation.</param>
        /// <returns>The ratio of the two numbers.</returns>
        TNumber Divide(TPrimitive other);

        /// <summary>
        /// Calculates the value of this number to the power of <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The exponent used in the calculation.</param>
        /// <returns>The power of the two numbers.</returns>
        TNumber Power(TPrimitive other);

        /// <summary>
        /// Returns the factory object responsible for providing instances of this number type.
        /// </summary>
        /// <returns>An object that can be used to construct instances of the same type as this value.</returns>
        new INumberFactory<TNumber, TPrimitive> GetFactory();
    }
}
