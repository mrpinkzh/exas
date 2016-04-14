using ExAs.Utils.StringExtensions;

namespace ExAs.Utils.Creation
{
    public static class CreateNinjas
    {
        public static Ninja Naruto()
        {
            return new Ninja();
        }

        public static Ninja Kakashi()
        {
            return new Ninja("Kakashi", 26);
        }

        public static Ninja MultilinedNarutoUzumaki()
        {
            return new Ninja("Naruto".NewLine()
                        .Add("Uzumaki"));
        }

        public static Ninja NamelessNinja()
        {
            return new Ninja(name:"");
        }

        public static Ninja NullNinja()
        {
            return new Ninja(name:null);
        }

        public static Ninja PadavanNaruto()
        {
            return new Ninja(skillValue: 38.4);
        }

        public static WeaponedNinja WeaponlessNinja()
        {
            return new WeaponedNinja();
        }

        public static WeaponedNinja NinjaWithTwoWeapons()
        {
            return new WeaponedNinja("Sword", "Shuriken");
        }
    }
}