using System;
using static ExAs.Utils.Dates;

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
            return new City(new Dojo(new Ninja(), StandardDay()));
        }

        public static City CityWithNullDojoList()
        {
            return new City(dojoList: null);
        }

        public static City ThreeDojoCity()
        {
            return new City(new Dojo(new Ninja(), new DateTime(1515, 11, 15)),
                            new Dojo(new Ninja("Kakashi", 26), new DateTime(1500, 1, 1)),
                            new Dojo(new Ninja("Tsubasa", 14), StandardDay()));
        }
    }
}