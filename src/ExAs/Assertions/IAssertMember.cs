namespace ExAs.Assertions
{
    public interface IAssertMember<T, out TMember>
    {
        IAssert<T> SetAssertion(IAssertValue<TMember> newAssertion);
    }
}