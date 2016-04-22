using System.Collections.Generic;
using System.Linq;

namespace ExAs.Utils
{
    public static class NinjaExtensions
    {
        public static short ShortAge(this Ninja ninja)
        {
            return (short) ninja.Age;
        }

        public static IList<string> WeaponList(this WeaponedNinja ninja)
        {
            return ninja.Weapons.ToList();
        }

        public static IList<string> NullWeaponList(this WeaponedNinja ninja)
        {
            return null;
        } 
    }
}