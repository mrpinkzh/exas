using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class BeforeAssertion : IAssertValue<DateTime>
    {
        private readonly DateTime expected;

        public BeforeAssertion(DateTime expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual < expected,
                actual.ToExasDateTimeString(),
                ComposeLog.Expected($"before {expected.ToExasDateTimeString()}"));
        }
    }
}