using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;
using static ExAs.Utils.Times;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasSecond_Feature
    {
        [Test]
        public void OnDateWith15Seconds_With15Seconds_ShouldPass()
        {
            var dojo = new Dojo(Naruto(), LunchTime().Add(15.Seconds()));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasSecond(15));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 16.11.1984 12:00:15")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has second 15)"));
        }

        [Test]
        public void OnDateWith3_With55_ShouldFail()
        {
            var dojo = new Dojo(Naruto(), LunchTime().Add(3.Seconds()));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasSecond(55));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: (X)Founded = 16.11.1984 12:00:03")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has second 55)"));
        }
    }
}