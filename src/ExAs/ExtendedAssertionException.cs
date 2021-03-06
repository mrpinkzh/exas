﻿using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;

namespace ExAs
{
    public class ExtendedAssertionException : Exception
    {
        public ExtendedAssertionException(Result result)
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