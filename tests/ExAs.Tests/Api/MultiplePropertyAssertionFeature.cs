using ExAs.Assertions;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class MultiplePropertyAssertionFeature
    {
        private readonly Ninja naruto = new Ninja("Naruto", 12);

        [Test]
        public void Assert_WithNaruto_AndValidAssertionForBothProperties_ShouldPass()
        {
            ObjectAssertionResult result = naruto.Evaluate(
                n => n.Member(x => x.Name).IsEqualTo("Naruto")
                      .Member(x => x.Age) .IsEqualTo(12));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: ( )Name = 'Naruto' (expected: 'Naruto')".NewLine()
                       .Add("       ( )Age  = 12       (expected: 12)"),
                       result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndInvalidNameAssertion_ShouldFail()
        {
            ObjectAssertionResult result = naruto.Evaluate(
                n => n.Member(x => x.Name).IsEqualTo("Tsubasa")
                      .Member(x => x.Age) .IsEqualTo(12));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Ninja: (X)Name = 'Naruto' (expected: 'Tsubasa')".NewLine()
                       .Add("       ( )Age  = 12       (expected: 12)"),
                       result.PrintLog());
        }
    }
}