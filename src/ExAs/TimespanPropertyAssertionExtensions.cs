using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.MemberAssertions.Timespans;

namespace ExAs
{
    public static class TimespanPropertyAssertionExtensions
    {
        public static IAssert<T> IsPositive<T>(this IAssertMember<T, TimeSpan> property)
        {
            return property.SetAssertion(new IsPositiveAssertion());
        }

        public static IAssert<T> IsNegative<T>(this IAssertMember<T, TimeSpan> property)
        {
            return property.SetAssertion(new IsNegativeAssertion());
        }

        public static IAssert<T> IsNotEqualTo<T>(this IAssertMember<T, TimeSpan> property, TimeSpan expected)
        {
            return property.SetAssertion(new NotEqualAssertion<TimeSpan>(expected));
        }

        public static IAssert<T> IsCloseTo<T>(this IAssertMember<T, TimeSpan> property, TimeSpan expected, TimeSpan range)
        {
            return property.SetAssertion(new IsCloseToAssertion(expected, range));
        } 
    }
}