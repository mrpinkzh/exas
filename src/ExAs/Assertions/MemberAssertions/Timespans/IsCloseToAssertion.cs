using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.Timespans
{
    public class IsCloseToAssertion : IAssertValue<TimeSpan>
    {
        private readonly TimeSpan expected;
        private readonly TimeSpan range;

        public IsCloseToAssertion(TimeSpan expected, TimeSpan range)
        {
            this.expected = expected;
            this.range = range;
        }

        public ValueAssertionResult AssertValue(TimeSpan actual)
        {
            TimeSpan min = expected - range;
            TimeSpan max = expected + range;
            return new ValueAssertionResult(
                min <= actual && actual <= max, 
                actual.ToValueString(), 
                ComposeLog.Expected($"between {min} and {max}"));
        }
    }
}