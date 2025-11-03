//Варіант 2: Система бронювання в готелі 
namespace lab5a
{
    internal class Program
    {
        static void Main()
        {
            var bookingService = new BookingService();
            var room1 = new StandardRoom(1, 2, 500);
            var room2 = new SuiteRoom(2, 4, 1000);
            var rooms = new List<Room> { room1, room2 };
            bool continueBooking = true;
            Console.WriteLine("Вітаємо у системі бронювання готелю!");
            while (continueBooking)
            {
                Console.WriteLine("Доступні кімнати:");
                foreach (var room in rooms)
                {
                    Console.WriteLine($"{room.Id} — {room.GetType().Name} на {room.Capacity} осіб, {room.PricePerNight} грн/ніч");
                }
                Console.Write("Введіть номер кімнати для бронювання: ");
                if (!int.TryParse(Console.ReadLine(), out int roomId))
                {
                    Console.WriteLine("Невірний ввід. Спробуйте ще раз.\n");
                    continue;
                }
                Room selectedRoom = rooms.Find(r => r.Id == roomId);
                if (selectedRoom == null)
                {
                    Console.WriteLine("Такої кімнати немає. Спробуйте ще раз.\n");
                    continue;
                }
                try
                {
                    Console.Write("Введіть дату заселення (рррр-мм-дд): ");
                    DateOnly startDate = DateOnly.Parse(Console.ReadLine()!);

                    Console.Write("Введіть дату кінця (рррр-мм-дд): ");
                    DateOnly endDate = DateOnly.Parse(Console.ReadLine()!);

                    try
                    {
                        bookingService.BookRoom(selectedRoom, startDate, endDate);
                        Console.WriteLine($"Кімнату {selectedRoom.GetType().Name} заброньовано з {startDate} по {endDate}.\n");
                    }
                    catch (RoomAlreadyBookedException ex)
                    {
                        Console.WriteLine($"Помилка бронювання: {ex.Message}\n");
                    }
                }
                catch
                {
                    Console.WriteLine("Невірний формат дати. Використовуйте рррр-мм-дд.\n");
                    continue;
                }
                Console.Write("Бажаєте забронювати ще кімнату? (так/ні): ");
                string answer = Console.ReadLine()!.Trim().ToLower();
                continueBooking = answer == "так";
                Console.WriteLine();
            }
             Console.WriteLine("Список всіх бронювань:");
             foreach (var booking in bookingService.GetAllBookings())
             {
                Console.WriteLine($"{booking.Room.GetType().Name} #{booking.Room.Id}: {booking.StartDate} — {booking.EndDate}");
             }
             Console.WriteLine("\nДякуємо за користування системою. Натисніть будь-яку клавішу для виходу...");
             Console.ReadKey();
            
        }
    }
}