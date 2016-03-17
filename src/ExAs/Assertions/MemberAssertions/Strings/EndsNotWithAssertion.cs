using ExAs.Results;
using ExAs.Utils;

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
            return new ValueAssertionResult(
                !actual.EndsWith(expected),
                actual.ToValueString(),
                ComposeLog.Expected($"doesn't end with '{expected}'"));
        }
    }
}