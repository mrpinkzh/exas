using ExAs.Utils;

namespace ExAs.Assertions
{
    public class IsNotNullAssertion : Assertion
    {
        private const string ExpectationString = "(expected: not null)";

        public override AssertionResult Assert(object actual)
        {
            if (actual != null)
                return new AssertionResult(true, "not null ".Add(ExpectationString));
            return new AssertionResult(false, "null ".Add(ExpectationString).Add(" FAIL"));
        }
    }
}