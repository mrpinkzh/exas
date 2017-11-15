using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class HasAnyAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly IAssert<TElement> childAssertion;

        public HasAnyAssertion(IAssert<TElement> childAssertion)
        {
            this.childAssertion = childAssertion;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            string expectation = ComposeLog.Expected("at least 1 match");

            if (actual == null)
                return new ValueAssertionResult(
                    false,
                    actual.ToValueString(), 
                    expectation);

            var actualList = actual.ToList();
            if (!actualList.Any())
                return new ValueAssertionResult(
                    false,
                    actualList.ToValueString(),
                    expectation);

            IReadOnlyCollection<Result> results = actualList.Map(item => childAssertion.Assert(item));
            int amountOfSucceededResults = results.Count(r => r.succeeded);

	        if (amountOfSucceededResults > 0)
	        {
		        return new ValueAssertionResult(
					true,
					amountOfSucceededResults.Matches()
						.Cons(results.Where(x => x.succeeded)
									 .Select(x => x.actual))
						.JoinToString(Environment.NewLine),
					expectation
						.Cons(results.Where(x => x.succeeded)
									 .Select(x => x.expectation))
						.JoinToString(Environment.NewLine));
	        }

			return new ValueAssertionResult(
                false,
				amountOfSucceededResults.Matches()
	                .Cons(results.Select(r => r.actual))
					.JoinToString(Environment.NewLine),
				expectation
					.Cons(results.Select(r => r.expectation))
					.JoinToString(Environment.NewLine));
        }
    }
}