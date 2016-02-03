using System;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions;
using ExAs.Assertions.ObjectAssertions;

namespace ExAs
{
    public static class MemberAssertionExtensions
    {
        public static IAssert<T> IsNull<T, TMember>(this IAssertMember<T, TMember> member)
            where TMember : class
        {
            return member.SetAssertion(new IsNullAssertion<TMember>());
        }

        public static IAssert<T> IsNotNull<T, TMember>(this IAssertMember<T, TMember> member)
            where TMember : class
        {
            return member.SetAssertion(new IsNotNullAssertion<TMember>());
        }

        public static IAssert<T> IsOfType<T, TMember>(this IAssertMember<T, TMember> member, Type expected)
        {
            return member.SetAssertion(new OfTypeAssertion<TMember>(expected));
        }

        public static IAssert<T> IsEqualTo<T, TMember>(this IAssertMember<T, TMember> member, TMember expected)
        {
            return member.SetAssertion(new EqualAssertion<TMember>(expected));
        }

        public static IAssert<T> Fulfills<T, TMember>(
            this IAssertMember<T, TMember> member,
            Func<IAssert<TMember>, IAssert<TMember>> assertion)
        {
            return
                member.SetAssertion(
                    new AssertToAssertValueAdapter<TMember>(assertion(new ObjectAssertion<TMember>())));
        }
    }
}