using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Strings;

namespace ExAs
{
    public static class StringPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEqualTo<T>(this PropertyAssertion<T, string> property, string expected)
        {
            return property.SetAssertion(new EqualAssertion(expected));
        }

        public static ObjectAssertion<T> IsEmpty<T>(this PropertyAssertion<T, string> property)
        {
            return property.SetAssertion(new IsEmptyAssertion());
        }

        public static ObjectAssertion<T> IsNotEmpty<T>(this PropertyAssertion<T, string> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion());
        } 

        public static ObjectAssertion<T> HasLength<T>(this PropertyAssertion<T, string> property, int expectedLength)
        {
            return property.SetAssertion(new HasLengthAssertion(expectedLength));
        }
    }
}