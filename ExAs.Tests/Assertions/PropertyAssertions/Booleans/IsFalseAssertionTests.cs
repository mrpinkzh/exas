using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.Booleans
{
    [TestFixture]
    public class IsFalseAssertionTests
    {
        [Test]
        public void WithFalse_ShouldPass()
        {
            var assertion = new IsFalseAssertion();
            ValueAssertionResult result = assertion.AssertValue(false);
            Assert.AreEqual("False", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("False"), result.expectationString);
            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void WithTrue_ShouldFail()
        {
            var assertion = new IsFalseAssertion();
            ValueAssertionResult result = assertion.AssertValue(true);
            Assert.AreEqual("True", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("False"), result.expectationString);
            Assert.IsFalse(result.succeeded);
        }
    }
}