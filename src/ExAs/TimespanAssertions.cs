using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.MemberAssertions.Timespans;

namespace ExAs
{
    public static class TimespanAssertions
    {
        public static IAssert<T> IsPositive<T>(this IAssertMember<T, TimeSpan> member)
        {
            return member.SetAssertion(new IsPositiveAssertion());
        }

        public static IAssert<T> IsNegative<T>(this IAssertMember<T, TimeSpan> member)
        {
            return member.SetAssertion(new IsNegativeAssertion());
        }

        public static IAssert<T> IsNotEqualTo<T>(this IAssertMember<T, TimeSpan> member, TimeSpan expected)
        {
            return member.SetAssertion(new NotEqualAssertion<TimeSpan>(expected));
        }

        public static IAssert<T> IsCloseTo<T>(this IAssertMember<T, TimeSpan> member, TimeSpan expected, TimeSpan range)
        {
            return member.SetAssertion(new IsCloseToAssertion(expected, range));
        } 
    }
}