using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class StringAssertionFeature
    {
        [Test]
        public void IsNull_WithNullNinja_ShouldPass()
        {
            var nullNinja = new Ninja(name: null);
            AssertionResult result = nullNinja.Evaluate(n => n.Property(x => x.Name).IsNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual(
                "Ninja: Name = null (expected: null)",
                result.PrintLog());
        }

        [Test]
        public void IsNull_WithNaruto_ShouldFail()
        {
            var ninja = new Ninja("Naruto");
            AssertionResult result = ninja.Evaluate(n => n.Property(x => x.Name).IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual(
                "Ninja: Name = 'Naruto' (expected: null)",
                result.PrintLog());
        }
    }
}