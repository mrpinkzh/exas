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
    }
}