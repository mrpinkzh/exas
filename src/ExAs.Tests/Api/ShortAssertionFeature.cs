using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class ShortAssertionFeature
    {
        private readonly DetailedNinja strongNinja = new DetailedNinja(65);

        [Test]
        public void IsEqualTo_Expecting65_OnNinjaWith65_ShouldSucceed()
        {
            // act
            var result = strongNinja.Evaluate(n => n.Property(x => x.strength).IsEqualTo(65));

            // assert
            result.ExAssert(r => r.Fullfills(true, "DetailedNinja: ( )strength = 65", "(expected: 65)"));
        }

        [Test]
        public void IsSmallerThan_ExpectingSmallerThan66_OnNinjaWith65_ShouldSucceed()
        {
            // act
            var result = strongNinja.Evaluate(n => n.Property(x => x.strength).IsSmallerThan(66));

            // assert
            result.ExAssert(r => r.Fullfills(true, "DetailedNinja: ( )strength = 65", "(expected: smaller than 66)"));
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