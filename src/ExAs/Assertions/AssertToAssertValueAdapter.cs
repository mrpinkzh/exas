using ExAs.Results;

namespace ExAs.Assertions
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
            Result result = assert.Assert(actual);
            return new ValueAssertionResult(result.succeeded, result.actual, result.expectation);
        }
    }
}