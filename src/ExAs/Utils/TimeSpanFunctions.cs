using System;

namespace ExAs.Utils
{
    public static class TimeSpanFunctions
    {
        public static TimeSpan Seconds(this int amount)
        {
            return new TimeSpan(0, 0, amount);
        }

        public static TimeSpan Minutes(this int amount)
        {
            return new TimeSpan(0, amount, 0);
        }

        public static TimeSpan Hours(this int amount, int minutes = 0)
        {
            return new TimeSpan(amount, minutes, 0);
        }
    }
}