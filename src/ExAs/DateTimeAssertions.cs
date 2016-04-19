using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.DateTimes;

namespace ExAs
{
    public static class DateTimeAssertions
    {
        public static IAssert<T> IsAfter<T>(this IAssertMember<T, DateTime> member, DateTime expected)
        {
            return member.SetAssertion(new AfterAssertion(expected));
        }

        public static IAssert<T> IsOnSameDayAs<T>(this IAssertMember<T, DateTime> member, DateTime expectedDate)
        {
            return member.SetAssertion(new SameDayAssertion(expectedDate));
        }

        public static IAssert<T> IsCloseTo<T>(this IAssertMember<T, DateTime> member, DateTime expectedTime, TimeSpan plusMinusRange)
        {
            return member.SetAssertion(new CloseToAssertion(expectedTime, plusMinusRange));
        }
    }
}