using System;
using System.Linq.Expressions;
using ExAs.Utils;
using ToText.Core;

namespace ExAs.Assertions.Generic
{
    public class PropertyAssertion<T>
    {
        private readonly Expression<Func<T, object>> propertyExpression;
        private readonly ObjectAssertion<T> parent;
        private IAssertValue assertion;

        public PropertyAssertion(Expression<Func<T, object>> propertyExpression, ObjectAssertion<T> parent)
        {
            this.parent = parent;
            this.propertyExpression = propertyExpression;
        }

        public ObjectAssertion<T> EqualTo(object expected)
        {
            assertion = new EqualAssertion(expected);
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
            object value = propertyExpression.Compile()(actual);
            ValueAssertionResult result = assertion.AssertValue(value);
            if (result.succeeded)
                return new PropertyAssertionResult(propertyName, result);
            return new PropertyAssertionResult(propertyName, result);
        }
    }
}