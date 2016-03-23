using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;

namespace ExAs.Assertions.MemberAssertions.Strings
{
    [TestFixture]
    public class EqualAssertionTests
    {
        [Test]
        public void OnEqualsStringy_WithStringy_ShouldReturnSuccess()
        {
            EqualAssertion assertion = EqualAssertion("Stringy");
            ValueAssertionResult result = assertion.AssertValue("Stringy");
            Assert.AreEqual("'Stringy'", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("'Stringy'"), result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void OnEqualsStringy_WithEmptyString_ShouldReturnFailure()
        {
            EqualAssertion assertion = EqualAssertion("Stringy");
            ValueAssertionResult result = assertion.AssertValue("");
            Assert.AreEqual("''", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("'Stringy'"), result.expectationString);
            Assert.IsFalse(result.succeeded);
        }
        
        [Test]
        public void OnEqualsStringy_WithNull_ShouldReturnFailure()
        {
            EqualAssertion assertion = EqualAssertion("Stringy");
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("'Stringy'"), result.expectationString);
            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void OnEqualsNull_WithNull_ShouldReturnSuccess()
        {
            EqualAssertion assertion = EqualAssertion(null);
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("null"), result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void OnEqualsMultiLineString_WithMultiLineString_ShouldReturnSuccess()
        {
            var multiLineString = "MultiLine".NewLine().Add("String");
            EqualAssertion assertion = EqualAssertion(multiLineString);
            ValueAssertionResult result = assertion.AssertValue(multiLineString);
            Assert.AreEqual("'MultiLine".NewLine()
                       .Add(" String'"), 
                       result.actualValueString);
            Assert.AreEqual("(expected: 'MultiLine".NewLine()
                       .Add("            String')"), 
                       result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        private static EqualAssertion EqualAssertion(string expected)
        {
            return new EqualAssertion(expected);
        }
    }
}