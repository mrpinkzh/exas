using ToText;

namespace ExAs.Assertions.Generic
{
    public class PropertyAssertionResult : AssertionResult
    {
        public readonly string propertyName;

        public PropertyAssertionResult(bool succeeded, string log, string propertyName) 
            : base(succeeded, log)
        {
            this.propertyName = propertyName;
        }

        public override string ToString()
        {
            return this.ToText(x => x.propertyName,
                               x => x.succeeded,
                               x => x.log);
        }
    }
}