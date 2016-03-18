namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public static class OutputExtensions
    {
        public static string Matches(this int amount)
        {
            if (amount == 1)
                return "<1 match>";
            return string.Format("<{0} matches>", amount);
        }
        
    }
}