using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Timespans
{
    public class IsNegativeAssertion : IAssertValue<TimeSpan>
    {
        public ValueAssertionResult AssertValue(TimeSpan actual)
        {
            return new ValueAssertionResult(actual < default(TimeSpan), actual.ToValueString(), ComposeLog.Expected("negative"));
        }
    }
}