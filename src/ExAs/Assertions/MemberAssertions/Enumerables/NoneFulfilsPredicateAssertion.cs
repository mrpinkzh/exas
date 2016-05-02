using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class NoneFulfilsPredicateAssertion<T> : IAssertValue<IEnumerable<T>>
    {
        private readonly Expression<Func<T, bool>> predicate;

        public NoneFulfilsPredicateAssertion(Expression<Func<T, bool>> predicate)
        {
            this.predicate = predicate;
        }

        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            var actualList = actual.ToReadOnly();
            return new ValueAssertionResult(
                !Any_NullAware(actualList, predicate),
                actualList.ToValueString(),
                ComposeLog.Expected($"none fulfils {predicate.ToValueString()}"));
        }

        private static bool Any_NullAware(IEnumerable<T> actual, Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return true;
            if (actual == null)
                return false;
            return actual.Any(predicate.Compile());
        }
    }
}