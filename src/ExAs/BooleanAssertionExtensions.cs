using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Booleans;

namespace ExAs
{
    public static class BooleanAssertionExtensions
    {
        public static ObjectAssertion<T> IsTrue<T>(this IAssertMember<T, bool> property)
        {
            return property.SetAssertion(new IsTrueAssertion());
        }

        public static ObjectAssertion<T> IsFalse<T>(this IAssertMember<T, bool> property)
        {
            return property.SetAssertion(new IsFalseAssertion());
        }
    }
}