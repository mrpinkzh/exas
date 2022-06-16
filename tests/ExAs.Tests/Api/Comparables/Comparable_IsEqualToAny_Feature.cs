using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.ComposeLog;

namespace ExAs.Api.Comparables
{
    [TestFixture]
    public class Comparable_IsEqualToAny_Feature
    {
        [Test]
        public void ExpectedEqualToAnyNarutoOrKakashi_OnNaruto_ShouldSucceed()
        {
            //Act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsEqualToAny("Naruto", "Kakashi"));

            //Assert
            result.ExAssert(r => r
                .Member(x => x.succeeded).IsTrue()
                .Member(x => x.actual).IsEqualTo("Ninja: ( )Name = 'Naruto'")
                .Member(x => x.expectation).IsEqualTo(Expected("is one of ['Naruto', 'Kakashi']")));
        }
        
        [Test]
        public void ExpectedEqualToAnyDeidaraOrKakashi_OnNaruto_ShouldFail()
        {
            //Act
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).IsEqualToAny("Deidara", "Kakashi"));

            //Assert
            result.ExAssert(r => r
                .Member(x => x.succeeded).IsFalse()
                .Member(x => x.actual).IsEqualTo("Ninja: (X)Name = 'Naruto'")
                .Member(x => x.expectation).IsEqualTo(Expected("is one of ['Deidara', 'Kakashi']")));
        }
    }
}