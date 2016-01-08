using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class ReadOnlyCollectionPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEmpty<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> IsNotEmpty<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion<TPropertyElement>());
        }   
    }
}