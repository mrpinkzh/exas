using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExAs.Utils.SystemExtensions
{
    public static class EnumerableExtensions
    {
        public static bool Any_NullAware<T>(this IEnumerable<T> items, Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return false;
            if (items == null)
                return false;
            return items.Any(predicate.Compile());
        }

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
            return items?.ToArray();
        }

	    public static string JoinToString(this IEnumerable<string> input, string separator)
	    {
		    if (input == null)
			    return null;
		    return string.Join(separator, input);
	    }

	    public static string ToCountString(this IEnumerable input)
	    {
		    var arrayList = input.ToArrayList();
		    if (arrayList.Count == 0)
			    return "<empty>";
			var typeName = arrayList.FirstOrDefault().GetType().Name;
		    if (arrayList.Count != 1)
			    typeName = $"{typeName}s";
		    return $"<{arrayList.Count} {typeName}>";
	    }
    }
}