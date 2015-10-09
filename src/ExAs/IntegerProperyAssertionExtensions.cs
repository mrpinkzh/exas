using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Integers;

namespace ExAs
{
    public static class IntegerProperyAssertionExtensions
    {
        public static ObjectAssertion<T> IsSmallerThan<T>(this PropertyAssertion<T, int> property, int expected)
        {
            return property.SetAssertion(new IsSmallerAssertion(expected));
        } 
    }
}