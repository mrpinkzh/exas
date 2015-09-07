using System;
using ExAs.Assertions;

namespace ExAs
{
    public static class ExAsExtensions
    {
        public static AssertionResult Evaluate<T>(this T instance, Func<ObjectAssertion<T>, ObjectAssertion<T>> assertion)
        {
            ObjectAssertion<T> exAssertion = assertion(new ObjectAssertion<T>());
            return exAssertion.Assert(instance);
        }
    }
}