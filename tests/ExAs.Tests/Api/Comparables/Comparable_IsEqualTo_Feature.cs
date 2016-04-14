using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsEqualTo_Feature
    {
        [Test]
        public void Double_Expect38_4_Get38_4_ShouldPass()
        {
            Result result = PadavanNaruto().Evaluate(n => n.Member(x => x.SkillValue).IsEqualTo(38.4));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: ( )SkillValue = 38.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: 38.4)"));
        }

        [Test]
        public void Double_IsEqualTo_Expect38_4_Get13_8_ShouldFail()
        {
            Result result = PadavanNaruto().Evaluate(n => n.p(x => x.SkillValue).IsEqualTo(13.8));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: (X)SkillValue = 38.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: 13.8)"));
        }

        [Test]
        public void Integer_Expect12_Get12_ShouldPass()
        {
            Result result = Naruto().Evaluate(n => n.Member(x => x.Age).IsEqualTo(12));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: ( )Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: 12)"));
        }

        [Test]
        public void Integer_Expect13_Get12_ShouldFail()
        {
            Result result = Naruto().Evaluate(n => n.p(x => x.Age).IsEqualTo(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: (X)Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: 13)"));
        }

        [Test]
        public void Short_Expecting12_OnNinjaWith12_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.ShortAge()).IsEqualTo(12));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )ShortAge() = 12", "(expected: 12)"));
        }
    }
}