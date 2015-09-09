using System;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.DateTimes
{
    [TestFixture]
    public class CloseToAssertionTests
    {
        [Test]
        public void OnLunchTimePlusMinus5Seconds_WithLunchTimePlusAlmost5Seconds_ShouldPass()
        {
            CloseToAssertion assertion = CloseToAssertion(Times.LunchTime(), 5.Seconds());
            var result = assertion.AssertValue(Times.LunchTime().AddSeconds(4).AddMilliseconds(999));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("11/16/1984 12:00:04.999", result.actualValueString);
            Assert.AreEqual("(expected between 11/16/1984 11:59:55.000 and 11/16/1984 12:00:05.000)", result.expectationString);
        }

        [Test]
        public void OnLunchTimePlusMinus5Seconds_WithLunchTimePlusMoreThan5Seconds_ShouldFail()
        {
            CloseToAssertion assertion = CloseToAssertion(Times.LunchTime(), 5.Seconds());
            var result = assertion.AssertValue(Times.LunchTime().AddSeconds(5).AddMilliseconds(1));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("11/16/1984 12:00:05.001", result.actualValueString);
            Assert.AreEqual("(expected between 11/16/1984 11:59:55.000 and 11/16/1984 12:00:05.000)", result.expectationString);
        }

        [Test]
        public void OnDinnerTimePlus4Seconds_WithDinnerTimePlus4Seconds_ShouldPass()
        {
            var assertion = CloseToAssertion(Times.DinnerTime(), 4.Seconds());
            var result = assertion.AssertValue(Times.DinnerTime().AddSeconds(4));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("11/16/1984 18:00:04.000", result.actualValueString);
            Assert.AreEqual("(expected between 11/16/1984 17:59:56.000 and 11/16/1984 18:00:04.000)", result.expectationString);
        }

        [Test]
        public void OnLunchTimePlusMinus5Seconds_WithLuchTimeMinus5Seconds_ShouldPass()
        {
            CloseToAssertion assertion = CloseToAssertion(Times.LunchTime(), 5.Seconds());
            var result = assertion.AssertValue(Times.LunchTime().AddSeconds(-5));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("11/16/1984 11:59:55.000", result.actualValueString);
            Assert.AreEqual("(expected between 11/16/1984 11:59:55.000 and 11/16/1984 12:00:05.000)", result.expectationString);
        }

        [Test]
        public void OnLunchTimePlusMinus5Seconds_WithLuchTimeMinusMoreThan5Seconds_ShouldFail()
        {
            CloseToAssertion assertion = CloseToAssertion(Times.LunchTime(), 5.Seconds());
            var result = assertion.AssertValue(Times.LunchTime().AddSeconds(-5).AddMilliseconds(-1));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("11/16/1984 11:59:54.999", result.actualValueString);
            Assert.AreEqual("(expected between 11/16/1984 11:59:55.000 and 11/16/1984 12:00:05.000)", result.expectationString);
        }

        private static CloseToAssertion CloseToAssertion(DateTime time, TimeSpan plusMinusRange)
        {
            return new CloseToAssertion(time, plusMinusRange);
        }
    }
}