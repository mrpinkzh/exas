namespace ExAs.Assertions
{
    public abstract class Assertion
    {
        public abstract AssertionResult Assert(object actual);

        public virtual string Print(object actual)
        {
            return string.Empty;
        }
    }
}