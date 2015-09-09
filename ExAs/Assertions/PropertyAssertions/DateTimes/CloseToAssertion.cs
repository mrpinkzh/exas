using System;
using System.Globalization;
using ExAs.Results;
using ExAs.Utils;

namespace ExAs.Assertions.PropertyAssertions.DateTimes
{
    public class CloseToAssertion : IAssertValue<DateTime>
    {
        private const string OutputFormat = "MM/dd/yyyy HH:mm:ss.fff";
        
        private readonly DateTime expected;
        private readonly TimeSpan plusMinusRange;

        public CloseToAssertion(DateTime expected, TimeSpan plusMinusRange)
        {
            this.expected = expected;
            this.plusMinusRange = plusMinusRange;
        }

        public ValueAssertionResult AssertValue(DateTime actual)
        {
            DateTime expectedMaximum = expected.Add(plusMinusRange);
            DateTime expectedMinimum = expected.Add(-plusMinusRange);
            return new ValueAssertionResult(
                expectedMinimum <= actual && actual <= expectedMaximum,
                Print(actual),
                "(expected between ".Add(Print(expectedMinimum).Add(" and ").Add(Print(expectedMaximum)).Add(")")));
        }

        private static string Print(DateTime dateTime)
        {
            return dateTime.ToString(OutputFormat, CultureInfo.InvariantCulture);
        }
    }
}