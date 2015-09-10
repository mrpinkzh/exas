using System;
using System.Linq.Expressions;
using ExAs.Results;
using ToText.Core;

namespace ExAs.Assertions
{
    public class PropertyAssertion<T, TProperty> : IAssertOnProperty<T>
    {
        private readonly Expression<Func<T, TProperty>> genericPropertyExpression;
        private readonly ObjectAssertion<T> parent;
        private IAssertValue<TProperty> assertion;

        public PropertyAssertion(Expression<Func<T, TProperty>> genericPropertyExpression, ObjectAssertion<T> parent)
        {
            this.genericPropertyExpression = genericPropertyExpression;
            this.parent = parent;
        }

        public ObjectAssertion<T> SetAssertion(IAssertValue<TProperty> newAssertion)
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