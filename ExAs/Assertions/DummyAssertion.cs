using ToText;

namespace ExAs.Assertions
{
    public class DummyAssertion : Assertion
    {
        public override AssertionResult Assert(object actual)
        {
            return new AssertionResult(true, string.Empty);
        }
    }
}