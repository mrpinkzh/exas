using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasDay_Feature
    {
        [Test]
        public void OnCommonStandardDay_With16_ShouldPass()
        {
            var dojo = new Dojo(Naruto(), StandardDay());

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasDay(16));

            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("Dojo: ( )Founded = 16.11.1984")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has day 16)"));
        }

        [Test]
        public void On3rd_With9_ShouldFail()
        {
            var dojo = new Dojo(Naruto(), 3.August(2016));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasDay(9));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: (X)Founded = 03.08.2016")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has day 9)"));
        }
    }
}