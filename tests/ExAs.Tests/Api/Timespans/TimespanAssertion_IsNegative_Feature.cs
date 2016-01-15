using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Api.Timespans.SleepyNinja;

namespace ExAs.Api.Timespans
{
    [TestFixture]
    public class TimespanAssertion_IsNegative_Feature
    {
        [Test]
        public void OnAsleepNinja_ShouldSucceed()
        {
            // act
            var result = AsleepNinja().Evaluate(n => n.Property(x => x.awake).IsNegative());

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = -04:15:45", "(expected: negative)"));
        }

        [Test]
        public void OnWorkdayNinja_ShouldFail()
        {
            // act
            var result = WorkDayNinja().Evaluate(n => n.Property(x => x.awake).IsNegative());

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 08:30:15", "(expected: negative)"));
        }

        [Test]
        public void OnWokeUpNinja_ShouldFail()
        {
            // act
            var result = WokeUpNinja().Evaluate(n => n.Property(x => x.awake).IsNegative());

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 00:00:00", "(expected: negative)"));
        }
    }
}