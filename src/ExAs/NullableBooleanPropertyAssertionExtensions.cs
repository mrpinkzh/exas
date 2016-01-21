using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Booleans;

namespace ExAs
{
    public static class NullableBooleanPropertyAssertionExtensions
    {
        public static IAssert<T> IsNull<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new IsNullAssertion<bool?>());
        }

        public static IAssert<T> IsNotNull<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new IsNotNullAssertion<bool?>());
        }

        public static IAssert<T> IsTrue<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new NullableAssertionAdapter<bool>(new IsTrueAssertion()));
        }

        public static IAssert<T> IsFalse<T>(this IAssertMember<T, bool?> property)
        {
            return property.SetAssertion(new NullableAssertionAdapter<bool>(new IsFalseAssertion()));
        }
    }
}