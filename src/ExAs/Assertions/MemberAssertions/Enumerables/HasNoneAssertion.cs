using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class HasNoneAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly IAssert<TElement> childAssertion;

        public HasNoneAssertion(IAssert<TElement> childAssertion)
        {
            this.childAssertion = childAssertion;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            string expectation = ComposeLog.Expected("0 matches");
            if (actual == null)
                return new ValueAssertionResult(
                    true,
                    actual.ToValueString(),
                    expectation);

            var actualList = actual.ToList();
            if (!actualList.Any())
                return new ValueAssertionResult(
                    true,
                    actualList.ToValueString(),
                    expectation);
            
            IReadOnlyCollection<ObjectAssertionResult> results = actualList.Map(a => childAssertion.Assert(a));
            int numberOfSucceededResults = results.Count(r => r.succeeded);
            return new ValueAssertionResult(
                numberOfSucceededResults == 0, 
                string.Join(
                    Environment.NewLine, 
                    numberOfSucceededResults.Matches()
                        .Cons(results.Select(r => r.actual))), 
                string.Join(
                    Environment.NewLine,
                    expectation
                        .Cons(results.Select(r => r.expectation))));
        }
    }
}