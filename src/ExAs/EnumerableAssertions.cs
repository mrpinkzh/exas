using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Enumerables;

namespace ExAs
{
    public static class EnumerableAssertions
    {
        public static IAssert<T> IsEmpty<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member)
        {
            return member.SetAssertion(new IsEmptyAssertion<TElement>());
        }

        public static IAssert<T> IsNotEmpty<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member)
        {
            return member.SetAssertion(new IsNotEmptyAssertion<TElement>());
        }

        public static IAssert<T> HasAny<T, TElement>(
            this IAssertMember<T, IEnumerable<TElement>> member,
            Func<IAssert<TElement>, IAssert<TElement>> assertion)
        {
            return member.SetAssertion(new HasAnyAssertion<TElement>(assertion(new ObjectAssertion<TElement>())));
        }

        public static IAssert<T> HasNone<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Func<IAssert<TElement>, IAssert<TElement>> assertion)
        {
            return member.SetAssertion(new HasNoneAssertion<TElement>(assertion(new ObjectAssertion<TElement>())));
        }

        public static IAssert<T> HasNone<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Expression<Func<TElement, bool>> predicate)
        {
            return member.SetAssertion(new NoneFulfilsPredicateAssertion<TElement>(predicate));
        }

        public static IAssert<T> HasCount<T, TMember>(this IAssertMember<T, IEnumerable<TMember>> member, int expected)
        {
            return member.SetAssertion(new HasCountAssertion<TMember>(expected));
        }

        public static IAssert<T> Contains<T, TItem>(this IAssertMember<T, IEnumerable<TItem>> member, params TItem[] expectedItems)
        {
            return member.SetAssertion(new ContainsAssertion<TItem>(expectedItems));
        }

        public static IAssert<T> DoesntContain<T, TItem>(this IAssertMember<T, IEnumerable<TItem>> member, params TItem[] expectedItems)
        {
            return member.SetAssertion(new ContainsNotAssertion<TItem>(expectedItems));
        }

        public static IAssert<T> IsEqualTo<T, TItem>(this IAssertMember<T, IList<TItem>> member, params TItem[] expectedItems)
        {
            return member.SetAssertion(new Assertions.MemberAssertions.Lists.EqualAssertion<TItem>(expectedItems));
        }

        public static IAssert<T> IsEqualTo<T, TItem>(this IAssertMember<T, IList<TItem>> member, IList<TItem> expectedItems)
        {
            return member.SetAssertion(new Assertions.MemberAssertions.Lists.EqualAssertion<TItem>(expectedItems));
        } 
    }
}