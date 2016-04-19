using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class AfterAssertion : IAssertValue<DateTime>
    {
        private readonly DateTime expected;

        public AfterAssertion(DateTime expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual > expected,
                actual.ToExasDateTimeString(),
                ComposeLog.Expected($"after {expected.ToExasDateTimeString()}"));
        }
    }
}