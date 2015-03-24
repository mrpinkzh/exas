using NUnit.Framework;

namespace ExAs.Assertions
{
    [TestFixture]
    public class IsNotNullAssertionTests
    {
        private IsNotNullAssertion assertion;

        [SetUp]
        public void SetupContext()
        {
            assertion = new IsNotNullAssertion();
        }

        [Test]
        public void AssertValue_WithObject_ShouldPass()
        {
            ValueAssertionResult result = assertion.AssertValue(new object());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("not null", result.actualValueString);
            Assert.AreEqual("(expected: not null)", result.expectationString);
        }

        [Test]
        public void AssertValue_WithNull_ShouldFail()
        {
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual("(expected: not null)", result.expectationString);
        }
    }
}