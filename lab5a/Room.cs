using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5a
{
    internal abstract class Room
    {
        public int Id {  get; private set; }
        public int Capacity { get; private set; }
        public double PricePerNight { get; private set; }
        public Room(int id, int capacity, double pricePerNight)
        {
            Id = id;
            Capacity = capacity;
            PricePerNight = pricePerNight;
        }
    }
}
