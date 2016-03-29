using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class ContainsNotAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public ContainsNotAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                !actual.Contains_NullAware(expected),
                HarmonizeLineCount(
                    actual.ToValueString(),
                    ComposeLog.Expected($"doesn't contain {expected.ToValueString()}")));
        }
    }
}