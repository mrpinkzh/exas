using ExAs.Utils;

namespace ExAs.Assertions
{
    public class EqualAssertion : IAssert
    {
        private readonly object expected;

        public EqualAssertion(object expected)
        {
            this.expected = expected;
        }

        public AssertionResult Assert(object actual)
        {
            return new AssertionResult(ConcreteAssert(actual), ResultString(actual));
        }

        private string ResultString(object actual)
        {
            if (ConcreteAssert(actual))
                return SuccessString(actual);
            return SuccessString(actual).Add(" FAIL");
        }

        private string SuccessString(object actual)
        {
            return "'".Add(actual.ToNullAwareString()).Add("' (expected: '").Add(expected.ToString()).Add("')");
        }

        private bool ConcreteAssert(object actual)
        {
            return Equals(expected, actual);
        }
    }
}