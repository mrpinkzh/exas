using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions
{
    public class EnumerableAssertion<TElement>
    {
        private readonly IAssertValue<IEnumerable<TElement>> itemAssertion;

        public EnumerableAssertion(IAssertValue<IEnumerable<TElement>> itemAssertion)
        {
            this.itemAssertion = itemAssertion;
        }

        public ObjectAssertionResult AssertEnumerable(IEnumerable<TElement> enumerable)
        {
            var valueAssertionResult = itemAssertion.AssertValue(enumerable);
            string log = StringFunctions.HangingIndent("Enumerable<".Add(typeof(TElement).Name).Add(">: "), valueAssertionResult.actualValueString);
            return new ObjectAssertionResult(valueAssertionResult.succeeded, log, valueAssertionResult.expectationString);
        }
    }
}