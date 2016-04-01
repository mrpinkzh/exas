using System;
using System.Collections.Generic;
using System.Linq;

namespace ExAs.Utils.SystemExtensions
{
    public static class SystemFunctions
    {
        public static IReadOnlyCollection<T> Cons<T>(this T item, IEnumerable<T> items)
        {
            var list = new List<T> { item };
            list.AddRange(items);
            return list;
        }

        public static IReadOnlyCollection<T> Rest<T>(this IEnumerable<T> items)
        {
            return items.Skip(1).ToList();
        }

        public static IReadOnlyCollection<TResult> Map<T, TResult>(this IEnumerable<T> items, Func<T, TResult> func)
        {
            return items?.Select(func).ToList();
        }

        public static IReadOnlyCollection<T> Map<T>(this IEnumerable<T> items, Action<T> action)
        {
            List<T> itemList = items.ToList();
            foreach (T item in itemList)
            {
                action(item);
            }
            return itemList;
        }

        public static IReadOnlyList<TResult> Map<T, TOther, TResult>(
            this IList<T> items,
            IList<TOther> arguments, 
            Func<T, TOther, TResult> func)
        {
            int longestPossibleResult = new[] {items.Count, arguments.Count}.Min();
            var result = new List<TResult>(longestPossibleResult);
            for (int i = 0; i < longestPossibleResult; i++)
            {
                result.Add(func(items[i], arguments[i]));
            }
            return result;
        }

        public static int MaxOrDefault<T>(this IEnumerable<T> items, Func<T, int> selector)
        {
            var itemList = items.ToList();
            if (itemList.Any())
            {
                return itemList.Max(selector);
            }
            return 0;
        }

        public static bool TryCast<T>(this object objectToCast, out T result)
        {
            try
            {
                result = (T) objectToCast;
                return true;
            }
            catch (InvalidCastException)
            {
                result = default(T);
                return false;
            }
        }
    }
}