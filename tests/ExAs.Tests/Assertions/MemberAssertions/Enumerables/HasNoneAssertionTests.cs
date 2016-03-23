using System;
using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;

namespace ExAs.Assertions.MemberAssertions.Enumerables
{
    [TestFixture]
    public class HasNoneAssertionTests
    {
        [Test]
        public void OnHasNoneWhichIsNull_WithArrayHavingStringy_ShouldReturnSuccess()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(x => x.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new[] {"Stringy"});

            result.ExAssert(r => r.Member(x => x.succeeded)        .IsTrue()
                                  .Member(x => x.actualValueString).IsEqualTo("<0 matches>".NewLine()
                                                                         .Add("'Stringy'"))
                                  .Member(x => x.expectationString).IsEqualTo(ComposeLog.Expected("0 matches").NewLine()
                                                                         .Add(ComposeLog.Expected("null"))));
        }

        [Test]
        public void OnHasNoneWhichIsNull_WithArrayHavingNull_ShouldReturnFailure()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new string[] { null });
            
            result.ExAssert(r => r.Member(x => x.succeeded)        .IsFalse()
                                  .Member(x => x.actualValueString).IsEqualTo("<1 match>".NewLine()
                                                                         .Add("null"))
                                  .Member(x => x.expectationString).IsEqualTo(ComposeLog.Expected("0 matches").NewLine()
                                                                         .Add(ComposeLog.Expected("null"))));
        }

        [Test]
        public void OnHasNoneWhichIsNull_WithEmptyArray_ShouldReturnSuccess()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(new string[] { });
            
            result.ExAssert(r => r.Member(x => x.succeeded).IsTrue()
                                  .Member(x => x.actualValueString).IsEqualTo("<empty>")
                                  .Member(x => x.expectationString).IsEqualTo(ComposeLog.Expected("0 matches")));
        }

        [Test]
        public void OnHasNoneWhichIsNull_WithNull_ShouldReturnSuccess()
        {
            HasNoneAssertion<string> assertion = HasNoneAssertion(s => s.IsNull());
            ValueAssertionResult result = assertion.AssertValue(null);
            
            result.ExAssert(r => r.Member(x => x.succeeded)        .IsTrue()
                                  .Member(x => x.actualValueString).IsEqualTo("null")
                                  .Member(x => x.expectationString).IsEqualTo(ComposeLog.Expected("0 matches")));
        }

        private static HasNoneAssertion<string> HasNoneAssertion(
            Func<IAssert<string>, IAssert<string>> assertionFunc)
        {
            return new HasNoneAssertion<string>(assertionFunc(new ObjectAssertion<string>()));
        }
    }
}