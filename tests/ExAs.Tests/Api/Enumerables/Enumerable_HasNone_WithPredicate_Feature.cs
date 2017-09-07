using System;
using System.Linq.Expressions;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.ComposeLog;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_HasNone_WithPredicate_Feature
    {
        [Test]
        public void ExpectingNoneStartingWithSw_OnWeaponlessNinja_ShouldSucceed()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).HasNonePredicate(w => w.StartsWith("Sw")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)    .IsEqualTo("WeaponedNinja: ( )Weapons = <empty>")
                                  .Member(x => x.expectation).IsEqualTo(Expected("none fulfils w => w.StartsWith(\"Sw\")")));
        }

        [Test]
        public void ExpectingNoneStartingWithShu_OnNinjaWithShuriken_ShouldFail()
        {
            // act
            Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).HasNonePredicate(w => w.StartsWith("Shu")));

            // assert
            Console.WriteLine(result.PrintLog());
            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo($"WeaponedNinja: (X)Weapons = ['Sword', 'Shuriken'] (expected: none fulfils w => w.StartsWith(\"Shu\"))"));
        }

        [Test]
        public void ExpectingNullPredicate_OnWeaponlessNinja_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).HasNonePredicate((Expression<Func<string, bool>>)null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.expectation).IsEqualTo(Expected("none fulfils null")));
        }

        [Test]
        public void ExpectingNoneStartingWithSw_OnNullWeapons_ShouldSucceed()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.NullWeaponList()).HasNonePredicate(w => w.StartsWith("Sw")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )NullWeaponList() = null (expected: none fulfils w => w.StartsWith(\"Sw\"))"));
        }
    }
}