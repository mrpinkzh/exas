using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Integers;

namespace ExAs
{
    public static class ShortPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEqualTo<T>(this PropertyAssertion<T, short> property, short expected)
        {
            return property.SetAssertion(new EqualAssertion<short>(expected));
        }

        public static ObjectAssertion<T> IsSmallerThan<T>(this PropertyAssertion<T, short> property, short expected)
        {
            return property.SetAssertion(new IsSmallerAssertion<short>(expected));
        }
    }
}