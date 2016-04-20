using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Creation.CreateDojos;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_Before_Feature
    {
        [Test]
        public void ExpectingBeforeStandardDay_OnMedievalFoundation_ShouldSucceed()
        {
            var dojo = new Dojo(new Ninja(), founded: 12.March(878));

            // act
            Result result = dojo.Evaluate(d => d.Member(x => x.Founded).IsBefore(StandardDay()));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 03/12/0878 00:00:00")
                                  .Member(x => x.expectation).IsEqualTo(Expected("before 11/16/1984 00:00:00")));
        }
    }
}