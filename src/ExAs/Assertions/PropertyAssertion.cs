using System;
using System.Linq.Expressions;
using ExAs.Results;

namespace ExAs.Assertions
{
    public class PropertyAssertion<T, TMember> : IAssertMember<T, TMember>
    {
        private readonly Expression<Func<T, TMember>> genericPropertyExpression;
        private readonly IAssert<T> parent;
        private IAssertValue<TMember> assertion;

        public PropertyAssertion(Expression<Func<T, TMember>> genericPropertyExpression, IAssert<T> parent)
        {
            this.genericPropertyExpression = genericPropertyExpression;
            this.parent = parent;
        }

        public IAssert<T> SetAssertion(IAssertValue<TMember> newAssertion)
        {
            assertion = newAssertion;
            return parent;
        }

        public PropertyAssertionResult Assert(T actual)
        {
            return PropertyAssertionFunctions.Assert(actual, genericPropertyExpression, assertion);
        }
    }
}