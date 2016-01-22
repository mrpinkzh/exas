using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.ObjectAssertions;

namespace ExAs
{
    public static class PropertyAssertionExtensions
    {
        public static IAssert<T> IsNull<T, TProperty>(this IAssertMember<T, TProperty> property)
            where TProperty : class
        {
            return property.SetAssertion(new IsNullAssertion<TProperty>());
        }

        public static IAssert<T> IsNotNull<T, TProperty>(this IAssertMember<T, TProperty> property)
            where TProperty : class
        {
            return property.SetAssertion(new IsNotNullAssertion<TProperty>());
        }

        public static IAssert<T> IsEqualTo<T, TProperty>(this IAssertMember<T, TProperty> property, TProperty expected)
        {
            return property.SetAssertion(new EqualAssertion<TProperty>(expected));
        }

        public static IAssert<T> Fulfills<T, TProperty>(
            this IAssertMember<T, TProperty> property,
            Func<IAssert<TProperty>, IAssert<TProperty>> assertionFunc)
        {
            return
                property.SetAssertion(
                    new AssertToAssertValueAdapter<TProperty>(assertionFunc(new ObjectAssertion<TProperty>())));
        }
    }
}