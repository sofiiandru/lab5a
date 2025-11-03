using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5a
{
    internal class Booking
    {
        public Room Room { get; }
        public DateOnly StartDate { get; }
        public DateOnly EndDate { get; }
        public Booking(Room room, DateOnly startDate, DateOnly endDate)
        {
            Room = room;
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
