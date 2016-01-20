using ExAs.Utils;
using NUnit.Framework;

namespace ExAs.Api.Timespans
{
    [TestFixture]
    public class TimespanAssertion_Comparables_Feature
    {
        [Test]
        public void IsSmaller_Expecting5Seconds_On4Seconds_ShouldSucceed()
        {
            // arrange
            var ninja = new SleepyNinja(4.Seconds());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsSmallerThan(5.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 00:00:04", "(expected: smaller than 00:00:05)"));
        }
        
        [Test]
        public void IsBigger_Expecting6Seconds_On6Seconds_ShouldFail()
        {
            // arrange
            var ninja = new SleepyNinja(6.Seconds());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsBiggerThan(6.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 00:00:06", "(expected: bigger than 00:00:06)"));
        }

        [Test]
        public void IsInRange_ExpectingBetween16And38Minutes_On2Hours_ShouldFail()
        {
            // arrange
            var ninja = new SleepyNinja(2.Hours());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsInRange(16.Minutes(), 38.Minutes()));

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 02:00:00", "(expected: between 00:16:00 and 00:38:00)"));
        }
    }
}