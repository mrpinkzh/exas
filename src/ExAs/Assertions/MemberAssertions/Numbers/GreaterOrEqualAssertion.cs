using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Numbers
{
    public class GreaterOrEqualAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {
        private readonly T expected;

        public GreaterOrEqualAssertion(T expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                Compare_NullAware(actual, expected) >= 0, 
                actual.ToValueString(),
                ComposeLog.Expected($"greater or equal to {expected.ToValueString()}"));
        }

        private static int Compare_NullAware(T first, T other)
        {
            if (first == null)
            {
                if (other == null)
                    return 0;
                return other.CompareTo(first);
            }
            return first.CompareTo(other);
        }
    }
}