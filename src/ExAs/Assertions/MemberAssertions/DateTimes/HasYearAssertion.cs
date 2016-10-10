using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
{
    public class HasYearAssertion : IAssertValue<DateTime>
    {
        private readonly int expectedYear;

        public HasYearAssertion(int expectedYear)
        {
            this.expectedYear = expectedYear;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            return new ValueAssertionResult(
                actual.Year == expectedYear, 
                actual.ToExasDateString(), 
                ComposeLog.Expected($"has year {expectedYear}"));
        }
    }
}