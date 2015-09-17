using ExAs.Results;
using ExAs.Utils;
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

            result.ExAssert(r => r.Property(x => x.succeeded) .IsTrue()
                                  .Property(x => x.PrintLog()).IsEqualTo("Enumerable<String>: <1 match> (expected: at least 1 match)".NewLine()
                                                                    .Add("                    'Stringy' (expected: null)").NewLine()
                                                                    .Add("                    null      (expected: null)")));
        }

        [Test]
        public void ExAssertHanNoneWhichIsNull_OnArrayWithNullValue_ShouldFail()
        {
            var array = new[] {"Stringy", null};
            ObjectAssertionResult result = array.EvaluateHasNone(a => a.IsNull());

            result.ExAssert(r => r.Property(x => x.succeeded ).IsFalse()
                                  .Property(x => x.PrintLog()).IsEqualTo("Enumerable<String>: <1 match> (expected: 0 matches)".NewLine()
                                                                    .Add("                    'Stringy' (expected: null)").NewLine()
                                                                    .Add("                    null      (expected: null)")));
        }
    }
}