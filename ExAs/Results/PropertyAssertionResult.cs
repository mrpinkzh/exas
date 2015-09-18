namespace ExAs.Results
{
    public class PropertyAssertionResult
    {
        public readonly string propertyName;
        public readonly ValueAssertionResult childResult;

        public PropertyAssertionResult(string propertyName, ValueAssertionResult childResult) 
        {
            this.propertyName = propertyName;
            this.childResult = childResult;
        }

        public override string ToString()
        {
            return string.Format("PropertyAssertionResult: propertyName = {0}", propertyName);
        }
    }
}