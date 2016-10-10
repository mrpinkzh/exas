using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasMinuteAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedMinute;

        public HasMinuteAssertion(int expectedMinute)
        {
            this.expectedMinute = expectedMinute;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Minute == expectedMinute,
                actual.ToExasDateTimeString(),
                ComposeLog.Expected($"has minute {expectedMinute}"));
        }
    }
}