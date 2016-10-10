using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasMonthAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedMonth;

        public HasMonthAssertion(int expectedMonth)
        {
            this.expectedMonth = expectedMonth;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Month == expectedMonth,
                actual.ToExasDateString(),
                ComposeLog.Expected($"has month {expectedMonth}"));
        }
    }
}