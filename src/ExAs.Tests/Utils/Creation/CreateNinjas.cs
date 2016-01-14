namespace ExAs.Utils.Creation
{
    public static class CreateNinjas
    {
        public static Ninja Naruto()
        {
            return new Ninja();
        }

        public static Ninja NullNinja()
        {
            return new Ninja(name:null);
        }
    }
}