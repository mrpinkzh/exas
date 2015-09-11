using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    [TestFixture]
    public class IsEmptyAssertionTests
    {
        [Test]
        public void WithEmptyEnumerable_ShouldReturnSuccess()
        {
            IsEmptyAssertion<string> assertion = IsEmptyAssertion<string>();
            ValueAssertionResult result = assertion.AssertValue(new string[0]);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("<empty>", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("empty enumerable"), result.expectationString);
        }

        [Test]
        public void WithEnumerableHavingOneItem_ShouldReturnFail()
        {
            var assertion = IsEmptyAssertion<string>();
            var result = assertion.AssertValue(new[] {"AnyString"});
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("[ 'AnyString' ]", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("empty enumerable"), result.expectationString);
        }

        [Test]
        public void WithNull_ShouldReturnFail()
        {
            var assertion = IsEmptyAssertion<string>();
            var result = assertion.AssertValue(null);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("empty enumerable"), result.expectationString);
        }

        private static IsEmptyAssertion<T> IsEmptyAssertion<T>()
        {
            return new IsEmptyAssertion<T>();
        }
    }
}