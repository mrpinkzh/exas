using ExAs.Results;

namespace ExAs.Assertions
{
    public interface IAssertMemberOf<in T>
    {
        PropertyAssertionResult Assert(T actual);
    }
}