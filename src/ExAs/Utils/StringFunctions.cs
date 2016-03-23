using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Utils
{
    public static class StringFunctions
    {
        public static string ToValueString<T>(this T item, string nullString = "null")
        {
            if (item == null)
                return nullString;
            if (item is string)
                return $"'{item.ToString().HangingIndent(1)}'";
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
            {
                var typeName = arrayList.FirstOrDefault().GetType().Name;
                if (strings.Count != 1)
                    typeName = typeName.Add("s");
                return "<".Add(strings.Count.ToString()).Add(" ").Add(typeName).Add(">");
            }
            return "[".Add(string.Join(", ", strings)).Add("]");
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