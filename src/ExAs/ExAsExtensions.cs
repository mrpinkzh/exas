using System;
using System.Collections.Generic;
using ExAs.Assertions;
using ExAs.Assertions.MemberAssertions.Enumerables;
using ExAs.Results;

namespace ExAs
{
    public static class ExAsExtensions
    {
        public static Result Evaluate<T>(this T instance, Func<IAssert<T>, IAssert<T>> assertion)
        {
            IAssert<T> exAssertion = assertion(new ObjectAssertion<T>());
            return exAssertion.Assert(instance);
        }

        public static Result EvaluateHasAny<T>(this IEnumerable<T> enumerable, Func<IAssert<T>, IAssert<T>> assertion)
        {
            var enumerableAssertion = new EnumerableAssertion<T>(new HasAnyAssertion<T>(assertion(new ObjectAssertion<T>())));
            return enumerableAssertion.AssertEnumerable(enumerable);
        }

        public static Result EvaluateHasNone<T>(this IEnumerable<T> enumerable, Func<IAssert<T>, IAssert<T>> assertion)
        {
            var enumerableAssertion = new EnumerableAssertion<T>(new HasNoneAssertion<T>((assertion(new ObjectAssertion<T>()))));
            return enumerableAssertion.AssertEnumerable(enumerable);
        }

        public static void ExAssert<T>(this T instance, Func<IAssert<T>, IAssert<T>> assertion)
        {
            Result result = instance.Evaluate(assertion);
            if (result.succeeded)
                return;
            throw new ExtendedAssertionException(result);
        }

        public static void ExAssertHasAny<T>(this IEnumerable<T> enumerable, Func<IAssert<T>, IAssert<T>> assertion)
        {
            Result result = enumerable.EvaluateHasAny(assertion);
            if (result.succeeded)
                return;
            throw new ExtendedAssertionException(result);
        }

        public static void ExAssertHasNone<T>(this IEnumerable<T> enumerable, Func<IAssert<T>, IAssert<T>> assertion)
        {
            Result result = enumerable.EvaluateHasNone(assertion);
            if (result.succeeded)
                return;
            throw new ExtendedAssertionException(result);
        }
    }
}