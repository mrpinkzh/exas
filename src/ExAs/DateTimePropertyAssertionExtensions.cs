using System;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.DateTimes;

namespace ExAs
{
    public static class DateTimePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsOnSameDayAs<T>(this IAssertMember<T, DateTime> property, DateTime expectedDate)
        {
            return property.SetAssertion(new SameDayAssertion(expectedDate));
        }

        public static ObjectAssertion<T> IsCloseTo<T>(this IAssertMember<T, DateTime> property, DateTime expectedTime, TimeSpan plusMinusRange)
        {
            return property.SetAssertion(new CloseToAssertion(expectedTime, plusMinusRange));
        }
    }
}