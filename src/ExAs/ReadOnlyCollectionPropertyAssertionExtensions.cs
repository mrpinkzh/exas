using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class ReadOnlyCollectionPropertyAssertionExtensions
    {
        public static IAssert<T> IsEmpty<T, TPropertyElement>(this IAssertMember<T, IReadOnlyCollection<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }

        public static IAssert<T> IsNotEmpty<T, TPropertyElement>(this IAssertMember<T, IReadOnlyCollection<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion<TPropertyElement>());
        }

        public static IAssert<T> HasCount<T, TPropertyElement>(this IAssertMember<T, IReadOnlyCollection<TPropertyElement>> property, int expected)
        {
            return property.SetAssertion(new HasCountAssertion<TPropertyElement>(expected));
        }

        public static IAssert<T> HasAny<T, TPropertyElement>(this IAssertMember<T, IReadOnlyCollection<TPropertyElement>> property, 
                                                                     Func<IAssert<TPropertyElement>, IAssert<TPropertyElement>> assertionFactory)
        {
            return property.SetAssertion(new HasAnyAssertion<TPropertyElement>(assertionFactory(new ObjectAssertion<TPropertyElement>())));
        }

        public static IAssert<T> HasNone<T, TPropertyElement>(this IAssertMember<T, IReadOnlyCollection<TPropertyElement>> property,
                                                                      Func<IAssert<TPropertyElement>, IAssert<TPropertyElement>> assertionFactory)
        {
            return property.SetAssertion(new HasNoneAssertion<TPropertyElement>(assertionFactory(new ObjectAssertion<TPropertyElement>())));
        }
    }
}