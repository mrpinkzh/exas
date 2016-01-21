using ExAs.Results;

namespace ExAs.Assertions
{
    public interface IAssert<T> : IAssertInstance<T>
    {
        ObjectAssertionResult Assert(T actual);
    }
}