using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Numbers;

namespace ExAs
{
    public static class ShortPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEqualTo<T>(this IAssertMember<T, short> property, short expected)
        {
            return property.SetAssertion(new EqualAssertion<short>(expected));
        }

        public static ObjectAssertion<T> IsSmallerThan<T>(this IAssertMember<T, short> property, short expected)
        {
            return property.SetAssertion(new IsSmallerAssertion<short>(expected));
        }

        public static ObjectAssertion<T> IsBiggerThan<T>(this IAssertMember<T, short> property, short expected)
        {
            return property.SetAssertion(new IsBiggerAssertion<short>(expected));
        }

        public static ObjectAssertion<T> IsInRange<T>(this IAssertMember<T, short> property, short min, short max)
        {
            return property.SetAssertion(new InRangeAssertion<short>(min, max));
        }
    }
}