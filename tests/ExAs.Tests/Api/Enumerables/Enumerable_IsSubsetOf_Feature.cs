using System.Collections.Generic;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_IsSubsetOf_Feature
    {
        [Test]
        public void OnShuriken_WithSwordAndShuriken_ShouldPass()
        {
            var ninja = new WeaponedNinja("Shuriken");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf("Sword", "Shuriken"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = ['Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: is subset of ['Sword', 'Shuriken'])"));
        }

        [Test]
        public void OnSwordAndShuriken_WithSword_ShouldFail()
        {
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf(new List<string> {"Sword"}));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: is subset of ['Sword'])"));
        }

        [Test]
        public void OnSwordAndShuriken_WithShurikenAndSword_ShouldPass()
        {
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf("Shuriken", "Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue());
        }

        [Test]
        public void OnWeaponless_WithSwordAndShuriken_ShouldPass()
        {
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf("Sword", "Shuriken"));

            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void OnSwordAndNullWeapon_WithSwordAndNull_ShouldPass()
        {
            var ninja = new WeaponedNinja("Sword", null);

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf("Sword", null));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', null]")
                                  .Member(x => x.expectation).IsEqualTo("(expected: is subset of ['Sword', null])"));
        }

        [Test]
        public void OnNull_WithSword_ShouldFail()
        {
            var ninja = new WeaponedNinja(null);

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf("Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = null"));
        }

        [Test]
        public void OnSword_WithNull_ShouldFail()
        {
            var ninja = new WeaponedNinja("Sword");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).IsSubsetOf(null));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: is subset of null)"));
        }

    }
}