using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Numbers
{
    public class GreaterOrEqualAssertion : IAssertValue<int>
    {
        private int expected;

        public GreaterOrEqualAssertion(int expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(int actual)
        {
            return new ValueAssertionResult(
                actual >= expected, 
                actual.ToValueString(),
                ComposeLog.Expected($"greater or equal to {expected}"));
        }
    }
}