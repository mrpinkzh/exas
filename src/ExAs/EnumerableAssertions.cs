using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.MemberAssertions.Enumerables;
using ExAs.Utils.SystemExtensions;

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

        public static IAssert<T> HasAny<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Func<IAssert<TElement>, IAssert<TElement>> assertion)
        {
            return member.SetAssertion(new HasAnyAssertion<TElement>(assertion(new ObjectAssertion<TElement>())));
        }

	    public static IAssert<T> HasAny<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, params Func<IAssert<TElement>, IAssert<TElement>>[] assertions)
	    {
		    return member.SetAssertion(new HasAnyMultipleAssertion<TElement>(assertions.Map(assertion => assertion(new ObjectAssertion<TElement>()))));
	    }

	    public static IAssert<T> HasAnyPredicate<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Expression<Func<TElement, bool>> predicate)
        {
            return member.SetAssertion(new AnyFulfilsPredicateAssertion<TElement>(predicate));
        }

	    public static IAssert<T> HasNone<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Func<IAssert<TElement>, IAssert<TElement>> assertion)
        {
            return member.SetAssertion(new HasNoneAssertion<TElement>(assertion(new ObjectAssertion<TElement>())));
        }

        public static IAssert<T> HasNonePredicate<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Expression<Func<TElement, bool>> predicate)
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

        public static IAssert<T> DoesntContainNulls<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member)
        {
            return member.SetAssertion(new ContainsNoNullsAssertion<TElement>());
        }

        public static IAssert<T> IsEqualTo<T, TItem>(this IAssertMember<T, IList<TItem>> member, params TItem[] expectedItems)
        {
            return member.SetAssertion(new Assertions.MemberAssertions.Lists.EqualAssertion<TItem>(expectedItems));
        }

        public static IAssert<T> IsEqualTo<T, TItem>(this IAssertMember<T, IList<TItem>> member, IList<TItem> expectedItems)
        {
            return member.SetAssertion(new Assertions.MemberAssertions.Lists.EqualAssertion<TItem>(expectedItems));
        }

        public static IAssert<T> IsEquivalentTo<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, params TElement[] expected)
        {
            return member.SetAssertion(new EquivalentAssertion<TElement>(expected));
        }

        public static IAssert<T> IsEquivalentTo<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, IEnumerable<TElement> expected)
        {
            return member.SetAssertion(new EquivalentAssertion<TElement>(expected));
        }

        public static IAssert<T> FulfilAll<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, Expression<Func<TElement, bool>> expected)
        {
            return member.SetAssertion(new AllFulfilPredicateAssertion<TElement>(expected));
        }

        public static IAssert<T> StartsWith<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, TElement expected)
        {
            return member.SetAssertion(new StartsWithAssertion<TElement>(expected));
        }

        public static IAssert<T> EndsWith<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, TElement expected)
        {
            return member.SetAssertion(new EndsWithAssertion<TElement>(expected));
        }

        public static IAssert<T> IsSubsetOf<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, params TElement[] expectedSuperset)
        {
            return member.SetAssertion(new IsSubsetOfAssertion<TElement>(expectedSuperset));
        }

        public static IAssert<T> IsSubsetOf<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, IEnumerable<TElement> expectedSuperset)
        {
            return member.SetAssertion(new IsSubsetOfAssertion<TElement>(expectedSuperset));
        }

        public static IAssert<T> ContainsInOrder<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, params TElement[] expectedElements)
        {
            return member.SetAssertion(new ContainsInOrderAssertion<TElement>(expectedElements?.ToList()));
        }

        public static IAssert<T> ContainsInOrder<T, TElement>(this IAssertMember<T, IEnumerable<TElement>> member, IList<TElement> expectedElements)
        {
            return member.SetAssertion(new ContainsInOrderAssertion<TElement>(expectedElements));
        }
    }
}