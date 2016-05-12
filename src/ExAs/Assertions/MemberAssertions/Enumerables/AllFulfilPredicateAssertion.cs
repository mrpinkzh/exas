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
    public class AllFulfilPredicateAssertion<T> : IAssertValue<IEnumerable<T>>
    {
        private readonly Expression<Func<T, bool>> predicate;

        public AllFulfilPredicateAssertion(Expression<Func<T, bool>> predicate)
        {
            this.predicate = predicate;
        }

        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            var actualList = actual.ToReadOnly();
            bool result = predicate != null && actualList != null && actualList.Any() && actualList.All(predicate.Compile());
            return new ValueAssertionResult(
                result,
                actualList.ToValueString(),
                ComposeLog.Expected($"all fulfil {predicate.ToValueString()}"));
        }
    }
}