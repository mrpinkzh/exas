using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.MemberAssertions.Numbers;
using ExAs.Assertions.ObjectAssertions;

namespace ExAs
{
    public static class NullableIntegerPropertyAssertionExtensions
    {
        public static IAssert<T> IsNull<T>(this IAssertMember<T, int?> property)
        {
            return property.SetAssertion(new IsNullAssertion<int?>());
        }

        public static IAssert<T> IsNotNull<T>(this IAssertMember<T, int?> property)
        {
            return property.SetAssertion(new IsNotNullAssertion<int?>());
        }

        public static IAssert<T> IsSmallerThan<T>(this IAssertMember<T, int?> property, int expected)
        {
            return property.SetAssertion(new NullableAssertionAdapter<int>(new IsSmallerAssertion<int>(expected)));
        }

        public static IAssert<T> IsBiggerThan<T>(this IAssertMember<T, int?> property, int expected)
        {
            return property.SetAssertion(new NullableAssertionAdapter<int>(new IsBiggerAssertion<int>(expected)));
        }

        public static IAssert<T> IsInRange<T>(this IAssertMember<T, int?> property, int min, int max)
        {
            return property.SetAssertion(new NullableAssertionAdapter<int>(new InRangeAssertion<int>(min, max)));
        }
    }
}