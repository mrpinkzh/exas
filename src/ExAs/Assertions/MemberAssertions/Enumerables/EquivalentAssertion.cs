using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    public class EquivalentAssertion<T> : IAssertValue<IEnumerable<T>>
    {
        private readonly IReadOnlyCollection<T> expected;

        public EquivalentAssertion(IEnumerable<T> expected)
        {
            this.expected = expected.ToReadOnly();
        }

        public ValueAssertionResult AssertValue(IEnumerable<T> actual)
        {
            var actualList = actual.ToReadOnly();
            return new ValueAssertionResult(
                Equivalent(actualList, expected),
                actualList.ToValueString(),
                ComposeLog.Expected($"equivalent to {expected.ToValueString()}"));
        }

        private static bool Equivalent(IReadOnlyCollection<T> first, IReadOnlyCollection<T> other)
        {
            if (first == null && other == null)
                return true;
            if (first == null)
                return false;
            if (other == null)
                return false;
            bool result = first.Count == other.Count;
            foreach (T element in first)
                result &= other.Contains(element);
            return result;
        }
    }
}