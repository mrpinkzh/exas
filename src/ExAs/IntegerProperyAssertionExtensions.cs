using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;

namespace ExAs
{
    public static class IntegerProperyAssertionExtensions
    {
        public static ObjectAssertion<T> IsSmallerThan<T>(this PropertyAssertion<T, int> property, int expected)
        {
            return property.SetAssertion(new PrintoutAssertion<int>());
        } 
    }
}