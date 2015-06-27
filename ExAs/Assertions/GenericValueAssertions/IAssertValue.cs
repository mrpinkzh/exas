namespace ExAs.Assertions.GenericValueAssertions
{
    public interface IAssertValue<in T>
    {
        ValueAssertionResult AssertValue(T actual);
    }
}