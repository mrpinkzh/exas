using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions
{
    public class ObjectAssertion<T> : IAssert<T>
    {
        private readonly List<IAssertMemberOf<T>> memberAssertions; 
        private IsNotNullAssertion<T> isNotNullAssertion;
        private IsNullAssertion<T> isNullAssertion;

        public ObjectAssertion()
        {
            memberAssertions = new List<IAssertMemberOf<T>>();
        }

        public IAssert<T> IsNotNull()
        {
            isNotNullAssertion = new IsNotNullAssertion<T>();
            return this;
        }

        public IAssert<T> IsNull()
        {
            isNullAssertion = new IsNullAssertion<T>();
            return this;
        }

        public void AddMemberAssertion(IAssertMemberOf<T> memberAssertion)
        {
            memberAssertions.Add(memberAssertion);
        }

        public ObjectAssertionResult Assert(T actual)
        {
            if (isNotNullAssertion != null)
            {
                ValueAssertionResult isNotNullResult = isNotNullAssertion.AssertValue(actual);
                if (!isNotNullResult.succeeded)
                    return new ObjectAssertionResult(isNotNullResult.succeeded, isNotNullResult.actualValueString, isNotNullResult.expectationString);
                if (!memberAssertions.Any())
                    return new ObjectAssertionResult(true, isNotNullResult.actualValueString, isNotNullResult.expectationString);
            }
            if (isNullAssertion != null)
            {
                ValueAssertionResult isNullResult = isNullAssertion.AssertValue(actual);
                return new ObjectAssertionResult(isNullResult.succeeded, isNullResult.actualValueString, isNullResult.expectationString);
            }

            if (!memberAssertions.Any())
                return new ObjectAssertionResult(true, "no assertions", "-");

            IReadOnlyCollection<MemberAssertionResult> results = memberAssertions.Map(assertion => assertion.Assert(actual));
            int lengthOfLongestMember = results.Max(x => x.memberName.Length);
            IReadOnlyCollection<string> memberResults = results.Map(
                r =>
                {
                    string failureIndicator = r.childResult.succeeded ? "( )" : "(X)";
                    string memberString = failureIndicator.Add(r.memberName.FillUpWithSpacesToLength(lengthOfLongestMember)).Add(" = ");
                    return StringFunctions.HangingIndent(memberString, r.childResult.actualValueString);
                });
            string log = StringFunctions.HangingIndent(TypeName(), string.Join(Environment.NewLine, memberResults));
            return new ObjectAssertionResult(results.All(r => r.childResult.succeeded), log, string.Join(Environment.NewLine, results.Select(r => r.childResult.expectationString)));
        }

        private static string TypeName()
        {
            return typeof(T).Name.Add(": ");
        }
    }
}