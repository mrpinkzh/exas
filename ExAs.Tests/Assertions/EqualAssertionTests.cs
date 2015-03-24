using NUnit.Framework;

namespace ExAs.Assertions
{
    [TestFixture]
    public class EqualAssertionTests
    {
        [Test]
        public void AssertValue_OnEqualsWithObject_WithSameObject_ShouldPass()
        {
            var expected = new object();
            EqualAssertion assertion = CreateAssertion(expected);
            ValueAssertionResult result = assertion.AssertValue(expected);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("'System.Object'", result.actualValueString);
            Assert.AreEqual("(expected: 'System.Object')", result.expectationString);
        }

        [Test]
        public void Assert_OnEqualsWithObject_WithDifferentObject_ShouldFail()
        {
            var expected = new object();
            EqualAssertion assertion = CreateAssertion(expected);
            ValueAssertionResult result = assertion.AssertValue(new object());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("'System.Object'", result.actualValueString);
            Assert.AreEqual("(expected: 'System.Object')", result.expectationString);
        }

        [Test]
        public void Assert_OnEqualsWithObject_WithAnyString_ShouldFail()
        {
            var expected = new object();
            EqualAssertion assertion = CreateAssertion(expected);
            ValueAssertionResult result = assertion.AssertValue("AnyString");
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("'AnyString'", result.actualValueString);
            Assert.AreEqual("(expected: 'System.Object')", result.expectationString);
        }

        private static EqualAssertion CreateAssertion(object expected)
        {
            return new EqualAssertion(expected);
        }
    }
}