using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Booleans;

namespace ExAs
{
    public static class BooleanAssertionExtensions
    {
        public static ObjectAssertion<T> IsTrue<T>(this PropertyAssertion<T, bool> property)
        {
            return property.SetAssertion(new IsTrueAssertion());
        }

        public static ObjectAssertion<T> IsFalse<T>(this PropertyAssertion<T, bool> property)
        {
            return property.SetAssertion(new IsFalseAssertion());
        }
    }
}