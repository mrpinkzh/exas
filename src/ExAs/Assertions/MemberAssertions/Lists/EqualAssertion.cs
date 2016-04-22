using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using static ExAs.Utils.SystemExtensions.EqualityFunctions;

namespace ExAs.Assertions.MemberAssertions.Lists
{
    public class EqualAssertion<T> : IAssertValue<IList<T>>
    {
        private readonly IList<T> expected;

        public EqualAssertion(IList<T> expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(IList<T> actual)
        {
            return new ValueAssertionResult(
                Equal(actual, expected),
                actual.ToValueString(),
                ComposeLog.Expected(expected.ToValueString()));
        }

        private static bool Equal(IList<T> first, IList<T> other)
        {
            bool equal = true;
            bool isFirstNull = first == null;
            bool isOtherNull = other == null;
            if (isFirstNull && isOtherNull)
                return true;
            if (isFirstNull)
                return false;
            if (isOtherNull)
                return false;
            equal &= first.Count == other.Count;
            if (!equal)
                return false;
            for (int i = 0; i < first.Count; i++)
            {
                equal &= Equals(first[i], other[i]);
            }
            return equal;
        }
    }
}