using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class ContainsAssertion<TItem> : IAssertValue<IEnumerable<TItem>>
    {
        private readonly TItem[] expectedItems;

        public ContainsAssertion(params TItem[] expectedItems)
        {
            this.expectedItems = expectedItems;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TItem> actual)
        {
            var actualList = actual?.ToList();
            return new ValueAssertionResult(
                actualList.ContainsAny_NullAware(expectedItems),
                actualList.ToValueString(),
                ComposeLog.Expected($"contains {expectedItems.ToValueString()}"));
        }
    }
}