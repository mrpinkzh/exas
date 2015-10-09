using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Integers
{
    public class IsSmallerAssertion : IAssertValue<int>
    {
        private readonly int expected;

        public IsSmallerAssertion(int expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(int actual)
        {
            return new ValueAssertionResult(
                actual < expected, 
                actual.ToValueString(), 
                string.Format("(expected: smaller than {0})", expected));
        }
    }
}