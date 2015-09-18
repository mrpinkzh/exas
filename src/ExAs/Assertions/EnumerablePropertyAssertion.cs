using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExAs.Results;

namespace ExAs.Assertions
{
    public class EnumerablePropertyAssertion<T, TElement> : IAssertOnProperty<T>
    {
        private readonly Expression<Func<T, IEnumerable<TElement>>> propertExpression;
        private readonly ObjectAssertion<T> parent;
        private IAssertValue<IEnumerable<TElement>> childAssertion;

        public EnumerablePropertyAssertion(Expression<Func<T, IEnumerable<TElement>>> propertExpression, ObjectAssertion<T> parent)
        {
            this.propertExpression = propertExpression;
            this.parent = parent;
        }

        public ObjectAssertion<T> SetAssertion(IAssertValue<IEnumerable<TElement>> assertion)
        {
            childAssertion = assertion;
            return parent;
        }

        public PropertyAssertionResult Assert(T actual)
        {
            return PropertyAssertionFunctions.Assert(actual, propertExpression, childAssertion);
        }
    }
}