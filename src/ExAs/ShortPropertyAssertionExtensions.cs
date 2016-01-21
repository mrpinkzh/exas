using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Numbers;

namespace ExAs
{
    public static class ShortPropertyAssertionExtensions
    {
        public static IAssert<T> IsEqualTo<T>(this IAssertMember<T, short> property, short expected)
        {
            return property.SetAssertion(new EqualAssertion<short>(expected));
        }

        public static IAssert<T> IsSmallerThan<T>(this IAssertMember<T, short> property, short expected)
        {
            return property.SetAssertion(new IsSmallerAssertion<short>(expected));
        }

        public static IAssert<T> IsBiggerThan<T>(this IAssertMember<T, short> property, short expected)
        {
            return property.SetAssertion(new IsBiggerAssertion<short>(expected));
        }

        public static IAssert<T> IsInRange<T>(this IAssertMember<T, short> property, short min, short max)
        {
            return property.SetAssertion(new InRangeAssertion<short>(min, max));
        }
    }
}