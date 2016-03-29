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
            return ValueAssertionResult.Create(
                string.Equals(actual, expected),
                HarmonizeLineCount(
                    actual.ToValueString(),
                    ComposeLog.Expected(expected.ToValueString()))); 
        }
    }
}