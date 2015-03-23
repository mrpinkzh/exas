using System;
using System.Linq.Expressions;
using ExAs.Utils;
using ToText.Core;

namespace ExAs.Assertions.Generic
{
    public class PropertyAssertion<T> : Assertion<T>
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

        public override AssertionResult Assert(T actual)
        {
            if (assertion == null)
                return new AssertionResult(false, "no assertion specified");
            object value = propertyExpression.Compile()(actual);
            AssertionResult result = assertion.Assert(value);
            string memberName = propertyExpression.ExtractMemberName();
            string log = memberName.Add(" = ").Add(result.log);
            if (result.succeeded)
                return new AssertionResult(true, log);
            return new AssertionResult(false, log);
        }
    }
}