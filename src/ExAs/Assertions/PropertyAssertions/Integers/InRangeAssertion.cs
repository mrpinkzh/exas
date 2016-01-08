using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Integers
{
    public class InRangeAssertion : IAssertValue<int>
    {
        private readonly int min, max;

        public InRangeAssertion(int min, int max)
        {
            this.max = max;
            this.min = min;
        }

        public ValueAssertionResult AssertValue(int actual)
        {
            return new ValueAssertionResult(
                min <= actual && actual <= max, 
                actual.ToValueString(), 
                ComposeLog.Expected($"between {min} and {max}"));
        }
    }
}