using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.MemberAssertions.Numbers;

namespace ExAs
{
    public static class ShortAssertions
    {
        public static IAssert<T> IsEqualTo<T>(this IAssertMember<T, short> member, short expected)
        {
            return member.SetAssertion(new EqualAssertion<short>(expected));
        }

        public static IAssert<T> IsSmallerThan<T>(this IAssertMember<T, short> member, short expected)
        {
            return member.SetAssertion(new IsSmallerAssertion<short>(expected));
        }

        public static IAssert<T> IsGreaterThan<T>(this IAssertMember<T, short> member, short expected)
        {
            return member.SetAssertion(new GreaterThanAssertion<short>(expected));
        }

        public static IAssert<T> IsInRange<T>(this IAssertMember<T, short> member, short min, short max)
        {
            return member.SetAssertion(new InRangeAssertion<short>(min, max));
        }
    }
}