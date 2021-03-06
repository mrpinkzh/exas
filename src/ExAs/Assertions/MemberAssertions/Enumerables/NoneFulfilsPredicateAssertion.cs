﻿using System;
using System.Collections.Generic;
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
            bool succeeded = predicate != null && !actualList.Any_NullAware(predicate);
            return new ValueAssertionResult(
                succeeded,
                actualList.ToValueString(),
                ComposeLog.Expected($"none fulfils {predicate.ToValueString()}"));
        }
    }
}