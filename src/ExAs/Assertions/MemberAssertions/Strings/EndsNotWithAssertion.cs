using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class EndsNotWithAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public EndsNotWithAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                !actual.EndsWith(expected),
                HarmonizeLineCount(
                    actual.ToValueString(),
                    ComposeLog.Expected($"doesn't end with '{expected}'")));
        }
    }
}