using System;
using System.Linq.Expressions;
using ExAs.Results;

namespace ExAs.Assertions
{
    public class MemberAssertion<T, TMember> : IAssertMember<T, TMember>
    {
        private readonly Expression<Func<T, TMember>> memberExpression;
        private readonly IAssert<T> parent;
        private IAssertValue<TMember> assertion;

        public MemberAssertion(Expression<Func<T, TMember>> memberExpression, IAssert<T> parent)
        {
            this.memberExpression = memberExpression;
            this.parent = parent;
        }

        public IAssert<T> SetAssertion(IAssertValue<TMember> newAssertion)
        {
            assertion = newAssertion;
            return parent;
        }

        public MemberAssertionResult Assert(T actual)
        {
            return MemberAssertionFunctions.Assert(actual, memberExpression, assertion);
        }
    }
}