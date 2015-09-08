using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Strings;

namespace ExAs
{
    public static class StringPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEmpty<T>(this PropertyAssertion<T, string> property)
        {
            return property.SetAssertion(new IsEmptyAssertion());
        }
    }
}