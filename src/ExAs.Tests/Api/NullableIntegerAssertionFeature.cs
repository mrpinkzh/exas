using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class NullableIntegerAssertionFeature
    {
        private readonly AppearingNinja notAppearingNinja = new AppearingNinja(null);
        private readonly AppearingNinja earlyAppearingNinja = new AppearingNinja(1);

        [Test]
        public void IsNull_OnNotAppearingNinja_ShouldSucceed()
        {
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
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Property(x => x.FirstAppearance).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)FirstAppearance = 1", "(expected: null)"));
        }

        [Test]
        public void IsNotNull_OnEarlyAppearingNinja_ShouldSucceed()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Property(x => x.FirstAppearance).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "AppearingNinja: ( )FirstAppearance = 1", "(expected: not null)"));
        }

        [Test]
        public void IsNotNull_OnNotAppearingNinja_ShouldFail()
        {
            // act
            var result = notAppearingNinja.Evaluate(n => n.Property(x => x.FirstAppearance).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)FirstAppearance = null", "(expected: not null)"));
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