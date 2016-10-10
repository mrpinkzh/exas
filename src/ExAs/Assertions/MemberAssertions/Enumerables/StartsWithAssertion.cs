using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class StartsWithAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly TElement expected;

        public StartsWithAssertion(TElement expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            List<TElement> actuaList = actual?.ToList();
            bool result = actuaList != null
                       && actuaList.Any()
                       && Equals(actuaList.First(), expected);
            return new ValueAssertionResult(
                result,
                actuaList.ToValueString(),
                ComposeLog.Expected($"starts with {expected.ToValueString()}"));
        }
    }
}