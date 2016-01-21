using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Booleans;

namespace ExAs
{
    public static class NullableBooleanPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new IsNullAssertion<bool?>());
        }

        public static ObjectAssertion<T> IsNotNull<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new IsNotNullAssertion<bool?>());
        }

        public static ObjectAssertion<T> IsTrue<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new NullableAssertionAdapter<bool>(new IsTrueAssertion()));
        }

        public static ObjectAssertion<T> IsFalse<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new NullableAssertionAdapter<bool>(new IsFalseAssertion()));
        }
    }
}