using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Dates;
using static ExAs.Utils.Times;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_After_Feature
    {
        private static Dojo StandardDayDojo()
        {
            return new Dojo(new Ninja(), founded: StandardDay());
        }

        [Test]
        public void ExpectingAfterChristBirth_OnStandardDay_ShouldSucceed()
        {
            // act
            Result result = StandardDayDojo().Evaluate(d => d.Member(x => x.Founded).IsAfter(1.January(0001)));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 11/16/1984 00:00:00")
                                  .Member(x => x.expectation).IsEqualTo(Expected("after 01/01/0001 00:00:00")));
        }

        [Test]
        public void ExpectingAfterStandardDay_OnADayInMedieval_ShouldFail()
        {
            // arrange
            var dojo = new Dojo(new Ninja(), founded: 11.March(1515));

            // act
            Result result = dojo.Evaluate(d => d.Member(x => x.Founded).IsAfter(StandardDay()));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)   .IsEqualTo("Dojo: (X)Founded = 03/11/1515 00:00:00")
                                  .Member(x => x.expectation).Contains("after 11/16/1984 00:00:00"));
        }

        [Test]
        public void ExpectingAfterStandardDay_OnStandardDay_ShouldFail()
        {
            // act
            Result result = StandardDayDojo().Evaluate(d => d.Member(x => x.Founded).IsAfter(StandardDay()));

            // assert
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void ExpectingAfterStandardDay_OnStandardAndHalfDay_ShouldSucceed()
        {
            // arrange
            var dojo = new Dojo(new Ninja(), founded: 16.November(1984).At(13.Hours(00)));
            
            // act
            Result result = dojo.Evaluate(d => d.Member(x => x.Founded).IsAfter(StandardDay()));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("Dojo: ( )Founded = 11/16/1984 13:00:00"));
        }
    }
}