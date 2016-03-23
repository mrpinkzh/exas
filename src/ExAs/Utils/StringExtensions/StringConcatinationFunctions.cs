using System;

namespace ExAs.Utils.StringExtensions
{
    public static class StringConcatinationFunctions
    {
        public static string Add(this string value, object valueToConcat)
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

        public static string NewLines(this string value, int amount)
        {
            if (amount <= 0)
                return value;
            if (amount == 1)
                return value.NewLine();
            return value.NewLines(amount - 1);
        }
    }
}