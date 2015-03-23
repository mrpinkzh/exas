using NUnit.Framework;

namespace ExAs.Assertions
{
    [TestFixture]
    public class EqualAssertionTests
    {
        [Test]
        public void Assert_OnEqualsWithObject_WithSameObject_ShouldPass()
        {
            var expected = new object();
            EqualAssertion assertion = CreateAssertion(expected);
            AssertionResult result = assertion.Assert(expected);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("'System.Object' (expected: 'System.Object')", result.log);
        }

        [Test]
        public void Assert_OnEqualsWithObject_WithDifferentObject_ShouldFail()
        {
            var expected = new object();
            EqualAssertion assertion = CreateAssertion(expected);
            AssertionResult result = assertion.Assert(new object());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("'System.Object' (expected: 'System.Object') FAIL", result.log);
        }

        [Test]
        public void Assert_OnEqualsWithObject_WithAnyString_ShouldFail()
        {
            var expected = new object();
            EqualAssertion assertion = CreateAssertion(expected);
            AssertionResult result = assertion.Assert("AnyString");
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("'AnyString' (expected: 'System.Object') FAIL", result.log);
        }

        private static EqualAssertion CreateAssertion(object expected)
        {
            return new EqualAssertion(expected);
        }
    }
}