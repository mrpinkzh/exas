using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class EnumerablePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsNullAssertion<IEnumerable<TPropertyElement>>());
        }

        public static ObjectAssertion<T> IsEmpty<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }
    }
}