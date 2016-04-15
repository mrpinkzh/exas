using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.Numbers
{
    public class GreaterThanAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {

        private readonly T expected;

        public GreaterThanAssertion(T expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                actual.CompareTo(expected) > 0, 
                actual.ToString(), 
                ComposeLog.Expected($"greater than {expected}"));
        }
    }
}