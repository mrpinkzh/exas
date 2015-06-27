using ExAs.Assertions.Generic;
using ExAs.Assertions.GenericValueAssertions;

namespace ExAs
{
    public static class GenericPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T, TProperty>(
            this GenericPropertyIdentifier<T, TProperty> propertyIdentifier)
        {
            return propertyIdentifier.SetAssertion(new IsNullAssertion<TProperty>());
        } 
    }
}