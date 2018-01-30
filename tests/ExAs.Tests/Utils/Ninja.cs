using ExAs.Utils.StringExtensions;
using static System.Environment;

namespace ExAs.Utils
{
    public class Ninja
    {
        private readonly string name;
        private readonly int age;
        private readonly double skillValue;

        public Ninja(string name = "Naruto", int age = 12, double skillValue = 0)
        {
            this.age = age;
            this.name = name;
            this.skillValue = skillValue;
        }

        public string Name
        {
            get { return name; }
        }

        public int Age
        {
            get { return age; }
        }

        public double SkillValue
        {
            get { return skillValue; }
        }

        public override string ToString()
        {
	        return $"Ninja: Name = {Name.ToValueString()}{NewLine}" +
	               $"       Age  = {Age.ToValueString()}";
		}
    }
}