using ExAs.Assertions.GenericValueAssertions;

namespace ExAs.Assertions.Generic
{
    public class AssertToAssertValueAdapter<T> : IAssertValue<T>
    {
        private readonly IAssert<T> assert;

        public AssertToAssertValueAdapter(IAssert<T> assert)
        {
            this.assert = assert;
        }

        public ValueAssertionResult AssertValue(T actual)
        {
            AssertionResult result = assert.Assert(actual);
            return new ValueAssertionResult(result.succeeded, result.log, result.expectation);
        }
    }
}