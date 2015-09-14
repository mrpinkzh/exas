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

        [Test]
        public void HasAnyStandardDayDojo_OnCityWithStandardDayDojo_ShouldPass()
        {
            var city = new City(new Dojo(new Ninja(), Dates.StandardDay()));
            var result = city.Evaluate(
                c => c.Property(x => x.Dojos).HasAny(d => d.Property(x => x.Founded).OnSameDayAs(Dates.StandardDay())));
            Assert.IsTrue(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: ( )Dojos = <1 match>                     (expected: at least 1 match)".NewLine()
                       .Add("                 Dojo: ( )Founded = 11/16/1984 (expected: 11/16/1984)"), result.PrintLog());
        }

        [Test]
        public void HasAnyStandardDayDojo_OnCityWithOldAndStandardDayDojo_ShouldPass()
        {
            var city = new City(new Dojo(new Ninja(), new DateTime(1515, 11, 15)),
                                new Dojo(new Ninja(), Dates.StandardDay()));
            ObjectAssertionResult result = city.Evaluate(
                c => c.Property(x => x.Dojos).HasAny(d => d.Property(x => x.Founded).OnSameDayAs(Dates.StandardDay())));
            Assert.IsTrue(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: ( )Dojos = <1 match>                     (expected: at least 1 match)".NewLine()
                       .Add("                 Dojo: (X)Founded = 11/15/1515 (expected: 11/16/1984)").NewLine()
                       .Add("                 Dojo: ( )Founded = 11/16/1984 (expected: 11/16/1984)"),
                            result.PrintLog());
        }

        [Test]
        public void HasAnySpecificDojo_OnCityWithThreeOtherDojos_ShouldFail()
        {
            var city = new City(new Dojo(new Ninja(), new DateTime(1515, 11, 15)),
                                new Dojo(new Ninja("Kakashi", 26), new DateTime(1500, 1, 1)),
                                new Dojo(new Ninja("Tsubasa", 14), Dates.StandardDay()));
            
            var result = city.Evaluate(
                c => c.Property(x => x.Dojos).HasAny(d => d.Property(x => x.Master) .Fulfills(n => n.Property(x => x.Age).EqualTo(26))
                                                           .Property(x => x.Founded).OnSameDayAs(Dates.StandardDay())));
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual(
                        "City: (X)Dojos = <0 matches>                           (expected: at least 1 match)".NewLine()
                   .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 12 (expected: 26)").NewLine()
                   .Add("                       (X)Founded = 11/15/1515         (expected: 11/16/1984)").NewLine()
                   .Add("                 Dojo: ( )Master  = Ninja: ( )Age = 26 (expected: 26)".NewLine()
                   .Add("                       (X)Founded = 01/01/1500         (expected: 11/16/1984)".NewLine()
                   .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 14 (expected: 26)").NewLine()
                   .Add("                       ( )Founded = 11/16/1984         (expected: 11/16/1984)"))),
                 result.PrintLog());
        }
    }
}