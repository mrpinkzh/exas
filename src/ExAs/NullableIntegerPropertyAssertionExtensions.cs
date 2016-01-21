using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Numbers;

namespace ExAs
{
    public static class NullableIntegerPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T>(this IAssertMember<T, int?> property)
        {
            return property.SetAssertion(new IsNullAssertion<int?>());
        }

        public static ObjectAssertion<T> IsNotNull<T>(this IAssertMember<T, int?> property)
        {
            return property.SetAssertion(new IsNotNullAssertion<int?>());
        }

        public static ObjectAssertion<T> IsSmallerThan<T>(this IAssertMember<T, int?> property, int expected)
        {
            return property.SetAssertion(new NullableAssertionAdapter<int>(new IsSmallerAssertion<int>(expected)));
        }

        public static ObjectAssertion<T> IsBiggerThan<T>(this IAssertMember<T, int?> property, int expected)
        {
            return property.SetAssertion(new NullableAssertionAdapter<int>(new IsBiggerAssertion<int>(expected)));
        }

        public static ObjectAssertion<T> IsInRange<T>(this IAssertMember<T, int?> property, int min, int max)
        {
            return property.SetAssertion(new NullableAssertionAdapter<int>(new InRangeAssertion<int>(min, max)));
        }
    }
}