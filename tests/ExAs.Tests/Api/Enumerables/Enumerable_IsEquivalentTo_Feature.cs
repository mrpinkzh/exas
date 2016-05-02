using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_IsEquivalentTo_Feature
    {
        private readonly WeaponedNinja swordNinja = new WeaponedNinja("Sword");

        [Test]
        public void ExpectingShurikenAndSword_OnNinjaWithBothDifferentOrder_ShouldSucceed()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).IsEquivalentTo("Shuriken", "Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken'] (expected: equivalent to ['Shuriken', 'Sword'])"));
        }

        [Test]
        public void ExpectingNoWeapon_OnNinjaWithSword_ShouldFail()
        {
            // act
            Result result = swordNinja.Evaluate(n => n.Member(x => x.Weapons).IsEquivalentTo(new List<string>()));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword'] (expected: equivalent to <empty>)"));
        }

        [Test]
        public void ExpectingShuriken_OnNinjaWithSword_ShouldFail()
        {
            // act
            Result result = swordNinja.Evaluate(n => n.Member(x => x.Weapons).IsEquivalentTo("Shuriken"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword'] (expected: equivalent to ['Shuriken'])"));
        }

        [Test]
        public void ExpectingNull_OnWeaponLessNinja_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).IsEquivalentTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = <empty> (expected: equivalent to null)"));
        }

        [Test]
        public void ExpectingShuriken_OnNullWeapon_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.NullWeaponList()).IsEquivalentTo("Shuriken"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)NullWeaponList() = null (expected: equivalent to ['Shuriken'])"));
        }

        [Test]
        public void ExpectingNull_OnNullWeapon_ShouldSucceed()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.NullWeaponList()).IsEquivalentTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )NullWeaponList() = null (expected: equivalent to null)"));
        }

        [Test]
        public void ExpectingSwordAndNull_OnNinjaWithSwordAndNull_ShouldSucceed()
        {
            // arrange
            var ninja = new WeaponedNinja("Sword", null);

            // act
            Result result = ninja.Evaluate(n => n.Member(x => x.Weapons).IsEquivalentTo(null, "Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', null] (expected: equivalent to [null, 'Sword'])"));
        }
    }
}