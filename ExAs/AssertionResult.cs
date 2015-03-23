using ToText;

namespace ExAs
{
    public class AssertionResult
    {
        public readonly bool succeeded;
        public readonly string log;

        public AssertionResult(bool succeeded, string log)
        {
            this.succeeded = succeeded;
            this.log = log;
        }

        public string Print()
        {
            return log;
            return string.Format("(_)Ninja: (_)Name = 'Naruto'");
        }

        public override string ToString()
        {
            return this.ToText(x => x.succeeded,
                               x => x.log);
        }
    }
}