using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Strings
{
    public class IsNotEmptyAssertion : IAssertValue<string>
    {
        public ValueAssertionResult AssertValue(string actual)
        {
            return new ValueAssertionResult(
                actual != string.Empty, 
                actual.ToValueString(), 
                ComposeLog.Expected("not empty"));
        }
    }
}