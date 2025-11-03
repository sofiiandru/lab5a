using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5a
{
    internal class BookingService
    {
        private readonly List<Booking> _bookings = new List<Booking>();
        private bool DateCheck(DateOnly startA, DateOnly endA, DateOnly startB, DateOnly endB)
        {
            return startA <= endB && startB <= endA;
        }
        public void BookRoom(Room room, DateOnly startDate, DateOnly endDate)
        {
            if (endDate < startDate)
                throw new Exception("Дата завершення не може бути раніше дати початку.");
            foreach (var booking in _bookings.Where(b => b.Room.Id == room.Id))
            {
                if (DateCheck(startDate, endDate, booking.StartDate, booking.EndDate))
                {
                    throw new RoomAlreadyBookedException(
                        $"Обрана кімната вже зайнята на період {booking.StartDate:yyyy-MM-dd} — {booking.EndDate:yyyy-MM-dd}.");

                }

            }
            _bookings.Add(new Booking(room, startDate, endDate));

        }
        public List<Booking> GetAllBookings()
        {
            return new List<Booking>(_bookings); // повертаємо копію списку
        }
    }
}
