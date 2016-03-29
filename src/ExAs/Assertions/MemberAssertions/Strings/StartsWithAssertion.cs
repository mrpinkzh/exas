using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class StartsWithAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public StartsWithAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                actual.StartsWith_NullAware(expected),
                HarmonizeLineCount(
                    actual.ToValueString(), 
                    $"(expected: starts with {expected.ToValueString()})"));
        }
    }
}