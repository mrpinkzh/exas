using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class HasLengthAssertion : IAssertValue<string>
    {
        private readonly int expected;

        public HasLengthAssertion(int expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                actual?.Length == expected,
                HarmonizeLineCount(
                    $"{actual.ToValueString()}[{actual?.Length ?? 0}]", 
                    ComposeLog.Expected($"length {expected}")));
        }
    }
}