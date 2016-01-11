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
    }
}