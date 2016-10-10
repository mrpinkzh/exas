using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;
using static ExAs.Utils.Times;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasMinute_Feature
    {
        [Test]
        public void OnQuarterPast_With15_ShouldPass()
        {
            var dojo = new Dojo(Naruto(), StandardDay().At(12.Hours(15)));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasMinute(15));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 16.11.1984 12:15:00")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has minute 15)"));
        }

        [Test]
        public void OnHalfPast_With17_ShouldFail()
        {
            var dojo = new Dojo(Naruto(), 14.December(2015).At(13.Hours(30)));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasMinute(17));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: (X)Founded = 14.12.2015 13:30:00")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has minute 17)"));
        }
    }
}