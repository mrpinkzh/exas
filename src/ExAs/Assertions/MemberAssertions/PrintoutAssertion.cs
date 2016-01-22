using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions
{
    public class PrintoutAssertion<T> : IAssertValue<T>
    {
        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(true, actual.ToValueString(), " ");
        }
    }
}