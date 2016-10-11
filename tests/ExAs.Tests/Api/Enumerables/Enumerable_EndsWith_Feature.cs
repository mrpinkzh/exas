using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_EndsWith_Feature
    {
        [Test]
        public void OnSwordShurikenAndBow_WithBow_ShouldPass()
        {
            var ninja = new WeaponedNinja("Sword", "Shuriken", "Bow");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).EndsWith("Bow"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken', 'Bow']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: ends with 'Bow')"));
        }

        [Test]
        public void OnSwordAndShuriken_WithSword_ShouldFail()
        {
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).EndsWith("Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: ends with 'Sword')"));
        }

        [Test]
        public void OnEmptyList_WithBow_ShouldFail()
        {
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).EndsWith("Bow"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = <empty>"));
        }

        [Test]
        public void OnWeaponless_WithNull_ShouldFail()
        {
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).EndsWith(null));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: ends with null)"));
        }

        [Test]
        public void OnNullWeapons_WithBow_ShouldFail()
        {
            var ninja = new WeaponedNinja(null);

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).EndsWith("Bow"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = null"));
        }
    }
}