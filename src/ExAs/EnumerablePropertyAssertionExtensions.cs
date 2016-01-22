using System;
using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Enumerables;

namespace ExAs
{
    public static class EnumerablePropertyAssertionExtensions
    {
        public static IAssert<T> IsEmpty<T, TPropertyElement>(this IAssertMember<T, IEnumerable<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }

        public static IAssert<T> IsNotEmpty<T, TPropertyElement>(this IAssertMember<T, IEnumerable<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion<TPropertyElement>());
        }

        public static IAssert<T> HasAny<T, TPropertyElement>(
            this IAssertMember<T, IEnumerable<TPropertyElement>> property,
            Func<IAssert<TPropertyElement>, IAssert<TPropertyElement>> assertionFunc)
        {
            return property.SetAssertion(new HasAnyAssertion<TPropertyElement>(assertionFunc(new ObjectAssertion<TPropertyElement>())));
        }

        public static IAssert<T> HasNone<T, TPropertyElement>(
            this IAssertMember<T, IEnumerable<TPropertyElement>> property,
            Func<IAssert<TPropertyElement>, IAssert<TPropertyElement>> assertionFunc)
        {
            return property.SetAssertion(new HasNoneAssertion<TPropertyElement>(assertionFunc(new ObjectAssertion<TPropertyElement>())));
        }

        public static IAssert<T> HasCount<T, TProperyElement>(this IAssertMember<T, IEnumerable<TProperyElement>> property, int expected)
        {
            return property.SetAssertion(new HasCountAssertion<TProperyElement>(expected));
        }
    }
}