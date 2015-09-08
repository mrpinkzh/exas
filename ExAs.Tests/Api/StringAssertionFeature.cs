using ExAs.Assertions;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class StringAssertionFeature
    {
        private readonly Ninja naruto = new Ninja();

        [Test]
        public void IsNull_WithNullNinja_ShouldPass()
        {
            var nullNinja = new Ninja(name: null);
            ObjectAssertionResult result = nullNinja.Evaluate(n => n.Property(x => x.Name).IsNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual(
                "Ninja: Name = null (expected: null)",
                result.PrintLog());
        }

        [Test]
        public void IsNull_WithNaruto_ShouldFail()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.Property(x => x.Name).IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual(
                "Ninja: Name = 'Naruto' (expected: null)",
                result.PrintLog());
        }

        [Test]
        public void IsEmpty_WithEmptyNinja_ShouldPass()
        {
            var ninja = new Ninja("");
            ObjectAssertionResult result = ninja.Evaluate(n => n.Property(x => x.Name).IsEmpty());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual(
                "Ninja: Name = '' (expected: empty string)",
                result.PrintLog());
        }

        [Test]
        public void IsEmpty_WithNaruto_ShouldFail()
        {
            ObjectAssertionResult result = naruto.Evaluate(n => n.Property(x => x.Name).IsEmpty());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual(
                "Ninja: Name = 'Naruto' (expected: empty string)",
                result.PrintLog());
        }
    }
}