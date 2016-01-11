using System;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class EnumerableAssertion_IsNotEmpty_Feature
    {
        [Test]
        public void OnCityWithDojo_ShouldSucceed()
        {
            // act
            var result = CityWithDojo().Evaluate(c => c.p(x => x.Dojos).IsNotEmpty());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = <1 Dojo> (expected: not empty)"));
        }

        [Test]
        public void OnCityWithoutDojo_ShouldFail()
        {
            // act
            var result = CityWithoutDojo().Evaluate(c => c.p(x => x.Dojos).IsNotEmpty());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("City: (X)Dojos = <empty> (expected: not empty)"));
        }

        [Test]
        public void OnCityNullDojos_ShouldSucceed()
        {
            // act
            var result = CityWithNullDojoList().Evaluate(c => c.Property(x => x.Dojos).IsNotEmpty());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = null (expected: not empty)"));
        }
    }
}