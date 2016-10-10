using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasHourAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedHour;

        public HasHourAssertion(int expectedHour)
        {
            this.expectedHour = expectedHour;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Hour == expectedHour,
                actual.ToExasDateTimeString(),
                ComposeLog.Expected($"has hour {expectedHour}"));
        }
    }
}