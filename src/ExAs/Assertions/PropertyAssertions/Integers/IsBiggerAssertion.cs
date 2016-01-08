using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Integers
{
    public class IsBiggerAssertion : IAssertValue<int>
    {
        private readonly int expected;

        public IsBiggerAssertion(int expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(int actual)
        {
            return new ValueAssertionResult(
                actual > expected, 
                actual.ToString(), 
                ComposeLog.Expected($"bigger than {expected}"));
        }
    }
}