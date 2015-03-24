using NUnit.Framework;

namespace ExAs.Assertions
{
    [TestFixture]
    public class IsNullAssertionTests
    {
        private IsNullAssertion assertion;

        [SetUp]
        public void SetupContext()
        {
            assertion = new IsNullAssertion();
        }

        [Test]
        public void AssertValue_WithNull_ShouldPass()
        {
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual("(expected: null)", result.expectationString);
        }

        [Test]
        public void AssertValue_WithObject_ShouldFail()
        {
            ValueAssertionResult result = assertion.AssertValue(new object());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("not null", result.actualValueString);
            Assert.AreEqual("(expected: null)", result.expectationString);
        }
    }
}