using System;
using ExAs.Utils;

namespace ExAs.Api.Timespans
{
    public class SleepyNinja : Ninja
    {
        public static SleepyNinja WorkDayNinja()
        {
            return new SleepyNinja(new TimeSpan(8, 30, 15));
        }

        public static SleepyNinja AsleepNinja()
        {
            return new SleepyNinja(new TimeSpan(-4, -15, -45));
        }

        public static SleepyNinja WokeUpNinja()
        {
            return new SleepyNinja(default(TimeSpan));
        }

        public readonly TimeSpan awake;

        public SleepyNinja(TimeSpan awake)
        {
            this.awake = awake;
        }
    }
}