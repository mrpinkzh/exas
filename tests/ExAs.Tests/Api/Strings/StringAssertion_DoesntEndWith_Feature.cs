using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api.Strings
{
    [TestFixture]
    public class StringAssertion_DoesntEndWith_Feature
    {
        [Test]
        public void ExpectingNotShi_OnNaruto_ShouldPass()
        {
            // arrange
            var result = Naruto().Evaluate(n => n.Member(x => x.Name).DoesntEndWith("shi"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.log)      .IsEqualTo("Ninja: ( )Name = 'Naruto'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: doesn't end with 'shi')"));
        }

        [Test]
        public void ExpectingNotAshi_OnNaruto_ShouldPass()
        {
            // arrange
            var result = Kakashi().Evaluate(n => n.Member(x => x.Name).DoesntEndWith("ashi"));

            // assert
            result.ExAssert(r => r.Member(x => x.succeeded).IsFalse()
                                  .Member(x => x.log)      .IsEqualTo("Ninja: (X)Name = 'Kakashi'")
                                  .Member(x => x.expectation).IsEqualTo("(expected: doesn't end with 'ashi')"));
        }
    }
}