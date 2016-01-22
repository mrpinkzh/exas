using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Strings;

namespace ExAs
{
    public static class StringPropertyAssertionExtensions
    {
        public static IAssert<T> IsEqualTo<T>(this IAssertMember<T, string> property, string expected)
        {
            return property.SetAssertion(new EqualAssertion(expected));
        }

        public static IAssert<T> IsEmpty<T>(this IAssertMember<T, string> property)
        {
            return property.SetAssertion(new IsEmptyAssertion());
        }

        public static IAssert<T> IsNotEmpty<T>(this IAssertMember<T, string> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion());
        } 

        public static IAssert<T> HasLength<T>(this IAssertMember<T, string> property, int expectedLength)
        {
            return property.SetAssertion(new HasLengthAssertion(expectedLength));
        }
    }
}