using ExAs.Results;
using ExAs.Utils;

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
            return new ValueAssertionResult(
                !actual.Contains_NullAware(expected),
                actual.ToValueString(),
                ComposeLog.Expected($"doesn't contain {expected.ToValueString()}"));
        }
    }
}