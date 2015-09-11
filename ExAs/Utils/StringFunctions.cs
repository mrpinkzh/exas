using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Utils
{
    public static class StringFunctions
    {
        public static string ToNullAwareString(this object instance, string nullString = "null")
        {
            if (instance == null)
                return nullString;
            if (instance is string)
                return string.Format("'{0}'", instance);
            return instance.ToString();
        }

        public static string ToValueString<T>(this IEnumerable<T> enumerable)
        {
            IReadOnlyCollection<string> strings = enumerable.Map(item => item.ToNullAwareString());
            if (!strings.Any())
                return "<empty>";
            if (strings.Any(s => s.Contains(Environment.NewLine)))
                return "<".Add(strings.Count.ToString()).Add(" ").Add(typeof(T).Name).Add(">");
            return "[ ".Add(string.Join(", ", strings)).Add(" ]");
        }

        public static string ToValueString<T>(this T item, string nullString = "null")
        {
            if (item == null)
                return nullString;
            if (item is string)
                return string.Format("'{0}'", item);
            var enumerable = item as IEnumerable;
            if (enumerable != null)
                return enumerable.ToValueString();
            return item.ToString();
        }

        public static string ToValueString(this IEnumerable enumerable)
        {
            var arrayList = enumerable.ToArrayList();
            IReadOnlyCollection<string> strings = arrayList.Map(item => item.ToNullAwareString());
            if (!strings.Any())
                return "<empty>";
            if (strings.Any(s => s.Contains(Environment.NewLine)))
            {
                var typeName = arrayList.FirstOrDefault().GetType().Name;
                return "<".Add(strings.Count.ToString()).Add(" ").Add(typeName).Add(">");
            }
            return "[ ".Add(string.Join(", ", strings)).Add(" ]");
        }

        public static string HangingIndent(string unindentedPrefix, string indentedBlock)
        {
            int indentation = 0;
            if (unindentedPrefix != null)
                indentation = unindentedPrefix.Length;
            return String.Format("{0}{1}", unindentedPrefix, indentedBlock).HangingIndent(indentation);
        }

        public static string HangingIndent(this string value, int indentation)
        {
            if (value == null)
                return null;
            IReadOnlyCollection<string> lines = value.Split(new[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> indentedSubLines = lines.Rest().Select(x => String.Format("{0}{1}", indentation.Spaces(), x));
            IReadOnlyCollection<string> result = SystemFunctions.Cons(lines.First(), indentedSubLines);
            return String.Join(Environment.NewLine, result);
        }

        public static string Add(this string value, string valueToConcat)
        {
            return String.Format("{0}{1}", value, valueToConcat);
        }

        public static string NewLine(this string value)
        {
            return value.Add(Environment.NewLine);
        }

        public static string Spaces(this int amount)
        {
            if (amount <= 0)
                return String.Empty;
            return String.Format(" {0}", (amount - 1).Spaces());
        }

        public static string FillUpWithSpacesToLength(this string input, int length)
        {
            if (length <= input.Length)
                return input;
            int amount = length - input.Length;
            return input.Add(amount.Spaces());
        }

        public static string[] SplitLines(this string multiLineString)
        {
            return multiLineString.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}