using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class ContainsInOrderAssertion<TElement> : IAssertValue<IEnumerable<TElement>>
    {
        private readonly IList<TElement> expectedElements;

        public ContainsInOrderAssertion(IList<TElement> expectedElements)
        {
            this.expectedElements = expectedElements;
        }

        public ValueAssertionResult AssertValue(IEnumerable<TElement> actual)
        {
            List<TElement> actualList = actual?.ToList();

            bool result = ContainsInOrder(actualList, expectedElements);

            return new ValueAssertionResult(
                result,
                actualList.ToValueString(), 
                ComposeLog.Expected($"contains in order {expectedElements.ToValueString()}"));
        }

        private static bool ContainsInOrder<T>(IList<T> testee, IList<T> expectedElements)
        {
            if (testee == null || expectedElements == null)
                return false;
            for (int i = 0; i < testee.Count; i++)
            {
                int matches = 0;
                for (int j = 0; j < expectedElements.Count; j++)
                {
                    if (Equals(testee[i + j], expectedElements[j]))
                        matches++;
                    else
                        break;
                }
                if (expectedElements.Count == matches)
                    return true;
            }
            return false;
        }
    }
}