namespace ExAs.Assertions
{
    public abstract class Assertion
    {
        public abstract AssertionResult Assert(object actual);
    }
}