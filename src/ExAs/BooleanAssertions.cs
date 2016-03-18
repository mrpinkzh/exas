using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Booleans;

namespace ExAs
{
    public static class BooleanAssertions
    {
        public static IAssert<T> IsTrue<T>(this IAssertMember<T, bool> member)
        {
            return member.SetAssertion(new IsTrueAssertion());
        }

        public static IAssert<T> IsFalse<T>(this IAssertMember<T, bool> member)
        {
            return member.SetAssertion(new IsFalseAssertion());
        }
    }
}