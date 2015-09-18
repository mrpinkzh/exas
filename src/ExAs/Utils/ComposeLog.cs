namespace ExAs.Utils
{
    public static class ComposeLog
    {
        public static string Expected(string expectedValue)
        {
            return "(expected: ".Add(expectedValue).Add(")");
        }
    }
}