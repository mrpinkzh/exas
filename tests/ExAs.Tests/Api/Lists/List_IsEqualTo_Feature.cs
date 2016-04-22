using System.Collections.Generic;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Lists
{
    [TestFixture]
    public class List_IsEqualTo_Feature
    {
        [Test]
        public void ExpectingSwordAndShuriken_OnNinjaWithBothInThisOrder_ShouldSucceed()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Sword", "Shuriken"));

            // assert
            result.Evaluate(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: ( )WeaponList() = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Sword', 'Shuriken']")));
        }

        [Test]
        public void ExpectingSword_OnNinjaWithNone_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)   .IsEqualTo("WeaponedNinja: (X)WeaponList() = <empty>")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Sword']")));
        }

        [Test]
        public void ExpectingSword_OnNinjaWithBoth_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo(new List<string> {"Sword"}));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)     .IsFalse()
                                  .Member(x => x.expectation)   .IsEqualTo(Expected("['Sword']")));
        }

        [Test]
        public void ExpectingSword_OnNinjaWithShuriken_ShouldFail()
        {
            // arrange
            var shurikenNinja = new WeaponedNinja("Shuriken");

            // act
            Result result = shurikenNinja.Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Sword"));

            // assert
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void ExpectingShurikenAndSword_OnNinjaWithBothDifferentOrder_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Shuriken", "Sword"));

            // assert
            result.Evaluate(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: (X)WeaponList() = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Shuriken', 'Sword']")));
        }

        [Test]
        public void ExpectingSwordAndShuriken_OnNinjaWithSwordAndNull_ShouldFail()
        {
            // arrange
            var ninja = new WeaponedNinja("Sword", null);

            // act
            Result result = ninja.Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Sword", "Shuriken"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: (X)WeaponList() = ['Sword', null]")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Sword', 'Shuriken']")));
        }

        [Test]
        public void ExpectingSwordAndNull_OnNinjaWithSwordAndShuriken_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Sword", null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual).IsEqualTo("WeaponedNinja: (X)WeaponList() = ['Sword', 'Shuriken']")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Sword', null]")));
        }

        [Test]
        public void ExpectingSwordAndNull_OnNinjaWithSwordAndNull_ShouldSucceed()
        {
            // arrange
            var ninja = new WeaponedNinja("Sword", null);

            // act
            Result result = ninja.Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo("Sword", null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: ( )WeaponList() = ['Sword', null]")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Sword', null]")));
        }

        [Test]
        public void ExpectingSword_OnNinjaWithNullWeapon_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.NullWeaponList()).IsEqualTo("Sword"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: (X)NullWeaponList() = null")
                                  .Member(x => x.expectation).IsEqualTo(Expected("['Sword']")));
        }

        [Test]
        public void ExpectingNull_OnWeaponlessNinja_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.WeaponList()).IsEqualTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: (X)WeaponList() = <empty>")
                                  .Member(x => x.expectation).IsEqualTo(Expected("null")));
        }

        [Test]
        public void ExpectingNull_OnNinjaWithNullWeapon_ShouldSucceed()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.NullWeaponList()).IsEqualTo(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)     .IsEqualTo("WeaponedNinja: ( )NullWeaponList() = null")
                                  .Member(x => x.expectation).IsEqualTo(Expected("null")));
        }
    }
}