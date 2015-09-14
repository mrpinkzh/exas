using System;
using ExAs.Results;
using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Assertions.PropertyAssertions.Enumerables
{
    [TestFixture]
    public class HasNoneAssertionTests
    {
        [Test]
        public void OnHasNoneWhichIsNull_WithArrayHavingStringy_ShouldReturnSuccess()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(x => x.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new[] {"Stringy"});

            result.ExAssert(r => r.Property(x => x.succeeded)        .IsTrue()
                                  .Property(x => x.actualValueString).EqualTo("<0 matches>".NewLine()
                                                                         .Add("'Stringy'"))
                                  .Property(x => x.expectationString).EqualTo(ComposeLog.Expected("0 matches").NewLine()
                                                                         .Add(ComposeLog.Expected("null"))));
        }

        [Test]
        public void OnHasNoneWhichIsNull_WithArrayHavingNull_ShouldReturnFailure()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new string[] { null });
            
            result.ExAssert(r => r.Property(x => x.succeeded)        .IsFalse()
                                  .Property(x => x.actualValueString).EqualTo("<1 match>".NewLine()
                                                                         .Add("null"))
                                  .Property(x => x.expectationString).EqualTo(ComposeLog.Expected("0 matches").NewLine()
                                                                         .Add(ComposeLog.Expected("null"))));
        }

        [Test]
        public void OnHasNoneWhichIsNull_WithEmptyArray_ShouldReturnSuccess()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new string[] { });
            
            result.ExAssert(r => r.Property(x => x.succeeded).IsTrue()
                                  .Property(x => x.actualValueString).EqualTo("<empty>")
                                  .Property(x => x.expectationString).EqualTo(ComposeLog.Expected("0 matches")));
        }

        [Test]
        public void OnHasNoneWhichIsNull_WithNull_ShouldReturnSuccess()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(null);
            
            result.ExAssert(r => r.Property(x => x.succeeded)        .IsTrue()
                                  .Property(x => x.actualValueString).EqualTo("null")
                                  .Property(x => x.expectationString).EqualTo(ComposeLog.Expected("0 matches")));
        }

        private static HasNoneAssertion<string> HasNoneAssertion(
            Func<ObjectAssertion<string>, ObjectAssertion<string>> assertionFunc)
        {
            return new HasNoneAssertion<string>(assertionFunc(new ObjectAssertion<string>()));
        }
    }
}