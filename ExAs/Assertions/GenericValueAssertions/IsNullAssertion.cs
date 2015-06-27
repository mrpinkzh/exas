using ExAs.Utils;

namespace ExAs.Assertions.GenericValueAssertions
{
    public class IsNullAssertion<T> : IAssertValue<T>
    {
        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(actual == null, actual.ToNullAwareString(), "(expected: null)");
        }
    }
}