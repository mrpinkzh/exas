using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    [TestFixture]
    public class HasAnyAssertionTests
    {
        [Test]
        public void OnHasAnyWhichIsNull_WithArrayHavingNull_ShouldReturnSuccess()
        {
            HasAnyAssertion<string> assertion = HasAnyAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new string[] {null});
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("<1 match>".NewLine()
                       .Add("null"), 
                       result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("at least 1 match").NewLine()
                       .Add(ComposeLog.Expected("null")),
                       result.expectationString);
        }

        [Test]
        public void OnHasAnyWhichIsNull_WhitArrayHavingStringy_ShouldFail()
        {
            HasAnyAssertion<string> assertion = HasAnyAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new[] { "Stringy" });
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("<0 matches>".NewLine()
                       .Add("'Stringy'"), 
                       result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("at least 1 match").NewLine()
                       .Add(ComposeLog.Expected("null")),
                       result.expectationString);
        }

        [Test]
        public void OnHasAnyWhichIsNull_WithEmptyArray_ShouldReturnFailure()
        {
            HasAnyAssertion<string> assertion = HasAnyAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new string[] { });
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("<empty>",
                       result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("at least 1 match"),
                       result.expectationString);
        }

        [Test]
        public void OnHasAnyWhichIsNull_WithNull_ShouldReturnFailure()
        {
            HasAnyAssertion<string> assertion = HasAnyAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(null);
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("null", result.actualValueString);
            Assert.AreEqual(ComposeLog.Expected("at least 1 match"),
                       result.expectationString);
        }

        private static HasAnyAssertion<string> HasAnyAssertion(
            Func<IAssert<string>, IAssert<string>> assertionFunc)
        {
            return new HasAnyAssertion<string>(assertionFunc(new ObjectAssertion<string>()));
        }
    }
}