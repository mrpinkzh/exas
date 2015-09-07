using System;
using System.Collections.Generic;
using System.Linq;

namespace ExAs.Utils
{
    public static class StringFunctions
    {
        public static string ToNullAwareString(this object instance, string nullString = "null")
        {
            if (instance == null)
                return nullString;
            return instance.ToString();
        }

        public static string Apostrophed(this string input)
        {
            return string.Format("'{0}'", input);
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