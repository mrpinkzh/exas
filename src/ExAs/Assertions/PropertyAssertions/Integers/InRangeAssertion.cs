using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Integers
{
    public class InRangeAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {
        private readonly T min, max;

        public InRangeAssertion(T min, T max)
        {
            this.max = max;
            this.min = min;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                min.CompareTo(actual) <= 0 && actual.CompareTo(max) <= 0, 
                actual.ToValueString(), 
                ComposeLog.Expected($"between {min} and {max}"));
        }
    }
}