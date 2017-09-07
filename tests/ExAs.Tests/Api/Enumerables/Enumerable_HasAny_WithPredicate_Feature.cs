using System;
using System.Linq.Expressions;
using ExAs.Results;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_HasAny_WithPredicate_Feature
    {
        [Test]
        public void ExpectingEndingWithOrd_OnNinjaWithSword_ShouldSucceed()
        {
			// act
			Result result = NinjaWithTwoWeapons().Evaluate(n => n.Member(x => x.Weapons).HasAnyPredicate(w => w.EndsWith("ord")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: ( )Weapons = ['Sword', 'Shuriken'] (expected: any fulfils w => w.EndsWith(\"ord\"))"));
        }

        [Test]
        public void ExpectingEndingWithIken_OnWeaponlessNinja_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).HasAnyPredicate(w => w.EndsWith("iken")));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded) .IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("WeaponedNinja: (X)Weapons = <empty> (expected: any fulfils w => w.EndsWith(\"iken\"))"));
        }

        [Test]
        public void ExpectingNullPredicate_OnWeaponlessNinja_ShouldFail()
        {
            // act
            Result result = WeaponlessNinja().Evaluate(n => n.Member(x => x.Weapons).HasAnyPredicate((Expression<Func<string, bool>>)null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.expectation).Contains("any fulfils null"));
        }
    }
}