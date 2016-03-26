using System;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Utils.StringExtensions
{
    public static class StringConcatinationFunctions
    {
        public static string Add(this string value, object valueToConcat)
        {
            return $"{value}{valueToConcat}";
        }

        public static string NewLine(this string value)
        {
            return value.Add(Environment.NewLine);
        }

        public static string Spaces(this int amount)
        {
            if (amount <= 0)
                return string.Empty;
            return $" {(amount - 1).Spaces()}";
        }

        public static string NewLines(this string value, int amount)
        {
            if (amount <= 0)
                return value;
            if (amount == 1)
                return value.NewLine();
            return value.NewLines(amount - 1);
        }

        public static string Apostrophed(string value)
        {
            return $"'{HangingIndent(value, 1)}'";
        }
    }
}