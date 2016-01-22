using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class NullableBooleanAssertionFeature
    {
        private readonly FightNinja virginNinja = new FightNinja(null);
        private readonly FightNinja defeatedNinja = new FightNinja(true);

        [Test]
        public void IsNull_OnVirginNinja_ShouldPass()
        {
            // act
            var result = virginNinja.Evaluate(n => n.Member(x => x.defeated).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = null", "(expected: null)"));
        }

        [Test]
        public void IsNull_OnDefeatedNinja_ShouldFail()
        {
            // act
            var result = defeatedNinja.Evaluate(n => n.Member(x => x.defeated).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = True", "(expected: null)"));
        }

        [Test]
        public void IsNotNull_OnDefeatedNinja_ShouldSucceed()
        {
            // act
            var result = defeatedNinja.Evaluate(n => n.Member(x => x.defeated).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = True", "(expected: not null)"));
        }

        [Test]
        public void IsNotNull_OnVirginNinja_ShouldFail()
        {
            // act
            var result = virginNinja.Evaluate(n => n.Member(x => x.defeated).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = null", "(expected: not null)"));
        }

        [Test]
        public void IsEqual_ExpectingTrue_OnDefeatedNinja_ShouldSucceed()
        {
            // act
            var result = defeatedNinja.Evaluate(n => n.Member(x => x.defeated).IsEqualTo(true));

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = True", "(expected: True)"));
        }

        [Test]
        public void IsEqual_ExpectingTrue_OnVirginNinja_ShouldFail()
        {
            // act
            var result = virginNinja.Evaluate(n => n.Member(x => x.defeated).IsEqualTo(true));

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = null", "(expected: True)"));
        }

        [Test]
        public void IsTrue_OnDefeatedNinja_ShouldSucceed()
        {
            // act
            var result = defeatedNinja.Evaluate(n => n.Member(x => x.defeated).IsTrue());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = True", "(expected: True)"));
        }

        [Test]
        public void IsTrue_OnVirginNinja_ShouldFail()
        {
            // act
            var result = virginNinja.Evaluate(n => n.Member(x => x.defeated).IsTrue());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = null", "(expected: True)"));
        }

        [Test]
        public void IsFalse_OnUndefeatedNinja_ShouldSucceed()
        {
            // arrange
            var undefeatedNinja = new FightNinja(false);

            // act
            var result = undefeatedNinja.Evaluate(n => n.Member(x => x.defeated).IsFalse());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = False", "(expected: False)"));
        }

        [Test]
        public void IsFalse_OnVirginNinja_ShouldFail()
        {
            // act
            var result = virginNinja.Evaluate(n => n.Member(x => x.defeated).IsFalse());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = null", "(expected: False)"));
        }

        private class FightNinja : Ninja
        {
            public readonly bool? defeated;

            public FightNinja(bool? defeated)
            {
                this.defeated = defeated;
            }
        }
    }
}