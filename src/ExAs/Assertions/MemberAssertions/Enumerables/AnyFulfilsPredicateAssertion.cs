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
    public class AnyFulfilsPredicateAssertion<T> : IAssertValue<IEnumerable<T>>
    {
        private readonly Expression<Func<T, bool>> predicate;

        public AnyFulfilsPredicateAssertion(Expression<Func<T, bool>> predicate)
        {
            this.predicate = predicate;
        }

        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            var actualList = actual.ToReadOnly();
            return new ValueAssertionResult(
                actualList.Any_NullAware(predicate),
                actualList.ToValueString(),
                ComposeLog.Expected($"any fulfils {predicate.ToValueString()}"));
        }
    }
}