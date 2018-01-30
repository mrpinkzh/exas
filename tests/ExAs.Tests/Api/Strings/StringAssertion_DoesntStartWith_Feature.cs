using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_DoesntStartWith_Feature
    {
        [Test]
        public void ExpectingNotNaru_WithKakashi_ShouldPass()
        {
            // act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).DoesntStartWith("Naru"));
            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: ( )Name = 'Kakashi'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: doesn't start with 'Naru')"));
        }

        [Test]
        public void ExpectingNotKak_WithKakashi_ShouldFail()
        {
            // act
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).DoesntStartWith("Kak"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded)  .IsFalse()
                                  .Member(x => x.actual)        .IsEqualTo("Ninja: (X)Name = 'Kakashi'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: doesn't start with 'Kak')"));
        }

        [Test]
        public void ExpectingNotKash_OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).DoesntStartWith("kash"));

            // assert
            Assert.AreEqual("Ninja: ( )Name = 'Naruto   (expected: doesn't start with 'kash')".NewLine()
                       .Add("                  Uzumaki' "),
                       result.PrintLog());
        }
    }
}