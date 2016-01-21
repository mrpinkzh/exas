namespace ExAs.Assertions
{
    public interface IAssertInstance<T>
    {
        IAssert<T> IsNotNull();

        IAssert<T> IsNull();

        void AddPropertyAssertion(IAssertOnProperty<T> propertyAssertion);
    }
}