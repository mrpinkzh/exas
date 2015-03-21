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
            if (Equals(expected, actual))
            {
                return new AssertionResult(true, actual.ToString(), this);
            }
            return new AssertionResult(false, actual.ToString(), this);
        }
    }
}