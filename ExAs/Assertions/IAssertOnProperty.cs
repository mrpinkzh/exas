namespace ExAs.Assertions
{
    public interface IAssertOnProperty<in T>
    {
        PropertyAssertionResult Assert(T actual);
    }
}