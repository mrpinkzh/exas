using System;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Timespans;

namespace ExAs
{
    public static class TimespanPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsPositive<T>(this PropertyAssertion<T, TimeSpan> property)
        {
            return property.SetAssertion(new IsPositiveAssertion());
        }
    }
}