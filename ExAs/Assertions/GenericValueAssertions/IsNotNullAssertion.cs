using ExAs.Utils;

namespace ExAs.Assertions.GenericValueAssertions
{
    public class IsNotNullAssertion<T> : IAssertValue<T>
    {
        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(actual != null, actual.ToNullAwareString(), ComposeLog.Expected("not null"));
        }
    }
}