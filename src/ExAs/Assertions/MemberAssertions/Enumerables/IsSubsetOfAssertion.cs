using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class IsSubsetOfAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly IEnumerable<TElement> expectedSuperset;

        public IsSubsetOfAssertion(IEnumerable<TElement> expectedSuperset)
        {
            this.expectedSuperset = expectedSuperset;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            var actualList = actual?.ToList();
            bool result = actualList != null 
                          && expectedSuperset != null
                          && actualList.All(e => expectedSuperset.Contains(e));
            return new ValueAssertionResult(
                result,
                actualList.ToValueString(),
                ComposeLog.Expected($"is subset of {expectedSuperset.ToValueString()}"));
        }
    }
}