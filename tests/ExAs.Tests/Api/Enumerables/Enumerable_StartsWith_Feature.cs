using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_StartsWith_Feature
    {
        [Test]
        public void OnSwordShurikenAndBow_WithSword_ShouldPass()
        {
            var ninja = new WeaponedNinja("Sword", "Shuriken", "Bow");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).StartsWith("Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken', 'Bow']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: starts with 'Sword')"));
        }

        [Test]
        public void OnShurikenAndBow_WithPistol_ShouldFail()
        {
            var ninja = new WeaponedNinja("Shuriken", "Bow");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).StartsWith("Pistol"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = ['Shuriken', 'Bow']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: starts with 'Pistol')"));
        }

        [Test]
        public void OnShurikenAndBow_WithBow_ShouldFail()
        {
            var ninja = new WeaponedNinja("Shuriken", "Bow");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).StartsWith("Bow"));

            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: starts with 'Bow')"));
        }

        [Test]
        public void OnWeaponlessNinja_WithSword_ShouldFail()
        {
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).StartsWith("Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = <empty>"));
        }

        [Test]
        public void OnWeaponlessNinja_WithNull_ShouldFail()
        {
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).StartsWith(null));

            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)   .IsEqualTo("WeaponedNinja: (X)Weapons = <empty>")
                                  .Member(x => x.expectation).IsEqualTo("(expected: starts with null)"));
        }

        [Test]
        public void OnNinjaWithNullWeapons_WithSword_ShouldFail()
        {
            var ninja = new WeaponedNinja(null);

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).StartsWith("Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = null"));
        }

        [Test]
        public void OnNinjaWithFirstWeaponNull_WithNull_ShouldPass()
        {
            var ninja = new WeaponedNinja(null, "Shuriken");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).StartsWith(null));

            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue());
        }

        [Test]
        public void OnThreeDojoCities_WithNull_ShouldFail()
        {
            var result = ThreeDojoCity().Evaluate(n => n.Member(x => x.Dojos).StartsWith(null));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("City: (X)Dojos = <3 Dojos>")
                                  .Member(x => x.expectation).IsEqualTo("(expected: starts with null)"));
        }
    }
}