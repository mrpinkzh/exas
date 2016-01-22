using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Numbers;

namespace ExAs
{
    public static class ComparablePropertyAssertionExtensions
    {
        public static IAssert<T> IsSmallerThan<T, TProperty>(this IAssertMember<T, TProperty> property, TProperty expected)
            where TProperty : IComparable<TProperty>
        {
            return property.SetAssertion(new IsSmallerAssertion<TProperty>(expected));
        }

        public static IAssert<T> IsBiggerThan<T, TProperty>(this IAssertMember<T, TProperty> property, TProperty expected)
            where TProperty : IComparable<TProperty>
        {
            return property.SetAssertion(new IsBiggerAssertion<TProperty>(expected));
        }

        public static IAssert<T> IsInRange<T, TProperty>(this IAssertMember<T, TProperty> property, TProperty min, TProperty max)
            where TProperty : IComparable<TProperty>
        {
            return property.SetAssertion(new InRangeAssertion<TProperty>(min, max));
        }
    }
}