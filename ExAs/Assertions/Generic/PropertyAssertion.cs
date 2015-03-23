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
        private IAssert assertion;

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
            string memberName = propertyExpression.ExtractMemberName();
            if (assertion == null)
                return new PropertyAssertionResult(false, "no assertion specified", memberName);
            object value = propertyExpression.Compile()(actual);
            AssertionResult result = assertion.Assert(value);
            if (result.succeeded)
                return new PropertyAssertionResult(true, result.log, memberName);
            return new PropertyAssertionResult(false, result.log, memberName);
        }
    }
}