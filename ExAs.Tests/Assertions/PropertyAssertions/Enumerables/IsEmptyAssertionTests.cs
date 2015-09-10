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
            ValueAssertionResult result = assertion.Assert(new string[0]);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("0", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("0"), result.expectationString);
        }

        private static IsEmptyAssertion<T> IsEmptyAssertion<T>()
        {
            return new IsEmptyAssertion<T>();
        }
    }
}