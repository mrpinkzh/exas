using ExAs.Utils;

namespace ExAs.Assertions.Generic
{
    public abstract class Assertion<T> : Assertion
    {
        public abstract AssertionResult Assert(T actual);

        public virtual string Print(T actual)
        {
            return string.Empty;
        }

        public override AssertionResult Assert(object actual)
        {
            T actualInstanceOrValue;
            if (actual.TryCast(out actualInstanceOrValue))
                return Assert(actualInstanceOrValue);
            return new AssertionResult(false, actual.ToNullAwareString(), this);
        }

        public override string Print(object actual)
        {
            T actualInstanceOrValue;
            if (actual.TryCast(out actualInstanceOrValue))
                return Print(actualInstanceOrValue);
            return "Blub";
        }
    }
}