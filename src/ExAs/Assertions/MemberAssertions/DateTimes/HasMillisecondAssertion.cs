using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasMillisecondAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedMilliseconds;

        public HasMillisecondAssertion(int expectedMilliseconds)
        {
            this.expectedMilliseconds = expectedMilliseconds;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Millisecond == expectedMilliseconds,
                actual.ToExasDatetimeStringWithMilliseconds(),
                ComposeLog.Expected($"has millisecond {expectedMilliseconds}"));
        }
    }
}