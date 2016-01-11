using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class EnumerableAssertion_IsNull_Feature
    {
        [Test]
        public void OnCityWithNullDojos_ShouldPass()
        {
            // act
            var result = CityWithNullDojoList().Evaluate(n => n.p(x => x.Dojos).IsNull());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = null (expected: null)"));
        }

        [Test]
        public void OnCityWithoutDojo_ShouldFail()
        {
            // act
            var result = CityWithoutDojo().Evaluate(c => c.p(x => x.Dojos).IsNull());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("City: (X)Dojos = <empty> (expected: null)"));
        }
    }
}