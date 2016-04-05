using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Numbers;

namespace ExAs
{
    public static class ComparableAssertions
    {
        public static IAssert<T> IsSmallerThan<T, TMember>(this IAssertMember<T, TMember> member, TMember expected)
            where TMember : IComparable<TMember>
        {
            return member.SetAssertion(new IsSmallerAssertion<TMember>(expected));
        }

        public static IAssert<T> IsGreaterThan<T, TMember>(this IAssertMember<T, TMember> member, TMember expected)
            where TMember : IComparable<TMember>
        {
            return member.SetAssertion(new GreaterThanAssertion<TMember>(expected));
        }

        public static IAssert<T> IsInRange<T, TMember>(this IAssertMember<T, TMember> member, TMember min, TMember max)
            where TMember : IComparable<TMember>
        {
            return member.SetAssertion(new InRangeAssertion<TMember>(min, max));
        }
    }
}