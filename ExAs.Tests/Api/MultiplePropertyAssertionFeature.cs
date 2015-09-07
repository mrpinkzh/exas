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
            AssertionResult result = naruto.Evaluate(
                n => n.Property(x => x.Name).EqualTo("Naruto")
                      .Property(x => x.Age) .EqualTo(12));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: 'Naruto')".NewLine()
                       .Add("       Age  = '12'     (expected: '12')"),
                       result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndInvalidNameAssertion_ShouldFail()
        {
            AssertionResult result = naruto.Evaluate(
                n => n.Property(x => x.Name).EqualTo("Tsubasa")
                      .Property(x => x.Age) .EqualTo(12));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: 'Tsubasa')".NewLine()
                       .Add("       Age  = '12'     (expected: '12')"),
                       result.PrintLog());
        }
    }
}