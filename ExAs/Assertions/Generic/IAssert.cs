namespace ExAs.Assertions.Generic
{
    public interface IAssert<T>
    {
        AssertionResult Assert(T actual);
    }
}