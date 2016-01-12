using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class NullableBooleanAssertionFeature
    {
        [Test]
        public void IsNull_OnVirginNinja_ShouldPass()
        {
            // arrange
            var virginNinja = new FightNinja(null);

            // act
            var result = virginNinja.Evaluate(n => n.Property(x => x.defeated).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "FightNinja: ( )defeated = null", "(expected: null)"));
        }

        [Test]
        public void IsNull_OnDefeatedNinja_ShouldFail()
        {
            // act
            var defeatedNinja = new FightNinja(true);

            // act
            var result = defeatedNinja.Evaluate(n => n.Property(x => x.defeated).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "FightNinja: (X)defeated = True", "(expected: null)"));
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