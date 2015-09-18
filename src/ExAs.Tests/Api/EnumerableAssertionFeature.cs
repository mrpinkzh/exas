using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class EnumerableAssertionFeature
    {
        private readonly City cityWithDojo = new City(new Dojo(new Ninja(), Dates.StandardDay()));
        private readonly City cityWithoutDojo = new City();
        private readonly City cityWithNullDojoList = new City(dojoList:null);
        private readonly City threeDojoCity = new City(new Dojo(new Ninja(), new DateTime(1515, 11, 15)),
                                                       new Dojo(new Ninja("Kakashi", 26), new DateTime(1500, 1, 1)),
                                                       new Dojo(new Ninja("Tsubasa", 14), Dates.StandardDay()));

        [Test]
        public void IsNull_WithNullDojos_ShouldPass()
        {
            ObjectAssertionResult result = cityWithNullDojoList.Evaluate(n => n.Property(x => x.Dojos).IsNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("City: ( )Dojos = null (expected: null)", result.PrintLog());
        }

        [Test]
        public void IsNull_OnCityWithoutDojo_ShouldFail()
        {
            ObjectAssertionResult result = cityWithoutDojo.Evaluate(c => c.Property(x => x.Dojos).IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("City: (X)Dojos = <empty> (expected: null)", result.PrintLog());
        }

        [Test]
        public void IsNotNull_OnCityWithoutDojo_ShouldSucceed()
        {
            ObjectAssertionResult result = cityWithoutDojo.Evaluate(c => c.Property(x => x.Dojos).IsNotNull());
            Assert.AreEqual("City: ( )Dojos = <empty> (expected: not null)", result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void IsNotNull_WithNullDojos_ShouldFail()
        {
            ObjectAssertionResult result = cityWithNullDojoList.Evaluate(n => n.Property(x => x.Dojos).IsNotNull());
            Assert.AreEqual("City: (X)Dojos = null (expected: not null)", result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void IsEmpty_OnCityWithoutDojo_ShouldSucceed()
        {
            ObjectAssertionResult result = cityWithoutDojo.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("City: ( )Dojos = <empty> (expected: empty enumerable)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldFail()
        {
            ObjectAssertionResult result = cityWithDojo.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: (X)Dojos = <1 Dojo> (expected: empty enumerable)", result.PrintLog());
        }

        [Test]
        public void IsEmpty_OnCityNullDojos_ShouldFail()
        {
            ObjectAssertionResult result = cityWithNullDojoList.Evaluate(c => c.Property(x => x.Dojos).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual("City: (X)Dojos = null (expected: empty enumerable)", result.PrintLog());
        }

        [Test]
        public void IsNotEmpty_OnCityWithDojo_ShouldSucceed()
        {
            var result = cityWithDojo.Evaluate(c => c.Property(x => x.Dojos).IsNotEmpty());
            Assert.AreEqual("City: ( )Dojos = <1 Dojo> (expected: not empty)", result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void IsNotEmpty_OnCityWithoutDojo_ShouldFail()
        {
            var city = cityWithoutDojo;
            ObjectAssertionResult result = city.Evaluate(c => c.Property(x => x.Dojos).IsNotEmpty());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("City: (X)Dojos = <empty> (expected: not empty)", result.PrintLog());
        }

        [Test]
        public void IsNotEmpty_OnCityNullDojos_ShouldSucceed()
        {
            ObjectAssertionResult result = cityWithNullDojoList.Evaluate(c => c.Property(x => x.Dojos).IsNotEmpty());
            Console.Out.WriteLine(result.PrintLog());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("City: ( )Dojos = null (expected: not empty)", result.PrintLog());
        }

        [Test]
        public void HasAnyStandardDayDojo_OnCityWithStandardDayDojo_ShouldPass()
        {
            var city = new City(new Dojo(new Ninja(), Dates.StandardDay()));
            var result = city.Evaluate(
                c => c.Property(x => x.Dojos).HasAny(d => d.Property(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));
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
                c => c.Property(x => x.Dojos).HasAny(d => d.Property(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));
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
            var result = threeDojoCity.Evaluate(
                c => c.Property(x => x.Dojos).HasAny(d => d.Property(x => x.Master) .Fulfills(n => n.Property(x => x.Age).IsEqualTo(26))
                                                           .Property(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));
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

        [Test]
        public void HasNoneSpecificDojo_OnCityWithThreeOtherDojos_ShouldSucceed()
        {
            var result = threeDojoCity.Evaluate(
                c => c.Property(x => x.Dojos).HasNone(d => d.Property(x => x.Master).Fulfills(n => n.Property(x => x.Age).IsEqualTo(26))
                                                            .Property(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));

            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual(
                            "City: ( )Dojos = <0 matches>                           (expected: 0 matches)".NewLine()
                       .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 12 (expected: 26)").NewLine()
                       .Add("                       (X)Founded = 11/15/1515         (expected: 11/16/1984)").NewLine()
                       .Add("                 Dojo: ( )Master  = Ninja: ( )Age = 26 (expected: 26)".NewLine()
                       .Add("                       (X)Founded = 01/01/1500         (expected: 11/16/1984)".NewLine()
                       .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 14 (expected: 26)").NewLine()
                       .Add("                       ( )Founded = 11/16/1984         (expected: 11/16/1984)"))),
                   result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void HasNoneSpecificDojo_OnCityWithSpecificAndOtherDojo_ShouldFail()
        {
            var city = new City(new Dojo(new Ninja("Naruto".NewLine().Add("Uzumaki")), new DateTime(1515, 11, 15)),
                                new Dojo(new Ninja("Kakashi", 26), new DateTime(1500, 1, 1)));

            var result = city.Evaluate(
                c => c.Property(x => x.Dojos).HasNone(d => d.Property(x => x.Master).Fulfills(n => n.Property(x => x.Age) .IsEqualTo(26)
                                                                                                    .Property(x => x.Name).IsEqualTo("Kakashi"))
                                                            .Property(x => x.Founded).IsOnSameDayAs(new DateTime(1500, 1, 1))));

            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual(
                            "City: (X)Dojos = <1 match>                                     (expected: 0 matches)"  .NewLine()
                       .Add("                 Dojo: (X)Master  = Ninja: (X)Age  = 12        (expected: 26)")        .NewLine()
                       .Add("                                           (X)Name = 'Naruto   (expected: 'Kakashi')") .NewLine()
                       .Add("                                                      Uzumaki' ")                      .NewLine()
                       .Add("                       (X)Founded = 11/15/1515                 (expected: 01/01/1500)").NewLine()
                       .Add("                 Dojo: ( )Master  = Ninja: ( )Age  = 26        (expected: 26)")        .NewLine()
                       .Add("                                           ( )Name = 'Kakashi' (expected: 'Kakashi')") .NewLine()
                       .Add("                       ( )Founded = 01/01/1500                 (expected: 01/01/1500)"),
                   result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }
    }
}