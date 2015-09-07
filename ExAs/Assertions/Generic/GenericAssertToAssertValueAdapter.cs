using ExAs.Assertions.GenericValueAssertions;

namespace ExAs.Assertions.Generic
{
    public class GenericAssertToAssertValueAdapter<T> : IAssertValue<T>
    {
        private readonly IAssert assert;

        public GenericAssertToAssertValueAdapter(IAssert<T> assert)
        {
            this.assert = new GenericAdapter<T>(assert);
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            AssertionResult result = assert.Assert(actual);
            return new ValueAssertionResult(result.succeeded, result.log, result.expectation);
        }
    }
}