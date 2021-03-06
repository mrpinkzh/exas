﻿using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Assertions.MemberAssertions.Numbers
{
    public class GreaterOrEqualAssertion<T> : IAssertValue<T>
        where T : IComparable<T>
    {
        private readonly T expected;

        public GreaterOrEqualAssertion(T expected)
        {
            this.expected = expected;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            return new ValueAssertionResult(
                actual.Compare_NullAware(expected) >= 0, 
                actual.ToValueString(),
                ComposeLog.Expected($"greater or equal to {expected.ToValueString()}"));
        }
    }
}