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
        public void OnExpectedYesterday_WithYesterday_ShouldSucceed()
        {
            DateTime yesterday = Dates.Yesterday();
            SameDayAssertion assertion = SameDayAssertion(yesterday);
            ValueAssertionResult result = assertion.AssertValue(yesterday.AddHours(5));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual(yesterday.ToShortDateString(), result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected(yesterday.ToShortDateString()), result.expectationString);
        }

        [Test]
        public void OnTomorrow_WithToday_ShouldFail()
        {
            var assertion = SameDayAssertion(Dates.Tomorrow());
            var result = assertion.AssertValue(Dates.Today());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual(Dates.Today().ToShortDateString(), result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected(Dates.Tomorrow().ToShortDateString()), result.expectationString);
        }

        private static SameDayAssertion SameDayAssertion(DateTime expected)
        {
            return new SameDayAssertion(expected);
        }
    }
}