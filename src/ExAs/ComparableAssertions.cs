using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Numbers;

namespace ExAs
{
    public static class ComparableAssertions
    {
        public static IAssert<T> IsLessThan<T, TMember>(this IAssertMember<T, TMember> member, TMember expected)
            where TMember : IComparable<TMember>
        {
            return member.SetAssertion(new LessThanAssertion<TMember>(expected));
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

        public static IAssert<T> IsGreaterOrEqualTo<T, TMember>(this IAssertMember<T, TMember> member, TMember expected)
            where TMember : IComparable<TMember>
        {
            return member.SetAssertion(new GreaterOrEqualAssertion<TMember>(expected));
        } 
    }
}