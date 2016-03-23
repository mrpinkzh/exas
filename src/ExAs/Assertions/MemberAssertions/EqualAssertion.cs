using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions
{
    public class EqualAssertion<T> : IAssertValue<T>
    {
        private readonly T expected;

        public EqualAssertion(T expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                Equals(expected, actual), 
                actual.ToValueString(), 
                ComposeLog.Expected(expected.ToValueString()));
        }
    }
}