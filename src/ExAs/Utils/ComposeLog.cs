using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Utils
{
    public static class ComposeLog
    {
        public static string Expected(string expectationString)
        {
            return $"{HangingIndent("(expected: ", expectationString)})";
        }
    }
}