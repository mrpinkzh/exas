using System;
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
            Assert.AreEqual("City: ( )Dojos = <empty> (expected: empty enumerable)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldSucceed()
        {
            var city = new City(new Dojo(new Ninja(), Dates.StandardDay()));
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: (X)Dojos = <1 Dojo> (expected: empty enumerable)", result.PrintLog());
        }
    }
}