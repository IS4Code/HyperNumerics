using System;

namespace IS4.HyperNumerics.Utils
{
    public interface IReadOnlyRefComparable<T> : IComparable<T>
    {
        int CompareTo(in T other);
    }
}
