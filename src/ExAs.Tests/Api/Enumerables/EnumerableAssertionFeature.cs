using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class EnumerableAssertionFeature
    {
        private readonly City threeDojoCity = new City(new Dojo(new Ninja(), new DateTime(1515, 11, 15)),
                                                       new Dojo(new Ninja("Kakashi", 26), new DateTime(1500, 1, 1)),
                                                       new Dojo(new Ninja("Tsubasa", 14), Dates.StandardDay()));

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