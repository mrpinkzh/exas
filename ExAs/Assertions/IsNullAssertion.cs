using ExAs.Utils;

namespace ExAs.Assertions
{
    public class IsNullAssertion : IAssertValue, IAssert
    {
        private const string ExpectationString = "(expected: null)";

        public ValueAssertionResult AssertValue(object actual)
        {
            return new ValueAssertionResult(ConcreteAssert(actual), ActualValueString(actual), ExpectationString);
        }

        private static string ActualValueString(object actual)
        {
            if (ConcreteAssert(actual))
                return "null";
            return "not null";
        }

        public AssertionResult Assert(object actual)
        {
            return new AssertionResult(ConcreteAssert(actual), ComposeResultString(actual));
        }

        private static string ComposeResultString(object actual)
        {
            if (ConcreteAssert(actual))
                return "null ".Add(ExpectationString);
            return "not null ".Add(ExpectationString).Add(" FAIL");
        }

        private static bool ConcreteAssert(object actual)
        {
            return actual == null;
        }
    }
}