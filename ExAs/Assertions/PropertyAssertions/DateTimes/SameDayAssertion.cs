using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.DateTimes
{
    public class SameDayAssertion : IAssertValue<DateTime>
    {
        private readonly DateTime expected;

        public SameDayAssertion(DateTime expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Date == expected.Date, 
                actual.ToShortDateString(), 
                ComposeLog.Expected(expected.ToShortDateString()));
        }
    }
}