using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Assertions.ObjectAssertions;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

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
			if (isNotNullAssertion == null)
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
	        IsNotNull();
        }

        public Result Assert(T actual)
        {
            if (isNotNullAssertion != null)
            {
                ValueAssertionResult isNotNullResult = isNotNullAssertion.AssertValue(actual);
                if (!isNotNullResult.succeeded)
                    return new Result(isNotNullResult.succeeded, isNotNullResult.actualValueString, isNotNullResult.expectationString);
                if (!memberAssertions.Any())
                    return new Result(true, isNotNullResult.actualValueString, isNotNullResult.expectationString);
            }
            if (isNullAssertion != null)
            {
                ValueAssertionResult isNullResult = isNullAssertion.AssertValue(actual);
                return new Result(isNullResult.succeeded, isNullResult.actualValueString, isNullResult.expectationString);
            }

            if (!memberAssertions.Any())
                return new Result(true, "no assertions", "-");

            IReadOnlyCollection<MemberAssertionResult> results = memberAssertions.Map(assertion => assertion.Assert(actual));
            int lengthOfLongestMember = results.Max(x => x.memberName.Length);
            IReadOnlyCollection<string> memberResults = results.Map(
                r =>
                {
                    string failureIndicator = r.childResult.succeeded ? "( )" : "(X)";
                    string memberString = failureIndicator.Add(r.memberName.FillUpWithSpacesToLength(lengthOfLongestMember)).Add(" = ");
                    return HangingIndent(memberString, r.childResult.actualValueString);
                });
            string log = HangingIndent(TypeName(), string.Join(Environment.NewLine, memberResults));
            return new Result(results.All(r => r.childResult.succeeded), log, string.Join(Environment.NewLine, results.Select(r => r.childResult.expectationString)));
        }

        private static string TypeName()
        {
            return typeof(T).Name.Add(": ");
        }
    }
}