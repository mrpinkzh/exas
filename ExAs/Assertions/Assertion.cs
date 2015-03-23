namespace ExAs.Assertions
{
    public abstract class Assertion : IAssert
    {
        public abstract AssertionResult Assert(object actual);
    }
}