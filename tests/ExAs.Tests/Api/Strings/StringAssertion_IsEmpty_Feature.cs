using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_IsEmpty_Feature
    {
        [Test]
        public void OnNamelessNinja_ShouldPass()
        {
            // act
            var result = NamelessNinja().Evaluate(n => n.Member(x => x.Name).IsEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = ''", "(expected: empty string)"));
        }

        [Test]
        public void OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: empty string)"));
        }

        [Test]
        public void OnNullNinja_ShouldFail()
        {
            // act
            var result = NullNinja().Evaluate(n => n.Member(x => x.Name).IsEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = null", "(expected: empty string)"));
        }
    }
}