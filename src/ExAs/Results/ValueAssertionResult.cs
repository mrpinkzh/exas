using System;

namespace ExAs.Results
{
    public class ValueAssertionResult
    {
        public static ValueAssertionResult Create(bool succeeded, Tuple<string, string> strings)
        {
            return new ValueAssertionResult(succeeded, strings.Item1, strings.Item2);
        }

        public readonly bool succeeded;
        public readonly string actualValueString;
        public readonly string expectationString;

        public ValueAssertionResult(bool succeeded, string actualValueString, string expectationString)
        {
            this.succeeded = succeeded;
            this.actualValueString = actualValueString;
            this.expectationString = expectationString;
        }

        public override string ToString()
        {
            return $"ValueAssertionResult: succeeded = {succeeded}";
        }
    }
}