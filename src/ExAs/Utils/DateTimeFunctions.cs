using System;

namespace ExAs.Utils
{
    public static class DateTimeFunctions
    {
        public static DateTime January(this int day, int year) { return new DateTime(year, 01, day); }

        public static DateTime February(this int day, int year) { return new DateTime(year, 02, day); }

        public static DateTime March(this int day, int year) { return new DateTime(year, 03, day); }

        public static DateTime April(this int day, int year) { return new DateTime(year, 04, day); }

        public static DateTime May(this int day, int year) { return new DateTime(year, 05, day); }

        public static DateTime June(this int day, int year) { return new DateTime(year, 06, day); }

        public static DateTime July(this int day, int year) { return new DateTime(year, 07, day); }

        public static DateTime August(this int day, int year) { return new DateTime(year, 08, day); }

        public static DateTime September(this int day, int year) { return new DateTime(year, 09, day); }

        public static DateTime October(this int day, int year) { return new DateTime(year, 10, day); }

        public static DateTime November(this int day, int year) { return new DateTime(year, 11, day); }

        public static DateTime December(this int day, int year) { return new DateTime(year, 12, day); }

        public static DateTime At(this DateTime day, TimeSpan time)
        {
            return day.Add(time);
        }
    }
}