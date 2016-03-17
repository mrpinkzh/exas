using System;
using static ExAs.Utils.Dates;
using static ExAs.Utils.Creation.CreateNinjas;

namespace ExAs.Utils.Creation
{
    public static class CreateCities
    {
        public static City CityWithoutDojo()
        {
            return new City();
        }

        public static City CityWithDojo()
        {
            return new City(new Dojo(Naruto(), StandardDay()));
        }

        public static City CityWithNullDojoList()
        {
            return new City(dojoList: null);
        }

        public static City ThreeDojoCity()
        {
            return new City(new Dojo(Naruto(), new DateTime(1515, 11, 15)),
                            new Dojo(Kakashi(), new DateTime(1500, 1, 1)),
                            new Dojo(new Ninja("Tsubasa", 14), StandardDay()));
        }
    }
}