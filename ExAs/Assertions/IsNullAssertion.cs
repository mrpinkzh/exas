namespace ExAs.Assertions
{
    public class IsNullAssertion : IAssertValue
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

        private static bool ConcreteAssert(object actual)
        {
            return actual == null;
        }
    }
}