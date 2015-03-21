namespace ExAs.Assertions.Generic
{
    public class StructAssertion<T> : DataAssertion<T>
        where T : struct 
    {
        public override AssertionResult Assert(T actual)
        {
            throw new System.NotImplementedException();
        }
    }
}