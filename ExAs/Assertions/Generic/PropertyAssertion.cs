using System;
using System.Linq.Expressions;
using ExAs.Utils;

namespace ExAs.Assertions.Generic
{
    public class PropertyAssertion<T> : Assertion<T>
    {
        private readonly Expression<Func<T, object>> propertyExpression;
        private readonly DataAssertion<T> parent;
        private Assertion assertion;

        public PropertyAssertion(Expression<Func<T, object>> propertyExpression, DataAssertion<T> parent)
        {
            this.parent = parent;
            this.propertyExpression = propertyExpression;
        }

        public DataAssertion<T> EqualTo(object expected)
        {
            assertion = new EqualAssertion(expected);
            return parent;
        }

        public override AssertionResult Assert(T actual)
        {
            if (assertion == null)
                return new AssertionResult(false, actual.ToNullAwareString(), this);
            object value = propertyExpression.Compile()(actual);
            AssertionResult result = assertion.Assert(value);
            if (result.succeeded)
                return new AssertionResult(true, actual.ToNullAwareString(), assertion);
            return new AssertionResult(false, actual.ToNullAwareString(), assertion);
        }
    }
}