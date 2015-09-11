using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExAs.Utils.SystemExtensions
{
    public static class ClassicEnumerableExtensions
    {
        public static ArrayList ToArrayList(this IEnumerable enumerable)
        {
            var arrayList = new ArrayList();
            foreach (var item in enumerable)
                arrayList.Add(item);
            return arrayList;
        }

        public static IReadOnlyCollection<TReturn> Map<TReturn>(this IEnumerable enumerable, Func<object, TReturn> func)
        {
            var returnList = new List<TReturn>();
            foreach (object item in enumerable)
            {
                returnList.Add(func(item));
            }
            return returnList;
        }

        public static object FirstOrDefault(this IEnumerable enumerable)
        {
            return Enumerable.FirstOrDefault(enumerable.Cast<object>());
        }
    }
}