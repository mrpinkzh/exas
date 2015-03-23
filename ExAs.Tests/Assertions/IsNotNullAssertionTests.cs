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
        public void Assert_WithObject_ShouldPass()
        {
            AssertionResult result = assertion.Assert(new object());
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("not null (expected: not null)", result.log);
        }

        [Test]
        public void Assert_WithNull_ShouldFail()
        {
            AssertionResult result = assertion.Assert(null);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("null (expected: not null) FAIL", result.log);
        }
    }
}