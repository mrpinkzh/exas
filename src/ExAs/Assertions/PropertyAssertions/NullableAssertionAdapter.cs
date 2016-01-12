using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions
{
    public class NullableAssertionAdapter<T> : IAssertValue<T?>
        where T : struct 
    {
        private readonly IAssertValue<T> assertion;

        public NullableAssertionAdapter(IAssertValue<T> assertion)
        {
            this.assertion = assertion;
        }

        public ValueAssertionResult AssertValue(T? actual)
        {
            if (actual.HasValue)
                return assertion.AssertValue(actual.Value);
            ValueAssertionResult innerResult = assertion.AssertValue(default(T));
            return new ValueAssertionResult(false, StringFunctions.ToValueString(null), innerResult.expectationString);
        }
    }
}