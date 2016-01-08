using ExAs.Assertions.PropertyAssertions.Enumerables;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.Strings
{
    [TestFixture]
    public class IsEmptyAssertionTests
    {
        [Test]
        public void WithEmptyString_ShouldReturnSuccess()
        {
            IsEmptyAssertion<char> assertion = IsEmptyAssertion();
            ValueAssertionResult result = assertion.AssertValue("");
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("''", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("empty string"), result.expectationString);
        }

        [Test]
        public void WithStringy_ShouldReturnFailure()
        {
            IsEmptyAssertion<char> assertion = IsEmptyAssertion();
            ValueAssertionResult result = assertion.AssertValue("Stringy");
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("'Stringy'", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("empty string"), result.expectationString);
        }

        [Test]
        public void WithNull_ShouldReturnFailure()
        {
            IsEmptyAssertion<char> assertion = IsEmptyAssertion();
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("empty string"), result.expectationString);
        }

        private static IsEmptyAssertion<char> IsEmptyAssertion()
        {
            return new IsEmptyAssertion<char>();
        }
    }
}