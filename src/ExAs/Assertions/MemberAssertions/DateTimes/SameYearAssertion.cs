using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class SameYearAssertion : IAssertValue<DateTime>
    {
        private readonly DateTime expected;

        public SameYearAssertion(DateTime expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Year == expected.Year, 
                actual.ToExasDateString(), 
                ComposeLog.Expected($"in same year as {expected.ToExasDateString()}"));
        }
    }
}