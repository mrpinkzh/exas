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
        public void Assert_WithNull_ShouldPass()
        {
            AssertionResult result = assertion.Assert(null);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null (expected: null)", result.log);
        }

        [Test]
        public void Assert_WithObject_ShouldFail()
        {
            AssertionResult result = assertion.Assert(new object());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("not null (expected: null) FAIL", result.log);
        }
    }
}