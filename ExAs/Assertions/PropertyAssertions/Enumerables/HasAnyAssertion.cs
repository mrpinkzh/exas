using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    public class HasAnyAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly ObjectAssertion<TElement> childAssertion;

        public HasAnyAssertion(ObjectAssertion<TElement> childAssertion)
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
                            Matches(amountOfSucceededResults)
                                .Cons(results.Select(r => r.log))),
                string.Join(Environment.NewLine,
                            expectation
                                .Cons(results.Select(r => r.expectation))));
        }

        private static string Matches(int amount)
        {
            if (amount == 1)
                return "<1 match>";
            return string.Format("<{0} matches>", amount);
        }
    }
}