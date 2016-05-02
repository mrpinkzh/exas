using System;
using System.Linq.Expressions;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions
{
    public class PredicateAssertion<T> : IAssertValue<T>, IAssert<T>
    {
        private readonly Expression<Func<T, bool>> predicate;

        public PredicateAssertion(Expression<Func<T, bool>> predicate)
        {
            this.predicate = predicate;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                this.predicate.Compile()(actual),
                actual.ToValueString(),
                ComposeLog.Expected($"none full filling predicated '{predicate}'"));
        }

        public void AddMemberAssertion(IAssertMemberOf<T> memberAssertion)
        {
        }

        public Result Assert(T actual)
        {
            ValueAssertionResult result = this.AssertValue(actual);
            return new Result(result.succeeded, result.actualValueString, result.expectationString);
        }

        public IAssert<T> IsNotNull()
        {
            return null;
        }

        public IAssert<T> IsNull()
        {
            return null;
        }
    }
}