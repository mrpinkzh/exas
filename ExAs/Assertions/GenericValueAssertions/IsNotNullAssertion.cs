using ExAs.Utils;

namespace ExAs.Assertions.GenericValueAssertions
{
    public class IsNotNullAssertion<T> : IAssertValue<T>
    {
        public ValueAssertionResult AssertValue(T actual)
        {
            var actualString = actual.ToNullAwareString();
            var expectationString = ComposeLog.Expected("not null");
            if (actual != null)
                return new ValueAssertionResult(true, actualString, expectationString);
            return new ValueAssertionResult(false, actualString, expectationString);
        }
    }
}