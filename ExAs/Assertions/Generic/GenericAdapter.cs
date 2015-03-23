using System;
using ExAs.Utils;

namespace ExAs.Assertions.Generic
{
    public class GenericAdapter<T> : IAssert
    {
        private readonly IAssert<T> genericAssertion;

        public GenericAdapter(IAssert<T> genericAssertion)
        {
            this.genericAssertion = genericAssertion;
        }

        public AssertionResult Assert(object actual)
        {
            T actualInstanceOrValue;
            if (actual.TryCast(out actualInstanceOrValue))
                return genericAssertion.Assert((T)actual);
            return new AssertionResult(false, "not of expected type ".Add(typeof(T).ToString()));
        }
    }
}