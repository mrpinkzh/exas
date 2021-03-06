﻿using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.DateTimes
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
                actual.ToExasDateString(),
                ComposeLog.Expected($"on same day as {expected.ToExasDateString()}"));
        }
    }
}