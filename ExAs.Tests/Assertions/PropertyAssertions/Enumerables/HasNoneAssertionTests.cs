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
                                  .Property(x => x.actualValueString).EqualTo("<0 matches>".NewLine().Add("'Stringy'"))
                                  .Property(x => x.expectationString).EqualTo(ComposeLog.Expected("0 matches").NewLine().Add(ComposeLog.Expected("null"))));
        }

        private static HasNoneAssertion<string> HasNoneAssertion(
            Func<ObjectAssertion<string>, ObjectAssertion<string>> assertionFunc)
        {
            return new HasNoneAssertion<string>();
        }
    }
}