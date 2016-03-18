using System;
using ExAs.Utils;
using static ExAs.Utils.Timespans;

namespace ExAs.Api.Timespans
{
    public class SleepyNinja : Ninja
    {
        public static SleepyNinja WorkDayNinja()
        {
            return new SleepyNinja(WorkDay());
        }

        public static SleepyNinja AsleepNinja()
        {
            return new SleepyNinja(new TimeSpan(-4, -15, -45));
        }

        public static SleepyNinja WokeUpNinja()
        {
            return new SleepyNinja(default(TimeSpan));
        }

        public static SleepyNinja SleeplessNinja()
        {
            return new SleepyNinja(MonthAndWorkDay());
        }

        public readonly TimeSpan awake;

        public SleepyNinja(TimeSpan awake)
        {
            this.awake = awake;
        }
    }
}