using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions
{
    public class OfTypeAssertion<T> : IAssertValue<T>
    {
        private readonly Type expected;

        public OfTypeAssertion(Type expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                expected.IsInstanceOfType(actual), 
                actual.ToValueString(), 
                ComposeLog.Expected($"of type {expected.Name}"));
        }
    }
}