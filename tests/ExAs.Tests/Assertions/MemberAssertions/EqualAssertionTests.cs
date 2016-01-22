using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.MemberAssertions
{
    [TestFixture]
    public class EqualAssertionTests
    {
        [Test]
        public void Assert_OnEquals12_With12_ShouldReturnSuccess()
        {
            EqualAssertion<int> assertion = EqualAssertion<int>(12);
            ValueAssertionResult result = assertion.AssertValue(12);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("12", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("12"), result.expectationString);
        }

        [Test]
        public void Assert_OnEqualsStringy_WithStringy_ShouldReturnSuccess()
        {
            EqualAssertion<string> assertion = EqualAssertion("Stringy");
            ValueAssertionResult result = assertion.AssertValue("Stringy");
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("'Stringy'", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("'Stringy'"), result.expectationString);
        }

        [Test]
        public void Assert_OnEqualsNull_WithNull_ShouldReturnSuccess()
        {
            EqualAssertion<string> assertion = EqualAssertion<string>(null);
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("null"), result.expectationString);
        }

        [Test]
        public void Assert_OnEquals12_With25_ShouldReturnFailure()
        {
            EqualAssertion<int> assertion = EqualAssertion(12);
            ValueAssertionResult result = assertion.AssertValue(25);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("25", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("12"), result.expectationString);
        }

        private static EqualAssertion<T> EqualAssertion<T>(T expected)
        {
            return new EqualAssertion<T>(expected);
        }
    }
}