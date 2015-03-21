using ExAs.Utils;

namespace ExAs.Assertions
{
    public class IsNullAssertion : Assertion
    {
        private const string ExpectationString = "(expected: null)";

        public override AssertionResult Assert(object actual)
        {
            if (actual == null)
                return new AssertionResult(true, "null ".Add(ExpectationString));
            return new AssertionResult(false, "not null ".Add(ExpectationString).Add(" FAIL"));
        }
    }
}