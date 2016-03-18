using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Api
{
    [TestFixture]
    public class SimpleAssertionFeature
    {
        [Test]
        public void Assert_WithNaruto_WithoutAssertions_ShouldPass()
        {
            var result = Naruto().Evaluate(n => n);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("no assertions", result.actual);
        }

        [Test]
        public void Assert_WithNaruto_AndNotNull_ShouldPass()
        {
            var result = Naruto().Evaluate(
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
            var result = Naruto().Evaluate(
                n => n.IsNull());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: null)", result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndValidNameAssertion_ShouldPass()
        {
            Result result = Naruto().Evaluate(
                n => n.Member(x => x.Name).IsEqualTo("Naruto"));

            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: ( )Name = 'Naruto' (expected: 'Naruto')",
                            result.PrintLog());
        }

        [Test]
        public void Assert_WithNaruto_AndValidAgeAssertion_ShouldPass()
        {
            Result result = Naruto().Evaluate(
                n => n.Member(x => x.Age).IsEqualTo(12));

            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Ninja: ( )Age = 12 (expected: 12)",
                            result.PrintLog());
        }
    }
}