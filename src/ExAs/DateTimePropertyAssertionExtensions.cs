using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.DateTimes;

namespace ExAs
{
    public static class DateTimePropertyAssertionExtensions
    {
        public static IAssert<T> IsOnSameDayAs<T>(this IAssertMember<T, DateTime> property, DateTime expectedDate)
        {
            return property.SetAssertion(new SameDayAssertion(expectedDate));
        }

        public static IAssert<T> IsCloseTo<T>(this IAssertMember<T, DateTime> property, DateTime expectedTime, TimeSpan plusMinusRange)
        {
            return property.SetAssertion(new CloseToAssertion(expectedTime, plusMinusRange));
        }
    }
}