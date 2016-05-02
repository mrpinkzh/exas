using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_DoesntContain_Feature
    {
        [Test]
        public void ExpectingNoShuriken_OnWeaponlessNinja_ShouldSucceed()
        {
            // act
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).DoesntContain("Shuriken"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("WeaponedNinja: ( )Weapons = <empty>")
                                  .Member(x => x.expectation).IsEqualTo(ComposeLog.Expected("doesn't contain ['Shuriken']")));
        }

        [Test]
        public void ExpectingNoSword_OnTwoWeaponNinja_ShouldFail()
        {
            // act
            var result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).DoesntContain("Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).Contains("doesn't contain ['Sword']"));
        }

        [Test]
        public void ExpectingNull_ShouldSucceed()
        {
            // act
            var result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).DoesntContain(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.expectation).Contains("doesn't contain null"));
        }

        [Test]
        public void ExpectingNoSwordAndShuriken_OnNullWeaponNinja_ShouldSucceed()
        {
            // act
            var result = new WeaponedNinja(null).Evaluate(n => n.Member(x => x.Weapons).DoesntContain("Sword", "Shuriken"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = null")
                                  .Member(x => x.expectation).Contains("doesn't contain ['Sword', 'Shuriken']"));
        }
    }
}