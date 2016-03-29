using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_IsNotEmpty_Feature
    {
        [Test]
        public void OnNaruto_ShouldSucceed()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsNotEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = 'Naruto'", "(expected: not empty)"));
        }

        [Test]
        public void OnNamelessNinja_ShouldFail()
        {
            // act
            var result = NamelessNinja().Evaluate(n => n.Member(x => x.Name).IsNotEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = ''", "(expected: not empty)"));
        }

        [Test]
        public void OnNullNinja_ShouldSucceed()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsNotEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = null", "(expected: not empty)"));
        }
         
        [Test]
        public void OnMultiLineNaruto_ShouldReturnHarmonizedResult()
        {
            // act
            var result = MultilinedNarutoUzumaki().Evaluate(n => n.Member(x => x.Name).IsNotEmpty());

            // assert
            Assert.AreEqual(
                 "Ninja: ( )Name = 'Naruto   (expected: not empty)".NewLine()
            .Add("                  Uzumaki' "),
                 result.PrintLog());
        }
    }
}