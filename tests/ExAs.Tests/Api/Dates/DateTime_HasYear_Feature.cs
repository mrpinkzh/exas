using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasYear_Feature
    {
        [Test]
        public void OnCommonFoundationDay_With1515_ShouldPass()
        {
            // arrange
            var dojo = new Dojo(Naruto(), CommonFoundationDay());

            // act
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasYear(1515));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)     .IsEqualTo("Dojo: ( )Founded = 15.11.1515")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has year 1515)"));
        }

        [Test]
        public void OnStandardDay_With2016_ShouldFail()
        {
            // arrange
            var dojo = new Dojo(Naruto(), StandardDay());

            // act
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasYear(2016));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo("Dojo: (X)Founded = 16.11.1984")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has year 2016)"));
        }
    }
}