using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.MemberAssertions.Booleans
{
    [TestFixture]
    public class IsTrueAssertionTests
    {
        [Test]
        public void OnTrue_ShouldPass()
        {
            var assertion = new IsTrueAssertion();
            ValueAssertionResult result = assertion.AssertValue(true);
            Assert.AreEqual("True", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("True"), result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void OnFalse_ShouldFail()
        {
            var assertion = new IsTrueAssertion();
            ValueAssertionResult result = assertion.AssertValue(false);
            Assert.AreEqual("False", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("True"), result.expectationString);
            Assert.IsFalse(result.succeeded);
        }
    }
}