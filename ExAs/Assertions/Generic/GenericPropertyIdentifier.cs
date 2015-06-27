using System;
using System.Linq.Expressions;
using ExAs.Assertions.GenericValueAssertions;
using ToText.Core;

namespace ExAs.Assertions.Generic
{
    public class GenericPropertyIdentifier<T, TProperty> : IAssertOnProperty<T>
    {
        private readonly Expression<Func<T, TProperty>> propertyExpression; 
        private readonly ObjectAssertion<T> parent;
        private IAssertValue<TProperty> assertion;

        public GenericPropertyIdentifier(Expression<Func<T, TProperty>> propertyExpression, ObjectAssertion<T> parent)
        {
            this.propertyExpression = propertyExpression;
            this.parent = parent;
        }

        public ObjectAssertion<T> SetAssertion(IAssertValue<TProperty> newAssertion)
        {
            assertion = newAssertion;
            return parent;
        }

        public PropertyAssertionResult Assert(T actual)
        {
            string propertyName = propertyExpression.ExtractMemberName();
            if (assertion == null)
                return new PropertyAssertionResult(propertyName,
                                                   new ValueAssertionResult(false,
                                                                            "no assertion specified",
                                                                            string.Empty));
            TProperty value = propertyExpression.Compile()(actual);
            ValueAssertionResult result = assertion.AssertValue(value);
            if (result.succeeded)
                return new PropertyAssertionResult(propertyName, result);
            return new PropertyAssertionResult(propertyName, result);
        }
    }
}