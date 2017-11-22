using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Utils.StringExtensions
{
    public static class StringFormattingFunctions
    {
        public static string HangingIndent(string unindentedPrefix, string indentedBlock)
        {
            int indentation = 0;
            if (unindentedPrefix != null)
                indentation = unindentedPrefix.Length;
            return HangingIndent($"{unindentedPrefix}{indentedBlock}", indentation);
        }

        public static string HangingIndent(string value, int indentation)
        {
            if (value == null)
                return null;
            IReadOnlyCollection<string> lines = value.Split(new[] { Environment.NewLine}, StringSplitOptions.None);
            IEnumerable<string> indentedSubLines = lines.Rest().Select(x => $"{indentation.Spaces()}{x}");
            IReadOnlyCollection<string> result = lines.First().Cons(indentedSubLines);
            return string.Join(Environment.NewLine, result);
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
            return multiLineString.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }

        public static Tuple<string, string> HarmonizeLineCount(string left, string right)
        {
            int leftLineCount = left.SplitLines().Length;
            int rightLineCount = right.SplitLines().Length;
            int difference = rightLineCount - leftLineCount;
            if (difference == 0)
                return new Tuple<string, string>(left, right);
            if (difference < 0)
            {
                Tuple<string, string> invertedResult = HarmonizeLineCount(right, left);
                return new Tuple<string, string>(invertedResult.Item2, invertedResult.Item1);
            }
            return new Tuple<string, string>(left.NewLines(difference), right);
        } 
    }
}