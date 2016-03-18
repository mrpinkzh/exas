using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class StartsWithAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public StartsWithAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return new ValueAssertionResult(
                actual.StartsWith_NullAware(expected), 
                actual.ToValueString(), 
                $"(expected: starts with '{expected}')");
        }
    }
}