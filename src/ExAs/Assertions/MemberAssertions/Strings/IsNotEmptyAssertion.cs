using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    public class IsNotEmptyAssertion : IAssertValue<string>
    {
        public ValueAssertionResult AssertValue(string actual)
        {
            return ValueAssertionResult.Create(
                actual != string.Empty,
                HarmonizeLineCount(
                    actual.ToValueString(),
                    ComposeLog.Expected("not empty")));
        }
    }
}