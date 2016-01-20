using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Api.Timespans.SleepyNinja;
using static ExAs.Utils.Timespans;

namespace ExAs.Api.Timespans
{
    [TestFixture]
    public class TimespanAssertion_IsCloseTo_Feature
    {
        [Test]
        public void ExpectingWithinOfWorkday_OnWorkdayNinja_ShouldSucceed()
        {
            // act
            var result = WorkDayNinja().Evaluate(n => n.Property(x => x.awake).IsCloseTo(WorkDay(), 5.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 08:30:15", "(expected: between 08:30:10 and 08:30:20)"));
        }

        [Test]
        public void ExpectingWithin1Of5Seconds_On4Seconds_ShouldSucceed()
        {
            // arrange
            var ninja = new SleepyNinja(4.Seconds());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsCloseTo(5.Seconds(), 1.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 00:00:04", "(expected: between 00:00:04 and 00:00:06)"));
        }

        [Test]
        public void ExpectingWithin1Of5Seconds_On6Seconds_ShouldSucceed()
        {
            // arrange
            var ninja = new SleepyNinja(6.Seconds());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsCloseTo(5.Seconds(), 1.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 00:00:06", "(expected: between 00:00:04 and 00:00:06)"));
        }

        [Test]
        public void ExpectingWithin1Of5Seconds_On3Seconds_ShouldFail()
        {
            // arrange
            var ninja = new SleepyNinja(3.Seconds());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsCloseTo(5.Seconds(), 1.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 00:00:03", "(expected: between 00:00:04 and 00:00:06)"));
        }

        [Test]
        public void ExpectingWithin1Of5Seconds_On7Seconds_ShouldFail()
        {
            // arrange
            var ninja = new SleepyNinja(7.Seconds());

            // act
            var result = ninja.Evaluate(n => n.Property(x => x.awake).IsCloseTo(5.Seconds(), 1.Seconds()));

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 00:00:07", "(expected: between 00:00:04 and 00:00:06)"));
        }
    }
}