using System;
using System.Linq.Expressions;
using ExAs.Assertions;

namespace ExAs
{
    public static class ObjectAssertionExtensions
    {
        public static MemberAssertion<T, TMember> Member<T, TMember>(
            this IAssert<T> parent,
            Expression<Func<T, TMember>> memberExpression)
        {
            var memberAssertion = new MemberAssertion<T, TMember>(memberExpression, parent);
            parent.AddMemberAssertion(memberAssertion);
            return memberAssertion;
        }

        [Obsolete]
        public static MemberAssertion<T, TMember> Property<T, TMember>(
            this IAssert<T> parent,
            Expression<Func<T, TMember>> memberExpression)
        {
            var memberAssertion = new MemberAssertion<T, TMember>(memberExpression, parent);
            parent.AddMemberAssertion(memberAssertion);
            return memberAssertion;
        }
    }
}