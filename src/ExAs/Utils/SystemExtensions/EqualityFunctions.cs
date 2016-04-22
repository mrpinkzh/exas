using System;

namespace ExAs.Utils.SystemExtensions
{
    public static class EqualityFunctions
    {
        public static int Compare_NullAware<T>(this T first, T other)
            where T : IComparable<T>
        {
            if (first == null)
            {
                if (other == null)
                    return 0;
                return other.CompareTo(first);
            }
            return first.CompareTo(other);
        }
    }
}