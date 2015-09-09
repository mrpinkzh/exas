using System;

namespace ExAs.Utils
{
    public static class Times
    {
        public static DateTime LunchTime()
        {
            return Dates.StandardDay().AddHours(12);
        }

        public static DateTime DinnerTime()
        {
            return Dates.StandardDay().AddHours(18);
        }
    }
}