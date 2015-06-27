using System;
using System.Linq.Expressions;
using ExAs.Assertions.Generic;

namespace ExAs
{
    public static class PropertyIdentificationExtensions
    {
        public static GenericPropertyIdentifier<T, TProperty> Property<T, TProperty>(
            this ObjectAssertion<T> item,
            Expression<Func<T, TProperty>> propertyExpression)
        {
            var identifier = new GenericPropertyIdentifier<T, TProperty>(propertyExpression, item);
            item.AddPropertAssertion(identifier);
            return identifier;
        }
    }
}