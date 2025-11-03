using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5a
{
    internal class RoomAlreadyBookedException : Exception
    {
        public RoomAlreadyBookedException(string message) : base(message) {}
    }
}
