using System.Collections.Generic;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_ContainsInOrder_Feature
    {
        private readonly WeaponedNinja threeWeaponNinja = new WeaponedNinja("Sword", "Shuriken", "Bow");

        [Test]
        public void OnSwordShurikenAndBow_WithSwordAndShuriken_ShouldPass()
        {
            var result = threeWeaponNinja.Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder("Sword", "Shuriken"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken', 'Bow']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: contains in order ['Sword', 'Shuriken'])"));
        }

        [Test]
        public void OnSwordShurikenAndBow_WithShurikenAndSword_ShouldFail()
        {
            var result = threeWeaponNinja.Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder("Shuriken", "Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken', 'Bow']")
                                  .Member(x => x.expectation).IsEqualTo("(expected: contains in order ['Shuriken', 'Sword'])"));
        }

        [Test]
        public void OnSwordShurikenAndBow_WithShurikenAndBow_ShouldPass()
        {
            var result = threeWeaponNinja.Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder("Shuriken", "Bow"));

            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue());
        }

        [Test]
        public void OnSwordShurikenBowSwordAndBow_WithSwordAndShuriken_ShouldPass()
        {
            var ninja = new WeaponedNinja("Sword", "Shuriken", "Bow", "Sword", "Bow");

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder("Sword", "Bow"));

            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue());
        }
        
        [Test]
        public void OnNullWeapons_WithSword_ShouldFail()
        {
            var ninja = new WeaponedNinja(null);

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder("Sword"));

            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse());
        }

        [Test]
        public void OnSwordAndShuriken_WithNullList_ShouldFail()
        {
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder((IList<string>)null));

            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse());
        }

        [Test]
        public void OnSwordShurikenAndNull_WithShurikenAndNull_ShouldPass()
        {
            var ninja = new WeaponedNinja("Sword", "Shuriken", null);

            var result = ninja.Evaluate(n => n.Member(x => x.Weapons).ContainsInOrder("Shuriken", null));

            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue());
        }
    }
}