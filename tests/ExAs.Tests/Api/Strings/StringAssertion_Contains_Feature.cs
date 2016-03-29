using NUnit.Framework;
using ToText.Core;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_Contains_Feature
    {
        [Test]
        public void ExpectingUt_OnNaruto_ShouldPass()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).Contains("ut"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: ( )Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: contains 'ut')"));
        }

        [Test]
        public void ExpectingArut_OnKakashi_ShouldFail()
        {
            // act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).Contains("arut"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: (X)Name = 'Kakashi'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: contains 'arut')"));
        }

        [Test]
        public void ExpectingNull_OnNaruto_ShouldFail()
        {
            // act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).Contains(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: contains null)"));
        }

        [Test]
        public void ExpectingArut_OnNullNinja_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).Contains("arut"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: (X)Name = null"));
        }

        [Test]
        public void ExpectingRuto_OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).Contains("ruto"));

            // assert
            Assert.AreEqual(
                 "Ninja: ( )Name = 'Naruto   (expected: contains 'ruto')".NewLine()
            .Add("                  Uzumaki' "),
                 result.PrintLog());
        }
    }
}