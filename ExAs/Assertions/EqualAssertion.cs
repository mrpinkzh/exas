using ExAs.Utils;

namespace ExAs.Assertions
{
    public class EqualAssertion : IAssertValue
    {
        private readonly object expected;

        public EqualAssertion(object expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(object actual)
        {
            return new ValueAssertionResult(
                Equals(expected, actual), 
                "'".Add(actual.ToNullAwareString()).Add("'"),
                "(expected: '".Add(expected.ToNullAwareString()).Add("')"));
        }
    }
}