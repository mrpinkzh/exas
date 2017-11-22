using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class HasCountAssertion<T> : IAssertValue<IEnumerable<T>>
    {
        private readonly int expected;

        public HasCountAssertion(int expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            List<T> actualValues = actual.ToList();
            return new ValueAssertionResult(
                actualValues.Count == expected, 
                actualValues.ToCountString(), 
                ComposeLog.Expected(ExpectedMessage()));
        }

        private string ExpectedMessage()
        {
	        string typeName = typeof(T).Name;
	        if (expected == 1)
                return $"{expected} {typeName}";
            return $"{expected} {typeName}s";
        }
    }
}