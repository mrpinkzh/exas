using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasDayAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedDay;

        public HasDayAssertion(int expectedDay)
        {
            this.expectedDay = expectedDay;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Day == expectedDay,
                actual.ToExasDateString(),
                ComposeLog.Expected($"has day {expectedDay}"));
        }
    }
}