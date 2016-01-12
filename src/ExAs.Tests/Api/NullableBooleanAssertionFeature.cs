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
            var result = virginNinja.Evaluate(n => n.Property(x => x.defeated).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = null", "(expected: null)"));
        }

        [Test]
        public void IsNull_OnDefeatedNinja_ShouldFail()
        {
            // act
            var result = defeatedNinja.Evaluate(n => n.Property(x => x.defeated).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = True", "(expected: null)"));
        }

        [Test]
        public void IsNotNull_OnDefeatedNinja_ShouldSucceed()
        {
            // act
            var result = defeatedNinja.Evaluate(n => n.Property(x => x.defeated).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = True", "(expected: not null)"));
        }

        [Test]
        public void IsNotNull_OnVirginNinja_ShouldFail()
        {
            // act
            var result = virginNinja.Evaluate(n => n.Property(x => x.defeated).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = null", "(expected: not null)"));
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