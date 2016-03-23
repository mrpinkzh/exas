using System;
using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.ReadOnlyCollections
{
    [TestFixture]
    public class ReadOnlyCollectionAssertionFeature
    {
        private readonly CollectionCity cityWithNullDojos = new CollectionCity(dojoList: null);
        private readonly CollectionCity cityWithoutDojo = new CollectionCity();
        private readonly CollectionCity cityWithDojo = new CollectionCity(new Dojo(Naruto(), Dates.StandardDay()));
        private readonly CollectionCity threeDojoCity = new CollectionCity(new Dojo(Naruto(), new DateTime(1515, 11, 15)),
                                                                           new Dojo(Kakashi(), new DateTime(1500, 1, 1)),
                                                                           new Dojo(new Ninja("Tsubasa", 14), Dates.StandardDay()));

        [Test]
        public void IsNull_WithNullDojos_ShouldPass()
        {
            // Act
            Result result = cityWithNullDojos.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsNull());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)      .IsEqualTo("CollectionCity: ( )ReadOnlyDojos = null"));
        }

        [Test]
        public void IsNull_OnCityWithoutDojo_ShouldFail()
        {
            // Act
            Result result = cityWithoutDojo.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsNull());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("CollectionCity: (X)ReadOnlyDojos = <empty>"));
        }

        [Test]
        public void IsNotNull_OnCityWithoutDojo_ShouldSucceed()
        {
            // Act
            Result result = cityWithoutDojo.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsNotNull());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)      .IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <empty>"));
        }

        [Test]
        public void IsNotNull_WithNullDojos_ShouldFail()
        {
            // Act
            Result result = cityWithNullDojos.Evaluate(n => n.Member(x => x.ReadOnlyDojos).IsNotNull());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual).IsEqualTo("CollectionCity: (X)ReadOnlyDojos = null"));
        }

        [Test]
        public void IsEmpty_OnCityWithoutDojo_ShouldSucceed()
        {
            // Act
            Result result = cityWithoutDojo.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsEmpty());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)      .IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <empty>"));
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldFail()
        {
            // Act
            Result result = cityWithDojo.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsEmpty());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("CollectionCity: (X)ReadOnlyDojos = <1 Dojo>"));
        }

        [Test]
        public void IsEmpty_WithNullDojos_ShouldFail()
        {
            // Act
            Result result = cityWithNullDojos.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsEmpty());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)      .IsEqualTo("CollectionCity: (X)ReadOnlyDojos = null"));
        }

        [Test]
        public void IsNotEmpty_OnCityWithDojo_ShouldSucceed()
        {
            // Act
            var result = cityWithDojo.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsNotEmpty());

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue());
        }

        [Test]
        public void IsNotEmpty_OnCityWithoutDojo_ShouldFail()
        {
            // Act
            var result = cityWithoutDojo.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsNotEmpty());

            // Assert
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void IsNotEmpty_OnCityNullDojos_ShouldSucceed()
        {
            // Act
            Result result = cityWithNullDojos.Evaluate(c => c.Member(x => x.ReadOnlyDojos).IsNotEmpty());

            // Assert
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void HasCount_Expecting1_OnCityWithDojo_ShouldSucceed()
        {
            // act
            var result = cityWithDojo.Evaluate(c => c.p(x => x.ReadOnlyDojos).HasCount(1));

            // assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <1 Dojo> (expected: 1 Dojo)"));
        }

        [Test]
        public void HasCount_Expecting2_OnCityWithoutDojo_ShouldFail()
        {
            // act
            var result = cityWithoutDojo.Evaluate(c => c.p(x => x.ReadOnlyDojos).HasCount(2));

            // assert
            result.ExAssert(r => r.IsNotNull()
                                  .p(x => x.succeeded).IsFalse()
                                  .p(x => x.PrintLog()).IsEqualTo("CollectionCity: (X)ReadOnlyDojos = <empty> (expected: 2 Dojos)"));
        }

        [Test]
        public void HasAnyStandardDayDojo_OnCityWithStandardDayDojo_ShouldPass()
        {
            // Act
            var result = cityWithDojo.Evaluate(
                c => c.Member(x => x.ReadOnlyDojos).HasAny(d => d.Member(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <1 match>                     (expected: at least 1 match)".NewLine()
                                                                    .Add("                                   Dojo: ( )Founded = 11/16/1984 (expected: 11/16/1984)")));
        }

        [Test]
        public void HasNoneSpecificDojo_OnCityWithThreeOtherDojos_ShouldSucceed()
        {
            // Act
            var result = threeDojoCity.Evaluate(
                c => c.Member(x => x.ReadOnlyDojos).HasNone(d => d.Member(x => x.Master).Fulfills(n => n.Member(x => x.Age).IsEqualTo(26))
                                                                  .Member(x => x.Founded).IsOnSameDayAs(Dates.StandardDay())));

            // Assert
            result.ExAssert(r => r.p(x => x.succeeded) .IsTrue()
                                  .p(x => x.PrintLog()).IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <0 matches>                           (expected: 0 matches)".NewLine()
                                                             .Add("                                   Dojo: (X)Master  = Ninja: (X)Age = 12 (expected: 26)").NewLine()
                                                             .Add("                                         (X)Founded = 11/15/1515         (expected: 11/16/1984)").NewLine()
                                                             .Add("                                   Dojo: ( )Master  = Ninja: ( )Age = 26 (expected: 26)".NewLine()
                                                             .Add("                                         (X)Founded = 01/01/1500         (expected: 11/16/1984)".NewLine()
                                                             .Add("                                   Dojo: (X)Master  = Ninja: (X)Age = 14 (expected: 26)").NewLine()
                                                             .Add("                                         ( )Founded = 11/16/1984         (expected: 11/16/1984)")))));
            
        }

        private class CollectionCity : City
        {
            public CollectionCity(List<Dojo> dojoList) : base(dojoList) { }

            public CollectionCity(params Dojo[] dojos) : base(dojos) { }

            public IReadOnlyCollection<Dojo> ReadOnlyDojos => Dojos?.ToList();
        }
    }
}