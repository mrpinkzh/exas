using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.Booleans
{
    public class IsTrueAssertion : IAssertValue<bool>
    {
        public ValueAssertionResult AssertValue(bool actual)
        {
            return new ValueAssertionResult(actual, actual.ToString(), ComposeLog.Expected("True"));
        }
    }
}