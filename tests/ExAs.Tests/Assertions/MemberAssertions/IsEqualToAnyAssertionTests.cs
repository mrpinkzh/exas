using NUnit.Framework;

namespace ExAs.Assertions.MemberAssertions
{
    [TestFixture]
    public class IsEqualToAnyAssertionTests
    {
        [Test]
        public void Assert_StringValue_EqualToOneOfTheValues_ShouldReturnSuccess()
        {
            var isEqualToAnyAssertion = new IsEqualToAnyAssertion<string>("1", "2", "3");

            var result = isEqualToAnyAssertion.AssertValue("2");

            Assert.IsTrue(result.succeeded);
        }

        [Test]
        public void Assert_String_EqualToNoneOfTheValues_ShouldReturnFailure()
        {
            var isEqualToAnyAssertion = new IsEqualToAnyAssertion<string>("1", "2", "3");

            var result = isEqualToAnyAssertion.AssertValue("4");

            Assert.IsFalse(result.succeeded);
        }

        [Test]
        public void Assert_String_EqualToNoValues_ShouldReturnFailure()
        {
            var isEqualToAnyAssertion = new IsEqualToAnyAssertion<string>();

            var result = isEqualToAnyAssertion.AssertValue("whatever");

            Assert.IsFalse(result.succeeded);
        }
    }
}