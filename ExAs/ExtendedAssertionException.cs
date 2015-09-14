using System;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs
{
    public class ExtendedAssertionException : Exception
    {
        public ExtendedAssertionException(ObjectAssertionResult result)
            : base(Pretty(result.PrintLog()))
        {
        }

        private static string Pretty(string message)
        {
            return "".NewLine()
                   .Add(message);
        }
    }
}