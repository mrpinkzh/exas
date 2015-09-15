using System;
using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class EnumerablePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsNull<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsNullAssertion<IEnumerable<TPropertyElement>>());
        }

        public static ObjectAssertion<T> IsNotNull<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsNotNullAssertion<IEnumerable<TPropertyElement>>());
        }

        public static ObjectAssertion<T> IsEmpty<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> IsNotEmpty<T, TPropertyElement>(this EnumerablePropertyAssertion<T, TPropertyElement> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> HasAny<T, TPropertyElement>(
            this EnumerablePropertyAssertion<T, TPropertyElement> property,
            Func<ObjectAssertion<TPropertyElement>, ObjectAssertion<TPropertyElement>> assertionFunc)
        {
            return property.SetAssertion(new HasAnyAssertion<TPropertyElement>(assertionFunc(new ObjectAssertion<TPropertyElement>())));
        }

        public static ObjectAssertion<T> HasNone<T, TPropertyElement>(
            this EnumerablePropertyAssertion<T, TPropertyElement> property,
            Func<ObjectAssertion<TPropertyElement>, ObjectAssertion<TPropertyElement>> assertionFunc)
        {
            return property.SetAssertion(new HasNoneAssertion<TPropertyElement>(assertionFunc(new ObjectAssertion<TPropertyElement>())));
        }
    }
}