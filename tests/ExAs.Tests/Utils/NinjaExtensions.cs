using System;

namespace ExAs.Utils
{
    public static class NinjaExtensions
    {
        public static short ShortAge(this Ninja ninja)
        {
            return (short) ninja.Age;
        }
    }
}