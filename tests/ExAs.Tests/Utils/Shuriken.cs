namespace ExAs.Utils
{
    public struct Shuriken
    {
        private readonly string name;

        public Shuriken(string name = "black shuriken")
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}