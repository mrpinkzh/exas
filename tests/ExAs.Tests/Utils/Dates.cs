using System;

namespace ExAs.Utils
{
    public static class Dates
    {
        public static DateTime StandardDay()
        {
            return 16.November(1984);
        }

        public static DateTime Yesterday()
        {
            return Today().AddDays(-1);
        }

        public static DateTime Today()
        {
            return DateTime.Today;
        }

        public static DateTime Tomorrow()
        {
            return Today().AddDays(1);
        }

        public static DateTime CommonFoundationDay()
        {
            return 15.November(1515).At(2.Hours(15));
        }
    }
}