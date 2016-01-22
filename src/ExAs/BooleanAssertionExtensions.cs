using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Booleans;

namespace ExAs
{
    public static class BooleanAssertionExtensions
    {
        public static IAssert<T> IsTrue<T>(this IAssertMember<T, bool> property)
        {
            return property.SetAssertion(new IsTrueAssertion());
        }

        public static IAssert<T> IsFalse<T>(this IAssertMember<T, bool> property)
        {
            return property.SetAssertion(new IsFalseAssertion());
        }
    }
}