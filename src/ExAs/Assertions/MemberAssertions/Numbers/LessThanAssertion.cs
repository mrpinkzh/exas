using System;
using ExAs.Results;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Numbers
{
    public class LessThanAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {
        private readonly T expected;

        public LessThanAssertion(T expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                actual.CompareTo(expected) < 0, 
                actual.ToValueString(),
                $"(expected: smaller than {expected})");
        }
    }
}