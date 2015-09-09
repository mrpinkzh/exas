using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api
{
    [TestFixture]
    public class DateTimeAssertionFeature
    {
        [Test]
        public void SameDayAs_OnYesterday_WithYesterday_ShouldSucceed()
        {
            var dojosYesterday = Dates.Yesterday();
            var dojo = new Dojo(new Ninja(), dojosYesterday);
            var expectedYesterday = Dates.Yesterday();
            var result = dojo.Evaluate(d => d.Property(x => x.Founded).OnSameDayAs(expectedYesterday));
            Assert.IsTrue(result.succeeded);
            Assert.AreEqual("Dojo: ( )Founded = ".Add(dojosYesterday.ToShortDateString()).Add(" (expected: ").Add(expectedYesterday.ToShortDateString()).Add(")"),
                            result.PrintLog());
        }

        [Test]
        public void SameDayAs_OnToday_WithTomoroow_ShouldFail()
        {
            var dojosFoundation = Dates.Today();
            var dojo = new Dojo(new Ninja(), dojosFoundation);
            var expectation = Dates.Tomorrow();
            var result = dojo.Evaluate(d => d.Property(x => x.Founded).OnSameDayAs(expectation));
            Assert.IsFalse(result.succeeded);
            Assert.AreEqual("Dojo: (X)Founded = ".Add(dojosFoundation.ToShortDateString()).Add(" (expected: ").Add(expectation.ToShortDateString()).Add(")"),
                            result.PrintLog());
        }
    }
}