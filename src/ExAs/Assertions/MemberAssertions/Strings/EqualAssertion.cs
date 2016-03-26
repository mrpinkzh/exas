using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

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
            Tuple<string, string> harmonizedOutput = HarmonizeLineCount(actualValueString, expectationString);
            return new ValueAssertionResult(
                string.Equals(actual, expected), 
                harmonizedOutput.Item1, 
                harmonizedOutput.Item2);
        }
    }
}