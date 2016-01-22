using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    [TestFixture]
    public class IsNotEmptyAssertionTests
    {
        [Test]
        public void WithEnumerableHavingOneString_ShouldReturnSuccess()
        {
            IsNotEmptyAssertion<string> assertion = IsNotEmptyAssertion();
            ValueAssertionResult result = assertion.AssertValue(new[] {"Stringy"});
            Assert.AreEqual("['Stringy']", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("not empty"), result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void WithEmptyEnumerable_ShouldReturnFailure()
        {
            IsNotEmptyAssertion<string> assertion = IsNotEmptyAssertion();
            ValueAssertionResult result = assertion.AssertValue(new string[0]);
            Assert.AreEqual("<empty>", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("not empty"), result.expectationString);
            Assert.IsFalse(result.succeeded);
        }
        
        [Test]
        public void WithNull_ShouldReturnSuccess()
        {
            var assertion = IsNotEmptyAssertion();
            var result = assertion.AssertValue(null);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("not empty"), result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        private static IsNotEmptyAssertion<string> IsNotEmptyAssertion()
        {
            return new IsNotEmptyAssertion<string>();
        }
    }
}