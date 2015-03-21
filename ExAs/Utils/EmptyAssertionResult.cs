using ExAs.Assertions;

namespace ExAs.Utils
{
    public class EmptyAssertionResult : AssertionResult
    {
        public EmptyAssertionResult(Assertion parentAssertion)
            : base(true, string.Empty, parentAssertion)
        {
        }
    }
}