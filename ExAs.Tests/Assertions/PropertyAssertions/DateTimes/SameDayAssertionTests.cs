using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.DateTimes
{
    [TestFixture]
    public class SameDayAssertionTests
    {
        [Test]
        public void OnStandardDay_WithStandardDay_ShouldSucceed()
        {
            SameDayAssertion assertion = SameDayAssertion(Dates.StandardDay());
            ValueAssertionResult result = assertion.AssertValue(Dates.StandardDay().AddHours(5));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("11/16/1984", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("11/16/1984"), result.expectationString);
        }

        [Test]
        public void OnStandardDay_WithDayAfter_ShouldFail()
        {
            var assertion = SameDayAssertion(Dates.StandardDay());
            var result = assertion.AssertValue(Dates.StandardDay().AddDays(1));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("11/17/1984", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("11/16/1984"), result.expectationString);
        }

        private static SameDayAssertion SameDayAssertion(DateTime expected)
        {
            return new SameDayAssertion(expected);
        }
    }
}