using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class NullableIntegerAssertionFeature
    {
        [Test]
        public void IsNull_OnNotAppearingNinja_ShouldSucceed()
        {
            // arrange
            var notAppearingNinja = new AppearingNinja(null);

            // act
            var result = notAppearingNinja.Evaluate(n => n.Property(x => x.FirstAppearance).IsNull());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.log)        .IsEqualTo("AppearingNinja: ( )FirstAppearance = null")
                                  .p(x => x.expectation).IsEqualTo("(expected: null)"));
        }

        [Test]
        public void IsNull_OnEarlyAppearingNinja_ShouldFail()
        {
            // arrange
            var earlyAppearingNinja = new AppearingNinja(1);

            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Property(x => x.FirstAppearance).IsNull());

            // asset
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.log).IsEqualTo("AppearingNinja: ( )FirstAppearance = null")
                                  .p(x => x.expectation).IsEqualTo("(expected: null)"));
        }

        private class AppearingNinja : Ninja
        {
            public readonly int? FirstAppearance;

            public AppearingNinja(int? firstAppearance)
            {
                this.FirstAppearance = firstAppearance;
            }
        }
    }
}