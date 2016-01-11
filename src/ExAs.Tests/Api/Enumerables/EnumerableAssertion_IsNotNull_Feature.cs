using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class EnumerableAssertion_IsNotNull_Feature
    {
        [Test]
        public void OnCityWithoutDojo_ShouldSucceed()
        {
            // act
            var result = CityWithoutDojo().Evaluate(c => c.p(x => x.Dojos).IsNotNull());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = <empty> (expected: not null)"));
        }

        [Test]
        public void OnCityWithNullDojos_ShouldFail()
        {
            // act
            var result = CityWithNullDojoList().Evaluate(n => n.p(x => x.Dojos).IsNotNull());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("City: (X)Dojos = null (expected: not null)"));
        }
    }
}