using System;

namespace IS4.HyperNumerics.AdditionalInterfaces
{
    public interface IReadOnlyRefComparable<T> : IComparable<T>
    {
        int CompareTo(in T other);
    }
}
