using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Strings;

namespace ExAs
{
    public static class StringPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEqualTo<T>(this IAssertMember<T, string> property, string expected)
        {
            return property.SetAssertion(new EqualAssertion(expected));
        }

        public static ObjectAssertion<T> IsEmpty<T>(this IAssertMember<T, string> property)
        {
            return property.SetAssertion(new IsEmptyAssertion());
        }

        public static ObjectAssertion<T> IsNotEmpty<T>(this IAssertMember<T, string> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion());
        } 

        public static ObjectAssertion<T> HasLength<T>(this IAssertMember<T, string> property, int expectedLength)
        {
            return property.SetAssertion(new HasLengthAssertion(expectedLength));
        }
    }
}