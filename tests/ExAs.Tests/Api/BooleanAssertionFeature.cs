using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.ExAs;

namespace ExAs.Api
{
    [TestFixture]
    public class BooleanAssertionFeature
    {
        private readonly City cityWithDojo = new City(new Dojo(Naruto(), Dates.StandardDay()));
        private readonly City cityWithoutDojo = new City();

        [Test]
        public void CityHasDojosIsTrue_OnCityWithDojos_ShouldPass()
        {
            // act
            var result = cityWithDojo.Evaluate(c => c.Member(x => x.HasDojo).IsTrue());

            // assert
            ExAssert(result, Has<Result>().Member(x => x.succeeded).IsTrue()
                                          .Member(x => x.actual)   .IsEqualTo("City: ( )HasDojo = True")
                                          .Member(x => x.expectation).IsEqualTo(ComposeLog.Expected("True")));
        }

        [Test]
        public void CityHasDojosIsTrue_OnCityWithoutDojos_ShouldFail()
        {
            var result = cityWithoutDojo.Evaluate(c => c.Member(x => x.HasDojo).IsTrue());
            Assert.AreEqual("City: (X)HasDojo = False (expected: True)", result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void CityHasDojosIsFalse_OnCityWithoutDojos_ShouldPass()
        {
            var result = cityWithoutDojo.Evaluate(c => c.Member(x => x.HasDojo).IsFalse());
            Assert.AreEqual("City: ( )HasDojo = False (expected: False)", result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void CityHasDojosIsFalse_OnCityWithDojos_ShouldFail()
        {
            var result = cityWithDojo.Evaluate(c => c.Member(x => x.HasDojo).IsFalse());
            Assert.AreEqual("City: (X)HasDojo = True (expected: False)", result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }
    }
}