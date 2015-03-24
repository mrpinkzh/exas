namespace ExAs.Assertions
{
    public class IsNotNullAssertion : IAssertValue
    {
        private const string ExpectationString = "(expected: not null)";

        public ValueAssertionResult AssertValue(object actual)
        {
            return new ValueAssertionResult(ConcreteAssert(actual), ActualValueString(actual), ExpectationString);
        }

        private static bool ConcreteAssert(object actual)
        {
            return actual != null;
        }

        private static string ActualValueString(object actual)
        {
            if (ConcreteAssert(actual))
                return "not null";
            return "null";
        }
    }
}