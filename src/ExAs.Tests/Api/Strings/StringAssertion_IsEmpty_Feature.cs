using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_IsEmpty_Feature
    {
        [Test]
        public void OnEmptyNinja_ShouldPass()
        {
            // arrange
            var emptyNinja = new Ninja("");

            // act
            var result = emptyNinja.Evaluate(n => n.Property(x => x.Name).IsEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = ''", "(expected: empty string)"));
        }

        [Test]
        public void OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Property(x => x.Name).IsEmpty());

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: empty string)"));
        }
    }
}