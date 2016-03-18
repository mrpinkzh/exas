using System;
using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Enumerables;

namespace ExAs
{
    public static class ReadOnlyCollectionAssertions
    {
        public static IAssert<T> IsEmpty<T, TElement>(this IAssertMember<T, IReadOnlyCollection<TElement>> member)
        {
            return member.SetAssertion(new IsEmptyAssertion<TElement>());
        }

        public static IAssert<T> IsNotEmpty<T, TElement>(this IAssertMember<T, IReadOnlyCollection<TElement>> member)
        {
            return member.SetAssertion(new IsNotEmptyAssertion<TElement>());
        }

        public static IAssert<T> HasCount<T, TElement>(this IAssertMember<T, IReadOnlyCollection<TElement>> member, int expected)
        {
            return member.SetAssertion(new HasCountAssertion<TElement>(expected));
        }

        public static IAssert<T> HasAny<T, TElement>(
            this IAssertMember<T, IReadOnlyCollection<TElement>> member, 
            Func<IAssert<TElement>, IAssert<TElement>> assertionFactory)
        {
            return member.SetAssertion(new HasAnyAssertion<TElement>(assertionFactory(new ObjectAssertion<TElement>())));
        }

        public static IAssert<T> HasNone<T, TElement>(
            this IAssertMember<T, IReadOnlyCollection<TElement>> member,
            Func<IAssert<TElement>, IAssert<TElement>> assertionFactory)
        {
            return member.SetAssertion(new HasNoneAssertion<TElement>(assertionFactory(new ObjectAssertion<TElement>())));
        }
    }
}