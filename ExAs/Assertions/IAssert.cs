using ExAs.Results;

namespace ExAs.Assertions
{
    public interface IAssert<T>
    {
        ObjectAssertionResult Assert(T actual);
    }
}