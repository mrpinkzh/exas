using System;

namespace ExAs.Utils
{
    public static class Timespans
    {
        public static TimeSpan WorkDay()
        {
            return new TimeSpan(8, 30, 15);
        }

        public static TimeSpan MonthAndWorkDay()
        {
            return new TimeSpan(30, 8, 30, 15);
        }
    }
}