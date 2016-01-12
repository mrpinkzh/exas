using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;

namespace ExAs
{
    public static class NullableIntegerPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T>(this PropertyAssertion<T, int?> property)
        {
            return property.SetAssertion(new IsNullAssertion<int?>());
        } 
    }
}