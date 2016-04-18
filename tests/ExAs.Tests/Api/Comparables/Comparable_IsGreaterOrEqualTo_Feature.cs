using ExAs.Results;
using ExAs.Utils;
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

        [Test]
        public void ExpectedGreaterOrEqual12_OnShortAge12_ShouldSucceed()
        {
            // act
            Result result = Naruto().Evaluate(n => n.Member(x => x.ShortAge()).IsGreaterOrEqualTo((short)12));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual).IsEqualTo("Ninja: ( )ShortAge() = 12")
                                  .Member(x => x.expectation).IsEqualTo(Expected("greater or equal to 12")));
        }

        [Test]
        public void ExpectedGreaterOrEqualNull_OnNaruto_ShouldLetStringCompareDecide()
        {
            // act
            Result result = Naruto().Evaluate(n => n.Member(x => x.Name).IsGreaterOrEqualTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("Ninja: ( )Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo(Expected("greater or equal to null")));
        }

        [Test]
        public void ExpectedGreaterOrEqualNaruto_OnNullNinja_ShouldLetStringCompareDecide()
        {
            // act
            Result result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsGreaterOrEqualTo("Naruto"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)     .IsEqualTo("Ninja: ( )Name = null")
                                  .Member(x => x.expectation).IsEqualTo(Expected("greater or equal to 'Naruto'")));
        }

        [Test]
        public void ExpectedGreaterOrEqualNull_OnNullNinja_ShouldPass()
        {
            // act
            Result result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsGreaterOrEqualTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual).IsEqualTo("Ninja: ( )Name = null")
                                  .Member(x => x.expectation).IsEqualTo(Expected("greater or equal to null")));
        }
    }
}