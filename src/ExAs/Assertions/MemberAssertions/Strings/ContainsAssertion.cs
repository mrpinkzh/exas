using ExAs.Results;
using ExAs.Utils;

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
            return new ValueAssertionResult(
                actual.Contains_NullAware(expected), 
                actual.ToValueString(),
                ComposeLog.Expected($"contains {expected.ToValueString()}"));
        }

        private static bool Contains(string actual, string expected)
        {
            if (actual == null) return false;
            if (expected == null) return false;
            return actual.Contains(expected);
        }
    }
}