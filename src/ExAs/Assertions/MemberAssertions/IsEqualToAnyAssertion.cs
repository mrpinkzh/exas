using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions
{
    public class IsEqualToAnyAssertion<TValue> : IAssertValue<TValue>
    {
        private readonly TValue[] expectedValues;

        public IsEqualToAnyAssertion(params TValue[] expectedValues)
        {
            this.expectedValues = expectedValues;
        }

        public ValueAssertionResult AssertValue(TValue actual)
        {
            var isEqualToAny = expectedValues?.Contains(actual) ?? false;

            return new ValueAssertionResult(
                isEqualToAny,
                actual.ToValueString(),
                ComposeLog.Expected($"is one of {expectedValues?.ToValueString()}")
            );
        }
    }
}