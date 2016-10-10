using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Times;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasHour_Feature
    {
        [Test]
        public void OnLunchTime_With12_ShouldPass()
        {
            var dojo = new Dojo(Naruto(), LunchTime());

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasHour(12));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 16.11.1984 12:00:00")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has hour 12)"));
        }

        [Test]
        public void On5oClock_With3_ShouldFail()
        {
            var dojo = new Dojo(Naruto(), 5.March(2016).At(5.Hours(20)));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasHour(3));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: (X)Founded = 05.03.2016 05:20:00")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has hour 3)"));
        }
    }
}