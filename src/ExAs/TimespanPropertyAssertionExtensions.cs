using System;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Timespans;

namespace ExAs
{
    public static class TimespanPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsPositive<T>(this PropertyAssertion<T, TimeSpan> property)
        {
            return property.SetAssertion(new IsPositiveAssertion());
        }

        public static ObjectAssertion<T> IsNegative<T>(this PropertyAssertion<T, TimeSpan> property)
        {
            return property.SetAssertion(new IsNegativeAssertion());
        }

        public static ObjectAssertion<T> IsNotEqualTo<T>(this PropertyAssertion<T, TimeSpan> property, TimeSpan expected)
        {
            return property.SetAssertion(new NotEqualAssertion<TimeSpan>(expected));
        }

        public static ObjectAssertion<T> IsCloseTo<T>(this PropertyAssertion<T, TimeSpan> property, TimeSpan expected, TimeSpan range)
        {
            return property.SetAssertion(new IsCloseToAssertion(expected, range));
        } 
    }
}