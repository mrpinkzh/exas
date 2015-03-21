using ToText;

namespace ExAs.Assertions.Generic
{
    public class PrintAssertion<T> : Assertion<T>
    {
        public override AssertionResult Assert(T actual)
        {
            return new AssertionResult(true, actual.ToText());
        }
    }
}