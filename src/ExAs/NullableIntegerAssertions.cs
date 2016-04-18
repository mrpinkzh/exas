﻿using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.MemberAssertions.Numbers;
using ExAs.Assertions.ObjectAssertions;

namespace ExAs
{
    public static class NullableIntegerAssertions
    {
        public static IAssert<T> IsNull<T>(this IAssertMember<T, int?> member)
        {
            return member.SetAssertion(new IsNullAssertion<int?>());
        }

        public static IAssert<T> IsNotNull<T>(this IAssertMember<T, int?> member)
        {
            return member.SetAssertion(new IsNotNullAssertion<int?>());
        }

        public static IAssert<T> IsLessThan<T>(this IAssertMember<T, int?> member, int expected)
        {
            return member.SetAssertion(new NullableAssertionAdapter<int>(new LessThanAssertion<int>(expected)));
        }

        public static IAssert<T> IsGreaterThan<T>(this IAssertMember<T, int?> member, int expected)
        {
            return member.SetAssertion(new NullableAssertionAdapter<int>(new GreaterThanAssertion<int>(expected)));
        }

        public static IAssert<T> IsInRange<T>(this IAssertMember<T, int?> member, int min, int max)
        {
            return member.SetAssertion(new NullableAssertionAdapter<int>(new InRangeAssertion<int>(min, max)));
        }
    }
}