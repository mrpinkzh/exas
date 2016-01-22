using ExAs.Utils;
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
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = 'Naruto'", "(expected: length 6)"));
        }

        [Test]
        public void Expecting7_OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).HasLength(7));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: length 7)"));
        }

        [Test]
        public void Expecting6_OnNullNinja_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).HasLength(6));

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = null", "(expected: length 6)"));
        }
    }
}