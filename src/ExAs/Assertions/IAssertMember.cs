namespace ExAs.Assertions
{
    public interface IAssertMember<T, out TMember>
    {
        ObjectAssertion<T> SetAssertion(IAssertValue<TMember> newAssertion);
    }
}