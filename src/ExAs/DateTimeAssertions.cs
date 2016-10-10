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

        public static IAssert<T> IsBefore<T>(this IAssertMember<T, DateTime> member, DateTime expected)
        {
            return member.SetAssertion(new BeforeAssertion(expected));
        }

        public static IAssert<T> IsOnSameDayAs<T>(this IAssertMember<T, DateTime> member, DateTime expectedDate)
        {
            return member.SetAssertion(new SameDayAssertion(expectedDate));
        }

        public static IAssert<T> IsInSameYearAs<T>(this IAssertMember<T, DateTime> member, DateTime expectedDate)
        {
            return member.SetAssertion(new SameYearAssertion(expectedDate));
        }

        public static IAssert<T> IsCloseTo<T>(this IAssertMember<T, DateTime> member, DateTime expectedTime, TimeSpan plusMinusRange)
        {
            return member.SetAssertion(new CloseToAssertion(expectedTime, plusMinusRange));
        }

        public static IAssert<T> HasYear<T>(this IAssertMember<T, DateTime> member, int expectedYear)
        {
            return member.SetAssertion(new HasYearAssertion(expectedYear));
        }

        public static IAssert<T> HasMonth<T>(this IAssertMember<T, DateTime> member, int expectedMonth)
        {
            return member.SetAssertion(new HasMonthAssertion(expectedMonth));
        }

        public static IAssert<T> HasDay<T>(this IAssertMember<T, DateTime> member, int expectedDay)
        {
            return member.SetAssertion(new HasDayAssertion(expectedDay));
        }

        public static IAssert<T> HasHour<T>(this IAssertMember<T, DateTime> member, int expectedHour)
        {
            return member.SetAssertion(new HasHourAssertion(expectedHour));
        }

        public static IAssert<T> HasMinute<T>(this IAssertMember<T, DateTime> member, int expectedMinute)
        {
            return member.SetAssertion(new HasMinuteAssertion(expectedMinute));
        }
    }
}