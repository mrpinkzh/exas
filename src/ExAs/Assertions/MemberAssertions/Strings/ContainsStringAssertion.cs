using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    using ExAs.Results;
    using ExAs.Utils;

    public class ContainsStringAssertion : IAssertValue<string>
    {
        private readonly string expected;

        public ContainsStringAssertion(string expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(string actual)
        {
            if (actual == null)
            {
                return new ValueAssertionResult(false, actual.ToValueString(), ComposeLog.Expected($"contains '{expected}'"));
            }

            return new ValueAssertionResult(actual.Contains(expected), actual.ToValueString(), ComposeLog.Expected($"contains '{expected}'"));
        }
    }
}
