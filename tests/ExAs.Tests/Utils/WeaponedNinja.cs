using System.Collections.Generic;

namespace ExAs.Utils
{
    public class WeaponedNinja : Ninja
    {
        private readonly string[] weapons;

        public WeaponedNinja(params string[] weapons)
        {
            this.weapons = weapons;
        }

        public IReadOnlyCollection<string> Weapons
        {
            get { return weapons; }
        }
    }
}