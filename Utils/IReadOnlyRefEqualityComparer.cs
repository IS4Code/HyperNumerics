using System.Collections.Generic;

namespace IS4.HyperNumerics.Utils
{
    public interface IReadOnlyRefEqualityComparer<T> : IEqualityComparer<T>
    {
        bool Equals(in T x, in T y);

        int GetHashCode(in T obj);
    }
}
