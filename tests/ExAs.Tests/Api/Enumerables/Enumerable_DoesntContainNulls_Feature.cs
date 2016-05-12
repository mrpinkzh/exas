using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_DoesntContainNulls_Feature
    {
        [Test]
        public void OnNinjaWithSwordAndShuriken_ShouldSucceed()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).DoesntContainNulls());

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken'] (expected: doesn't contain nulls)"));
        }

        [Test]
        public void OnNinjaWithSwordAndNull_ShouldFail()
        {
            // arrange
            var ninja = new WeaponedNinja("Sword", null);

            // act
            Result result = ninja.Evaluate(n => n.Member(x => x.Weapons).DoesntContainNulls());

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = ['Sword', null] (expected: doesn't contain nulls)"));
        }

        [Test]
        public void OnNinjaWithNullWeapons_ShouldSucceed()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.NullWeaponList()).DoesntContainNulls());

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )NullWeaponList() = null (expected: doesn't contain nulls)"));
        }
    }
}