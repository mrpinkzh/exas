using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class ContainsAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public ContainsAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                actual.Contains_NullAware(expected),
                HarmonizeLineCount(
                    actual.ToValueString(), 
                    ComposeLog.Expected($"contains {expected.ToValueString()}")));
        }
    }
}