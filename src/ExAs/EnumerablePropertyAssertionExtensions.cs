using System;
using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class EnumerablePropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEmpty<T, TPropertyElement>(this IAssertMember<T, IEnumerable<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> IsNotEmpty<T, TPropertyElement>(this IAssertMember<T, IEnumerable<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> HasAny<T, TPropertyElement>(
            this IAssertMember<T, IEnumerable<TPropertyElement>> property,
            Func<ObjectAssertion<TPropertyElement>, ObjectAssertion<TPropertyElement>> assertionFunc)
        {
            return property.SetAssertion(new HasAnyAssertion<TPropertyElement>(assertionFunc(new ObjectAssertion<TPropertyElement>())));
        }

        public static ObjectAssertion<T> HasNone<T, TPropertyElement>(
            this IAssertMember<T, IEnumerable<TPropertyElement>> property,
            Func<ObjectAssertion<TPropertyElement>, ObjectAssertion<TPropertyElement>> assertionFunc)
        {
            return property.SetAssertion(new HasNoneAssertion<TPropertyElement>(assertionFunc(new ObjectAssertion<TPropertyElement>())));
        }

        public static ObjectAssertion<T> HasCount<T, TProperyElement>(this IAssertMember<T, IEnumerable<TProperyElement>> property, int expected)
        {
            return property.SetAssertion(new HasCountAssertion<TProperyElement>(expected));
        }
    }
}