using System;
using System.Linq.Expressions;
using ExAs.Assertions;

namespace ExAs
{
    public static class ObjectAssertionExtensions
    {
        public static MemberAssertion<T, TProperty> Property<T, TProperty>(
            this IAssert<T> parent,
            Expression<Func<T, TProperty>> propertyExpression)
        {
            var propertyAssertion = new MemberAssertion<T, TProperty>(propertyExpression, parent);
            parent.AddMemberAssertion(propertyAssertion);
            return propertyAssertion;
        }
    }
}