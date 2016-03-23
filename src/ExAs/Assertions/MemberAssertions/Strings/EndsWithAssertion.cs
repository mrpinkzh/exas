using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class EndsWithAssertion : IAssertValue<string>
    {
        private readonly string expectedEnd;

        public EndsWithAssertion(string expectedEnd)
        {
            this.expectedEnd = expectedEnd;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            return new ValueAssertionResult(
                actual.EndsWith_NullAware(expectedEnd), 
                actual.ToValueString(), 
                $"(expected: ends with {expectedEnd.ToValueString()})");
        }
    }
}