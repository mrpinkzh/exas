using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class ShortAssertionFeature
    {
        private readonly DetailedNinja strongNinja = new DetailedNinja(65);

        

        

        [Test]
        public void IsInRange_ExpectingBetween64And66_OnNinjaWith65_ShouldSucceed()
        {
            // act
            var result = strongNinja.Evaluate(n => n.Member(x => x.strength).IsInRange(64, 66));

            // assert
            result.ExAssert(r => r.Fullfills(true, "DetailedNinja: ( )strength = 65", "(expected: between 64 and 66)"));
        }

        public class DetailedNinja : Ninja
        {
            public readonly short strength;

            public DetailedNinja(short strength)
            {
                this.strength = strength;
            }
        }
    }
}