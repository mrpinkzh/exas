using System.Linq;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Strings
{
    public class IsEmptyAssertion : IAssertValue<string>
    {
        public ValueAssertionResult AssertValue(string actual)
        {
            return new ValueAssertionResult(IsEmpty(actual), actual.ToNullAwareString(), ComposeLog.Expected("empty string"));
        }

        private static bool IsEmpty(string actual)
        {
            return actual != null && !actual.Any();
        }
    }
}