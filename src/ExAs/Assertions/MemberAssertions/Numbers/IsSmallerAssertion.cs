using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions.Numbers
{
    public class IsSmallerAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {
        private readonly T expected;

        public IsSmallerAssertion(T expected)
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