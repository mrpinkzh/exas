using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Strings;

namespace ExAs
{
    public static class StringAssertions
    {
        public static IAssert<T> IsEqualTo<T>(this IAssertMember<T, string> member, string expected)
        {
            return member.SetAssertion(new EqualAssertion(expected));
        }

        public static IAssert<T> IsEmpty<T>(this IAssertMember<T, string> member)
        {
            return member.SetAssertion(new IsEmptyAssertion());
        }

        public static IAssert<T> IsNotEmpty<T>(this IAssertMember<T, string> member)
        {
            return member.SetAssertion(new IsNotEmptyAssertion());
        } 

        public static IAssert<T> HasLength<T>(this IAssertMember<T, string> member, int expectedLength)
        {
            return member.SetAssertion(new HasLengthAssertion(expectedLength));
        }

        public static IAssert<T> Contains<T>(this IAssertMember<T, string> member, string containedString)
        {
            return member.SetAssertion(new ContainsStringAssertion(containedString));
        }
    }
}