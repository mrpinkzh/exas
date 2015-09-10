using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    public class IsEmptyAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            List<TElement> elements = actual.ToList();
            return new ValueAssertionResult(
                !elements.Any(),
                elements.ToValueString(),
                ComposeLog.Expected("empty enumerable"));
        }
    }
}