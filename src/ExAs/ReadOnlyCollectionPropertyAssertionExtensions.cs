using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExAs.Assertions;
using ExAs.Assertions.PropertyAssertions.Enumerables;

namespace ExAs
{
    public static class ReadOnlyCollectionPropertyAssertionExtensions
    {
        public static ObjectAssertion<T> IsEmpty<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> IsNotEmpty<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property)
        {
            return property.SetAssertion(new IsNotEmptyAssertion<TPropertyElement>());
        }

        public static ObjectAssertion<T> HasCount<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property, int expected)
        {
            return property.SetAssertion(new HasCountAssertion<TPropertyElement>(expected));
        }

        public static ObjectAssertion<T> HasAny<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property, 
                                                                     Func<ObjectAssertion<TPropertyElement>, ObjectAssertion<TPropertyElement>> assertionFactory)
        {
            return property.SetAssertion(new HasAnyAssertion<TPropertyElement>(assertionFactory(new ObjectAssertion<TPropertyElement>())));
        }

        public static ObjectAssertion<T> HasNone<T, TPropertyElement>(this PropertyAssertion<T, IReadOnlyCollection<TPropertyElement>> property,
                                                                      Func<ObjectAssertion<TPropertyElement>, ObjectAssertion<TPropertyElement>> assertionFactory)
        {
            return property.SetAssertion(new HasNoneAssertion<TPropertyElement>(assertionFactory(new ObjectAssertion<TPropertyElement>())));
        }
    }
}