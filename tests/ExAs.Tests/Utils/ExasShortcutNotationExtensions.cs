using System;
using System.Linq.Expressions;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Booleans;
using ExAs.Results;

namespace ExAs.Utils
{
    public static class ExasShortcutNotationExtensions
    {
        public static MemberAssertion<T, TMember> p<T, TMember>(
            this IAssert<T> assertion, 
            Expression<Func<T, TMember>> expession)
        {
            var memberAssertion = new MemberAssertion<T, TMember>(expession, assertion);
            assertion.AddMemberAssertion(memberAssertion);
            return memberAssertion;
        }

        public static IAssert<ObjectAssertionResult> Fullfills(
            this IAssert<ObjectAssertionResult> instance, 
            bool succeeded, 
            string log, 
            string expectation)
        {
            IAssertValue<bool> succeededAssertion = succeeded ? (IAssertValue<bool>) new IsTrueAssertion() : new IsFalseAssertion();
            return instance.p(x => x.succeeded)  .SetAssertion(succeededAssertion)
                           .p(x => x.actual)        .IsEqualTo(log)
                           .p(x => x.expectation).IsEqualTo(expectation);
        } 
    }
}