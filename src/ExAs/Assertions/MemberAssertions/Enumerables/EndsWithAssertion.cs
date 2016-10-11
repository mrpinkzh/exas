using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class EndsWithAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly TElement expected;

        public EndsWithAssertion(TElement expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            List<TElement> actualList = actual?.ToList();
            bool result = actualList != null
                          && actualList.Any()
                          && Equals(actualList.Last(), expected);
            return new ValueAssertionResult(
                result,
                actualList.ToValueString(),
                ComposeLog.Expected($"ends with {expected.ToValueString()}"));
        }
    }
}