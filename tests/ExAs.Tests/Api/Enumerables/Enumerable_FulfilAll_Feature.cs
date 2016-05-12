using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_FulfilAll_Feature
    {
        [Test]
        public void ExpectingContainWord_OnNinjaWithSword_ShouldSucceed()
        {
            // arrange
            var ninja = new WeaponedNinja("Sword");

            // act
            Result result = ninja.Evaluate(n => n.Member(x => x.Weapons).FulfilAll(w => w.Contains("word")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword'] (expected: all fulfil w => w.Contains(\"word\"))"));
        }

        [Test]
        public void ExpectingContainsUrike_OnNinjaWithoutWeapon_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).FulfilAll(w => w.Contains("urike")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = <empty> (expected: all fulfil w => w.Contains(\"urike\"))"));

        }

        [Test]
        public void ExpectingContainUrike_OnNinjaWithWeapons_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).FulfilAll(w => w.Contains("urike")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken'] (expected: all fulfil w => w.Contains(\"urike\"))"));
        }

        [Test]
        public void ExpectingNull_OnNinjaWithWeapons_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).FulfilAll(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken'] (expected: all fulfil null)"));
        }

        [Test]
        public void ExpectingAnytihing_OnNinjaWithNullWeapons_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.NullWeaponList()).FulfilAll(w => true));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)NullWeaponList() = null (expected: all fulfil w => True)"));
        }
    }
}