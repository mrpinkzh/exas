using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class ContainsNoNullsAssertion<T> : IAssertValue<IEnumerable<T>>
    {
        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            var actualList = actual.ToReadOnly();
            return new ValueAssertionResult(
                !actualList.Any_NullAware(x => x == null),
                actualList.ToValueString(),
                ComposeLog.Expected("doesn't contain nulls"));
        }
    }
}