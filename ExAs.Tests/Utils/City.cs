using System.Collections.Generic;
using System.Linq;

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

        public bool HasDojo
        {
            get { return dojos != null && dojos.Any(); }
        }
    }
}