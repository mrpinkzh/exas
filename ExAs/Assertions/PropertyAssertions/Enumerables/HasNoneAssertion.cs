using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    public class HasNoneAssertion<T>
    {
        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            return new ValueAssertionResult(true, "Whatever".NewLine().Add("nextLine"), "Whenever");
        }
    }
}