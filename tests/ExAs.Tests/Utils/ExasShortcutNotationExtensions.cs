using System;
using System.Linq.Expressions;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Booleans;
using ExAs.Results;

namespace ExAs.Utils
{
    public static class ExasShortcutNotationExtensions
    {
        public static PropertyAssertion<T, TProperty> p<T, TProperty>(
            this IAssert<T> objectAssertion, 
            Expression<Func<T, TProperty>> expession)
        {
            var propertyAssertion = new PropertyAssertion<T, TProperty>(expession, objectAssertion);
            objectAssertion.AddMemberAssertion(propertyAssertion);
            return propertyAssertion;
        }

        public static IAssert<ObjectAssertionResult> Fullfills(
            this IAssert<ObjectAssertionResult> instance, 
            bool succeeded, 
            string log, 
            string expectation)
        {
            IAssertValue<bool> succeededAssertion = succeeded ? (IAssertValue<bool>) new IsTrueAssertion() : new IsFalseAssertion();
            return instance.p(x => x.succeeded)  .SetAssertion(succeededAssertion)
                           .p(x => x.log)        .IsEqualTo(log)
                           .p(x => x.expectation).IsEqualTo(expectation);
        } 
    }
}