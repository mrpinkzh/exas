using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Api.Timespans.SleepyNinja;

namespace ExAs.Api.Timespans
{
    [TestFixture]
    public class TimespanAssertion_IsPositive_Feature
    {
        [Test]
        public void OnWorkDayNinja_ShouldSucceed()
        {
            // act
            var result = WorkDayNinja().Evaluate(n => n.Member(x => x.awake).IsPositive());

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 08:30:15", "(expected: positive)"));
        }

        [Test]
        public void OnAsleepNinja_ShouldFail()
        {
            // act
            var result = AsleepNinja().Evaluate(n => n.Member(x => x.awake).IsPositive());

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = -04:15:45", "(expected: positive)"));
        }

        [Test]
        public void OnWokeUpNinja_ShouldSucceed()
        {
            // act
            var result = WokeUpNinja().Evaluate(n => n.Member(x => x.awake).IsPositive());

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 00:00:00", "(expected: positive)"));
        }
    }
}