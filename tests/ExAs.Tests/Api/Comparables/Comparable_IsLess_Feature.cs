using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsLess_Feature
    {
        [Test]
        public void Expected43_2_Get38_4_ShouldPass()
        {
            Result result = PadavanNaruto().Evaluate(n => n.p(x => x.SkillValue).IsLessThan(43.2));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: ( )SkillValue = 38.4")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 43.2)"));
        }

        [Test]
        public void Expected99_2_Get99_7_ShouldFail()
        {
            Result result = SkilledNaruto().Evaluate(n => n.p(x => x.SkillValue).IsLessThan(99.2));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: (X)SkillValue = 99.7")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 99.2)"));
        }
        [Test]
        public void Expected13_Get12_ShouldPass()
        {
            Result result = Naruto().Evaluate(n => n.p(x => x.Age).IsLessThan(13));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: ( )Age = 12")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 13)"));
        }

        [Test]
        public void Expected26_Get26_ShouldFail()
        {
            Result result = Kakashi().Evaluate(n => n.p(x => x.Age).IsLessThan(26));
            result.ExAssert(r => r.p(x => x.succeeded)  .IsFalse()
                                  .p(x => x.actual)     .IsEqualTo("Ninja: (X)Age = 26")
                                  .p(x => x.expectation).IsEqualTo("(expected: smaller than 26)"));
        }

        [Test]
        public void ExpectingSmallerThan66_OnNinjaWith65_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.ShortAge()).IsLessThan(66));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )ShortAge() = 12", "(expected: smaller than 66)"));
        }
    }
}