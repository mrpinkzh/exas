using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.Generic
{
    [TestFixture]
    public class ObjectAssertionTests
    {
        [Test]
        public void Assert_OnNullAssertion_WithNull_ShouldPass()
        {
            var assertion = Ninja().IsNull();
            AssertionResult result = assertion.Assert(null);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null (expected: null)", result.log);
        }

        [Test]
        public void Assert_OnNullAssertion_WithNinja_ShouldFail()
        {
            var assertion = Ninja().IsNull();
            AssertionResult result = assertion.Assert(new Ninja());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("not null (expected: null)", result.log);
        }

        private static ObjectAssertion<Ninja> Ninja()
        {
            return ObjectAssertion<Ninja>();
        }

        private static ObjectAssertion<T> ObjectAssertion<T>()
        {
            return new ObjectAssertion<T>();
        }
    }
}