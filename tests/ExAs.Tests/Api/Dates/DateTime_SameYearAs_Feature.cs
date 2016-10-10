using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Api.Dates
{
    [TestFixture]
    public class DateTime_SameYearAs_Feature
    {
        [Test]
        public void OnCommonFoundationDay_WithCommonFoundationDay_ShouldPass()
        {
            // Arrange
            var dojo = new Dojo(Naruto(), CommonFoundationDay());

            // Act
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).IsInSameYearAs(CommonFoundationDay()));

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actual)   .IsEqualTo("Dojo: ( )Founded = 15.11.1515")
                                  .Member(x => x.expectation).IsEqualTo("(expected: in same year as 15.11.1515)"));
        }

        [Test]
        public void OnStandardDay_WithLastYear_ShouldFail()
        {
            // Arrange
            var dojo = new Dojo(Naruto(), StandardDay());

            // Act
            var result = dojo.Evaluate(d => d.Member(x => x.Founded).IsInSameYearAs(3.April(2015)));

            // Assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.actual)   .IsEqualTo("Dojo: (X)Founded = 16.11.1984")
                                  .Member(x => x.expectation).IsEqualTo("(expected: in same year as 03.04.2015)"));
        }
    }
}