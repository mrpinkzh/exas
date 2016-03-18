using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.MemberAssertions
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
            return new ValueAssertionResult(false, actual.ToValueString(), innerResult.expectationString);
        }
    }
}