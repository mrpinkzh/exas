using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Times;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_CloseTo_Feature
    {
        [Test]
        public void OnLunchTime_WithLunchTimePlus5Seconds_ShouldPass()
        {
            var dinnerAppointment = new DinnerAppointment(LunchTime());
            var result = dinnerAppointment.Evaluate(da => da.Member(x => x.Time).IsCloseTo(LunchTime(), 5.Seconds()));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("DinnerAppointment: ( )Time = 11/16/1984 12:00:00.000 (expected between 11/16/1984 11:59:55.000 and 11/16/1984 12:00:05.000)",
                             result.PrintLog());
        }

        [Test]
        public void OnLunchTime_WithDinnerTimePlus5Seconds_ShouldFail()
        {
            var dinnerAppointment = new DinnerAppointment(LunchTime());
            var result = dinnerAppointment.Evaluate(da => da.Member(x => x.Time).IsCloseTo(DinnerTime(), 5.Seconds()));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("DinnerAppointment: (X)Time = 11/16/1984 12:00:00.000 (expected between 11/16/1984 17:59:55.000 and 11/16/1984 18:00:05.000)",
                             result.PrintLog());
        }
    }
}