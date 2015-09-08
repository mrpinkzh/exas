using ExAs.Results;
using NUnit.Framework;

namespace ExAs.Assertions.ObjectAssertions
{
    [TestFixture]
    public class IsNullAssertionTests
    {
        [Test]
        public void Assert_WithNull_ShouldReturnSuccess()
        {
            IsNullAssertion<string> assertion = CreateStringIsNullAssertion();
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual("(expected: null)", result.expectationString);
        }

        [Test]
        public void Assert_WithString_ShouldReturnFailure()
        {
            IsNullAssertion<string> assertion = CreateStringIsNullAssertion();
            ValueAssertionResult result = assertion.AssertValue("String");
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("'String'", result.actualValueString);
            Assert.AreEqual("(expected: null)", result.expectationString);
        }

        private static IsNullAssertion<string> CreateStringIsNullAssertion()
        {
            return new IsNullAssertion<string>();
        } 
    }
}