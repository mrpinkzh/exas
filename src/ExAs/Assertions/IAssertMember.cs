namespace ExAs.Assertions
{
    public interface IAssertMember<T, out TMember> : IAssertMemberOf<T>
    {
        IAssert<T> SetAssertion(IAssertValue<TMember> newAssertion);
    }
}