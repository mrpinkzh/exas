using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Utils;
using ToText;

namespace ExAs
{
    public class AssertionResult
    {
        public readonly bool succeeded;
        public readonly string log;
        public readonly string expectation;

        public AssertionResult(bool succeeded, string log, string expectation)
        {
            this.succeeded = succeeded;
            this.log = log;
            this.expectation = expectation;
        }

        public string PrintLog()
        {
            string[] logLines = log.SplitLines();
            string[] expectationLines = expectation.SplitLines();
            int longestLogLine = logLines.Max(s => s.Length);
            IReadOnlyList<string> resultingLogLines = logLines.Map(
                (al, el) => al.FillUpWithSpacesToLength(longestLogLine).Add(" ").Add(el), expectationLines);
            return string.Join(Environment.NewLine, resultingLogLines);
        }

        public override string ToString()
        {
            return this.ToText(x => x.succeeded,
                               x => x.log,
                               x => x.expectation);
        }
    }
}