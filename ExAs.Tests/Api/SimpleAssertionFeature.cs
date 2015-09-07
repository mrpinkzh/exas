using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class SimpleAssertionFeature
    {
        private readonly Ninja naruto = new Ninja("Naruto", 12);

        [Test]
        public void Assert_WithNaruto_WithoutAssertions_ShouldPass()
        {
            var result = naruto.Evaluate(n => n);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("no assertions", result.log);
        }

        [Test]
        public void Assert_WithNaruto_AndNotNull_ShouldPass()
        {
            var result = naruto.Evaluate(
                n => n.IsNotNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: not null)", result.PrintLog());
        }

        [Test]
        public void Assert_WithNull_AndNotNullAssertion_ShouldFail()
        {
            Ninja ninja = null;
            var result = ninja.Evaluate(
                n => n.IsNotNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("null (expected: not null)", result.PrintLog());
        }

        [Test]
        public void Assert_WithNull_AndNullAssertion_ShouldPass()
        {
            Ninja ninja = null;
            var result = ninja.Evaluate(
                n => n.IsNull());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null (expected: null)", result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndNullAssertion_ShouldFail()
        {
            var result = naruto.Evaluate(
                n => n.IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: null)", result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndValidNameAssertion_ShouldPass()
        {
            var ninja = new Ninja("Naruto", 12);

            AssertionResult result = ninja.Evaluate(
                n => n.Property(x => x.Name).EqualTo("Naruto"));

            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: 'Naruto')",
                            result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndValidAgeAssertion_ShouldPass()
        {
            var ninja = new Ninja("Naruto", 12);

            AssertionResult result = ninja.Evaluate(
                n => n.Property(x => x.Age).EqualTo(12));

            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: Age = '12' (expected: '12')",
                            result.PrintLog());
        }
    }
}