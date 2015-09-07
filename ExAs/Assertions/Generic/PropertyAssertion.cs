using System;
using System.Linq.Expressions;
using ExAs.Assertions.GenericValueAssertions;
using ToText.Core;

namespace ExAs.Assertions.Generic
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

        public ObjectAssertion<T> EqualTo(TProperty expected)
        {
            assertion = new EqualAssertion<TProperty>(expected);
            return parent;
        }

        public ObjectAssertion<T> Fulfills(Func<ObjectAssertion<TProperty>, ObjectAssertion<TProperty>> assertionFunc)
        {
            ObjectAssertion<TProperty> objectAssertion = assertionFunc(new ObjectAssertion<TProperty>());
            assertion = new GenericAssertToAssertValueAdapter<TProperty>(objectAssertion);
            return parent;
        }

        public PropertyAssertionResult Assert(T actual)
        {
            string propertyName = genericPropertyExpression.ExtractMemberName();
            if (assertion == null)
                return new PropertyAssertionResult(propertyName, 
                                                   new ValueAssertionResult(false, 
                                                                            "no assertion specified", 
                                                                            string.Empty));
            TProperty value = genericPropertyExpression.Compile()(actual);
            ValueAssertionResult result = assertion.AssertValue(value);
            if (result.succeeded)
                return new PropertyAssertionResult(propertyName, result);
            return new PropertyAssertionResult(propertyName, result);
        }
    }
}