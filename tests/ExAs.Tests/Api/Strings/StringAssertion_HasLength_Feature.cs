using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_HasLength_Feature
    {
        [Test]
        public void Expecting6_OnNaruto_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).HasLength(6));

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = 'Naruto'[6]", "(expected: length 6)"));
        }

        [Test]
        public void Expecting7_OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).HasLength(7));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'[6]", "(expected: length 7)"));
        }

        [Test]
        public void Expecting6_OnNullNinja_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).HasLength(6));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = null[0]", "(expected: length 6)"));
        }
        [Test]
        public void Expecting13_OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).HasLength(13));

            // assert
            Assert.AreEqual(
                 "Ninja: (X)Name = 'Naruto       (expected: length 13)".NewLine()
            .Add("                  Uzumaki'[14] "),
                 result.PrintLog());
        }
    }
}