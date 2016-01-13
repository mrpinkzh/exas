using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Integers;

namespace ExAs
{
    public static class IntegerProperyAssertionExtensions
    {
        public static ObjectAssertion<T> IsInRange<T>(this PropertyAssertion<T, int> property, int min, int max)
        {
            return property.SetAssertion(new InRangeAssertion(min, max));
        }
    }
}