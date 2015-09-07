using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExAs.Assertions.GenericValueAssertions;
using ExAs.Utils;

namespace ExAs.Assertions.Generic
{
    public class ObjectAssertion<T> : IAssert<T>
    {
        private readonly List<IAssertOnProperty<T>> propertyAssertions; 
        private IsNotNullAssertion<T> isNotNullAssertion;
        private IsNullAssertion<T> isNullAssertion;

        public ObjectAssertion()
        {
            propertyAssertions = new List<IAssertOnProperty<T>>();
        }

        public ObjectAssertion<T> IsNotNull()
        {
            isNotNullAssertion = new IsNotNullAssertion<T>();
            return this;
        }

        public ObjectAssertion<T> IsNull()
        {
            isNullAssertion = new IsNullAssertion<T>();
            return this;
        }

        public void AddPropertAssertion(IAssertOnProperty<T> propertyAssertion)
        {
            propertyAssertions.Add(propertyAssertion);
        }

        public PropertyAssertion<T, TProperty> HasProperty<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var propertyAssertion = new PropertyAssertion<T, TProperty>(property, this);
            propertyAssertions.Add(propertyAssertion);
            return propertyAssertion;
        }

        public AssertionResult Assert(T actual)
        {
            if (isNotNullAssertion != null)
            {
                ValueAssertionResult isNotNullResult = isNotNullAssertion.AssertValue(actual);
                if (!isNotNullResult.succeeded)
                    return new AssertionResult(isNotNullResult.succeeded, isNotNullResult.actualValueString, isNotNullResult.expectationString);
                if (!propertyAssertions.Any())
                    return new AssertionResult(true, isNotNullResult.actualValueString, isNotNullResult.expectationString);
            }
            if (isNullAssertion != null)
            {
                ValueAssertionResult isNullResult = isNullAssertion.AssertValue(actual);
                return new AssertionResult(isNullResult.succeeded, isNullResult.actualValueString, isNullResult.expectationString);
            }

            if (!propertyAssertions.Any())
                return new AssertionResult(true, "no assertions", "-");

            IReadOnlyCollection<PropertyAssertionResult> results = propertyAssertions.Map(assertion => assertion.Assert(actual));
            int lengthOfLongestProperty = results.Max(x => x.propertyName.Length);
            IReadOnlyCollection<string> propertyResults = results.Map(
                r =>
                {
                    string propertyString = r.propertyName.FillUpWithSpacesToLength(lengthOfLongestProperty).Add(" = ");
                    return StringFunctions.HangingIndent(propertyString, r.childResult.actualValueString);
                });
            string log = StringFunctions.HangingIndent(TypeName(), string.Join(Environment.NewLine, propertyResults));
            return new AssertionResult(results.All(r => r.childResult.succeeded), log, string.Join(Environment.NewLine, results.Select(r => r.childResult.expectationString)));
        }

        private static string TypeName()
        {
            return typeof(T).Name.Add(": ");
        }
    }
}