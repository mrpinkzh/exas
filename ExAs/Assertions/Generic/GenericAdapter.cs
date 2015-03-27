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
            string actualoutput = "is of type ".Add(actual.GetType().ToString());
            string expectation = "(expected: of type ".Add(typeof(T).ToString().Add(")"));
            return new AssertionResult(false, actualoutput, expectation);
        }
    }
}