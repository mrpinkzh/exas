using System;
using System.Linq.Expressions;
using ExAs.Results;

namespace ExAs.Assertions
{
    public class PropertyAssertion<T, TMember> : IAssertOnProperty<T>, IAssertMember<T, TMember>
    {
        private readonly Expression<Func<T, TMember>> genericPropertyExpression;
        private readonly ObjectAssertion<T> parent;
        private IAssertValue<TMember> assertion;

        public PropertyAssertion(Expression<Func<T, TMember>> genericPropertyExpression, ObjectAssertion<T> parent)
        {
            this.genericPropertyExpression = genericPropertyExpression;
            this.parent = parent;
        }

        public ObjectAssertion<T> SetAssertion(IAssertValue<TMember> newAssertion)
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