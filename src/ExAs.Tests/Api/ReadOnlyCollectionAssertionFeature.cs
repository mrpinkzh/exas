using System.Collections.Generic;
using System.Linq;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class ReadOnlyCollectionAssertionFeature
    {
        private readonly CollectionCity cityWithNullDojos = new CollectionCity(dojoList: null);
        private readonly CollectionCity cityWithoutDojo = new CollectionCity();
        private readonly CollectionCity cityWithDojo = new CollectionCity(new Dojo(new Ninja(), Dates.StandardDay()));

        [Test]
        public void IsNull_WithNullDojos_ShouldPass()
        {
            // Act
            ObjectAssertionResult result = cityWithNullDojos.Evaluate(c => c.Property(x => x.ReadOnlyDojos).IsNull());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsTrue()
                                  .Property(x => x.log)      .IsEqualTo("CollectionCity: ( )ReadOnlyDojos = null"));
        }

        [Test]
        public void IsNull_OnCityWithoutDojo_ShouldFail()
        {
            // Act
            ObjectAssertionResult result = cityWithoutDojo.Evaluate(c => c.Property(x => x.ReadOnlyDojos).IsNull());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsFalse()
                                  .Property(x => x.log)      .IsEqualTo("CollectionCity: (X)ReadOnlyDojos = <empty>"));
        }

        [Test]
        public void IsNotNull_OnCityWithoutDojo_ShouldSucceed()
        {
            // Act
            ObjectAssertionResult result = cityWithoutDojo.Evaluate(c => c.Property(x => x.ReadOnlyDojos).IsNotNull());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsTrue()
                                  .Property(x => x.log)      .IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <empty>"));
        }

        [Test]
        public void IsNotNull_WithNullDojos_ShouldFail()
        {
            // Act
            ObjectAssertionResult result = cityWithNullDojos.Evaluate(n => n.Property(x => x.ReadOnlyDojos).IsNotNull());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsFalse()
                                  .Property(x => x.log).IsEqualTo("CollectionCity: (X)ReadOnlyDojos = null"));
        }

        [Test]
        public void IsEmpty_OnCityWithoutDojo_ShouldSucceed()
        {
            // Act
            ObjectAssertionResult result = cityWithoutDojo.Evaluate(c => c.Property(x => x.ReadOnlyDojos).IsEmpty());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsTrue()
                                  .Property(x => x.log)      .IsEqualTo("CollectionCity: ( )ReadOnlyDojos = <empty>"));
        }

        [Test]
        public void IsEmpty_OnCityWithDojo_ShouldFail()
        {
            // Act
            ObjectAssertionResult result = cityWithDojo.Evaluate(c => c.Property(x => x.ReadOnlyDojos).IsEmpty());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsFalse()
                                  .Property(x => x.log)      .IsEqualTo("CollectionCity: (X)ReadOnlyDojos = <1 Dojo>"));
        }

        [Test]
        public void IsEmpty_WithNullDojos_ShouldFail()
        {
            // Act
            ObjectAssertionResult result = cityWithNullDojos.Evaluate(c => c.Property(x => x.ReadOnlyDojos).IsEmpty());

            // Assert
            result.ExAssert(r => r.Property(x => x.succeeded).IsFalse()
                .Property(x => x.log)      .IsEqualTo("CollectionCity: (X)ReadOnlyDojos = null"));
        }

        private class CollectionCity : City
        {
            public CollectionCity(List<Dojo> dojoList) : base(dojoList) { }

            public CollectionCity(params Dojo[] dojos) : base(dojos) { }

            public IReadOnlyCollection<Dojo> ReadOnlyDojos => Dojos?.ToList();
        }
    }
}