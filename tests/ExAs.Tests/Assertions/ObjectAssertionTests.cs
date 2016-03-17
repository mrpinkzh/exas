using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Assertions
{
    [TestFixture]
    public class ObjectAssertionTests
    {
        [Test]
        public void Assert_OnNullAssertion_WithNull_ShouldPass()
        {
            var assertion = Ninja().IsNull();
            ObjectAssertionResult result = assertion.Assert(null);
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("null (expected: null)", result.PrintLog());
        }

        [Test]
        public void Assert_OnNullAssertion_WithNinja_ShouldFail()
        {
            var assertion = Ninja().IsNull();
            ObjectAssertionResult result = assertion.Assert(Naruto());
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Ninja: Name = 'Naruto' (expected: null)", result.PrintLog());
        }

        private static IAssert<Ninja> Ninja()
        {
            return ObjectAssertion<Ninja>();
        }

        private static IAssert<T> ObjectAssertion<T>()
        {
            return new ObjectAssertion<T>();
        }
    }
}