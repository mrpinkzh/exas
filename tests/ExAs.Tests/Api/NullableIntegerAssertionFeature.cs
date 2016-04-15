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
            var result = notAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsNull());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded)  .IsTrue()
                                  .p(x => x.actual)        .IsEqualTo("AppearingNinja: ( )firstAppearance = null")
                                  .p(x => x.expectation).IsEqualTo("(expected: null)"));
        }

        [Test]
        public void IsNull_OnEarlyAppearingNinja_ShouldFail()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = 1", "(expected: null)"));
        }

        [Test]
        public void IsNotNull_OnEarlyAppearingNinja_ShouldSucceed()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "AppearingNinja: ( )firstAppearance = 1", "(expected: not null)"));
        }

        [Test]
        public void IsNotNull_OnNotAppearingNinja_ShouldFail()
        {
            // act
            var result = notAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsNotNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = null", "(expected: not null)"));
        }

        [Test]
        public void IsEqual_Expecting1_OnEarlyAppearingNinja_ShouldSucceed()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsEqualTo(1));

            // assert
            result.ExAssert(r => r.Fullfills(true, "AppearingNinja: ( )firstAppearance = 1", "(expected: 1)"));
        }

        [Test]
        public void IsEqual_Expecting1_OnNotAppearingNinja_ShouldFail()
        {
            // act
            var result = notAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsEqualTo(1));

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = null", "(expected: 1)"));
        }

        [Test]
        public void IsEqual_Expecting2_OnEarlyAppearingNinja_ShouldFail()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsEqualTo(2));

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = 1", "(expected: 2)"));
        }

        [Test]
        public void IsLessThan_Expecting2_OnEarlyAppearingNinja_ShouldSucceed()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsLessThan(2));

            // assert
            result.ExAssert(r => r.Fullfills(true, "AppearingNinja: ( )firstAppearance = 1", "(expected: smaller than 2)"));
        }

        [Test]
        public void IsLessThan_Expecting2_OnNotAppearingNinja_ShouldFail()
        {
            // act
            var result = notAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsLessThan(2));

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = null", "(expected: smaller than 2)"));
        }

        [Test]
        public void IsGreaterThan_Expecting0_OnEarlyAppearingNinja_ShouldSucceed()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsGreaterThan(0));

            // assert
            result.ExAssert(r => r.Fullfills(true, "AppearingNinja: ( )firstAppearance = 1", "(expected: greater than 0)"));
        }

        [Test]
        public void IsGreaterThan_Expecting0_OnNotAppearingNinja_ShouldSucceed()
        {
            // act
            var result = notAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsGreaterThan(0));

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = null", "(expected: greater than 0)"));
        }

        [Test]
        public void IsInRange_ExpectingIn0And2_OnEarlyAppearingNinja_ShouldSucceed()
        {
            // act
            var result = earlyAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsInRange(0, 2));

            // assert
            result.ExAssert(r => r.Fullfills(true, "AppearingNinja: ( )firstAppearance = 1", "(expected: between 0 and 2)"));
        }

        [Test]
        public void IsInRange_ExpectingIn0And2_OnNotAppearingNinja_ShouldFail()
        {
            // act
            var result = notAppearingNinja.Evaluate(n => n.Member(x => x.firstAppearance).IsInRange(0, 2));

            // assert
            result.ExAssert(r => r.Fullfills(false, "AppearingNinja: (X)firstAppearance = null", "(expected: between 0 and 2)"));
        }

        private class AppearingNinja : Ninja
        {
            public readonly int? firstAppearance;

            public AppearingNinja(int? firstAppearance)
            {
                this.firstAppearance = firstAppearance;
            }
        }
    }
}