using System;
using ExAs.Assertions;
using ExAs.Results;

namespace ExAs
{
    public static class ExAsExtensions
    {
        public static ObjectAssertionResult Evaluate<T>(this T instance, Func<ObjectAssertion<T>, ObjectAssertion<T>> assertion)
        {
            ObjectAssertion<T> exAssertion = assertion(new ObjectAssertion<T>());
            return exAssertion.Assert(instance);
        }

        public static void ExAssert<T>(this T instance, Func<ObjectAssertion<T>, ObjectAssertion<T>> assertion)
        {
            ObjectAssertionResult result = instance.Evaluate(assertion);
            if (result.succeeded)
                return;
            throw new ExtendedAssertionException(result);
        }
    }
}