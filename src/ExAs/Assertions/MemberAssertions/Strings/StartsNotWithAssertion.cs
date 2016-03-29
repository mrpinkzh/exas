using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class StartsNotWithAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public StartsNotWithAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                !actual.StartsWith(expected),
                HarmonizeLineCount(
                    actual.ToValueString(), 
                    ComposeLog.Expected($"doesn't start with '{expected}'")));
        }
    }
}