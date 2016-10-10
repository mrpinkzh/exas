using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasSecondAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedSecond;

        public HasSecondAssertion(int expectedSecond)
        {
            this.expectedSecond = expectedSecond;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Second == expectedSecond,
                actual.ToExasDateTimeString(),
                ComposeLog.Expected($"has second {expectedSecond}"));
        }
    }
}