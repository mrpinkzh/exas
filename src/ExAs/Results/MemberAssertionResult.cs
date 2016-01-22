namespace ExAs.Results
{
    public class MemberAssertionResult
    {
        public readonly string memberName;
        public readonly ValueAssertionResult childResult;

        public MemberAssertionResult(string memberName, ValueAssertionResult childResult) 
        {
            this.memberName = memberName;
            this.childResult = childResult;
        }

        public override string ToString()
        {
            return $"MemberAssertionResult: memberName = {memberName}";
        }
    }
}