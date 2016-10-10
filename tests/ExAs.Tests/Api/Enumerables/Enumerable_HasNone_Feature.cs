using System;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class Enumerable_HasNone_Feature
    {
        [Test]
        public void ExpectingNoSpecificDojo_OnCityWithThreeOtherDojos_ShouldSucceed()
        {
            // act
            var result = ThreeDojoCity().Evaluate(
                c => c.Member(x => x.Dojos).HasNone(d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Age).IsEqualTo(26))
                                                          .Member(x => x.Founded).IsOnSameDayAs(StandardDay())));

            // assert
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual(
                            "City: ( )Dojos = <0 matches>                           (expected: 0 matches)".NewLine()
                       .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 12 (expected: 26)").NewLine()
                       .Add("                       (X)Founded = 15.11.1515         (expected: on same day as 16.11.1984)").NewLine()
                       .Add("                 Dojo: ( )Master  = Ninja: ( )Age = 26 (expected: 26)".NewLine()
                       .Add("                       (X)Founded = 01.01.1500         (expected: on same day as 16.11.1984)".NewLine()
                       .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 14 (expected: 26)").NewLine()
                       .Add("                       ( )Founded = 16.11.1984         (expected: on same day as 16.11.1984)"))),
                   result.PrintLog());
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void ExpectingNoSpecificDojo_OnCityWithSpecificAndOtherDojo_ShouldFail()
        {
            // arrange
            var city = new City(new Dojo(MultilinedNarutoUzumaki(), new DateTime(1515, 11, 15)),
                                new Dojo(Kakashi(), new DateTime(1500, 1, 1)));

            // act
            var result = city.Evaluate(
                c => c.Member(x => x.Dojos).HasNone(d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Age) .IsEqualTo(26)
                                                                                                .Member(x => x.Name).IsEqualTo("Kakashi"))
                                                          .Member(x => x.Founded).IsOnSameDayAs(new DateTime(1500, 1, 1))));

            // assert
            Console.Out.WriteLine(result.PrintLog());
            Assert.AreEqual(
                            "City: (X)Dojos = <1 match>                                     (expected: 0 matches)"  .NewLine()
                       .Add("                 Dojo: (X)Master  = Ninja: (X)Age  = 12        (expected: 26)")        .NewLine()
                       .Add("                                           (X)Name = 'Naruto   (expected: 'Kakashi')") .NewLine()
                       .Add("                                                      Uzumaki' ")                      .NewLine()
                       .Add("                       (X)Founded = 15.11.1515                 (expected: on same day as 01.01.1500)").NewLine()
                       .Add("                 Dojo: ( )Master  = Ninja: ( )Age  = 26        (expected: 26)")        .NewLine()
                       .Add("                                           ( )Name = 'Kakashi' (expected: 'Kakashi')") .NewLine()
                       .Add("                       ( )Founded = 01.01.1500                 (expected: on same day as 01.01.1500)"),
                   result.PrintLog());
            Assert.IsFalse(result.succeeded);
        }
    }
}