using System;
using System.Linq.Expressions;
using ExAs.Assertions;

namespace ExAs.Utils
{
    public static class ExasShortcutNotationExtensions
    {
        public static PropertyAssertion<T, TProperty> p<T, TProperty>(
            this ObjectAssertion<T> objectAssertion, 
            Expression<Func<T, TProperty>> expession)
        {
            var propertyAssertion = new PropertyAssertion<T, TProperty>(expession, objectAssertion);
            objectAssertion.AddPropertyAssertion(propertyAssertion);
            return propertyAssertion;
        }
    }
}