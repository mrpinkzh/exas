using ExAs.Results;

namespace ExAs.Assertions
{
    public interface IAssert<T>
    {
        IAssert<T> IsNotNull();

        IAssert<T> IsNull();

        void AddMemberAssertion(IAssertMemberOf<T> memberAssertion);

        Result Assert(T actual);
    }
}