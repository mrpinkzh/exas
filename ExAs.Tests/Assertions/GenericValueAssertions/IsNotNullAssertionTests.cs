using NUnit.Framework;

namespace ExAs.Assertions.GenericValueAssertions
{
    [TestFixture]
    public class IsNotNullAssertionTests
    {
        [Test]
        public void Assert_WithAnyString_ShouldReturnSuccess()
        {
            IsNotNullAssertion<string> assertion = IsNotNullAssertion<string>();
            ValueAssertionResult result = assertion.AssertValue("AnyString");
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("AnyString", result.actualValueString);
            Assert.AreEqual("(expected: not null)", result.expectationString);
        }

        [Test]
        public void Assert_WithNull_ShouldReturnFailure()
        {
            IsNotNullAssertion<string> assertion = IsNotNullAssertion<string>();
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual("(expected: not null)", result.expectationString);
        }

        private static IsNotNullAssertion<T> IsNotNullAssertion<T>()
        {
            return new IsNotNullAssertion<T>();
        }
    }
}