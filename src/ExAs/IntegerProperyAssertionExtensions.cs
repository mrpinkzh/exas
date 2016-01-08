using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Integers;

namespace ExAs
{
    public static class IntegerProperyAssertionExtensions
    {
        public static ObjectAssertion<T> IsSmallerThan<T>(this PropertyAssertion<T, int> property, int expected)
        {
            return property.SetAssertion(new IsSmallerAssertion(expected));
        }

        public static ObjectAssertion<T> IsBiggerThan<T>(this PropertyAssertion<T, int> property, int expected)
        {
            return property.SetAssertion(new IsBiggerAssertion(expected));
        }

        public static ObjectAssertion<T> IsInRange<T>(this PropertyAssertion<T, int> property, int min, int max)
        {
            return property.SetAssertion(new InRangeAssertion(min, max));
        }
    }
}