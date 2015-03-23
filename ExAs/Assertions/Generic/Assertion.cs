using ExAs.Utils;

namespace ExAs.Assertions.Generic
{
    public abstract class Assertion<T> : Assertion, IAssert<T>
    {
        public abstract AssertionResult Assert(T actual);

        public override AssertionResult Assert(object actual)
        {
            T actualInstanceOrValue;
            if (actual.TryCast(out actualInstanceOrValue))
                return Assert(actualInstanceOrValue);
            return new AssertionResult(false, "Not of expected type");
        }
    }
}