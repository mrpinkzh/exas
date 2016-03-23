using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.StringExtensions.StringFormattingFunctions;

namespace ExAs.Assertions
{
    public class EnumerableAssertion<TElement>
    {
        private readonly IAssertValue<IEnumerable<TElement>> itemAssertion;

        public EnumerableAssertion(IAssertValue<IEnumerable<TElement>> itemAssertion)
        {
            this.itemAssertion = itemAssertion;
        }

        public Result AssertEnumerable(IEnumerable<TElement> enumerable)
        {
            var valueAssertionResult = itemAssertion.AssertValue(enumerable);
            string log = HangingIndent("Enumerable<".Add(typeof(TElement).Name).Add(">: "), valueAssertionResult.actualValueString);
            return new Result(valueAssertionResult.succeeded, log, valueAssertionResult.expectationString);
        }
    }
}