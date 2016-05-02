using System.Collections.Generic;
using System.Linq;

namespace ExAs.Utils.SystemExtensions
{
    public static class EnumerableExtensions
    {
        public static bool Contains_NullAware<T>(this IEnumerable<T> items, T item)
        {
            if (items == null) return false;
            return items.Contains(item);
        }

        public static bool ContainsAny_NullAware<T>(this IEnumerable<T> items, IEnumerable<T> expectedItems)
        {
            if (expectedItems == null) return false;
            return expectedItems.Map(items.Contains_NullAware).All(b => b);
        }

        public static IReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return null;
            return items.ToArray();
        }
    }
}