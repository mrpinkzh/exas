using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class IsEmptyAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            var expectationString = ComposeLog.Expected("empty enumerable");

            if (actual == null)
                return new ValueAssertionResult(false, actual.ToValueString(), expectationString);

            List<TElement> elements = actual.ToList();
            return new ValueAssertionResult(
                !elements.Any(),
                elements.ToValueString(),
                expectationString);
        }
    }
}