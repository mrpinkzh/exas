using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_IsNull_Feature
    {
        [Test]
        public void OnNullNinja_ShouldSucceed()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = null", "(expected: null)"));
        }

        [Test]
        public void OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: null)"));
        }

        [Test]
        public void OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).IsNull());

            // assert
            Assert.AreEqual(
                 "Ninja: ( )Name = 'Naruto   (expected: null)".NewLine()
            .Add("                  Uzumaki' "),
                 result.PrintLog());
        }
    }
}