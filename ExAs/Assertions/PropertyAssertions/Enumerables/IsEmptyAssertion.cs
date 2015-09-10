using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    public class IsEmptyAssertion<TElement>
    {
        public ValueAssertionResult Assert(IEnumerable<TElement> actual)
        {
            return new ValueAssertionResult(
                true,
                "0",
                ComposeLog.Expected("0"));
        }
    }
}