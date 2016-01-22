using System;
using System.Linq.Expressions;
using ExAs.Assertions;

namespace ExAs
{
    public static class ObjectAssertionExtensions
    {
        public static MemberAssertion<T, TMember> Member<T, TMember>(
            this IAssert<T> parent,
            Expression<Func<T, TMember>> propertyExpression)
        {
            var propertyAssertion = new MemberAssertion<T, TMember>(propertyExpression, parent);
            parent.AddMemberAssertion(propertyAssertion);
            return propertyAssertion;
        }

        [Obsolete]
        public static MemberAssertion<T, TMember> Property<T, TMember>(
            this IAssert<T> parent,
            Expression<Func<T, TMember>> propertyExpression)
        {
            var propertyAssertion = new MemberAssertion<T, TMember>(propertyExpression, parent);
            parent.AddMemberAssertion(propertyAssertion);
            return propertyAssertion;
        }
    }
}