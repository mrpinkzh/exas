using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Strings
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
            return new ValueAssertionResult(actual?.Length == expected, actual.ToValueString(), ComposeLog.Expected($"length {expected}"));
        }
    }
}