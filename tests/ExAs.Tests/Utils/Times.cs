using System;
using static ExAs.Utils.Dates;

namespace ExAs.Utils
{
    public static class Times
    {
        public static DateTime LunchTime()
        {
            return StandardDay().At(12.Hours(00));
        }

        public static DateTime DinnerTime()
        {
            return StandardDay().At(18.Hours(00));
        }
    }
}