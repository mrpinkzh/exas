using ExAs.Utils;

namespace ExAs.Assertions
{
    public class IsNullAssertion : Assertion
    {
        private const string ExpectationString = "(expected: null)";

        public override AssertionResult Assert(object actual)
        {
            return new AssertionResult(ConcreteAssert(actual), ComposeResultString(actual));
        }

        private string ComposeResultString(object actual)
        {
            if (ConcreteAssert(actual))
                return "null ".Add(ExpectationString);
            return "not null ".Add(ExpectationString).Add(" FAIL");
        }

        private bool ConcreteAssert(object actual)
        {
            return actual == null;
        }
    }
}