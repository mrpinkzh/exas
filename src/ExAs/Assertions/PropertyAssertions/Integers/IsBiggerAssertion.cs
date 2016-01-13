using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Integers
{
    public class IsBiggerAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {

        private readonly T expected;

        public IsBiggerAssertion(T expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                actual.CompareTo(expected) > 0, 
                actual.ToString(), 
                ComposeLog.Expected($"bigger than {expected}"));
        }
    }
}