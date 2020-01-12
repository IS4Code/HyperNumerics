using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// Provides operations for a number type implementing <see cref="IHyperNumber{TNumber, TInner}"/>.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    public interface IHyperNumberOperations<TNumber, TInner> : IExtendedNumberOperations<TNumber, TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
    {
        /// <summary>
        /// Creates a new instance of <typeparamref name="TNumber"/> from the values of its two components.
        /// </summary>
        /// <param name="first">The first component's value.</param>
        /// <param name="second">The second component's value.</param>
        /// <returns>A new instance containing both values.</returns>
        TNumber Create(in TInner first, in TInner second);
    }

    /// <summary>
    /// Provides operations for a number type implementing <see cref="IHyperNumber{TNumber, TInner, TComponent}"/>.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations.</typeparam>
    /// <typeparam name="TInner">The inner type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    public interface IHyperNumberOperations<TNumber, TInner, TComponent> : IHyperNumberOperations<TNumber, TInner>, IExtendedNumberOperations<TNumber, TInner, TComponent> where TNumber : struct, IHyperNumber<TNumber, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {

    }
}
