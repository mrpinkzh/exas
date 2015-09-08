using System;
using ExAs.Assertions;
using ExAs.Results;

namespace ExAs.Utils
{
    public class AssertionStub<T> : IAssert<T>
    {
        public Func<T, ObjectAssertionResult> assertBehavior;

        public AssertionStub()
        {
            assertBehavior = s => null;
        }

        public ObjectAssertionResult Assert(T actual)
        {
            return assertBehavior(actual);
        }
    }
}