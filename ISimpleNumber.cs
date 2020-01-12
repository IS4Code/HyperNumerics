using System;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// A general interface type for any number backed up by a single component type.
    /// </summary>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    public interface ISimpleNumber<TComponent> : INumber, IList<TComponent>, IReadOnlyList<TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        TComponent Value { get; }
    }

    /// <summary>
    /// A general interface type for any number backed up by a single component type, supporting the common set of standard operations.
    /// </summary>
    /// <typeparam name="TNumber">The number type that serves as the argument and result of the operations, usually the same as the implementing type.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    public interface ISimpleNumber<TNumber, TComponent> : ISimpleNumber<TComponent>, INumber<TNumber, TComponent> where TNumber : struct, ISimpleNumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {

    }
}
