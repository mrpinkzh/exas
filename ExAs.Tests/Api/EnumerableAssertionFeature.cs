using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class EnumerableAssertionFeature
    {
        [Test]
        public void IsEmpty_OnCityWithoutDojo_ShouldSucceed()
        {
            var city = new City();
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("City: ( )Dojos.Length = 0 (expected: 0)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldSucceed()
        {
            var city = new City(new Dojo(new Ninja(), Dates.StandardDay()));
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("City: (X)Dojos.Length = 1 (expected: 0)", result.PrintLog());
        }
    }
}