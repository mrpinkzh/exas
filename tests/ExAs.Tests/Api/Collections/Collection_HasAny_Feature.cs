using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Collections
{
    [TestFixture]
    public class Collection_HasAny_Feature
    {
        [Test]
        public void ExpectingNarutosDojo_OnCityWithNarutosDojo_ShouldSucceed()
        {
            // act
            var result = CityWithDojo().Evaluate(
                c => c.Member(x => x.DojoCollection).HasAny(
                    d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Name).IsEqualTo("Naruto")
                                                                .Member(x => x.Age) .IsEqualTo(12))
                          .Member(x => x.Founded).IsOnSameDayAs(StandardDay())));

            // assert
            result.ExAssert(r => r.p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("CollectionCity: ( )DojoCollection = <1 match>                                    (expected: at least 1 match)".NewLine()
                                                             .Add("                                    Dojo: ( )Master  = Ninja: ( )Name = 'Naruto' (expected: 'Naruto')").NewLine()
                                                             .Add("                                                              ( )Age  = 12       (expected: 12)").NewLine()
                                                             .Add("                                          ( )Founded = 16.11.1984                (expected: on same day as 16.11.1984)")));

        }

        private static CollectionCity CityWithDojo()
        {
            return new CollectionCity(new Dojo(Naruto(), StandardDay()));
        }

        private class CollectionCity : City
        {
            public CollectionCity(params Dojo[] dojos) : base(dojos) { }

            public ICollection<Dojo> DojoCollection
            {
                get { return this.Dojos.ToList(); }
            }
        }
    }
}