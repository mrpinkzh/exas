using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
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

            IReadOnlyCollection<ObjectAssertionResult> results = actualList.Map(item => childAssertion.Assert(item));
            int amountOfSucceededResults = results.Count(r => r.succeeded);
            return new ValueAssertionResult(
                amountOfSucceededResults > 0, 
                string.Join(Environment.NewLine,
                            amountOfSucceededResults.Matches()
                                .Cons(results.Select(r => r.log))),
                string.Join(Environment.NewLine,
                            expectation
                                .Cons(results.Select(r => r.expectation))));
        }
    }
}