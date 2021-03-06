﻿using System;
using System.Linq.Expressions;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions
{
    public static class MemberAssertionFunctions
    {
        public static MemberAssertionResult Assert<T, TMember>(T instance,
            Expression<Func<T, TMember>> memberExpression, IAssertValue<TMember> assertion)
        {
            string memberName = memberExpression.ExtractMemberName();
            TMember value = memberExpression.Compile()(instance);
            return Assert(assertion, memberName, value);
        }

        public static MemberAssertionResult Assert<TMember>(IAssertValue<TMember> assertion, string memberName,
            TMember value)
        {
            if (assertion == null)
                return new MemberAssertionResult(memberName,
                    new ValueAssertionResult(false,
                        "no assertion specified",
                        string.Empty));
            ValueAssertionResult result = assertion.AssertValue(value);
            return new MemberAssertionResult(memberName, result);
        }
    }
}