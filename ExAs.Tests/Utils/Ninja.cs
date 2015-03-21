using ToText;

namespace ExAs.Utils
{
    public class Ninja
    {
        private readonly string name;
        private readonly int age;

        public Ninja(string name = "Naruto", int age = 12)
        {
            this.age = age;
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public int Age
        {
            get { return age; }
        }

        public override string ToString()
        {
            return this.ToText(x => x.Name, x => x.Age);
        }
    }
}