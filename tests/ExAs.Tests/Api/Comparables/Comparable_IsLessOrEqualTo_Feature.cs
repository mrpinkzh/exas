using ExAs.Results;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.ComposeLog;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsLessOrEqualTo_Feature
    {
        [Test]
        public void ExpectedLessOrEqual12_OnAge12_ShouldPass()
        {
            // act
            Result result = Naruto().Evaluate(n => n.Member(x => x.Age).IsLessOrEqualTo(12));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual).IsEqualTo("Ninja: ( )Age = 12")
                                  .Member(x => x.expectation).IsEqualTo(Expected("less or equal to 12")));
        }

        [Test]
        public void ExpectedLessOrEqual25_OnAge26_ShouldFail()
        {
            // act
            Result result = Kakashi().Evaluate(n => n.Member(x => x.Age).IsLessOrEqualTo(25));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual).IsEqualTo("Ninja: (X)Age = 26")
                                  .Member(x => x.expectation).IsEqualTo(Expected("less or equal to 25")));
        }

        [Test]
        public void ExpectedLessOrEqualNull_OnNameNaruto_ShouldLetStringCompareDecide()
        {
            // act
            Result result = Naruto().Evaluate(n => n.Member(x => x.Name).IsLessOrEqualTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.actual).IsEqualTo("Ninja: (X)Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo(Expected("less or equal to null")));
        }

        [Test]
        public void ExpectedLessOrEqualNaruto_OnNameNull_ShouldLetStringCompareDecide()
        {
            // act
            Result result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsLessOrEqualTo("Naruto"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual).IsEqualTo("Ninja: (X)Name = null")
                                  .Member(x => x.expectation).IsEqualTo(Expected("less or equal to 'Naruto'")));
        }

        [Test]
        public void ExpectedLessOrEqualNull_OnNameNull_ShouldPass()
        {
            // act
            Result result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsLessOrEqualTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual).IsEqualTo("Ninja: ( )Name = null")
                                  .Member(x => x.expectation).IsEqualTo(Expected("less or equal to null")));
        }
    }
}