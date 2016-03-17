using System;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateCities;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Enumerables
{
    [TestFixture]
    public class EnumerableAssertion_HasAny_Feature
    {
        [Test]
        public void ExpectingStandardDayDojo_OnCityWithStandardDayDojo_ShouldSucceed()
        {
            // act
            var result = CityWithDojo().Evaluate(
                c => c.Member(x => x.Dojos).HasAny(d => d.p(x => x.Founded).IsOnSameDayAs(StandardDay())));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = <1 match>                     (expected: at least 1 match)".NewLine()
                                                             .Add("                 Dojo: ( )Founded = 11/16/1984 (expected: 11/16/1984)")));
            
        }

        [Test]
        public void ExpectingStandardDayDojo_OnCityWithOldAndStandardDayDojo_ShouldSucceed()
        {
            // arrange
            var city = new City(new Dojo(Naruto(), new DateTime(1515, 11, 15)),
                                new Dojo(Naruto(), Dates.StandardDay()));

            // act
            var result = city.Evaluate(
                c => c.Member(x => x.Dojos).HasAny(d => d.p(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("City: ( )Dojos = <1 match>                     (expected: at least 1 match)".NewLine()
                                                             .Add("                 Dojo: (X)Founded = 11/15/1515 (expected: 11/16/1984)").NewLine()
                                                             .Add("                 Dojo: ( )Founded = 11/16/1984 (expected: 11/16/1984)")));
        }


        [Test]
        public void ExpectingSpecificDojo_OnCityWithThreeOtherDojos_ShouldFail()
        {
            // act
            var result = ThreeDojoCity().Evaluate(
                c => c.Member(x => x.Dojos).HasAny(d => d.Member(x => x.Master) .Fulfills(n => n.Member(x => x.Age).IsEqualTo(26))
                                                         .Member(x => x.Founded).IsOnSameDayAs(StandardDay())));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("City: (X)Dojos = <0 matches>                           (expected: at least 1 match)".NewLine()
                                                             .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 12 (expected: 26)").NewLine()
                                                             .Add("                       (X)Founded = 11/15/1515         (expected: 11/16/1984)").NewLine()
                                                             .Add("                 Dojo: ( )Master  = Ninja: ( )Age = 26 (expected: 26)".NewLine()
                                                             .Add("                       (X)Founded = 01/01/1500         (expected: 11/16/1984)".NewLine()
                                                             .Add("                 Dojo: (X)Master  = Ninja: (X)Age = 14 (expected: 26)").NewLine()
                                                             .Add("                       ( )Founded = 11/16/1984         (expected: 11/16/1984)")))));
        }
    }
}