using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class EndsWithAssertion : IAssertValue<string>
    {
        private readonly string expectedEnd;

        public EndsWithAssertion(string expectedEnd)
        {
            this.expectedEnd = expectedEnd;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                actual.EndsWith_NullAware(expectedEnd),
                HarmonizeLineCount(
                    actual.ToValueString(),
                    $"(expected: ends with {expectedEnd.ToValueString()})"));
        }
    }
}