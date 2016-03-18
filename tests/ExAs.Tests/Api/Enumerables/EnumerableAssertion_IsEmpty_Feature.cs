using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class EnumerableAssertion_IsEmpty_Feature
    {
        [Test]
        public void OnCityWithoutDojo_ShouldSucceed()
        {
            // act
            var result = CityWithoutDojo().Evaluate(c => c.p(x => x.Dojos).IsEmpty());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = <empty> (expected: empty enumerable)"));
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldFail()
        {
            // act
            var result = CityWithDojo().Evaluate(c => c.p(x => x.Dojos).IsEmpty());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("City: (X)Dojos = <1 Dojo> (expected: empty enumerable)"));
        }

        [Test]
        public void OnCityWithNullDojos_ShouldFail()
        {
            // act
            var result = CityWithNullDojoList().Evaluate(c => c.Member(x => x.Dojos).IsEmpty());

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("City: (X)Dojos = null (expected: empty enumerable)"));
        }
    }
}