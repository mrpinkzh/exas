using System.Collections;
using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;

namespace ExAs
{
    public static class EnumerablePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEmpty<T, TElement>(this PropertyAssertion<T, IEnumerable<TElement>> property)
        {
            return property.SetAssertion(new PrintoutAssertion<IEnumerable<TElement>>());
        }
    }
}