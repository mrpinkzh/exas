using ExAs.Results;

namespace ExAs.Assertions
{
    public interface IAssert<T>
    {
        IAssert<T> IsNotNull();

        IAssert<T> IsNull();

        void AddPropertyAssertion(IAssertMemberOf<T> propertyAssertion);

        ObjectAssertionResult Assert(T actual);
    }
}