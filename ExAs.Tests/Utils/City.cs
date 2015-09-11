using System.Collections.Generic;

namespace ExAs.Utils
{
    public class City
    {
        private readonly List<Dojo> dojos;

        public City(params Dojo[] dojos)
        {
            this.dojos = new List<Dojo>();
            this.dojos.AddRange(dojos);
        }

        public City(List<Dojo> dojoList)
        {
            this.dojos = dojoList;
        }

        public IEnumerable<Dojo> Dojos
        {
            get { return dojos; }
        }
    }
}