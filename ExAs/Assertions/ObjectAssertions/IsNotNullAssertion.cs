using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.ObjectAssertions
{
    public class IsNotNullAssertion<T> : IAssertValue<T>
    {
        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(actual != null, actual.ToValueString(), ComposeLog.Expected("not null"));
        }
    }
}