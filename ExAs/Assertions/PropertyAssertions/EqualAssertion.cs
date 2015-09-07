using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions
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
                actual.ToNullAwareString().Apostrophed(), 
                ComposeLog.Expected(expected.ToNullAwareString().Apostrophed()));
        }
    }
}