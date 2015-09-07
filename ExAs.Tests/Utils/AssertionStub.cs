using System;
using ExAs.Assertions;

namespace ExAs.Utils
{
    public class AssertionStub<T> : IAssert<T>
    {
        public Func<T, AssertionResult> assertBehavior;

        public AssertionStub()
        {
            assertBehavior = s => null;
        }

        public AssertionResult Assert(T actual)
        {
            return assertBehavior(actual);
        }
    }
}