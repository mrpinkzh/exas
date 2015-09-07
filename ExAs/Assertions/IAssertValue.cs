namespace ExAs.Assertions
{
    public interface IAssertValue<in T>
    {
        ValueAssertionResult AssertValue(T actual);
    }
}