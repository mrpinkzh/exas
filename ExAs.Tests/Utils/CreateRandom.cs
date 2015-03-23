using System;

namespace ExAs.Utils
{
    public static class CreateRandom
    {
        private readonly static Random Random = new Random();

        public static bool Bool()
        {
            return (Int()%2) == 1;
        }

        public static int Int()
        {
            return Random.Next();
        }

        public static string String()
        {
            return Int().ToString();
        }
    }
}