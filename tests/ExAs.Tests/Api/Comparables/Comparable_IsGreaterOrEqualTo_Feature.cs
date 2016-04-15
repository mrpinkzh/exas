using ExAs.Results;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsGreaterOrEqualTo_Feature
    {
        [Test]
        public void ExpectedGreaterOrEqual12_OnAge12_ShouldSucceed()
        {
            // act
            Result result = Naruto().Evaluate(n => n.Member(x => x.Age).IsGreaterOrEqualTo(12));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("Ninja: ( )Age = 12")
                                  .Member(x => x.expectation).IsEqualTo(Expected("greater or equal to 12")));
        }

        [Test]
        public void ExpectedGreaterOrEqual27_OnAge26_ShouldFail()
        {
            // act
            Result result = Kakashi().Evaluate(n => n.Member(x => x.Age).IsGreaterOrEqualTo(27));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("Ninja: (X)Age = 26")
                                  .Member(x => x.expectation).IsEqualTo(Expected("greater or equal to 27")));
        }
    }
}