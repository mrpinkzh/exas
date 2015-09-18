namespace ExAs.Results
{
    public class ValueAssertionResult
    {
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
            return string.Format("ValueAssertionResult: succeeded = {0}", succeeded);
        }
    }
}