using static ExAs.Utils.Creation.CreateNinjas;
using static ExAs.Utils.Dates;

namespace ExAs.Utils.Creation
{
    public static class CreateDojos
    {
        public static Dojo NarutosStandardDayDojo()
        {
            return new Dojo(Naruto(), StandardDay());
        }
    }
}