using System;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Integers;

namespace ExAs
{
    public static class ComparablePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsSmallerThan<T, TProperty>(this PropertyAssertion<T, TProperty> property, TProperty expected)
            where TProperty : IComparable<TProperty>
        {
            return property.SetAssertion(new IsSmallerAssertion<TProperty>(expected));
        }
    }
}