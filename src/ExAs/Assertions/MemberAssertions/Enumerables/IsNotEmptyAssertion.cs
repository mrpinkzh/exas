using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class IsNotEmptyAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            var expectation = ComposeLog.Expected("not empty");
            if (actual == null)
                return new ValueAssertionResult(true, actual.ToValueString(), expectation);
            var actualList = actual.ToList();
            return new ValueAssertionResult(actualList.Any(), actualList.ToValueString(), expectation);
        }
    }
}