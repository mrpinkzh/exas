using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions
{
    public class NotEqualAssertion<T> : IAssertValue<T>
    {
        private readonly TimeSpan expected;

        public NotEqualAssertion(TimeSpan expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                !Equals(actual, expected), 
                actual.ToValueString(), 
                ComposeLog.Expected($"not {expected}"));
        }
    }
}