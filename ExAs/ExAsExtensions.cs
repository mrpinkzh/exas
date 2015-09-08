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
    }
}