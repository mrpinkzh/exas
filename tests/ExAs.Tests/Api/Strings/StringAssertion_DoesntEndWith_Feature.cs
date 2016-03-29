using NUnit.Framework;
using ToText.Core;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_DoesntEndWith_Feature
    {
        [Test]
        public void ExpectingNotShi_OnNaruto_ShouldPass()
        {
            // arrange
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).DoesntEndWith("shi"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: ( )Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: doesn't end with 'shi')"));
        }

        [Test]
        public void ExpectingNotAshi_OnNaruto_ShouldPass()
        {
            // arrange
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).DoesntEndWith("ashi"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("Ninja: (X)Name = 'Kakashi'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: doesn't end with 'ashi')"));
        }

        [Test]
        public void ExpectingNotKash_OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).DoesntEndWith("kash"));

            // assert
            Assert.AreEqual("Ninja: ( )Name = 'Naruto   (expected: doesn't end with 'kash')".NewLine()
                       .Add("                  Uzumaki' "),
                       result.PrintLog());
        }
    }
}