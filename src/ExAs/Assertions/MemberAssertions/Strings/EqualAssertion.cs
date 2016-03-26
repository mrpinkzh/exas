using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class EqualAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public EqualAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            var actualValueString = actual.ToValueString();
            var expectationString = ComposeLog.Expected(expected.ToValueString());
            Tuple<string, string> harmonizedOutput = HarmonizeLineCountWith(actualValueString, expectationString);
            return new ValueAssertionResult(
                string.Equals(actual, expected), 
                harmonizedOutput.Item1, 
                harmonizedOutput.Item2);
        }

        private Tuple<string, string> HarmonizeLineCountWith(string firstString, string otherString)
        {
            int firstStringLineCount = firstString.SplitLines().Length;
            int otherStringLineCount = otherString.SplitLines().Length;
            int difference = otherStringLineCount - firstStringLineCount;
            if (difference == 0)
                return new Tuple<string, string>(firstString, otherString);
            if (difference < 0)
            {
                Tuple<string, string> invertedResult = HarmonizeLineCountWith(otherString, firstString);
                return new Tuple<string, string>(invertedResult.Item2, invertedResult.Item1);
            }
            return new Tuple<string, string>(firstString.NewLines(difference), otherString);
        }
    }
}