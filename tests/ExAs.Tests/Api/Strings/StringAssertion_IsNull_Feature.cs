using ExAs.Results;
using ExAs.Utils;
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
            var result = NullNinja().Evaluate(n => n.Property(x => x.Name).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(true, "Ninja: ( )Name = null", "(expected: null)"));
        }

        [Test]
        public void OnNaruto_ShouldFail()
        {
            // act
            var result = Naruto().Evaluate(n => n.Property(x => x.Name).IsNull());

            // assert
            result.ExAssert(r => r.Fullfills(false, "Ninja: (X)Name = 'Naruto'", "(expected: null)"));
        }
    }
}