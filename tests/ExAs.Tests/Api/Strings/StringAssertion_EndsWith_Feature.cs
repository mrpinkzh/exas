using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_EndsWith_Feature
    {
        [Test]
        public void ExpectingUto_OnNaruto_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).EndsWith("uto"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsTrue()
                                  .Member(x => x.actual)        .IsEqualTo("Ninja: ( )Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: ends with 'uto')"));
        }

        [Test]
        public void ExpectingUto_OnTakahashi_ShouldFail()
        {
            // act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).EndsWith("uto"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: (X)Name = 'Kakashi'"));
        }

        [Test]
        public void ExpectingAshi_ShouldPrintExpectationWithAshi()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).EndsWith("ashi"));
            
            // assert
            result.ExAssert(r => r.Member(x => x.expectation).IsEqualTo("(expected: ends with 'ashi')"));
        }

        [Test]
        public void ExpectingUto_OnNullNinja_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).EndsWith("uto"));

            // assert
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void ExpectingNull_OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).EndsWith(null));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.expectation).IsEqualTo("(expected: ends with null)"));
        }

        [Test]
        public void ExpectingMaki_OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).EndsWith("maki"));

            // assert
            Assert.AreEqual(
                 "Ninja: ( )Name = 'Naruto   (expected: ends with 'maki')".NewLine()
            .Add("                  Uzumaki' "),
                 result.PrintLog());
        }
    }
}