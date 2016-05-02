using ExAs.Results;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Creation.CreateNinjas;
using static System.Environment;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_HasNone_WithPredicate_Feature
    {
        [Test]
        public void ExpectingNoneStartingWithSw_OnWeaponlessNinja_ShouldSucceed()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).HasNone(w => w.StartsWith("Sw")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = <empty>")
                                  .Member(x => x.expectation).IsEqualTo(Expected("0 matches")));
        }

        [Test]
        public void ExpectingNoneStartingWithShu_OnNinjaWithShuriken_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).HasNone(w => w.StartsWith("Shu")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo($"WeaponedNinja: (X)Weapons = <1 match>")//{NewLine}" +"")
                                                                        //$"                            'Sword'{NewLine}" +
                                                                        //$"                            'Shuriken'")
                                  .Member(x => x.expectation).IsEqualTo($"1 match{NewLine}" +
                                                                        $""));
        }
    }
}