using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasMonth_Feature
    {
        [Test]
        public void OnCommonFoundationDay_With11_ShouldPass()
        {
            var dojo = new Dojo(Naruto(), CommonFoundationDay());

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasMonth(11));

            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)     .IsEqualTo("Dojo: ( )Founded = 15.11.1515")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has month 11)"));
        }

        [Test]
        public void OnAprilDay_With5_ShouldFail()
        {
            var dojo = new Dojo(Naruto(), 3.April(1968));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasMonth(5));

            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo("Dojo: (X)Founded = 03.04.1968")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has month 5)"));
        }
    }
}