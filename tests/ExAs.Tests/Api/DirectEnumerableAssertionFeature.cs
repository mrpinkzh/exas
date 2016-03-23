using ExAs.Results;
using ExAs.Utils;
using ExAs.Utils.StringExtensions;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class DirectEnumerableAssertionFeature
    {
        [Test]
        public void ExAssertHasAnyWhichIsNull_OnArrayWithNullValue_ShouldPass()
        {
            var array = new[] { "Stringy", null };
            var result = array.EvaluateHasAny(a => a.IsNull());

            result.ExAssert(r => r.Member(x => x.succeeded) .IsTrue()
                                  .Member(x => x.PrintLog()).IsEqualTo("Enumerable<String>: <1 match> (expected: at least 1 match)".NewLine()
                                                                    .Add("                    'Stringy' (expected: null)").NewLine()
                                                                    .Add("                    null      (expected: null)")));
        }

        [Test]
        public void ExAssertHanNoneWhichIsNull_OnArrayWithNullValue_ShouldFail()
        {
            var array = new[] {"Stringy", null};
            Result result = array.EvaluateHasNone(a => a.IsNull());

            result.ExAssert(r => r.Member(x => x.succeeded ).IsFalse()
                                  .Member(x => x.PrintLog()).IsEqualTo("Enumerable<String>: <1 match> (expected: 0 matches)".NewLine()
                                                                    .Add("                    'Stringy' (expected: null)").NewLine()
                                                                    .Add("                    null      (expected: null)")));
        }
    }
}