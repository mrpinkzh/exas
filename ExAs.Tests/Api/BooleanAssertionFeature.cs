using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class BooleanAssertionFeature
    {
        private readonly City cityWithDojo = new City(new Dojo(new Ninja(), Dates.StandardDay()));
        private readonly City cityWithoutDojo = new City();

        [Test]
        public void CityHasDojosIsTrue_OnCityWithDojos_ShouldPass()
        {
            var result = cityWithDojo.Evaluate(c => c.Property(x => x.HasDojo).IsTrue());
            Assert.AreEqual("City: ( )HasDojo = True (expected: True)", result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void CityHasDojosIsTrue_OnCityWithoutDojos_ShouldFail()
        {
            var result = cityWithoutDojo.Evaluate(c => c.Property(x => x.HasDojo).IsTrue());
            Assert.AreEqual("City: (X)HasDojo = False (expected: True)", result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void CityHasDojosIsFalse_OnCityWithoutDojos_ShouldPass()
        {
            var result = cityWithoutDojo.Evaluate(c => c.Property(x => x.HasDojo).IsFalse());
            Assert.AreEqual("City: ( )HasDojo = False (expected: False)", result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void CityHasDojosIsFalse_OnCityWithDojos_ShouldFail()
        {
            var result = cityWithDojo.Evaluate(c => c.Property(x => x.HasDojo).IsFalse());
            Assert.AreEqual("City: (X)HasDojo = True (expected: False)", result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }
    }
}