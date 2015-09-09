using System;

namespace ExAs.Utils
{
    public static class TimeSpanFunctions
    {
        public static TimeSpan Seconds(this int amount)
        {
            return new TimeSpan(0, 0, amount);
        }
    }
}