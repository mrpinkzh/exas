using System;
using ExAs.Assertions;
using ExAs.Assertions.Generic;

namespace ExAs
{
    public static class ExAsExtensions
    {
        public static AssertionResult Evaluate<T>(this T instance, Func<ObjectAssertion<T>, Assertion> assertion)
            where T : class 
        {
            Assertion exAssertion = assertion(new ObjectAssertion<T>());
            return exAssertion.Assert(instance);
        }

        public static AssertionResult Evaluate<T>(this T value, Func<StructAssertion<T>, Assertion> assertion)
            where T : struct
        {
            Assertion exAssertion = assertion(new StructAssertion<T>());
            return exAssertion.Assert(value);
        }
    }
}