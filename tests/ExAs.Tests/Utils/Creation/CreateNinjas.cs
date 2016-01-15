namespace ExAs.Utils.Creation
{
    public static class CreateNinjas
    {
        public static Ninja Naruto()
        {
            return new Ninja();
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
    }
}