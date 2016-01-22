using ExAs.Results;

namespace ExAs.Assertions
{
    public interface IAssertMemberOf<in T>
    {
        MemberAssertionResult Assert(T actual);
    }
}