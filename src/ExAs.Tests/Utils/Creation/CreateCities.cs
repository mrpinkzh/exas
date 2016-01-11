namespace ExAs.Utils.Creation
{
    public static class CreateCities
    {
        public static City CityWithoutDojo()
        {
            return new City();
        }

        public static City CityWithNullDojoList()
        {
            return new City(dojoList: null);
        }
    }
}