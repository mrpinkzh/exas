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
        public void IsNull_WithNullDojos_ShouldPass()
        {
            var city = new City(dojoList: null);
            ObjectAssertionResult result = city.Evaluate(n => n.Property(x => x.Dojos).IsNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("City: ( )Dojos = null (expected: null)", result.PrintLog());
        }

        [Test]
        public void IsNull_OnCityWithoutDojo_ShouldFail()
        {
            var city = new City();
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("City: (X)Dojos = <empty> (expected: null)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityWithoutDojo_ShouldSucceed()
        {
            var city = new City();
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("City: ( )Dojos = <empty> (expected: empty enumerable)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldFail()
        {
            var city = new City(new Dojo(new Ninja(), Dates.StandardDay()));
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: (X)Dojos = <1 Dojo> (expected: empty enumerable)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityNullDojos_ShouldFail()
        {
            var city = new City(dojoList:null);
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: (X)Dojos = null (expected: empty enumerable)", result.PrintLog());
        }
    }
}