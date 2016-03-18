using System;
using System.Collections.Generic;
using ExAs.Utils;
using ExAs.Utils.SystemExtensions;

namespace ExAs.Results
{
    public class Result
    {
        public readonly bool succeeded;
        public readonly string actual;
        public readonly string expectation;

        public Result(bool succeeded, string actual, string expectation)
        {
            this.succeeded = succeeded;
            this.actual = actual;
            this.expectation = expectation;
        }

        public string PrintLog()
        {
            string[] logLines = actual.SplitLines();
            string[] expectationLines = expectation.SplitLines();
            int longestLogLine = logLines.MaxOrDefault(s => s.Length);
            IReadOnlyList<string> resultingLogLines = logLines.Map(expectationLines, 
                                                                   (al, el) => al.FillUpWithSpacesToLength(longestLogLine).Add(" ").Add(el));
            return string.Join(Environment.NewLine, resultingLogLines);
        }

        public override string ToString()
        {
            return string.Format("ObjectAssertionResult: succeeded = {0}", succeeded);
        }
    }
}