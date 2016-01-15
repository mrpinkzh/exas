using System;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class DateTimeAssertionFeature
    {
        private readonly DateTime commonDojoFoundationDay = new DateTime(1515, 11, 15);

        [Test]
        public void SameDayAs_OnCommonDojoFoundationDay_WithCommonDojoFoundationDay_ShouldSucceed()
        {
            var dojo = new Dojo(new Ninja(), commonDojoFoundationDay);
            var result = dojo.Evaluate(d => d.Property(x => x.Founded).IsOnSameDayAs(commonDojoFoundationDay.AddHours(12)));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Dojo: ( )Founded = 11/15/1515 (expected: 11/15/1515)",
                            result.PrintLog());
        }

        [Test]
        public void SameDayAs_OnCommonDojoFoundationDay_With200YearsLater_ShouldFail()
        {
            var dojo = new Dojo(new Ninja(), commonDojoFoundationDay);
            var result = dojo.Evaluate(d => d.Property(x => x.Founded).IsOnSameDayAs(commonDojoFoundationDay.AddYears(200)));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Dojo: (X)Founded = 11/15/1515 (expected: 11/15/1715)",
                            result.PrintLog());
        }

        [Test]
        public void CloseTo_OnLunchTime_WithLunchTimePlus5Seconds_ShouldPass()
        {
            var dinnerAppointment = new DinnerAppointment(Times.LunchTime());
            var result = dinnerAppointment.Evaluate(da => da.Property(x => x.Time).IsCloseTo(Times.LunchTime(), 5.Seconds()));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("DinnerAppointment: ( )Time = 11/16/1984 12:00:00.000 (expected between 11/16/1984 11:59:55.000 and 11/16/1984 12:00:05.000)",
                             result.PrintLog());
        }

        [Test]
        public void CloseTo_OnLunchTime_WithDinnerTimePlus5Seconds_ShouldFail()
        {
            var dinnerAppointment = new DinnerAppointment(Times.LunchTime());
            var result = dinnerAppointment.Evaluate(da => da.Property(x => x.Time).IsCloseTo(Times.DinnerTime(), 5.Seconds()));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("DinnerAppointment: (X)Time = 11/16/1984 12:00:00.000 (expected between 11/16/1984 17:59:55.000 and 11/16/1984 18:00:05.000)",
                             result.PrintLog());
        }
    }
}