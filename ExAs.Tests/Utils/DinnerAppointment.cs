using System;

namespace ExAs.Utils
{
    public class DinnerAppointment
    {
        private readonly DateTime time;

        public DinnerAppointment(DateTime time)
        {
            this.time = time;
        }

        public DateTime Time
        {
            get { return time; }
        }
    }
}