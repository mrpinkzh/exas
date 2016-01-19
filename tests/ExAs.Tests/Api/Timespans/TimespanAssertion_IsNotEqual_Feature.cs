using System;
using ExAs.Utils;
using NUnit.Framework;
using static ExAs.Api.Timespans.SleepyNinja;
using static ExAs.Utils.Timespans;

namespace ExAs.Api.Timespans
{
    [TestFixture]
    public class TimespanAssertion_IsNotEqual_Feature
    {
        [Test]
        public void ExpectingWorkDay_OnAsleepNinja_ShouldSucceed()
        {
            // act
            var result = AsleepNinja().Evaluate(n => n.Property(x => x.awake).IsNotEqualTo(WorkDay()));

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = -04:15:45", "(expected: 08:30:15)"));
        }

        [Test]
        public void ExpectingWorkDay_OnWorkDayNinja_ShouldFail()
        {
            // act
            var result = WorkDayNinja().Evaluate(n => n.Property(x => x.awake).IsNotEqualTo(WorkDay()));

            // assert
            result.ExAssert(r => r.Fullfills(false, "SleepyNinja: (X)awake = 08:30:15", "(expected: 08:30:15)"));
        }

        [Test]
        public void ExpectingWorkDay_OnSleeplessNinja_ShouldSucceed()
        {
            // act
            var result = SleeplessNinja().Evaluate(n => n.Property(x => x.awake).IsNotEqualTo(WorkDay()));

            // assert
            result.ExAssert(r => r.Fullfills(true, "SleepyNinja: ( )awake = 30.08:30:15", "(expected: 08:30:15)"));
        }
    }
}