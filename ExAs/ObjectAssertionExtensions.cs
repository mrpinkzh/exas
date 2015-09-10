using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExAs.Assertions;

namespace ExAs
{
    public static class ObjectAssertionExtensions
    {
        public static PropertyAssertion<T, TProperty> Property<T, TProperty>(
            this ObjectAssertion<T> parent,
            Expression<Func<T, TProperty>> propertyExpression)
        {
            var propertyAssertion = new PropertyAssertion<T, TProperty>(propertyExpression, parent);
            parent.AddPropertyAssertion(propertyAssertion);
            return propertyAssertion;
        }

        public static EnumerablePropertyAssertion<T, TPropertyElement> Property<T, TPropertyElement>(
            this ObjectAssertion<T> parent,
            Expression<Func<T, IEnumerable<TPropertyElement>>> propertyExpression)
        {
            var propertyAssertion = new EnumerablePropertyAssertion<T, TPropertyElement>(propertyExpression, parent);
            parent.AddPropertyAssertion(propertyAssertion);
            return propertyAssertion;
        }
    }
}