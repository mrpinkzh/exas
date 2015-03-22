using ExAs.Utils;

namespace ExAs.Assertions
{
    public class EqualAssertion : Assertion
    {
        private readonly object expected;

        public EqualAssertion(object expected)
        {
            this.expected = expected;
        }

        public override AssertionResult Assert(object actual)
        {
            string actualString =
                "'".Add(actual.ToNullAwareString()).Add("' (expected: '").Add(expected.ToString()).Add("')");
            if (Equals(expected, actual))
            {
                return new AssertionResult(true, actualString);
            }
            return new AssertionResult(false, actualString.Add(" FAIL"));
        }
    }
}