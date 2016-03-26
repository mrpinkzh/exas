using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class IsEmptyAssertion : IAssertValue<string>
    {
        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                IsEmpty(actual),
                HarmonizeLineCount(actual.ToValueString(), ComposeLog.Expected("empty string")));
        }

        private static bool IsEmpty(string actual)
        {
            return actual != null && !actual.Any();
        }
    }
}