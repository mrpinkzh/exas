using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static System.Environment;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_Contains_Feature
    {
        [Test]
        public void ExpectingShuriken_OnNinjaWithShuriken_ShouldSucceed()
        {
            // act
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).Contains("Shuriken"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo(ComposeLog.Expected("contains ['Shuriken']")));
        }

        [Test]
        public void ExpectingSword_OnNinjaWeaponlessNinja_ShouldFail()
        {
            // act
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).Contains("Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)   .IsEqualTo("WeaponedNinja: (X)Weapons = <empty>")
                                  .Member(x => x.expectation).Contains("contains ['Sword']"));
        }

        [Test]
        public void ExpectingShurikenAndSword_OnNinjaWithBoth_ShouldSucceed()
        {
            // act
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).Contains("Shuriken", "Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.expectation).Contains("contains ['Shuriken', 'Sword']"));
        }

        [Test]
        public void ExpectingMultiLineRiffle_OnWeaponlessNinja_ShouldShortenExpectation()
        {
            // act
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).Contains($"Assault{NewLine}Rifle"));

            // assert
            StringAssert.Contains("contains <1 String>", result.expectation);
        }

        [Test]
        public void ExpectingNull_OnNinjaWithTwoWeapons_ShouldFail()
        {
            // act
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).Contains(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.expectation).Contains("contains null"));
        }

        [Test]
        public void ExpectingWeaponNull_OnNinjaWithTwoWeapons_ShouldFail()
        {
            // act
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).Contains("Sword", null));

            // assert
            StringAssert.Contains("contains ['Sword', null]", result.expectation);
        }

        [Test]
        public void ExpectingSword_OnNinjaWithNullWeapons_ShouldFail()
        {
            // act           
            var result = new WeaponedNinja(null).Evaluate(n => n.Member(x => x.Weapons).Contains("Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)   .IsEqualTo("WeaponedNinja: (X)Weapons = null")
                                  .Member(x => x.expectation).Contains("contains ['Sword']"));
        }
    }
}