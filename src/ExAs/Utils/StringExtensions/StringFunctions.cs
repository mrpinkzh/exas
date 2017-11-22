using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExAs.Utils.SystemExtensions;
using static ExAs.Utils.StringExtensions.StringConcatinationFunctions;

namespace ExAs.Utils.StringExtensions
{
    public static class StringFunctions
    {
        public static string ToValueString<T>(this T item, string nullString = "null")
        {
            if (item == null)
                return nullString;

            if (item is string)
                return Apostrophed(item.ToString());

            var enumerable = item as IEnumerable;
            if (enumerable != null)
                return enumerable.ToValueString();

            return item.ToString();
        }

        public static string ToValueString(this IEnumerable enumerable)
        {
            var arrayList = enumerable.ToArrayList();
            IReadOnlyCollection<string> strings = arrayList.Map(item => item.ToValueString());

            if (!strings.Any())
                return "<empty>";

			if (strings.Any(s => s.Contains(Environment.NewLine)))
		        return arrayList.ToCountString();

			return $"[{strings.JoinToString(", ")}]";
        }

	

        public static bool Contains_NullAware(this string subject, string value)
        {
            if (subject == null) return false;
            if (value == null) return false;
            return subject.Contains(value);
        }

        public static bool StartsWith_NullAware(this string subject, string value)
        {
            if (subject == null) return false;
            if (value == null) return false;
            return subject.Contains(value);
        }

        public static bool EndsWith_NullAware(this string subject, string value)
        {
            if (subject == null) return false;
            if (value == null) return false;
            return subject.EndsWith(value);
        }
    }
}