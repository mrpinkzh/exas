using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Timespans
{
    public class IsNegativeAssertion : IAssertValue<TimeSpan>
    {
        public ValueAssertionResult AssertValue(TimeSpan actual)
        {
            return new ValueAssertionResult(actual < default(TimeSpan), actual.ToValueString(), ComposeLog.Expected("negative"));
        }
    }
}