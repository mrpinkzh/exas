using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Times;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_HasMillisecond_Feature
    {
        [Test]
        public void OnTimeWith233Milliseconds_With233_ShouldPass()
        {
            var dojo = new Dojo(Naruto(), LunchTime().Add(233.Milliseconds()));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasMillisecond(233));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: ( )Founded = 1984-11-16T12:00:00.2330000")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has millisecond 233)"));
        }

        [Test]
        public void OnTimeWith746Milliseconds_With1_ShouldFail()
        {
            var dojo = new Dojo(Naruto(), LunchTime().Add(746.Milliseconds()));

            var result = dojo.Evaluate(d => d.Member(x => x.Founded).HasMillisecond(1));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("Dojo: (X)Founded = 1984-11-16T12:00:00.7460000")
                                  .Member(x => x.expectation).IsEqualTo("(expected: has millisecond 1)"));
        }
    }
}