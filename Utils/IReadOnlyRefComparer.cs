using System.Collections.Generic;

namespace IS4.HyperNumerics.Utils
{
    public interface IReadOnlyRefComparer<T> : IComparer<T>
    {
        int Compare(in T x, in T y);
    }
}
