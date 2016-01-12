using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;

namespace ExAs
{
    public static class NullableBooleanPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T>(this PropertyAssertion<T, bool?> property)
        {
            return property.SetAssertion(new IsNullAssertion<bool?>());
        }
    }
}