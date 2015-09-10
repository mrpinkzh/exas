using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class EnumerablePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEmpty<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }
    }
}