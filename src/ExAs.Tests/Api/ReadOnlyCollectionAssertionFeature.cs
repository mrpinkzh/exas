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

            public IReadOnlyCollection<Dojo> ReadOnlyDojos => Dojos?.ToList();
        }
    }
}