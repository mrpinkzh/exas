using System;
using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Assertions.PropertyAssertions;

namespace ExAs
{
    public static class PropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T, TProperty>(this PropertyAssertion<T, TProperty> property)
            where TProperty : class
        {
            return property.SetAssertion(new IsNullAssertion<TProperty>());
        }

        public static ObjectAssertion<T> EqualTo<T, TProperty>(this PropertyAssertion<T, TProperty> property, TProperty expected)
        {
            return property.SetAssertion(new EqualAssertion<TProperty>(expected));
        }

        public static ObjectAssertion<T> Fulfills<T, TProperty>(
            this PropertyAssertion<T, TProperty> property,
            Func<ObjectAssertion<TProperty>, ObjectAssertion<TProperty>> assertionFunc)
        {
            return
                property.SetAssertion(
                    new AssertToAssertValueAdapter<TProperty>(assertionFunc(new ObjectAssertion<TProperty>())));
        }
    }
}