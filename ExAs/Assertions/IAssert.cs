namespace ExAs.Assertions
{
    public interface IAssert<T>
    {
        AssertionResult Assert(T actual);
    }
}